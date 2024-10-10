using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maraphon
{
    public partial class Manage_charities : Form
    {
        public Manage_charities()
        {
            InitializeComponent();
            this.FormClosing += drw.Reg_FormClosing;

            // Инициализация таймера
            timer = new Timer();
            timer.Interval = 10000; // Интервал в миллисекундах (10 секунд)
            timer.Tick += Timer_Tick;
            timer.Start(); // Запуск таймера
            //dataGridView1.Columns[4].Width = 80;
        }

        private Timer timer;
        string Date;

        private void Timer_Tick(object sender, EventArgs e)
        {
            Drawer.remaining_Time(Date, Timer_label);
        }

        Drawer drw = new Drawer();

        SqlConnection connect = new SqlConnection(Drawer.connectionString);

        private void Manage_charities_Load(object sender, EventArgs e)
        {

            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Лого";
            dataGridView1.Columns[1].Name = "Наименование";
            dataGridView1.Columns[2].Name = "Описание";
            dataGridView1.Columns[3].Name = "Edit";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ReadOnly = true;

            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.CellPainting += dataGridView1_CellPainting;

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
                        textCell.Value = name;
                        row.Cells.Add(textCell);

                        DataGridViewTextBoxCell textCell2 = new DataGridViewTextBoxCell();
                        textCell2.Value = info;
                        row.Cells.Add(textCell2);

                        // Добавляем строку в DataGridView
                        dataGridView1.Rows.Add(row);
                    }
                    reader.Close();
                    connect.Close();
                }
            }

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
            Adm adm = new Adm();
            drw.FormSwitch(adm, this);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                int current_row = e.RowIndex;
                string org_name = dataGridView1.Rows[current_row].Cells[1].Value.ToString();
                OrgAdm form = new OrgAdm();
                form.SetFund(org_name);
                drw.FormSwitch(form, this);
            }
        }

        private void search_but_Click(object sender, EventArgs e)
        {
            OrgAdm orgAdm = new OrgAdm();
            drw.FormSwitch(orgAdm, this);
        }
    }
}
