using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SortOrder = System.Windows.Forms.SortOrder;

namespace Maraphon
{
    public partial class Sponsorship_overview : Form
    {
        public Sponsorship_overview()
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

        private void Sponsorship_overview_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);

            sort_comboBox.Items.Add("Название");
            sort_comboBox.Items.Add("Сумма");
            sort_comboBox.SelectedIndex = 1;

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Лого";
            dataGridView1.Columns[1].Name = "Название";
            dataGridView1.Columns[2].Name = "Сумма";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ReadOnly = true;

            dataGridView1.ScrollBars = ScrollBars.Both;

            Fill_DataGrid();
        }

        private void Fill_DataGrid()
        {
            dataGridView1.Rows.Clear();

            string query = "SELECT " +
                    "Фонды.Лого, " +
                    "Фонды.Название, " +
                    "COALESCE(SUM(Пожертвования.Сумма), 0) AS Сумма, " +
                    "COUNT(Фонды.Название) OVER () AS КоличествоФондов " +
                    "FROM Фонды " +
                    "LEFT JOIN Бегуны ON Название = Фонд " +
                    "LEFT JOIN Пожертвования ON Получатель = [№Бегуна] " +
                    "GROUP BY Фонды.Лого, Фонды.Название ";
            string query2 = "SELECT SUM(Пожертвования.Сумма) FROM Пожертвования";
            connect.Open();
            SqlCommand cmd = new SqlCommand(query2, connect);
            int summ = (int)cmd.ExecuteScalar();
            all_donat_label.Text = "Всего спонсорских взносов: " + summ.ToString("#,#", CultureInfo.InvariantCulture);
            using (SqlCommand command = new SqlCommand(query, connect))
            {
                
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int sum = (int)reader["Сумма"];
                    string logoPath = reader["Лого"].ToString().Trim();
                    string name = reader["Название"].ToString().Trim();
                    fund_summ_label.Text = "Благотворительные организации: " + reader["КоличествоФондов"].ToString().Trim();
                    // Загрузка изображения из локального файла
                    Image image = LoadImageFromFile(logoPath);

                    // Создаем новую строку DataGridViewRow
                    DataGridViewRow row = new DataGridViewRow();

                    // Создаем ячейку для изображения и добавляем ее в строку
                    DataGridViewImageCell imageCell = new DataGridViewImageCell();
                    imageCell.Value = image;
                    row.Cells.Add(imageCell);

                    // Создаем ячейку для текста и добавляем ее в строку
                    DataGridViewTextBoxCell textCell = new DataGridViewTextBoxCell();
                    textCell.Value = name;
                    row.Cells.Add(textCell);

                    DataGridViewTextBoxCell textCell2 = new DataGridViewTextBoxCell();
                    textCell2.Value = sum.ToString("#,#", CultureInfo.InvariantCulture);
                    row.Cells.Add(textCell2);

                    // Добавляем строку в DataGridView
                    dataGridView1.Rows.Add(row);
                }
                reader.Close();

            }
            connect.Close();
            sorted_but_Click(null, null);
            sorted_but_Click(null, null);

            dataGridView1.CurrentCell = null;
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

        private void Logout_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            coordinator_Menu coord = new coordinator_Menu();
            drw.FormSwitch(coord, this);
        }

        private void sorted_but_Click(object sender, EventArgs e)
        {
            
            // Проверяем, что столбец с индексом существует
            if (dataGridView1.Columns.Count > sort_comboBox.SelectedIndex+1)
            {
                // Получаем столбец, по которому сортируем
                DataGridViewColumn column = dataGridView1.Columns[sort_comboBox.SelectedIndex+1];

                // Определяем текущее направление сортировки
                ListSortDirection direction = (column.HeaderCell.SortGlyphDirection == SortOrder.Ascending) ?
                    ListSortDirection.Descending : ListSortDirection.Ascending;

                // Включаем сортировку для столбца
                dataGridView1.Sort(column, direction);
            }
        }
    }
}
