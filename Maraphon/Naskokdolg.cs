using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maraphon
{
    public partial class Naskokdolg : Form
    {
        public Naskokdolg()
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

        private void Naskokdolg_Load(object sender, EventArgs e)
        {
            image4_pb.Hide();
            image4_label.Hide();
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
        }

        public bool pb1clikd = false;
        public bool pb2clikd = false;
        public bool pb3clikd = false;
        public bool pb4clikd = false;
        private bool pb6clikd = false;
        private bool pb7clikd = false;
        private bool pb8clikd = false;

        private void straus_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = new Bitmap(Properties.Resources.straus_emu_11);
            pb1clikd = true;
            pb2clikd = false;
            pb3clikd = false;
            pb4clikd = false;
            float x = 60; // скорость
            float d1 = 42; // дистанции
            float d2 = 21;
            float d3 = 5;
            if (pb1clikd == true & pb6clikd == true)
            {
                Info_label.Text = $"Страус при скорости {x} км/ч пробежит эту дистанцию за 42 минуты";
            }
            if (pb1clikd == true & pb7clikd == true)
            {
                Info_label.Text = $"Страус при скорости {x} км/ч пробежит эту дистанцию за 21 минуту";
            }
            if (pb1clikd == true & pb8clikd == true)
            {
                Info_label.Text = $"Страус при скорости {x} км/ч пробежит эту дистанцию за 5 минут";
            }
            Distance_but_Click(sender, e);
        }

        private void car_Click(object sender, EventArgs e)
        {

            pb1clikd = false;
            pb2clikd = true;
            pb3clikd = false;
            pb4clikd = false;
            pictureBox5.Image = new Bitmap(Properties.Resources.car_content);
            float x = 100;
            if (pb2clikd == true & pb6clikd == true)
            {
                Info_label.Text = $"Машина при скорости {x} км/ч пробежит эту дистанцию за 25 минут";
            }
            if (pb2clikd == true & pb7clikd == true)
            {
                Info_label.Text = $"Машина при скорости {x} км/ч пробежит эту дистанцию за 12 минут";
            }
            if (pb2clikd == true & pb8clikd == true)
            {
                Info_label.Text = $"Машина при скорости {x} км/ч пробежит эту дистанцию за 3 минуты";
            }
            Distance_but_Click(sender, e);

        }

        private void yaguar_Click(object sender, EventArgs e)
        {

            pb1clikd = false;
            pb2clikd = false;
            pb3clikd = true;
            pb4clikd = false;
            pictureBox5.Image = new Bitmap(Properties.Resources.Leo);
            float x = 80;
            if (pb3clikd == true & pb6clikd == true)
            {
                Info_label.Text = $"Ягуар  при скорости {x} км/ч пробежит эту дистанцию за 31 минуту";
            }
            if (pb3clikd == true & pb7clikd == true)
            {
                Info_label.Text = $"Ягуар при скорости {x} км/ч пробежит эту дистанцию за 15 минут";
            }
            if (pb3clikd == true & pb8clikd == true)
            {
                Info_label.Text = $"Ягуар при скорости {x} км/ч пробежит эту дистанцию за 4 минуты";
            }
            Distance_but_Click(sender, e);
        }

        private void ulitka_Click(object sender, EventArgs e)
        {

            pb1clikd = false;
            pb2clikd = false;
            pb3clikd = false;
            pb4clikd = true;
            pictureBox5.Image = new Bitmap(Properties.Resources.ulitka);
            double x = 0.048;
            if (pb4clikd == true & pb6clikd == true)
            {
                Info_label.Text = $"Улитка при скорости {x} км/ч пробежит эту дистанцию за 36 дней";
            }
            if (pb4clikd == true & pb7clikd == true)
            {
                Info_label.Text = $"Улитка при скорости {x} км/ч пробежит эту дистанцию за 18 дней ";
            }
            if (pb4clikd == true & pb8clikd == true)
            {
                Info_label.Text = $"Улитка при скорости {x} км/ч пробежит эту дистанцию за 4 дня";
            }
            Distance_but_Click(sender, e);
        }

        private void pB1_Click(object sender, EventArgs e)
        {
            if (image1_label.Text == "Трасса 42км")
            {
                Speed_but_Click(sender, e);
                pictureBox6_Click(sender, e); 
            }
            else
                straus_Click(sender, e);

        }

        private void pB2_Click(object sender, EventArgs e)
        {
            if (image2_label.Text == "Трасса 21км")
            {
                Speed_but_Click(sender, e);
                pictureBox7_Click(sender, e);
            }
            else
                car_Click(sender, e);

        }

        private void pB3_Click(object sender, EventArgs e)
        {
            if (image3_label.Text == "Трасса 5км")
            {
                Speed_but_Click(sender, e);
                pictureBox8_Click(sender, e);
            }
            else
                yaguar_Click(sender, e);

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            pb6clikd = true;
            pb7clikd = false;
            pb8clikd = false;
            Speed_but_Click(sender, e);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            pb6clikd = false;
            pb7clikd = true;
            pb8clikd = false;
            Speed_but_Click(sender, e);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

            pb6clikd = false;
            pb7clikd = false;
            pb8clikd = true;
            Speed_but_Click(sender, e);
        }

        Drawer drw = new Drawer();

        private void Back_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main,this);

        }

        private void Speed_but_Click(object sender, EventArgs e)
        {
            image1_pb.Image = Properties.Resources.straus_emu_11; image1_label.Text = "Страус Эму";
            image2_pb.Image = Properties.Resources.car_content; image2_label.Text = "Автомобиль";
            image3_pb.Image = Properties.Resources.Leo; image3_label.Text = "Ягуар";
            image4_pb.Visible = true; image4_label.Visible = true;

            Speed_but.BackgroundColor = SystemColors.Control;
            Speed_but.Height = 36;
            Distance_but.BackgroundColor = SystemColors.ControlLight;
            Distance_but.Height = 32;
        }

        private void Distance_but_Click(object sender, EventArgs e)
        {
            image1_pb.Image = Properties.Resources.Map; image1_label.Text = "Трасса 42км";
            image2_pb.Image = Properties.Resources.Map; image2_label.Text = "Трасса 21км";
            image3_pb.Image = Properties.Resources.Map; image3_label.Text = "Трасса 5км";
            image4_pb.Visible = false; image4_label.Visible = false;

            Distance_but.BackgroundColor = SystemColors.Control;
            Distance_but.Height = 36;
            Speed_but.BackgroundColor = SystemColors.ControlLight;
            Speed_but.Height = 32;
        }
    }
}

