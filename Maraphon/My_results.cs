using System;
using System.Collections.Concurrent;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Maraphon
{
    public partial class My_results : Form
    {
        public My_results()
        {
            InitializeComponent();
            this.FormClosing += drw.Reg_FormClosing;
            timer = new Timer();
            timer.Interval = 10000; // Интервал в миллисекундах (10 секунд)
            timer.Tick += Timer_Tick;
            timer.Start(); // Запуск таймера
        }

        DataSet ds = new DataSet();
        private Timer timer;
        string Date;
        SqlConnection connect = new SqlConnection(Drawer.connectionString);

        private void Timer_Tick(object sender, EventArgs e)
        {
            Drawer.remaining_Time(Date, Timer_label);
        }

        Drawer drw = new Drawer();

        private void Logout_Click(object sender, EventArgs e)
        {
                Main main = new Main();
                drw.FormSwitch(main, this);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Runner_menu menu = new Runner_menu();
            drw.FormSwitch(menu, this);
        }
        DateTime date;
        private void My_results_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);

            string query = "SELECT Пол, CASE WHEN DATEDIFF(YEAR, [Дата рождения], GETDATE()) < 18 THEN '<18' " +
                "WHEN DATEDIFF(YEAR, [Дата рождения], GETDATE()) BETWEEN 18 AND 29 THEN '18-29' " +
                "WHEN DATEDIFF(YEAR, [Дата рождения], GETDATE()) BETWEEN 30 AND 39 THEN '30-39' " +
                "WHEN DATEDIFF(YEAR, [Дата рождения], GETDATE()) BETWEEN 40 AND 55 THEN '40-55' " +
                "WHEN DATEDIFF(YEAR, [Дата рождения], GETDATE()) BETWEEN 56 AND 70 THEN '56-70' " +
                "WHEN DATEDIFF(YEAR, [Дата рождения], GETDATE()) > 70 THEN '70>' " +
                "END AS Категория_возраста FROM Пользователи, Бегуны " +
                "WHERE Бегуны.Email = Пользователи.Email " +
                "AND Пользователи.Email = '" + Drawer.currentUserEmail + "'";

            using (SqlCommand command = new SqlCommand(query, connect))
            {

                connect.Open();
                SqlDataReader reader = command.ExecuteReader();


                // Загружаем данные в ComboBox
                while (reader.Read())
                {
                    Gender_label.Text = reader["Пол"].ToString().Trim();
                    age_Category_label.Text = reader["Категория_возраста"].ToString().Trim();
                }
                reader.Close();
                connect.Close();
            }

            string Table_sql = "SELECT CONCAT(TRIM([История марафона].Страна), ' ', YEAR([Год Марафона])) AS 'Соревнование', r.Дистанция, r.Время, " +
                "CASE WHEN r.Время IS NOT NULL THEN(SELECT COUNT(*) + 1 FROM Результаты WHERE Время < r.Время AND Дистанция = r.Дистанция) " +
                "ELSE NULL END AS Позиция, " +
                "CASE WHEN r.Время IS NOT NULL " +
                "THEN(SELECT COUNT(*) + 1 " +
                "FROM Результаты, Пользователи " +
                "WHERE Время < r.Время AND Дистанция = r.Дистанция AND Бегун = Email " +
                "AND DATEDIFF(YEAR, [Дата рождения], [Год Марафона]) = DATEDIFF(YEAR, [Дата рождения], [Год Марафона]) " +
                "AND CASE " +
                "WHEN DATEDIFF(YEAR, [Дата рождения], [Год Марафона]) < 18 THEN '<18' " +
                "WHEN DATEDIFF(YEAR, [Дата рождения], [Год Марафона]) BETWEEN 18 AND 29 THEN '18-29' " +
                "WHEN DATEDIFF(YEAR, [Дата рождения], [Год Марафона]) BETWEEN 30 AND 39 THEN '30-39' " +
                "WHEN DATEDIFF(YEAR, [Дата рождения], [Год Марафона]) BETWEEN 40 AND 55 THEN '40-55' " +
                "WHEN DATEDIFF(YEAR, [Дата рождения], [Год Марафона]) BETWEEN 56 AND 70 THEN '56-70' " +
                "ELSE '>70' END = 'Возрастная категория') " +
                "ELSE NULL END AS 'Позиция в возрастной категории' " +
                "FROM Результаты r, Пользователи p, [История марафона], Бегуны " +
                "WHERE Бегун = p.Email AND[Год Марафона] = Год AND p.Email = Бегуны.Email AND p.Email = '"+Drawer.currentUserEmail+"' " +
                "ORDER BY 'Соревнование'; ";
            Drawer.connect.Open();
            ds.Tables.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter(Table_sql, Drawer.connect);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            adapter.Dispose();
            Drawer.connect.Close();

        }

        private void all_result_but_Click(object sender, EventArgs e)
        {
            Results res = new Results();
            drw.FormSwitch(res, this);
        }
    }
}
