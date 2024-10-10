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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Maraphon
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            this.FormClosing += drw.Reg_FormClosing;
            dataGridView1.RowHeadersVisible = false;
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

        private void Users_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
            textBox1_Leave(sender, e);
            rule_comboBox.Items.Add("Все роли");
            rule_comboBox.Items.Add("Бегуны");
            rule_comboBox.Items.Add("Координаторы");
            rule_comboBox.Items.Add("Администраторы");
            rule_comboBox.SelectedIndex = 0;

            sort_comboBox.Items.Add("Имя");
            sort_comboBox.Items.Add("Фамилия");
            sort_comboBox.Items.Add("Email");
            sort_comboBox.Items.Add("Роль");
            sort_comboBox.SelectedIndex = 3;

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Имя";
            dataGridView1.Columns[1].Name = "Фамилия";
            dataGridView1.Columns[2].Name = "Email";
            dataGridView1.Columns[3].Name = "Роль";
            dataGridView1.Columns[4].Name = "Edit";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].Width = 80;

            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.CellPainting += dataGridView1_CellPainting;

            Drawer.connect.Open();
            SqlCommand com = new SqlCommand("SELECT COUNT([Email]) FROM [Пользователи]", Drawer.connect);
            total_users_label.Text = "Всего пользователей: " + com.ExecuteScalar().ToString();

            Drawer.connect.Close();

            drawer2_Click(null, null);

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

        private void drawer2_Click(object sender, EventArgs e)
        {
            string rule = "";
            string sort = "";
            if(rule_comboBox.SelectedIndex == 0) 
            {
                rule = "";
            }
            else if (rule_comboBox.SelectedIndex == 1)
            {
                rule = "WHERE Роль = 'run'";
            }
            else if (rule_comboBox.SelectedIndex == 2)
            {
                rule = "WHERE Роль = 'crd'";
            }
            else if (rule_comboBox.SelectedIndex == 3)
            {
                rule = "WHERE Роль = 'adm'";
            }

            if(sort_comboBox.SelectedIndex == 0)
            {
                sort= "ORDER BY Имя";
            }
            else if (sort_comboBox.SelectedIndex == 1)
            {
                sort = "ORDER BY Фамилия";
            }
            else if (sort_comboBox.SelectedIndex == 2)
            {
                sort = "ORDER BY Email";
            }
            else if (sort_comboBox.SelectedIndex == 3)
            {
                sort = "ORDER BY Роль";
            }

            string query = "SELECT Имя, Фамилия, Email, Роль FROM Пользователи " + rule + sort;

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
                    string Rule = reader["Роль"].ToString().Trim();

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
                    if (Rule == "adm")
                    {
                        textCell3.Value = "Администратор";
                    }
                    else if (Rule == "run")
                    {
                        textCell3.Value = "Бегун";
                    }
                    else if (Rule == "crd")
                    {
                        textCell3.Value = "Координотор";
                    }
                    row.Cells.Add(textCell3);

                    // Добавляем строку в DataGridView
                    dataGridView1.Rows.Add(row);
                }
                reader.Close();
                Drawer.connect.Close();
            }
            

            dataGridView1.CurrentCell = null;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Adm adm = new Adm();
            drw.FormSwitch(adm, this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Поиск")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "Поиск";
                textBox1.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Drawer.Filtr(dataGridView1, textBox1);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }

        private void Add_user_but_Click(object sender, EventArgs e)
        {
            User_Add form = new User_Add();
            drw.FormSwitch(form, this);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                int current_row = e.RowIndex;
                //MessageBox.Show("Открытие формы сергея и передача в нее выбранной ячейки - а точнее " + org_name);
                User_edit form = new User_edit();
                form.SetEmail(dataGridView1.Rows[current_row].Cells[2].Value.ToString());
                drw.FormSwitch(form, this);
            }
        }
    }
}
