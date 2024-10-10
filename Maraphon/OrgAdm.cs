using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Maraphon
{
    public partial class OrgAdm : Form
    {
        public OrgAdm()
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

        string Name = null;

        string name_textBox_Text = "Наименование";
        string info_textBox_Text = "Описание";
        string logo_textBox_Text = "Путь";


        public void SetFund(string Name_Fund)
        {
            Name = Name_Fund;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Drawer.remaining_Time(Date, Timer_label);
        }

        Drawer drw = new Drawer();

        SqlConnection connect = new SqlConnection(Drawer.connectionString);    

        private void OrgAdm_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
            name_textBox_Leave(sender, e);
            info_textBox_Leave(sender, e);
            logo_textBox_Leave(sender, e);
            if (Name != null)
            {
                using (connect)
                {
                    string query = "SELECT Название, Описание, Лого FROM Фонды WHERE название = '" + Name + "'";

                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        
                        connect.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // Загружаем данные в ComboBox
                        while (reader.Read())
                        {
                            name_textBox.Text = reader["Название"].ToString().Trim();
                            info_textBox.Text = reader["Описание"].ToString().Trim();
                            logo_textBox.Text = reader["Лого"].ToString().Trim();
                            pictureBox1.Image = new Bitmap(reader["Лого"].ToString().Trim());
                        }

                        Name = null;

                        reader.Close();
                        connect.Close();
                    }
                }
            }
        }

        private void open_explorer_but_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files (*.jpeg, *.jpg, *.png)|*.jpeg;*.jpg;*.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
               string imagePath = dlg.FileName;


                // Ваш код для соединения с базой данных и выполнения запроса на загрузку изображения

                // Пример кода для подключения к базе данных и выполнения запроса:

                {
                    logo_textBox.Text = imagePath;
                    pictureBox1.Image = new Bitmap(dlg.FileName);
                }

                MessageBox.Show("Изображение загружено");
            }
        }

        private void save_but_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(name_textBox.Text) && !string.IsNullOrEmpty(info_textBox.Text))
            {
                string query1 = "INSERT INTO Фонды (Название, Описание, Лого) VALUES (@Name, @Info, @Logo)";

                using (SqlCommand command = new SqlCommand(query1, Drawer.connect))
                {
                    command.Parameters.AddWithValue("@Name", name_textBox.Text.Trim());
                    command.Parameters.AddWithValue("@Info", info_textBox.Text.Trim());
                    command.Parameters.AddWithValue("@Logo", logo_textBox.Text.Trim());
                    Drawer.connect.Open();
                    command.ExecuteNonQuery();
                    Drawer.connect.Close();
                }
                MessageBox.Show("Данные успешно введены");
            }
            else
            {
                MessageBox.Show("Введите Название и Описание своей организации");
            }
        }

        private void cancel_but_Click(object sender, EventArgs e)
        {
            logo_textBox.Text = null;
            info_textBox.Text = null;
            name_textBox.Text = null;
            name_textBox_Leave(sender, e);
            info_textBox_Leave(sender, e);
            logo_textBox_Leave(sender, e);
            pictureBox1.Image = null;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Manage_charities form = new Manage_charities();
            drw.FormSwitch(form, this);
        }

        private void name_textBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(name_textBox, name_textBox_Text);
        }

        private void name_textBox_Leave(object sender, EventArgs e)
        {
            drw.Show_text(name_textBox, name_textBox_Text);
        }

        private void info_textBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(info_textBox, info_textBox_Text);
        }

        private void info_textBox_Leave(object sender, EventArgs e)
        {
            drw.Show_text(info_textBox, info_textBox_Text);
        }

        private void logo_textBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(logo_textBox, logo_textBox_Text);
        }

        private void logo_textBox_Leave(object sender, EventArgs e)
        {
            drw.Show_text(logo_textBox, logo_textBox_Text);
        }
    }
}

