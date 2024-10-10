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
using System.Xml.Linq;

namespace Maraphon
{
    public partial class my_sponsor : Form
    {
        SqlConnection connect = new SqlConnection(Drawer.connectionString);
        int userId;
        string Fond;
        int summirov;

        public my_sponsor()
        {
            InitializeComponent();
            this.FormClosing += drw.Reg_FormClosing;

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

        private void my_sponsor_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);

            using (connect)
            {
                connect.Open();
                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "Спонсор";
                dataGridView1.Columns[1].Name = "Взнос";

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.ScrollBars = ScrollBars.Vertical;

                //Ниже получаем тому кому будут отображаться отправления пожертвований
                string query = "SELECT [№Бегуна] FROM бегуны, Пользователи WHERE Бегуны.Email = Пользователи.Email AND Пользователи.Email = @Email";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@Email", Drawer.currentUserEmail);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    userId = Convert.ToInt32(reader["№Бегуна"]);
                }
                else
                {
                }

                reader.Close();

                try
                {
                    query = "SELECT Отправитель, Сумма FROM Пожертвования WHERE Получатель = @Poluchatel";
                    using (SqlCommand command1 = new SqlCommand(query, connect))
                    {
                        command1.Parameters.AddWithValue("@Poluchatel", userId);
                        SqlDataReader reader1 = command1.ExecuteReader();
                        while (reader1.Read())
                        {
                            string Sender = reader1["Отправитель"].ToString();
                            string Summ = reader1["Сумма"].ToString().Trim();
                            summirov += Convert.ToInt32(Summ);

                            dataGridView1.Rows.Add(Sender.Trim(), Summ.Trim());
                        }
                        reader1.Close();
                        label6.Text = "Всего: "+summirov.ToString();
                    }
                }
                catch { }
                query = "SELECT Фонд FROM Бегуны WHERE [№Бегуна] = @Begun";
                SqlCommand command3 = new SqlCommand(query, connect);
                command3.Parameters.AddWithValue("@Begun", userId);
                SqlDataReader reader2 = command3.ExecuteReader();

                if (reader2.Read())
                {
                    Fond = Convert.ToString(reader2["Фонд"]);
                }
                else
                {

                }
                reader2.Close();
                try
                {
                    query = "SELECT Название, Описание, Лого FROM Фонды WHERE Название = @Fond";
                    SqlCommand command4 = new SqlCommand(query, connect);
                    command4.Parameters.AddWithValue("@Fond", Fond);
                    SqlDataReader reader3 = command4.ExecuteReader();

                    if (reader3.Read())
                    {
                        label2.Text = Convert.ToString(reader3["Название"]).Trim();
                        Image image = LoadImageFromFile(Convert.ToString(reader3["Лого"]));
                        pictureBox1.Image = image;
                        label5.Text = Convert.ToString(reader3["Описание"]).Trim();
                    }
                    else
                    {
                    }
                    reader3.Close();
                }
                catch { }
                dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            }
            connect.Close();
            dataGridView1.CurrentCell = null;
        }
        private Image LoadImageFromFile(string imagePath)
        {
            try
            {
                // Загружаем изображение из локального файла
                return Image.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
                return null;
            }
        }

        Drawer drw = new Drawer();
        private void Back_Click(object sender, EventArgs e)
        {
            Runner_menu run = new Runner_menu();
            drw.FormSwitch(run, this);

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }
    }
}
