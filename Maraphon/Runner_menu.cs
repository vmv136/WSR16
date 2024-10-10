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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Maraphon
{
    public partial class Runner_menu : Form
    {
        public Runner_menu()
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

        private void Runner_menu_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
        }

        Drawer drw = new Drawer();

        private void Runner_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count <= 2)
            {
                Application.Exit();
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Logout_Click(sender, e);
        }

        private void Edit_Profile_but_Click(object sender, EventArgs e)
        {
            Edit_run_prof edit = new Edit_run_prof();
            edit.SetUserEmail(Drawer.currentUserEmail,false);
            drw.FormSwitch(edit, this);

        }

        private void myResults_but_Click(object sender, EventArgs e)
        {
            My_results res = new My_results();
            drw.FormSwitch(res, this);
        }

        private void mySponsors_but_Click(object sender, EventArgs e)
        {
            my_sponsor spons = new my_sponsor();
            drw.FormSwitch(spons, this);
        }

        private void Reg_Marathon_But_Click(object sender, EventArgs e)
        {
            Drawer.connect.Open();
            SqlCommand com = new SqlCommand("SELECT [Рег.статус] FROM [Бегуны], Пользователи WHERE Пользователи.[Email] = '" + Drawer.currentUserEmail+ "' AND Бегуны.Email = Пользователи.Email", Drawer.connect);
            string status;

            if (com.ExecuteScalar() == null)
            {
                int a;
                try
                {
                    SqlCommand com1 = new SqlCommand("SELECT MAX([№Бегуна]) FROM Бегуны", Drawer.connect);
                    a = (int)com1.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    a = 0;
                }
                string query2 = "INSERT INTO [Бегуны] ([№Бегуна], Email) VALUES(@ID, @Email)";

                // Создание объекта команды с параметрами
                using (SqlCommand command2 = new SqlCommand(query2, Drawer.connect))
                {
                    // Установка значений параметров
                    command2.Parameters.AddWithValue("@ID", a + 1);
                    command2.Parameters.AddWithValue("@Email", Drawer.currentUserEmail);
                    command2.ExecuteNonQuery();
                }
                status = com.ExecuteScalar().ToString();
            }
            else
            {
                try
                {
                    status = (string)com.ExecuteScalar();
                }
                catch 
                { 
                    status = ""; 
                }

            }

            status = status.Trim();

            if (status == null || status == "")
            {
                Reg_Marathon form = new Reg_Marathon();
                drw.FormSwitch(form, this);
                Drawer.connect.Close();
            }
            if (status == "Зарегистрирован")
            {
                MessageBox.Show("Вы уже зарегистрированы, но оплата еще не подтверждена");
            }
            else if (status == "Подтверждена оплата")
            {
                MessageBox.Show("Вы уже зарегистрированы, ожидайте получения своего пакета");
            }
            else if (status == "Выдан пакет")
            {
                MessageBox.Show("Вы уже зарегистрированы, готовтесь к старту марафона!");
            }
            Drawer.connect.Close();
            
        }

        private void Contacts_but_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для получения дополнительной информации пожалуйста свяжитесь с координаторами\r\n\r\nТелефон: +55 11 9988 7766\r\n\r\nEmail:  coordinators@marathonskills.org\r\n", "Контакты");
        }
    }
}
