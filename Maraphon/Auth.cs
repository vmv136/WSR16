using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Maraphon
{
    public partial class Auth : Form
    {

        public Auth()
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

        string Email_TextBox_Text = "Enter your email address";
        string Pass_TextBox_Text = "Enter your password";
        Font microsoftSansSerifItalic = new Font("Microsoft Sans Serif", 14f, FontStyle.Italic);
        Font microsoftSansSerif = new Font("Microsoft Sans Serif", 14f);
        Drawer drw = new Drawer();

        private void Auth_Load(object sender, EventArgs e)
        {
            Email_TextBox_Leave(sender, e);
            Pass_textBox_Leave(sender, e);
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Text = Text;
            main.Location = Location;
            main.Icon = Icon;
            main.StartPosition = FormStartPosition.Manual;
            main.Show();
            this.Close();
        }

        private void Auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count > 2)
            {
                //// Если есть открытые формы
                //MessageBox.Show("Есть открытые формы.");
                //// Вывести их имена
                //var openFormNames = string.Join(", ", Application.OpenForms.Cast<Form>().Select(f => f.Name));
                //MessageBox.Show($"Имена открытых форм: {openFormNames}");
            }
            else
            {
                //MessageBox.Show("Нет открытых форм.");
                Application.Exit();
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            ////foreach (Control control in this.Controls)
            ////{
            ////    if (control == Headers)
            ////    {
            ////        Headers.Height = 75;
            ////    }
            ////    else if (control == Back)
            ////    {
            ////        Back.Visible = true;
            ////    }
            ////    else
            ////    {
            ////        control.Visible = false;
            ////    }
            ////}
            ////Auth_panel.Visible = false;

            //Main main = new Main();
            //main.Text = Text;
            //main.Location = Location;
            //main.Icon = Icon;
            //main.StartPosition = FormStartPosition.Manual;
            //main.Show();
            //this.Hide();

            ////foreach (Control control in main.Controls)
            ////{
            ////    this.Controls.Add(control);
            ////}
            Back_Click(sender, e);  

        }

        private void Email_TextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Email_TextBox.Text))
            {
                Email_TextBox.Text = Email_TextBox_Text;
                Email_TextBox.ForeColor = SystemColors.GrayText;
                Email_TextBox.Font = microsoftSansSerifItalic;
            }
        }

        private void Email_TextBox_Enter(object sender, EventArgs e)
        {
            if (Email_TextBox.Text == Email_TextBox_Text)
            {
                Email_TextBox.Text = "";
                Email_TextBox.ForeColor = SystemColors.WindowText;
                Email_TextBox.Font = microsoftSansSerif;
            }
        }

        private void Pass_textBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(Pass_TextBox, Pass_TextBox_Text, null, '*');
        }

        private void Pass_textBox_Leave(object sender, EventArgs e)
        {
            drw.Show_text(Pass_TextBox, Pass_TextBox_Text);
        }

        private void Auth_MouseDown(object sender, MouseEventArgs e)
        {
            Headers.Focus();
        }

        private void Headers_MouseDown(object sender, MouseEventArgs e)
        {
            Headers.Focus();
        }

        private void Auth_panel_Click(object sender, EventArgs e)
        {
            Headers.Focus();
        }

        private void Info_Auth_Label_Click(object sender, EventArgs e)
        {
            Headers.Focus();
        }

        private void Auth_Label_Click(object sender, EventArgs e)
        {
            Headers.Focus();
        }

        private void Auth_but_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Email_TextBox.Text) && !string.IsNullOrEmpty(Pass_TextBox.Text))
            {
                Drawer.connect.Open();
                SqlCommand com = new SqlCommand("SELECT COUNT([Email]) FROM [Пользователи] WHERE [Email] = '" + Email_TextBox.Text + "' AND [Пароль] = '" + Pass_TextBox.Text + "'", Drawer.connect);
                int a;
                try
                {
                    a = (int)com.ExecuteScalar();
                }
                catch
                {
                    a = 0;
                }

                if (a == 1)
                {
                    SqlCommand role = new SqlCommand("SELECT Роль FROM [Пользователи] WHERE [Email] ='" + Email_TextBox.Text + "'", Drawer.connect);
                    string role_str = (string)role.ExecuteScalar();
                    if(role_str.Trim() == "adm")
                    {
                        Adm adm = new Adm();
                        drw.FormSwitch(adm, this);

                    }
                    if(role_str.Trim() == "run")
                    {
                        Runner_menu runner_Menu = new Runner_menu();
                        // Устанавливаем значение переменной StringValue на второй форме
                        Drawer.currentUserEmail = Email_TextBox.Text.Trim();
                        drw.FormSwitch(runner_Menu, this);

                    }
                    if (role_str.Trim() == "crd")
                    {
                        coordinator_Menu coord = new coordinator_Menu();
                        drw.FormSwitch(coord, this);
                    }
                    //if (Application.OpenForms.Count > 2)
                    //{
                    //    //MessageBox.Show("CLOSE");
                    //    this.Close();
                    //}
                    //else
                    //{
                    //    //MessageBox.Show("HIDE");
                    //    this.Hide();
                    //}
                }
                else
                {
                    MessageBox.Show("Данные не верны");
                }
                Drawer.connect.Close();
            }
            else
            {
                MessageBox.Show("Данные не введены");
            }
        }
    }
}
