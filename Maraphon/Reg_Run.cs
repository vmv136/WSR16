using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace Maraphon
{
    public partial class Reg_Run : Form
    {
        Drawer drw = new Drawer();
        public Reg_Run()
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

        string Email_TextBox_Text = "Email";
        string Pass_textBox_Text = "Пароль";
        string PassReap_TextBox_Text = "Повторите пароль";
        string name_textBox_Text = "Имя";
        string last_name_textBox_Text = "Фамилия";



        private void Reg_Load(object sender, EventArgs e)
        {

            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
            Email_TextBox_Leave(sender, e);
            Pass_textBox_Leave(sender,e);
            PassReap_TextBox_Leave(sender, e);
            name_textBox_Leave(sender, e);
            last_name_textBox_Leave(sender, e);
            name_textBox.KeyPress += textBox_KeyPress;
            last_name_textBox.KeyPress += textBox_KeyPress;


            SqlConnection connect = new SqlConnection(Drawer.connectionString);
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
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ буквой, пробелом или клавишей Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                // Если символ не буква, пробел и не клавиша Backspace, то отменяем его ввод
                e.Handled = true;
            }
        }

        private void Email_TextBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(Email_TextBox, Email_TextBox_Text);
        }

        private void Email_TextBox_Leave(object sender, EventArgs e)
        {
            drw.Show_text(Email_TextBox, Email_TextBox_Text);
        }

        private void Pass_textBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(Pass_textBox, Pass_textBox_Text,null,'*');
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            Back_Click(sender, e);
        }

        private void Reg_but_Click(object sender, EventArgs e)
        {
            bool isValid = ContainsUpperLowerNumberAndSymbol(Pass_textBox.Text);

            if (string.IsNullOrEmpty(Email_TextBox.Text) || Email_TextBox.Text == Email_TextBox_Text)
            {
                MessageBox.Show(this, "Введите Email");
            }
            else if (string.IsNullOrEmpty(Pass_textBox.Text) || Pass_textBox.Text == Pass_textBox_Text)
            {
                MessageBox.Show(this, "Введите пароль");
            }
            else if (PassReap_TextBox.Text != Pass_textBox.Text)
            {
                MessageBox.Show(this, "Пароли не совпадают");
            }
            else if (!isValid)
            {
                MessageBox.Show(this, "Пароль не соответствует требованиям безопасности.");
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

                SqlCommand EmailTest = new SqlCommand("SELECT COUNT([Email]) FROM[Пользователи] WHERE[Email] = '" + Email_TextBox.Text + "'", Drawer.connect);
                int EmailTest_value = (int)EmailTest.ExecuteScalar();

                if (EmailTest_value >= 1)
                {
                    MessageBox.Show(this, "Пользователь с таким адресом электронной почты уже зарегистрирован");
                }
                else
                {
                    int a;
                    try
                    {
                        SqlCommand com = new SqlCommand("SELECT MAX([№Бегуна]) FROM Бегуны", Drawer.connect);
                        a = (int)com.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        a = 0;
                    }



                    // SQL-запрос INSERT для добавления данных в таблицу
                    string query = "INSERT INTO [Пользователи] (Email, Имя, Фамилия, Роль, Пароль) VALUES (@Email, @Name, @Last_Name, @Rule, @Pass)";

                    // Создание объекта команды с параметрами
                    using (SqlCommand command = new SqlCommand(query, Drawer.connect))
                    {
                        command.Parameters.AddWithValue("@Email", Email_TextBox.Text);
                        command.Parameters.AddWithValue("@Name", name_textBox.Text);
                        command.Parameters.AddWithValue("@Last_Name", last_name_textBox.Text);
                        command.Parameters.AddWithValue("@Rule", "run");
                        command.Parameters.AddWithValue("@Pass", Pass_textBox.Text);

                        // Выполнение команды
                        int rowsAffected = command.ExecuteNonQuery();

                        // Проверка на успешность выполнения команды
                        if (rowsAffected > 0)
                        {
                            
                            // SQL-запрос INSERT для добавления данных в таблицу
                            string query2 = "INSERT INTO [Бегуны] ([№Бегуна], Страна, [Дата рождения], Пол, Email) VALUES(@ID, @Country, @DateOfBirth, @Gender, @Email)";

                            // Создание объекта команды с параметрами
                            using (SqlCommand command2 = new SqlCommand(query2, Drawer.connect))
                            {
                                // Установка значений параметров
                                command2.Parameters.AddWithValue("@Country", Country_ComboBox.Text);
                                command2.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
                                command2.Parameters.AddWithValue("@ID", a + 1);
                                command2.Parameters.AddWithValue("@Gender", Gender_comboBox.Text);
                                command2.Parameters.AddWithValue("@Email", Email_TextBox.Text);

                                // Выполнение команды
                                int rowsAffected2 = command2.ExecuteNonQuery();

                                // Проверка на успешность выполнения команды
                                if (rowsAffected2 > 0)
                                {
                                    Drawer.connect.Close();
                                    Reg_Marathon reg = new Reg_Marathon();
                                    // Устанавливаем значение переменной intValue на второй форме
                                    Drawer.currentUserEmail = Email_TextBox.Text.Trim();
                                    drw.FormSwitch(reg, this);
                                }
                                else
                                {
                                    MessageBox.Show(this, "Ошибка регистрации пользователя");// Что-то пошло не так
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Ошибка создания профиля бегуна");// Что-то пошло не так
                        }
                    }
                }
                Drawer.connect.Close();

            }
        }

        public static bool ContainsUpperLowerNumberAndSymbol(string input)
        {
            // Проверка на наличие хотя бы одной строчной буквы, одной заглавной буквы, одной цифры и одного специального символа
            return Regex.IsMatch(input, "(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d])");
        }       

        private void Back_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }
    }
}
