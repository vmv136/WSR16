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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Maraphon
{
    public partial class User_Add : Form
    {
        public User_Add()
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
        SqlConnection connect = new SqlConnection(Drawer.connectionString);

        string Email_TextBox_Text = "Email";
        string Pass_textBox_Text = "Пароль";
        string PassReap_TextBox_Text = "Повторите пароль";
        string name_textBox_Text = "Имя";
        string last_name_textBox_Text = "Фамилия";

        private void User_Add_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
            rule_comboBox.Items.Add("Бегун");
            rule_comboBox.Items.Add("Координатор");
            rule_comboBox.Items.Add("Администратор");
            rule_comboBox.SelectedIndex = 0;
            Email_TextBox_Leave(sender, e);
            Pass_textBox_Leave(sender, e);
            PassReap_TextBox_Leave(sender,e);
            name_textBox_Leave(sender, e);
            last_name_textBox_Leave(sender, e);
        }

        private void drawer2_Click(object sender, EventArgs e)
        {
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
            else if (string.IsNullOrEmpty(name_textBox.Text) || name_textBox.Text == name_textBox_Text)
            {
                MessageBox.Show(this, "Введите имя");
            }
            else if (string.IsNullOrEmpty(last_name_textBox.Text) || last_name_textBox.Text == last_name_textBox_Text)
            {
                MessageBox.Show(this, "Введите фамилию");
            }
            else
            {
                string rul;

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
                    if (rule_comboBox.SelectedIndex == 0)
                        rul = "run";
                    else if (rule_comboBox.SelectedIndex == 1)
                        rul = "crd";
                    else
                        rul = "adm";

                    string zapros = "INSERT INTO Пользователи (Email, Имя, Фамилия, Роль, Пароль) VALUES(@Email, @Name, @last_Name, @Rule, @Pass)";
                    using (SqlCommand command = new SqlCommand(zapros, Drawer.connect))
                    {
                        // Установка значений параметров
                        command.Parameters.AddWithValue("@Email", Email_TextBox.Text.Trim());
                        command.Parameters.AddWithValue("@Name", name_textBox.Text.Trim());
                        command.Parameters.AddWithValue("@Last_Name", last_name_textBox.Text.Trim());
                        command.Parameters.AddWithValue("@Rule", rul);
                        command.Parameters.AddWithValue("@Pass", Pass_textBox.Text.Trim());

                        // Выполнение команды
                        int rowsAffected = command.ExecuteNonQuery();
                        int rowsAffected2 = 1;
                        if (rule_comboBox.SelectedIndex == 0)
                        {
                            string id;
                            SqlCommand number = new SqlCommand("SELECT MAX([№Бегуна]) FROM Бегуны", Drawer.connect);
                            try { id = ((int)number.ExecuteScalar() + 1).ToString(); }
                            catch { id = "1"; }
                            SqlCommand upload = new SqlCommand("INSERT INTO Бегуны ([№Бегуна], Email) VALUES(" + id + ", " + Email_TextBox.Text.Trim() + ")", Drawer.connect);
                            rowsAffected2 = upload.ExecuteNonQuery();
                        }

                        // Проверка на успешность выполнения команды
                        if (rowsAffected > 0 && rowsAffected2 > 0)
                        {
                            MessageBox.Show("Пользователь зарегистрирован");
                        }
                        else
                        {
                            MessageBox.Show(this, "Ошибка регистрации пользователя");// Что-то пошло не так
                        }
                    }
                }
                Drawer.connect.Close();
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

        private void Back_Click(object sender, EventArgs e)
        {
            Adm adm = new Adm();
            drw.FormSwitch(adm, this);
        }

        private void drawer1_Click(object sender, EventArgs e)
        {
            Email_TextBox.Text = null;
            Email_TextBox_Leave(sender, e);
            name_textBox.Text = null;
            name_textBox_Leave(sender, e);
            last_name_textBox.Text = null;
            last_name_textBox_Leave(sender, e);
            Pass_textBox.Text = null;
            Pass_textBox_Leave(sender, e);
            PassReap_TextBox.Text = null;
            PassReap_TextBox_Leave(sender, e);
            rule_comboBox.SelectedIndex = 0;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }
    }
}
