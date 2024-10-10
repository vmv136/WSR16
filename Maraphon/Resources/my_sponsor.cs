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
        string Date;
        int userId;
        string Fond;
        int summirov;
        public my_sponsor()
        {
            InitializeComponent();
        }

        string userEmail;
        public void SetStringValue(string value)
        {
            userEmail = value;
        }
        private void my_sponsor_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);

            using (connect)
            {
                connect.Open();
                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "спонсор";
                dataGridView1.Columns[1].Name = "Взнос";

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.ScrollBars = ScrollBars.Vertical;

                //Ниже получаем тому кому будут отображаться отправления пожертвований
                string query = "SELECT [№Бегуна] FROM Пользователи WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@Email", userEmail);

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
                        label6.Text = summirov.ToString();
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
                        label2.Text = Convert.ToString(reader3["Название"]);
                        Image image = LoadImageFromFile(Convert.ToString(reader3["Лого"]));
                        pictureBox1.Image = image;
                        label5.Text = Convert.ToString(reader3["Описание"]);
                    }
                    else
                    {
                    }
                    reader3.Close();
                }
                catch { }
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Drawer drw = new Drawer();
        private void Back_Click(object sender, EventArgs e)
        {
            Runner_menu run= new Runner_menu();
            run.SetStringValue(userEmail);
            drw.FormSwitch(run, this);

        }
    }
}
