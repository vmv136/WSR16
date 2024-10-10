using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Maraphon
{
    public partial class Runner_Management : Form
    {
        public Runner_Management()
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

        private void Runner_Management_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);

            pay_combox.Items.Add("Все");                    //0
            pay_combox.Items.Add("Зарегистрирован");        //1
            pay_combox.Items.Add("Подтверждена оплата");    //2
            pay_combox.Items.Add("Выдан пакет");            //3
            pay_combox.Items.Add("Вышел на старт");         //4
            pay_combox.Items.Add("Не зарегистрирован");     //5
            pay_combox.SelectedIndex = 0;

            sort_comboBox.Items.Add("Имя");
            sort_comboBox.Items.Add("Фамилия");
            sort_comboBox.Items.Add("Email");
            sort_comboBox.Items.Add("Статус");
            sort_comboBox.SelectedIndex = 3;

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Имя";
            dataGridView1.Columns[1].Name = "Фамилия";
            dataGridView1.Columns[2].Name = "Email";
            dataGridView1.Columns[3].Name = "Статус";
            dataGridView1.Columns[4].Name = "Edit";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.CellPainting += dataGridView1_CellPainting;

            dataGridView1.ReadOnly = true;

            Drawer.connect.Open();

            SqlCommand distance = new SqlCommand("SELECT DISTINCT [Дистанция] FROM [Результаты]", Drawer.connect);
            SqlDataReader reader = distance.ExecuteReader();
            while (reader.Read())
            {
                distance_comboBox.Items.Add(reader["Дистанция"].ToString().Trim());
            }
            reader.Close();

            Drawer.connect.Close();

            if(distance_comboBox.Items.Count > 0)
                distance_comboBox.SelectedIndex = 0;

            drawer2_Click(null, null);

            dataGridView1.CurrentCell = null;
        }
        

        private void drawer2_Click(object sender, EventArgs e)
        {
            string status = "";

            if (pay_combox.SelectedIndex > 0 && pay_combox.SelectedIndex <= 4)
                status = " AND [Рег.статус] = '" + pay_combox.Text+"'";
            string query = "SELECT Имя, Фамилия, П.Email,[Рег.статус], ISNULL([Рег.статус], 'Не зарегистрирован') AS 'Статус' " +
                "FROM Бегуны Б " +
                "JOIN Пользователи П ON П.Email = Б.Email " +
                "JOIN Результаты ON Бегун = П.Email " +
                "WHERE Дистанция = '"+distance_comboBox.Text+"'" + status + "";

            using (SqlCommand command = new SqlCommand(query, Drawer.connect))
            {
                dataGridView1.Rows.Clear();

                Drawer.connect.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string Name = reader["Имя"].ToString().Trim();
                    string Family = reader["Фамилия"].ToString().Trim();
                    string Email = reader["Email"].ToString().Trim();
                    string Status = reader["Статус"].ToString().Trim();

                    // Создаем новую строку DataGridViewRow
                    DataGridViewRow row = new DataGridViewRow();

                    // Создаем ячейку для текста и добавляем ее в строку
                    DataGridViewTextBoxCell textCell0 = new DataGridViewTextBoxCell();
                    textCell0.Value = Name;
                    row.Cells.Add(textCell0);

                    DataGridViewTextBoxCell textCell1 = new DataGridViewTextBoxCell();
                    textCell1.Value = Family;
                    row.Cells.Add(textCell1);

                    DataGridViewTextBoxCell textCell2 = new DataGridViewTextBoxCell();
                    textCell2.Value = Email;
                    row.Cells.Add(textCell2);

                    DataGridViewTextBoxCell textCell3 = new DataGridViewTextBoxCell();
                    textCell3.Value = Status;
                    row.Cells.Add(textCell3);

                    // Добавляем строку в DataGridView
                    dataGridView1.Rows.Add(row);
                }
                reader.Close();
                Drawer.connect.Close();
            }


            // Проверяем, что столбец с индексом существует
            if (dataGridView1.Columns.Count > sort_comboBox.SelectedIndex)
            {
                // Получаем столбец, по которому сортируем
                DataGridViewColumn column = dataGridView1.Columns[sort_comboBox.SelectedIndex];

                // Определяем текущее направление сортировки
                ListSortDirection direction = (column.HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Ascending) ?
                    ListSortDirection.Descending : ListSortDirection.Ascending;

                // Включаем сортировку для столбца
                dataGridView1.Sort(column, direction);
            }

            total_users_label.Text = "Всего бегунов: " + dataGridView1.RowCount.ToString();

            dataGridView1.CurrentCell = null;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                Graphics graphics = e.Graphics;
                int buttonWidth = 50;
                int buttonHeight = 20;

                // Вычисляем координаты для центрирования кнопки в ячейке
                int buttonX = e.CellBounds.X + (e.CellBounds.Width - buttonWidth) / 2;
                int buttonY = e.CellBounds.Y + (e.CellBounds.Height - buttonHeight) / 2;

                Rectangle buttonRect = new Rectangle(buttonX, buttonY, buttonWidth, buttonHeight); // Размеры кнопки 100x50
                int cornerRadius = 7; // Радиус закругления углов
                int borderWidth = 2; // Ширина рамки

                // Рисуем прямоугольную кнопку с закругленными краями
                using (GraphicsPath path = RoundedRectangle(buttonRect, cornerRadius))
                {
                    // Заливаем кнопку белым цветом
                    graphics.FillPath(Brushes.White, path);

                    // Рисуем рамку кнопки
                    using (Pen borderPen = new Pen(SystemColors.ControlDarkDark, borderWidth))
                    {
                        graphics.DrawPath(borderPen, path);
                    }
                }

                // Выводим текст на кнопку
                string buttonText = "Edit";
                SizeF textSize = graphics.MeasureString(buttonText, new Font("Microsoft Sans Serif", 12, FontStyle.Bold)); // Используем шрифт Microsoft Sans Serif
                PointF textLocation = new PointF(buttonX + (buttonWidth - textSize.Width) / 2, buttonY + (buttonHeight - textSize.Height) / 2);

                // Используем цвет текста ControlDarkDark
                using (Brush brush = new SolidBrush(SystemColors.ControlDarkDark))
                {
                    graphics.DrawString(buttonText, new Font("Microsoft Sans Serif", 12, FontStyle.Bold), brush, textLocation);
                }

                e.Handled = true;
            }
        }

        private GraphicsPath RoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90); // Верхний левый угол
            path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90); // Верхний правый угол
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90); // Нижний правый угол
            path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90); // Нижний левый угол
            path.CloseFigure();

            return path;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                int current_row = e.RowIndex;
                string org_name = dataGridView1.Rows[current_row].Cells[2].Value.ToString();
                Manage_a_runner form = new Manage_a_runner();
                form.SetEmail(org_name);
                drw.FormSwitch(form, this);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            coordinator_Menu form = new coordinator_Menu();
            drw.FormSwitch(form, this);
        }
    }
}
