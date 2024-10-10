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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Maraphon
{
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
            this.FormClosing += drw.Reg_FormClosing;
            //dataGridView1.RowHeadersVisible = false;
            //dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dataGridView1.ReadOnly = true;
            //dataGridView1.AllowUserToAddRows = false;

            //for(int i = 0; i < 5; i++)
            //{
            //    // Добавление строки
            //    dataGridView1.Rows.Add("Значение1", "Значение2", "Значение3");

            //}

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            // Инициализация таймера
            timer = new Timer();
            timer.Interval = 10000; // Интервал в миллисекундах (10 секунд)
            timer.Tick += Timer_Tick;
            timer.Start(); // Запуск таймера
        }

        private Timer timer;
        string Date;
        Drawer drw = new Drawer();
        DataSet ds = new DataSet();

        private void Timer_Tick(object sender, EventArgs e)
        {
            Drawer.remaining_Time(Date, Timer_label);
        }

        SqlConnection connect = new SqlConnection(Drawer.connectionString);

        private void Results_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);

            using (connect)
            {
                string country_year = "SELECT Страна, YEAR(Год) AS Год FROM [История марафона]";

                using (SqlCommand command = new SqlCommand(country_year, connect))
                {

                    connect.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Очищаем ComboBox перед загрузкой данных
                    maraphon_comboBox.Items.Clear();

                    // Загружаем данные в ComboBox
                    while (reader.Read())
                    {
                        string country = reader["Страна"].ToString().Trim();
                        string year = reader["Год"].ToString().Trim();

                        maraphon_comboBox.Items.Add(country + " - " + year);
                    }
                    reader.Close();
                    connect.Close();
                }

                string distance_query = "SELECT DISTINCT (Дистанция) from Результаты";

                using (SqlCommand command = new SqlCommand(distance_query, connect))
                {

                    connect.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Очищаем ComboBox перед загрузкой данных
                    distance_comboBox.Items.Clear();

                    // Загружаем данные в ComboBox
                    while (reader.Read())
                    {
                        string distance = reader["Дистанция"].ToString().Trim();

                        distance_comboBox.Items.Add(distance);
                    }
                    reader.Close();
                    connect.Close();
                }
            } 

            maraphon_comboBox.SelectedIndex = 0;
            distance_comboBox.SelectedIndex = 0;
            Gender_comboBox.SelectedIndex = 0;
            Category_comboBox.SelectedIndex = 0;
            stat_table.Visible = false;


        }


        private void Back_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }

        string Age_category = "BETWEEN 0 AND 2000";
        string Gender = " ";
        int startIndex = 0;

        private void search_but_Click(object sender, EventArgs e)
        {
            string Table_sql = "SELECT " +
                "CASE " +
                "WHEN Время IS NOT NULL THEN ROW_NUMBER() OVER(ORDER BY CASE WHEN Результаты.Время IS NULL THEN 1 ELSE 0 END, Результаты.Время ASC) " +
                "ELSE NULL " +
                "END AS Место, Время, Пользователи.Имя, Бегуны.Страна " +
                "FROM Бегуны JOIN Пользователи ON Бегуны.Email = Пользователи.Email " +
                "JOIN Результаты ON Результаты.[Бегун] = Пользователи.Email " +
                "WHERE DATEDIFF(day, Бегуны.[Дата рождения], Результаты.[Год Марафона]) / 365.25 "+ Age_category + " " +
                "AND Результаты.[Дистанция] = '" + distance_comboBox.Text + "' "+Gender+" " +
                "ORDER BY CASE WHEN Результаты.Время IS NULL THEN 1 ELSE 0 END, Результаты.Время ASC; ";
            Drawer.connect.Open();
            ds.Tables.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter(Table_sql, Drawer.connect);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            adapter.Dispose();
            string label_sql = "SELECT CONVERT(TIME, DATEADD(SECOND, AVG(DATEDIFF(SECOND, '00:00:00', Результаты.Время)), '00:00:00')) AS Среднее_время " +
                "FROM Результаты JOIN Пользователи ON Результаты.[Бегун] = Пользователи.Email JOIN Бегуны " +
                "ON Бегуны.Email = Пользователи.Email WHERE Результаты.[Дистанция] = '" + distance_comboBox.Text + "' " +
                "AND YEAR(Результаты.[Год Марафона]) = '" + maraphon_comboBox.Text.Substring(startIndex + 1).Trim() + "' " +
                "AND DATEDIFF(day, Бегуны.[Дата рождения], Результаты.[Год Марафона]) / 365.25 " + Age_category + " " +Gender+"";
            SqlCommand com = new SqlCommand(label_sql, Drawer.connect);
            string label_Text = com.ExecuteScalar().ToString();
            Drawer.connect.Close();
            medium_time_label.Text = label_Text;
            quantity_run_label.Text = dataGridView1.RowCount.ToString();
            int no_finish_runners = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value == null || string.IsNullOrWhiteSpace(row.Cells[1].Value.ToString()))
                {
                    no_finish_runners++;
                }
            }
            finish_run_label.Text = (dataGridView1.RowCount - no_finish_runners).ToString();
            stat_table.Visible = true;
        }

        private void Category_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Category_comboBox.SelectedIndex == 1)
            {
                Age_category = "<18";
            }
            else if (Category_comboBox.SelectedIndex == 2)
            {
                Age_category = "BETWEEN 18 AND 29";
            }
            else if (Category_comboBox.SelectedIndex == 3)
            {
                Age_category = "BETWEEN 30 AND 39";
            }
            else if (Category_comboBox.SelectedIndex == 4)
            {
                Age_category = "BETWEEN 40 AND 55";
            }
            else if (Category_comboBox.SelectedIndex == 5)
            {
                Age_category = "BETWEEN 56 AND 70";
            }
            else if (Category_comboBox.SelectedIndex == 6)
            {
                Age_category = ">70";
            }
        }

        private void Gender_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Gender_comboBox.SelectedIndex != 0)
                Gender = " AND Пол = '" + Gender_comboBox.Text.Trim() + "' ";
            else 
                Gender = "";
        }

        private void maraphon_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            startIndex = maraphon_comboBox.Text.IndexOf("-"); // Находим индекс символа "-"
        }
    }
}
