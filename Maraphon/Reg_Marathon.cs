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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Maraphon
{
    public partial class Reg_Marathon : Form
    {
        Drawer drw = new Drawer();

        public Reg_Marathon()
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

        private void Reg_Marathon_Load(object sender, EventArgs e)
        {

            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
            SqlConnection connect = new SqlConnection(Drawer.connectionString);
            Summ_textBox_Leave(sender, e);
            connect.Open();
            string srch = "Select distinct [Название] From [Фонды]";//выбираем нужный столбец в нужной таблице
            DataTable sch = new DataTable();
            SqlDataAdapter sr = new SqlDataAdapter(srch, connect);
            sr.Fill(sch);
            connect.Close();
            foreach (DataRow row in sch.Rows)//заполняем массив значениями из столбца
            {
                Fund_comboBox.Items.Add(row[0].ToString());
            }
            //richTextBox1.Text = "";
            ////richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            ////richTextBox1.AppendText("Система, в которой основной единицей расчета считается золото, называется ");

            //richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
            //richTextBox1.AppendText("Вариант А ($0): ");

            ////richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
            ////richTextBox1.AppendText("Дальше будет курсив. ");

            //richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            //richTextBox1.AppendText("Номер бегуна+\r\nRFID браслет.");
        }

        public int Summ()
        {
            if (Summ_label.Text.Length > 0)
            {
                int sum = Convert.ToInt32(Summ_label.Text.Substring(1));
                return sum;
            }
            else {return 0; }
        }

        public void CheckedChanged(Control control, int summ)
        {
            int x;
            if(control is CheckBox CB)
            {
                if (CB.Checked)
                {
                    x = Summ();
                    Summ_label.Text = "";
                    Summ_label.Text = "$" + (x + summ).ToString();
                    check += 1;
                }
                else
                {
                    x = Summ();
                    Summ_label.Text = "";
                    Summ_label.Text = "$" + (x - summ).ToString();
                    check -= 1;
                }
            }
            else if( control is RadioButton RB )
            {
                if (RB.Checked)
                {
                    x = Summ();
                    Summ_label.Text = "";
                    Summ_label.Text = "$" + (x + summ).ToString();
                }
                else
                {
                    x = Summ();
                    Summ_label.Text = "";
                    Summ_label.Text = "$" + (x - summ).ToString();
                }
            }
            
        }

        int check = 0;

        private void Long_Marathon_CB_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(Long_Marathon_CB, 145);
        }

        private void Middle_Marathon_CB_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(Middle_Marathon_CB, 75);
        }

        private void Short_Marathon_CB_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(Short_Marathon_CB, 20);
        }

        int PackageID = 0;

        private void Option1_RB_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(Option1_RB, 0);
            PackageID = 0;
        }

        private void Option2_RB_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(Option2_RB, 20);
            PackageID = 1;
        }
        private void Option3_RB_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(Option3_RB, 45);
            PackageID = 2;
        }

        string Summ_textBox_Text = "$500";

        private void Summ_textBox_Enter(object sender, EventArgs e)
        {
            drw.Hide_text(Summ_textBox, Summ_textBox_Text);
        }

        private void Summ_textBox_Leave(object sender, EventArgs e)
        {
            drw.Show_text(Summ_textBox, Summ_textBox_Text);
        }

        int runID;

        private void Auth_but_Click(object sender, EventArgs e)
        {
            if (check <= 0)
            {
                MessageBox.Show("Выберите дистанцию марафона");
            }
            else if (string.IsNullOrEmpty(Fund_comboBox.Text))
            {
                MessageBox.Show("Не выбран фонд");
            }
            else if (Summ_textBox_Text == Summ_textBox.Text || string.IsNullOrEmpty(Summ_textBox.Text))
            {
                MessageBox.Show("Сумма взноса не указана");
            }
            else if (Convert.ToInt32(Summ_textBox.Text) < 0)
            {
                MessageBox.Show("Сумма взноса указана некорректно");
            }
            else 
            {
                Drawer.connect.Open();

                string query2 = "SELECT [№Бегуна] FROM бегуны, Пользователи WHERE Бегуны.Email = Пользователи.Email AND Пользователи.Email = @Email";

                using (SqlCommand command = new SqlCommand(query2, Drawer.connect))
                {
                    command.Parameters.AddWithValue("@Email", Drawer.currentUserEmail);
                    runID = Convert.ToInt32(command.ExecuteScalar());
                }

                // SQL-запрос INSERT для добавления данных в таблицу
                string query1 = "UPDATE [Бегуны] SET [Фонд] = '" + Fund_comboBox.Text.Trim() + "',[Пожертвование] = @Donat, [Выбранный пакет] = @PackageID, [Рег.статус] = @Status WHERE [№Бегуна] = @runID";

                // Создание объекта команды с параметрами
                using (SqlCommand command = new SqlCommand(query1, Drawer.connect))
                {
                    // Установка значений параметров
                    command.Parameters.AddWithValue("@runID", runID);
                    command.Parameters.AddWithValue("@Donat", Summ_textBox.Text);
                    command.Parameters.AddWithValue("@PackageID", PackageID);
                    command.Parameters.AddWithValue("@Status", "Зарегистрирован");

                    // Выполнение команды
                    command.ExecuteNonQuery();
                }
                
                Drawer.connect.Close();

                if (Long_Marathon_CB.Checked)
                {
                    Insert_Result("42km");
                }
                if (Middle_Marathon_CB.Checked)
                {
                    Insert_Result("21km");
                }
                if (Short_Marathon_CB.Checked)
                {
                    Insert_Result("5km");
                }

                //UPDATE Бегуны SET Фонд = 'кошки' WHERE[№Бегуна] = 1;
                //SELECT Email FROM Пользователи, Бегуны WHERE Пользователи.[№Бегуна] = Бегуны.[№Бегуна]
                //SELECT MAX([№Результата]) FROM Результаты
                //INSERT INTO[Результаты] ([Бегун], [Год Марафона], Дистанция) VALUES(@Value1, @Value2, @Value3)
                Auth_panel.Visible = false;
                Gratitude_Panel.Visible = true;
            }
        }

        public void Insert_Result(string Distance)
        {
            Drawer.connect.Open();

            string query = "SELECT Год FROM [История марафона] Where YEAR(Год) = 2024";
            SqlCommand com = new SqlCommand(query, Drawer.connect);
            string date = com.ExecuteScalar().ToString();

            // SQL-запрос INSERT для добавления данных в таблицу
            string query4 = "INSERT INTO [Результаты] ([Бегун], [Год Марафона], Дистанция) VALUES (@Email, @Year, @Distance)";

            // Создание объекта команды с параметрами
            using (SqlCommand command = new SqlCommand(query4, Drawer.connect))
            {
                // Установка значений параметров
                command.Parameters.AddWithValue("@Email", Drawer.currentUserEmail);
                command.Parameters.AddWithValue("@Year", date);
                command.Parameters.AddWithValue("@Distance", Distance);

                // Выполнение команды
                command.ExecuteNonQuery();
            }
            Drawer.connect.Close();
        }

        private void Summ_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой или клавишей Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Если символ не цифра и не клавиша Backspace, то отменяем его ввод
                e.Handled = true;
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }

        private void Reg_Marathon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count <= 2)
            {
                Application.Exit();
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Runner_menu run_menu = new Runner_menu();
            drw.FormSwitch(run_menu, this);
        }

        private void OK_But_Click(object sender, EventArgs e)
        {
            Back_Click(sender, e);
        }

        private void org_Info_But_Click(object sender, EventArgs e)
        {
            Organization_Info form = new Organization_Info();
            form.SetStringValue(Fund_comboBox.Text.Trim());
            form.ShowDialog();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Option1_RB.Checked = true;
            Long_Marathon_CB.Checked = false;
            Middle_Marathon_CB.Checked = false;
            Short_Marathon_CB.Checked = false;
            Fund_comboBox.SelectedIndex = -1;
            Summ_textBox.Text = null;
            Summ_textBox_Leave(sender, e);
        }
    }
}
