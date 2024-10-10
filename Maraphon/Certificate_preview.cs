using System;
using System.Collections;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Maraphon
{
    public partial class Certificate_preview : Form
    {
        public Certificate_preview()
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


        SqlConnection connect = new SqlConnection(Drawer.connectionString);

        private void Timer_Tick(object sender, EventArgs e)
        {
            Drawer.remaining_Time(Date, Timer_label);
        }

        string runEmail;

        public void SetUserEmail(string email)
        {
            runEmail = email;
        }
        
        private void Certificate_preview_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);

            using (connect)
            {
                string query = "SELECT CONCAT(r.Дистанция, ' - ',TRIM(m.Страна), ' ', YEAR([Год Марафона])) AS 'Соревнование', Лого, Имя, Фамилия, r.Дистанция, r.Время, " +
                    "CASE WHEN r.Время IS NOT NULL THEN(SELECT COUNT(*) + 1 FROM Результаты WHERE Время < r.Время AND Дистанция = r.Дистанция) " +
                    "ELSE NULL END AS Позиция, " +
                    "YEAR([Год Марафона]) AS Год, " +
                    "m.Страна, " +
                    "(SELECT SUM(Сумма) FROM Пожертвования WHERE Получатель = b.[№Бегуна]) AS Сумма " +
                    "FROM Результаты r " +
                    "JOIN Пользователи p ON r.Бегун = p.Email " +
                    "JOIN[История марафона] m ON[Год Марафона] = Год " +
                    "JOIN Бегуны b ON p.Email = b.Email " +
                    "JOIN Фонды ON Фонд = Название " +
                    "WHERE p.Email = '"+runEmail+"'; ";
;
                connect.Open();

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    race_comboBox.Items.Clear();

                    while (reader.Read())
                    {
                        race_comboBox.Items.Add(reader["Соревнование"].ToString().Trim());
                    }
                    reader.Close();

                }

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dataGridView1.DataSource = table;
                    }
                }

                connect.Close();
            }

            if(race_comboBox.Items.Count>0)
                race_comboBox.SelectedIndex = 0;

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

        private void Back_Click(object sender, EventArgs e)
        {
            Manage_a_runner form = new Manage_a_runner();
            form.SetEmail(runEmail);
            drw.FormSwitch(form, this);
        }

        private void race_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = dataGridView1[2, race_comboBox.SelectedIndex].Value.ToString().Trim();
            string last_name = dataGridView1[3, race_comboBox.SelectedIndex].Value.ToString().Trim();
            string distance = dataGridView1[4, race_comboBox.SelectedIndex].Value.ToString().Trim();
            string time = dataGridView1[5, race_comboBox.SelectedIndex].Value.ToString().Trim();
            string position = dataGridView1[6, race_comboBox.SelectedIndex].Value.ToString().Trim();
            string date = dataGridView1[7, race_comboBox.SelectedIndex].Value.ToString().Trim();
            string country = dataGridView1[8, race_comboBox.SelectedIndex].Value.ToString().Trim();
            int sum;
            try
            {
                sum = (int)dataGridView1[9, race_comboBox.SelectedIndex].Value;
            }
            catch
            {
                sum = 0;
            }

            Congratulation_label.Text = $"Поздравляем {name} {last_name} с участием в {distance} марафоне. Ваши результаты: Время {time} и занятое место {position}rd!";
            marathone_year_label.Text = $"Marathon Skills {date}";
            country_label.Text = country;
            earned_label.Text = $"Вы также заработали ${sum} для вашей благотворительной организации!";

        }
    }
}
