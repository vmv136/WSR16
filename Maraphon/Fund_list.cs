using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Maraphon
{
    public partial class Fund_list : Form
    {
        public Fund_list()
        {
            InitializeComponent();
            this.FormClosing += drw.Reg_FormClosing;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
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

        private void Fund_list_Load(object sender, EventArgs e)
        {

            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Logo";
            dataGridView1.Columns[1].Name = "Info";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.ScrollBars = ScrollBars.Both; // или ScrollBars.Vertical


            using (connect)
            {
                string query = "SELECT Описание, Лого, Название FROM Фонды";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    connect.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string info = reader["Описание"].ToString().Trim();
                        string logoPath = reader["Лого"].ToString().Trim();
                        string name = reader["Название"].ToString().Trim();

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
                        textCell.Value = name + "\n" + info;
                        row.Cells.Add(textCell);

                        // Добавляем строку в DataGridView
                        dataGridView1.Rows.Add(row);
                    }
                    reader.Close();
                    connect.Close();
                }
            }

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

        private void Back_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);

        }

    }
}
