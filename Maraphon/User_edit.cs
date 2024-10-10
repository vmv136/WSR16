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
    public partial class User_edit : Form
    {
        public User_edit()
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

        string Email;

        public void SetEmail(string email)
        {
            Email=email;
        }

        string Email_TextBox_Text = "Email";
        string Pass_textBox_Text = "Пароль";
        string PassReap_TextBox_Text = "Повторите пароль";
        string name_textBox_Text = "Имя";
        string last_name_textBox_Text = "Фамилия";

        string userName;
        string last_userName;
        string rule;

        private void User_edit_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
            Email_TextBox.Text = Email.Trim();

            rule_comboBox.Items.Add("Бегун");
            rule_comboBox.Items.Add("Администратор");
            rule_comboBox.Items.Add("Координатор");

            Pass_textBox_Leave(sender, e);
            PassReap_TextBox_Leave(sender, e);

            using (connect)
            {
                string query = "SELECT Имя, Фамилия, Роль FROM Пользователи WHERE Email = '" + Email + "'";

                using (SqlCommand command = new SqlCommand(query, connect))
                {

                    connect.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        userName = reader["Имя"].ToString().Trim();
                        last_userName = reader["Фамилия"].ToString().Trim();
                        rule = reader["Роль"].ToString().Trim();

                    }
                    reader.Close();
                    connect.Close();
                }
            }
            name_textBox.Text = userName;
            last_name_textBox.Text = last_userName;
            comboRule(rule);
        }

        private void comboRule(string usserRule)
        {
            if (usserRule == "run")
            {
                rule_comboBox.SelectedIndex = 0;
            }
            else if (usserRule == "adm")
            {
                rule_comboBox.SelectedIndex = 1;
            }
            else if (usserRule == "crd")
            {
                rule_comboBox.SelectedIndex = 2;
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            drw.FormSwitch(users, this);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }

        private void Save_but_Click(object sender, EventArgs e)
        {
            string password = "";
            string rule = "";

            Drawer.connect.Open();

            if(rule_comboBox.SelectedIndex == 0)
            {
                rule = "run";
            }
            else if (rule_comboBox.SelectedIndex == 1)
            {
                rule = "adm";
            }
            else if (rule_comboBox.SelectedIndex == 2)
            {
                rule = "crd";
            }

            if (!string.IsNullOrEmpty(Pass_textBox.Text) && Pass_textBox.Text == PassReap_TextBox.Text) 
            {
                password = ",[Пароль] = '"+Pass_textBox.Text.Trim()+"' ";
                MessageBox.Show("Обновил");
            }

            if (Pass_textBox.Text != PassReap_TextBox.Text && Pass_textBox.Text != Pass_textBox_Text)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else if (string.IsNullOrEmpty(name_textBox.Text) || name_textBox.Text == name_textBox_Text)
            {
                MessageBox.Show("Введите имя");
            }
            else if (string.IsNullOrEmpty(last_name_textBox.Text) || last_name_textBox.Text == last_name_textBox_Text)
            {
                MessageBox.Show("Введите фамилию");
            }
            else
            {
                string zapros = "UPDATE [Пользователи] SET [Имя] = @Name, [Фамилия] = @Last_Name, [Роль] = @Rule " + password + " WHERE [Email] = @Email";

                using (SqlCommand command = new SqlCommand(zapros, Drawer.connect))
                {
                    // Установка значений параметров
                    command.Parameters.AddWithValue("@Email", Email.Trim());
                    command.Parameters.AddWithValue("@Name", name_textBox.Text.Trim());
                    command.Parameters.AddWithValue("@Last_Name", last_name_textBox.Text.Trim());
                    command.Parameters.AddWithValue("@Rule", rule.Trim());

                    // Выполнение команды
                    int rowsAffected = command.ExecuteNonQuery();

                    // Проверка на успешность выполнения команды
                    if (rowsAffected > 0)
                    {
                        if (rule_comboBox.SelectedIndex == 0)
                        {
                            SqlCommand com = new SqlCommand("SELECT COUNT([№Бегуна]) FROM Бегуны WHERE [Email] = '" + Email + "'", Drawer.connect);
                            int a = (int)com.ExecuteScalar();
                            int rowsAffected2 = 0;
                            if (a == 0)
                            {
                                string id;
                                SqlCommand number = new SqlCommand("SELECT MAX([№Бегуна]) FROM Бегуны", Drawer.connect);
                                try { id = ((int)number.ExecuteScalar() + 1).ToString(); }
                                catch { id = "1"; }
                                SqlCommand upload = new SqlCommand("INSERT INTO Бегуны ([№Бегуна], Email) VALUES(" + id + ", '" + Email + "')", Drawer.connect);
                                rowsAffected2 = upload.ExecuteNonQuery();
                            }
                            else
                                rowsAffected2 = 1;
                            if (rowsAffected2>0)
                                MessageBox.Show("Данные изменены");
                            else          
                                MessageBox.Show(this, "Ошибка регистрации пользователя");
                        }
                        else
                            MessageBox.Show("Данные изменены");
                    }
                    else
                    {
                        MessageBox.Show(this, "Ошибка регистрации пользователя");
                    }
                }
            }
            Drawer.connect.Close();
        }

        bool passEdit;

        private void Pass_textBox_Enter(object sender, EventArgs e)
        {            
            passEdit = true;
            drw.Hide_text(Pass_textBox, Pass_textBox_Text, null, '*');

        }

        private void Pass_textBox_Leave(object sender, EventArgs e)
        {
            passEdit = false;
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

        private void cancel_but_Click(object sender, EventArgs e)
        {
            name_textBox.Text = userName;
            name_textBox_Enter(sender, e);
            last_name_textBox.Text = last_userName;
            last_name_textBox_Enter(sender, e);
            Pass_textBox.Text = null;
            Pass_textBox_Leave(sender, e);
            PassReap_TextBox.Text = null;
            PassReap_TextBox_Leave(sender, e);
            comboRule(rule);
        }
    }
}
