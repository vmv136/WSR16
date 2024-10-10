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
    public partial class Spons : Form
    {
        public Spons()
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

        string Сardowner_TextBox_Text = "Владелец карты";
        string Name_TextBox_Text = "Ваше имя";
        string Number_card_Text = "1234123412341234";
        string CardNumber_maskedTextBox1_text = "1234 1234 1234 1234";


        Drawer drw = new Drawer();
        SqlConnection connect = new SqlConnection(Drawer.connectionString);

        private void Spons_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);

            Name_TextBox_Leave(sender, e);
            Сardowner_TextBox_Leave(sender, e);
            CardNumber_maskedTextBox1_Leave(sender, e);
            Mount_Leave(sender, e);
            year_Leave(sender, e);
            CVC_Leave(sender, e);
            Сardowner_TextBox.KeyPress += textBox_KeyPress;
            Name_TextBox.KeyPress += textBox_KeyPress;
            Fund_label.Text = "";
            Info_but.Visible = false;

            using (connect)
            {
                string query = "SELECT Имя, Фамилия, Бегуны.[№Бегуна], Страна FROM Пользователи, Бегуны WHERE Бегуны.Email = Пользователи.Email ORDER BY [№Бегуна]";

                using (SqlCommand command = new SqlCommand(query, connect))
                {

                    connect.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Очищаем ComboBox перед загрузкой данных
                    Runner_comboBox.Items.Clear();

                    // Загружаем данные в ComboBox
                    while (reader.Read())
                    {
                        string country = reader["Страна"].ToString().Trim();
                        string fullName = reader["Имя"].ToString().Trim();
                        string lastName = reader["Фамилия"].ToString().Trim();
                        string runnerNumber = reader["№Бегуна"].ToString().Trim();
                        Runner_comboBox.Items.Add(fullName + ' ' + lastName +" - " + runnerNumber + " ("+country+")");
                    }
                    reader.Close();
                    connect.Close();
                }
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

        private void Back_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Back_Click(sender, e);
        }

        private void Plus_Price_but_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Price_textBox.Text) < 9999999 && !string.IsNullOrEmpty(Price_textBox.Text))
                Price_textBox.Text = (Convert.ToInt32(Price_textBox.Text)+10).ToString();
        }

        private void Min_Price_but_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(Price_textBox.Text)>0 && !string.IsNullOrEmpty(Price_textBox.Text))
                Price_textBox.Text = (Convert.ToInt32(Price_textBox.Text) - 10).ToString();
        }

        private void Name_TextBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(Name_TextBox, Name_TextBox_Text);
        }

        private void Name_TextBox_Leave(object sender, EventArgs e)
        {
            drw.Show_text(Name_TextBox, Name_TextBox_Text);
        }
        private void Сardowner_TextBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(Сardowner_TextBox, Сardowner_TextBox_Text);
        }

        private void Сardowner_TextBox_Leave(object sender, EventArgs e)
        {
            drw.Show_text(Сardowner_TextBox, Сardowner_TextBox_Text);
        }

        private void CardNumber_maskedTextBox1_Enter(object sender, EventArgs e)
        {
            Font defaultFont = new Font("Microsoft Sans Serif", 14f);

            if (CardNumber_maskedTextBox1.Text == CardNumber_maskedTextBox1_text)
            {
                CardNumber_maskedTextBox1.Text = "";
                CardNumber_maskedTextBox1.ForeColor = SystemColors.WindowText;
                CardNumber_maskedTextBox1.Font = defaultFont;
            }
        }

        private void CardNumber_maskedTextBox1_Leave(object sender, EventArgs e)
        {
            Font defaultFont = new Font("Microsoft Sans Serif", 14f, FontStyle.Italic);

            if (CardNumber_maskedTextBox1.Text == "               ")
            {
                CardNumber_maskedTextBox1.Text = Number_card_Text;
                CardNumber_maskedTextBox1.ForeColor = SystemColors.GrayText;
                CardNumber_maskedTextBox1.Font = defaultFont;
            }
        }

        private void CardNumber_maskedTextBox1_Click(object sender, EventArgs e)
        {
            if (CardNumber_maskedTextBox1.Text == "               ")
            {
                CardNumber_maskedTextBox1.Select(0, 0);
            }
        }

        private void Mount_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(month_textBox, "01");
        }

        private void Mount_Leave(object sender, EventArgs e)
        {
            drw.Show_text(month_textBox, "01");
        }

        private void year_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(year_textBox, "2020");
        }

        private void year_Leave(object sender, EventArgs e)
        {
            drw.Show_text(year_textBox, "2020");
        }

        private void CVC_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(CVC, "123");
        }

        private void CVC_Leave(object sender, EventArgs e)
        {
            drw.Show_text(CVC, "123");
        }

        private void CVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отмена обработки неподходящего символа
            }
        }

        private void Mount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отмена обработки неподходящего символа
            }
        }

        private void year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отмена обработки неподходящего символа
            }
        }

        private void CardNumber_maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отмена обработки неподходящего символа
            }
        }

        private void Mount_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Пытаемся преобразовать текст введенный в TextBox в число
            if (int.TryParse(textBox.Text, out int month))
            {
                // Если значение меньше 1, устанавливаем его в 1
                if (month < 1)
                {
                    textBox.Text = "1";
                }
                // Если значение больше 12, устанавливаем его в 12
                else if (month > 12)
                {
                    textBox.Text = "12";
                }
            }
            else
            {
                // Если введенный текст не является числом, устанавливаем его в пустую строку
                textBox.Text = "";
            }
            // Устанавливаем курсор в конец текста
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void Price_textBox_TextChanged(object sender, EventArgs e)
        {
            Donat_Sum_label.Text = "$" + Price_textBox.Text;
        }

        private void Price_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отмена обработки неподходящего символа
            }
        }

        string runnerID;

        private void Runner_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Runner_comboBox.SelectedIndex >= 0)
            {

                int startIndex = Runner_comboBox.Text.IndexOf("-"); // Находим индекс символа "-"
                int endIndex = Runner_comboBox.Text.IndexOf("(", startIndex); // Находим индекс символа "(", начиная с позиции startIndex

                if (startIndex != -1 && endIndex != -1) // Если оба символа найдены
                {
                    SqlConnection connect = new SqlConnection(Drawer.connectionString);
                    connect.Open();
                    // Извлекаем подстроку между символами "-" и "("
                    runnerID = Runner_comboBox.Text.Substring(startIndex + 2, endIndex - startIndex - 2);
                    SqlCommand com = new SqlCommand("SELECT [Фонд] FROM [Бегуны] WHERE [№Бегуна] = '" + runnerID.Trim() + "'", connect);
                    string a = com.ExecuteScalar().ToString();
                    Fund_label.Text = a.Trim();
                    Gratitude_Fund_label.Text = a.Trim();
                    if (!string.IsNullOrEmpty(Fund_label.Text))
                        Info_but.Visible = true;
                    else
                    {
                        Info_but.Visible = false;
                        MessageBox.Show("Бегун не выбрал благотворительную организацию");
                        Runner_comboBox.SelectedIndex = -1;
                    }

                    connect.Close();
                }
                Gratitude_Runner_label.Text = Runner_comboBox.Text;
            }
        }

        private void Auth_but_Click(object sender, EventArgs e)
        {
            DateTime cardDateTime = new DateTime(Convert.ToInt32(year_textBox.Text), Convert.ToInt32(month_textBox.Text), 1).AddMonths(1).AddDays(-1);

            if (string.IsNullOrEmpty(Name_TextBox.Text)|| Name_TextBox.Text == Name_TextBox_Text)
            {
                MessageBox.Show("Введите имя");
            }
            else if (string.IsNullOrEmpty(Runner_comboBox.Text))
            {
                MessageBox.Show("Выберите бегуна");
            }
            else if (string.IsNullOrEmpty(Сardowner_TextBox.Text) || Сardowner_TextBox.Text == Сardowner_TextBox_Text)
            {
                MessageBox.Show("Введите имя владельца карты");
            }
            else if (string.IsNullOrEmpty(CardNumber_maskedTextBox1.Text) || CardNumber_maskedTextBox1.Text == CardNumber_maskedTextBox1_text)
            {
                MessageBox.Show("Введите номер карты");
            }
            else if (string.IsNullOrEmpty(year_textBox.Text) || string.IsNullOrEmpty(month_textBox.Text))
            {
                MessageBox.Show("Введите срок действия карты");
            }
            else if (string.IsNullOrEmpty(CVC.Text))
            {
                MessageBox.Show("Введите CVC код");
            }
            else if (DateTime.Now > cardDateTime)
            {
                MessageBox.Show("Карта просрочена");
            }
            else if(Convert.ToInt32(Price_textBox.Text) <= 0)
            {
                MessageBox.Show("Некоректная сумма");
            }
            else
            {
                SqlConnection connect = new SqlConnection(Drawer.connectionString);
                connect.Open();
                SqlCommand com = new SqlCommand("SELECT MAX([№Операции]) FROM Пожертвования", connect);
                int operationID;
                try
                {
                    operationID = (int)com.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    operationID = 0;
                }

                // SQL-запрос INSERT для добавления данных в таблицу
                string query = "INSERT INTO [Пожертвования] ([№Операции], Получатель, Отправитель, Сумма) VALUES (@operationID, @runnerID, @Donater_Name, @Summ)";

                // Создание объекта команды с параметрами
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    // Установка значений параметров
                    command.Parameters.AddWithValue("@operationID", operationID + 1);
                    command.Parameters.AddWithValue("@runnerID", runnerID);
                    command.Parameters.AddWithValue("@Donater_Name", Name_TextBox.Text);
                    command.Parameters.AddWithValue("@Summ", Price_textBox.Text);

                    // Выполнение команды
                    int rowsAffected2 = command.ExecuteNonQuery();
                }
                Info_but.Visible = true;
                connect.Close();
                Gratitude_Donat_summ_label.Text = "$"+Price_textBox.Text;
                Gratitude_Panel.Visible = true;
                Auth_panel.Visible = false;
            }
            
        }

        private void Info_but_Click(object sender, EventArgs e)
        {
            Organization_Info form = new Organization_Info();
            form.SetStringValue(Fund_label.Text.Trim());
            form.ShowDialog();
        }
    }
}
