using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maraphon
{
    public partial class coordinator_Menu : Form
    {
        public coordinator_Menu()
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

        private void coordinator_Menu_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Logout_Click(sender, e);
        }

        private void runners_But_Click(object sender, EventArgs e)
        {
            Runner_Management form = new Runner_Management();
            drw.FormSwitch(form, this);
        }

        private void sponsList_but_Click(object sender, EventArgs e)
        {
            Sponsorship_overview sponsorship = new Sponsorship_overview();
            drw.FormSwitch(sponsorship, this);
        }
    }
}
