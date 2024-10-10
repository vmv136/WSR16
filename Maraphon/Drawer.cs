using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Data.SqlClient;


namespace Maraphon
{
    public class Drawer : Button
    {
        public static string connectionString = "Data Source=DESKTOP-LAPGCEQ;Initial Catalog=Maraphon;Integrated Security=True";
        public static SqlConnection connect = new SqlConnection(connectionString);
        public static string currentUserEmail;

        public void Reg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count <= 2)
            {
                Application.Exit();
            }
        }

        //Fields
        private int borderSize = 0;
        private int borderRadius = 20;
        private Color borderColor = Color.PaleVioletRed;

        //Properties
        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        [Category("RJ Code Advance")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        //Constructor
        public Drawer()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
        }

        //Methods
        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            if (borderRadius > 2) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    //Button surface
                    this.Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //Button border                    
                    if (borderSize >= 1)
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal button
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                //Button surface
                this.Region = new Region(rectSurface);
                //Button border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                borderRadius = this.Height;
        }

        public void Show_text(Control control, string text, Font customFont = null)
        {
            Font defaultFont = new Font("Microsoft Sans Serif", 14f, FontStyle.Italic);

            if (control is TextBox textBox)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = text;
                    textBox.ForeColor = SystemColors.GrayText;
                    textBox.Font = customFont ?? defaultFont;
                    textBox.PasswordChar = '\0';
                }
            }
            else if (control is MaskedTextBox maskedTextBox)
            {

            }
        }

        public void Hide_text(Control control, string text, Font customFont = null, char? PassChar = null)
        {
            Font defaultFont = new Font("Microsoft Sans Serif", 14f);

            if (control is TextBox textBox)
            {
                if (textBox.Text == text)
                {
                    textBox.Text = "";
                    textBox.ForeColor = SystemColors.WindowText;
                    textBox.Font = customFont ?? defaultFont;
                    if(PassChar != null)
                    {
                        textBox.PasswordChar = (char)PassChar ;
                    }
                }
            }
            else if (control is MaskedTextBox maskedTextBox)
            {

            }
        }

        public void FormSwitch(Form Newform, Form thisForm, int? CloseForm = null)
        {
            int CloseFormValue;
            try
            {
                CloseFormValue = (int)CloseForm;
            }
            catch 
            {
                CloseFormValue = 0;
            }
            Newform.Text = thisForm.Text;
            Newform.Location = thisForm.Location;
            Newform.Icon = thisForm.Icon;
            Newform.Size = thisForm.Size;
            Newform.StartPosition = FormStartPosition.Manual;
            Newform.Show();
            if (CloseFormValue == 1)
            {
                thisForm.Hide();
            }
            else { thisForm.Close(); }

        }

        public static string Import_Date()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT MAX(Год) FROM [История марафона]";
            SqlCommand com = new SqlCommand(query, connection);  
            string date = com.ExecuteScalar().ToString();
            connection.Close();
            return date;
        }

        public static void remaining_Time(string date, Label remainingTime_label)
        {
            DateTime dateTime = DateTime.Parse(date);
            TimeSpan remainingTime = dateTime - DateTime.Now;

            remainingTime_label.Text = string.Format("{0} дней {1} часов и {2} минут до старта марафона!",
            remainingTime.Days, remainingTime.Hours, remainingTime.Minutes);

        }

        public static void Filtr(DataGridView dataGridView1, TextBox textBox2)
        {
            dataGridView1.CurrentCell = null;
            int count = 0;
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                for (int j = 0; j < dataGridView1.RowCount ; j++)
                {
                    dataGridView1.Rows[j].Visible = false;
                    count = 0;
                    for (int i = 0; i < dataGridView1.ColumnCount-1; i++)
                    {

                        if (textBox2.Text.Length > 4)
                        {
                            if (LevenshteinDistance(textBox2.Text.ToLower(), dataGridView1[i, j].Value.ToString().ToLower().Trim()) < 3 || textBox2.Text.ToString() == dataGridView1[i, j].Value.ToString())
                            {
                                count++;
                            }
                        }
                        else
                        {
                            if (textBox2.Text.ToString().ToLower().Trim() == dataGridView1[i, j].Value.ToString().ToLower().Trim() || textBox2.Text.ToString() == dataGridView1[i, j].Value.ToString())
                            {
                                count++;
                            }
                        }
                    }
                    if (count != 0)
                    {
                        dataGridView1.Rows[j].Visible = true;
                    }
                }
            }
        }

        public static int LevenshteinDistance(string source, string target)
        {
            if (string.IsNullOrEmpty(source))
            {
                if (string.IsNullOrEmpty(target)) return 0;
                return target.Length;
            }
            if (string.IsNullOrEmpty(target)) return source.Length;

            if (source.Length > target.Length)
            {
                var temp = target;
                target = source;
                source = temp;
            }

            var m = target.Length;
            var n = source.Length;
            var distance = new int[2, m + 1];
            // Initialize the distance matrix
            for (var j = 1; j <= m; j++) distance[0, j] = j;

            var currentRow = 0;
            for (var i = 1; i <= n; ++i)
            {
                currentRow = i & 1;
                distance[currentRow, 0] = i;
                var previousRow = currentRow ^ 1;
                for (var j = 1; j <= m; j++)
                {
                    var cost = (target[j - 1] == source[i - 1] ? 0 : 1);
                    distance[currentRow, j] = Math.Min(Math.Min(
                                distance[previousRow, j] + 1,
                                distance[currentRow, j - 1] + 1),
                                distance[previousRow, j - 1] + cost);
                }
            }
            return distance[currentRow, m];
        }

    }
}
