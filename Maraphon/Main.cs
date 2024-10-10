using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maraphon
{
    public partial class Main : Form
    {
        

        public Main()
        {
            InitializeComponent();

            // Инициализация таймера
            timer = new Timer();
            timer.Interval = 10000; // Интервал в миллисекундах (10 секунд)
            timer.Tick += Timer_Tick;
            timer.Start(); // Запуск таймера
        }

        private Timer timer;
        string Date;

        private void Timer_Tick(object sender, EventArgs e)
        {
            Drawer.remaining_Time(Date, Timer_label);
        }
 
        SqlConnection connect = new SqlConnection(Drawer.connectionString);

        private void Main_Load(object sender, EventArgs e)
        {
            Headers.Height = 140;
            using (connect)
            {
                string query = "SELECT MAX(Convert(date,Год)) AS 'Пройдет', YEAR(Год) AS Год, Страна " +
                    "FROM [История марафона] " +
                    "GROUP BY Страна, Год " +
                    "ORDER BY 'Пройдет' DESC;";

                using (SqlCommand command = new SqlCommand(query, connect))
                {

                    connect.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Загружаем данные в ComboBox
                    while (reader.Read())
                    {
                        Info_But.Text = "Marathon Skills " + reader["Год"].ToString().Trim();
                        maraphone_name_label.Text = "MARATHON SKILLS " + reader["Год"].ToString().Trim();
                        DateTime date = Convert.ToDateTime(reader["Пройдет"].ToString().Trim());
                        maraphone_date_label.Text = "" + reader["Страна"].ToString().Trim() + "\n" + date.ToString("dddd") + " " + date.Day + "." + date.Month + "." + date.Year;
                    }
                    reader.Close();
                    connect.Close();
                }
            }

            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Headers.Height = 140;
            tableLayoutPanel1.Visible = true;
            Main_panel.Visible = true;
            Runner_panel.Visible = false;
            Back.Visible = false;
            FAQ_Panel.Visible = false;
            Login.Visible = true;
        }

        private void Runner_reg_Click(object sender, EventArgs e)
        {
            Headers.Height = 62;
            tableLayoutPanel1.Visible = false;
            Main_panel.Visible = false;
            Runner_panel.Visible = true;
            Back.Visible = true;
        }

        private void FAQ_Click(object sender, EventArgs e)
        {
            Headers.Height = 62;
            tableLayoutPanel1.Visible = false;
            Main_panel.Visible = false;
            FAQ_Panel.Visible = true;
            Back.Visible = true;
            Login.Visible = false;
        }

        private void Form_Switch(Form form)
        {
            form.Text = Text;
            form.Location = Location;
            form.Icon = Icon;
            form.StartPosition = FormStartPosition.Manual;
            form.Size = Size;
            form.Show();
            if (Application.OpenForms.Count > 2)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            //foreach (Control control in this.Controls)
            //{
            //    if (control == Headers)
            //    {
            //        Headers.Height = 75;
            //    }
            //    else if(control == Back)
            //    {
            //        Back.Visible = true;
            //    }
            //    else
            //    {
            //        control.Visible = false;
            //    }
            //}
            Auth auth = new Auth();
            Form_Switch(auth);

            //foreach (Control control in auth.Controls)
            //{
            //    this.Controls.Add(control);
            //}


        }

        private void Old_runner_Click(object sender, EventArgs e)
        {
            Login_Click(sender, e);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                Application.Exit();
            }
        }

        private void Sponsor_reg_Click(object sender, EventArgs e)
        {
            Spons spons = new Spons();
            Form_Switch(spons);
        }

        private void New_runner_Click(object sender, EventArgs e)
        {
            Reg_Run reg = new Reg_Run();
            Form_Switch(reg);
        }

        private void Info_But_Click(object sender, EventArgs e)
        {
            Map_marathon map_Marathon = new Map_marathon();
            Form_Switch(map_Marathon);
        }

        private void Organiz_but_Click(object sender, EventArgs e)
        {
            Fund_list fund = new Fund_list();
            Form_Switch(fund);
        }

        private void Old_results_Click(object sender, EventArgs e)
        {
            Results results = new Results();
            Form_Switch(results);
        }

        private void Duration_but_Click(object sender, EventArgs e)
        {
            Naskokdolg howLong = new Naskokdolg();
            Form_Switch(howLong);
        }

        private void drawer1_Click(object sender, EventArgs e)
        {
            coordinator_Menu coordinator = new coordinator_Menu();
            Form_Switch(coordinator);
        }

        private void drawer2_Click(object sender, EventArgs e)
        {
            Adm adm = new Adm();
            Form_Switch(adm);
        }
    }
}
