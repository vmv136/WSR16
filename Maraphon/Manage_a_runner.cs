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

namespace Maraphon
{
    public partial class Manage_a_runner : Form
    {
        public Manage_a_runner()
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

        Drawer drw = new Drawer();

        string runEmail;

        public void SetEmail(string email)
        {
            runEmail = email;
        }

        private void Manage_a_runner_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
            string Status= "";
            string query = "SELECT [Рег.статус], Имя, Фамилия, Пол, CONVERT(DATE, [Дата рождения]) AS 'Дата рождения', Страна, Фонд, Пожертвование, [Выбранный пакет], CONCAT(MAX(CAST(SUBSTRING(Дистанция, 1, LEN(Дистанция) - 2) AS INT)), 'km') AS Дистанция " +
                "FROM Бегуны Б, Пользователи П, Результаты " +
                "WHERE Б.Email = П.Email AND Бегун = П.Email AND П.Email = '"+runEmail+"' " +
                "GROUP BY [Рег.статус], Имя, Фамилия, Пол, [Дата рождения], Страна, Фонд, Пожертвование, [Выбранный пакет]";
            int pack=0;
            using (SqlCommand command = new SqlCommand(query, Drawer.connect))
            {
                Drawer.connect.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Email_textBox.Text = runEmail;
                    Name_textBox.Text = reader["Имя"].ToString().Trim();
                    Last_Name_textBox.Text = reader["Фамилия"].ToString().Trim();
                    Gender_textBox.Text = reader["Пол"].ToString().Trim();
                    DateTime dateWithTime = (DateTime)reader["Дата рождения"];
                    DateTime dateOnly = dateWithTime.Date;
                    BirthDay_textBox.Text = dateOnly.ToString("dd-MM-yyyy");
                    Country_textBox.Text = reader["Страна"].ToString().Trim();
                    Fund_textBox.Text = reader["Фонд"].ToString().Trim();
                    Donat_summ_textBox.Text = "$"+reader["Пожертвование"].ToString().Trim();
                    pack = Convert.ToInt32(reader["Выбранный пакет"]);
                    Distance_textBox.Text = "Начальная \n"+ reader["Дистанция"].ToString().Trim();
                    Status = reader["Рег.статус"].ToString().Trim();
                }
                reader.Close();
                Drawer.connect.Close();
            }
            switch (pack)
            {
                case 1:
                    Pack_textBox.Text = "Вариант А";
                    break;
                case 2:
                    Pack_textBox.Text = "Вариант B";
                    break;
                case 3:
                    Pack_textBox.Text = "Вариант С";
                    break;

            }
            switch (Status)
            {
                case "Зарегистрирован":
                    Painting(1, drawer1);
                    Painting(0, drawer2);
                    Painting(0, drawer3);
                    Painting(0, drawer4);
                    break;
                case "Подтверждена оплата":
                    Painting(1, drawer1);
                    Painting(1, drawer2);
                    Painting(0, drawer3);
                    Painting(0, drawer4);
                    break;
                case "Выдан пакет":
                    Painting(1, drawer1);
                    Painting(1, drawer2);
                    Painting(1, drawer3);
                    Painting(0, drawer4);
                    break;
                case "Вышел на старт":
                    Painting(1, drawer1);
                    Painting(1, drawer2);
                    Painting(1, drawer3);
                    Painting(1, drawer4);
                    break;

            }

        }

        private void Painting(int i, Drawer but)
        {
            if (i == 0)
            {
                but.BackgroundColor = Color.Firebrick;
                but.BorderColor = Color.Maroon;
                but.BackColor = Color.Firebrick;
                but.Text = "✗";
            }
            else
            {
                but.BackgroundColor = Color.LimeGreen;
                but.BorderColor = Color.Green;
                but.BackColor = Color.LimeGreen;
                but.Text = "✓";
            }

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Runner_Management form = new Runner_Management();
            drw.FormSwitch(form, this);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }

        private void Edit_but_Click(object sender, EventArgs e)
        {
            Edit_run_prof prof = new Edit_run_prof();
            prof.SetUserEmail(runEmail, true);
            drw.FormSwitch(prof, this);
        }

        private void Sertificate_but_Click(object sender, EventArgs e)
        {
            Certificate_preview preview = new Certificate_preview();
            preview.SetUserEmail(runEmail);
            drw.FormSwitch (preview, this);
        }
    }
}
