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
    public partial class Adm : Form
    {
        public Adm()
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
        private void Adm_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            drw.FormSwitch(main, this);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Back_Click(sender, e);
        }

        private void organiz_But_Click(object sender, EventArgs e)
        {
            Manage_charities form = new Manage_charities();
            drw.FormSwitch(form, this);
        }

        private void users_But_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            drw.FormSwitch(users, this);
        }

        private void invent_But_Click(object sender, EventArgs e)
        {
            MessageBox.Show("БУДЕТ ДОБАВЛЕНО В БУДУЩЕМ", "будет добавлено в будущем");
        }

        private void volunteers_But_Click(object sender, EventArgs e)
        {
            users_But_Click(sender, e);
        }
    }
}
