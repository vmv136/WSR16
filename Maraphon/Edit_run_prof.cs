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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Maraphon
{
    public partial class Edit_run_prof : Form
    {
        public Edit_run_prof()
        {
            InitializeComponent();
            this.FormClosing += drw.Reg_FormClosing;
            // Инициализация таймера
            timer = new Timer();
            timer.Interval = 10000; // Интервал в миллисекундах (10 секунд)
            timer.Tick += Timer_Tick;
            timer.Start(); // Запуск таймера
        }

        Drawer drw = new Drawer();

        private Timer timer;
        string Date;

        string Email_TextBox_Text = "Email";
        string Pass_textBox_Text = "Пароль";
        string PassReap_TextBox_Text = "Повторите пароль";
        string name_textBox_Text = "Имя";
        string last_name_textBox_Text = "Фамилия";
        string userName;
        string last_userName;
        string gender;
        string BirthDay;
        string userCountry;
        string payStatus;


        SqlConnection connect = new SqlConnection(Drawer.connectionString);

        private void Timer_Tick(object sender, EventArgs e)
        {
            Drawer.remaining_Time(Date, Timer_label);
        }
        string runEmail;
        bool visiblePayStatus = false;
        public void SetUserEmail(string email,bool root)
        {
            runEmail = email;
            visiblePayStatus = root;
        }

        private void Edit_run_prof_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
            email_value_label.Text = runEmail;

            label4.Visible = visiblePayStatus;
            pay_combox.Visible = visiblePayStatus;

            pay_combox.Items.Add("Зарегистрирован");
            pay_combox.Items.Add("Подтверждена оплата");
            pay_combox.Items.Add("Выдан пакет");
            pay_combox.Items.Add("Вышел на старт");

            using (connect)
            {
                connect.Open();
                string srch = "Select distinct [Страна] From [Страны]";//выбираем нужный столбец в нужной таблице
                DataTable sch = new DataTable();
                SqlDataAdapter sr = new SqlDataAdapter(srch, connect);
                sr.Fill(sch);
                connect.Close();
                foreach (DataRow row in sch.Rows)//заполняем массив значениями из столбца
                {
                    Country_ComboBox.Items.Add(row[0].ToString());
                }

                string query = "SELECT Имя, Фамилия, Бегуны.[№Бегуна], Страна, Пол, [Дата рождения], Пароль, [Рег.Статус] " +
                    "FROM Пользователи, Бегуны " +
                    "WHERE Бегуны.Email = Пользователи.Email AND Пользователи.Email='" + runEmail + "'";

                using (SqlCommand command = new SqlCommand(query, connect))
                {

                    connect.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    // Загружаем данные в ComboBox
                    while (reader.Read())
                    {
                        userCountry = reader["Страна"].ToString();
                        Country_ComboBox.Text = userCountry;
                        userName = reader["Имя"].ToString().Trim();
                        name_textBox.Text = userName;
                        last_userName = reader["Фамилия"].ToString().Trim();
                        last_name_textBox.Text = last_userName;
                        gender = reader["Пол"].ToString().Trim();
                        Gender_comboBox.SelectedIndex = Gender_comboBox.FindStringExact(gender);
                        BirthDay = reader["Дата рождения"].ToString().Trim();
                        dateTimePicker1.Text = BirthDay;
                        payStatus = reader["Рег.Статус"].ToString().Trim();
                        pay_combox.SelectedIndex = pay_combox.FindStringExact(payStatus);
                    }
                    reader.Close();
                    connect.Close();
                }
            }
            Pass_textBox_Leave(sender, e);
            PassReap_TextBox_Leave(sender, e);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (visiblePayStatus)
            {
                Manage_a_runner menu = new Manage_a_runner();
                menu.SetEmail(runEmail);
                drw.FormSwitch(menu, this);
            }
            else
            {
                Runner_menu menu = new Runner_menu();
                drw.FormSwitch(menu, this);
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {           
            name_textBox_Enter(sender, e);
            name_textBox.Text = userName;
            last_name_textBox_Enter(sender, e);
            last_name_textBox.Text = last_userName;
            Pass_textBox.Text = null;
            Pass_textBox_Leave(sender, e);
            PassReap_TextBox.Text = null;
            PassReap_TextBox_Leave(sender, e);
            Gender_comboBox.SelectedIndex = Gender_comboBox.FindStringExact(gender);
            dateTimePicker1.Text = BirthDay;
            Country_ComboBox.Text = userCountry;
            pay_combox.Text = payStatus;
        }

        private void Red_but_Click(object sender, EventArgs e)
        {
            if (PassReap_TextBox.Text != Pass_textBox.Text && Pass_textBox.Text != Pass_textBox_Text)
            {
                MessageBox.Show(this, "Пароли не совпадают");
            }
            else if (string.IsNullOrEmpty(name_textBox.Text) || name_textBox.Text == name_textBox_Text)
            {
                MessageBox.Show(this, "Введите имя");
            }
            else if (string.IsNullOrEmpty(last_name_textBox.Text) || last_name_textBox.Text == last_name_textBox_Text)
            {
                MessageBox.Show(this, "Введите фамилию");
            }
            else if (string.IsNullOrEmpty(Gender_comboBox.Text))
            {
                MessageBox.Show(this, "Выберите пол");
            }
            else if (dateTimePicker1.Value > DateTime.Now.AddYears(-10))
            {
                MessageBox.Show(this, "Вы слишком молоды");
            }
            else if (string.IsNullOrEmpty(Country_ComboBox.Text))
            {
                MessageBox.Show(this, "Выберите страну");
            }
            else
            {
                // Открыть соединение
                Drawer.connect.Open();

                // SQL-запрос UPDATE для добавления данных в таблицу
                string query1 = "UPDATE Пользователи SET Имя = @Name, Фамилия = @lastName, Пароль = @pass WHERE Email = @email";

                // Создание объекта команды с параметрами
                using (SqlCommand command = new SqlCommand(query1, Drawer.connect))
                {
                    // Установка значений параметров
                    command.Parameters.AddWithValue("@Name", name_textBox.Text.Trim());
                    command.Parameters.AddWithValue("@lastName", last_name_textBox.Text.Trim());
                    command.Parameters.AddWithValue("@pass", Pass_textBox.Text.Trim());
                    command.Parameters.AddWithValue("@email", runEmail);

                    // Выполнение команды
                    command.ExecuteNonQuery();
                }

                // SQL-запрос UPDATE для добавления данных в таблицу
                string query2 = "UPDATE Бегуны SET Пол = @gender, Страна = @country, [Дата рождения] = @birthDay, [Рег.Статус] = @status " +
                    "FROM Бегуны, Пользователи WHERE Пользователи.Email = @email AND Бегуны.Email = Пользователи.Email";

                // Создание объекта команды с параметрами
                using (SqlCommand command = new SqlCommand(query2, Drawer.connect))
                {
                    // Установка значений параметров
                    command.Parameters.AddWithValue("@gender", Gender_comboBox.Text.Trim());
                    command.Parameters.AddWithValue("@country", Country_ComboBox.Text.Trim());
                    command.Parameters.AddWithValue("@birthDay", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@email", runEmail);
                    command.Parameters.AddWithValue("@status", pay_combox.Text);

                    // Выполнение команды
                    command.ExecuteNonQuery();
                }

                Drawer.connect.Close();
                MessageBox.Show("Сохранение выполнено!");

            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main,this);
        }

        private void Pass_textBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(Pass_textBox, Pass_textBox_Text, null, '*');
        }

        private void Pass_textBox_Leave(object sender, EventArgs e)
        {
            drw.Show_text(Pass_textBox, Pass_textBox_Text);
        }

        private void PassReap_TextBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(PassReap_TextBox, PassReap_TextBox_Text, null, '*');
        }

        private void PassReap_TextBox_Leave(object sender, EventArgs e)
        {
            drw.Show_text(PassReap_TextBox, PassReap_TextBox_Text);
        }

        private void name_textBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(name_textBox, name_textBox_Text);
        }

        private void name_textBox_Leave(object sender, EventArgs e)
        {
            drw.Show_text(name_textBox, name_textBox_Text);
        }

        private void last_name_textBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(last_name_textBox, last_name_textBox_Text);
        }

        private void last_name_textBox_Leave(object sender, EventArgs e)
        {
            drw.Show_text(last_name_textBox, last_name_textBox_Text);
        }
    }
}
