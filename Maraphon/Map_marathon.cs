using System;
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


namespace Maraphon
{
    public partial class Map_marathon : Form
    {
        public Map_marathon()
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

        bool CP_panel=false;
        Drawer drw = new Drawer();

        SqlConnection connect = new SqlConnection(Drawer.connectionString);

        private void Map_marathon_Load(object sender, EventArgs e)
        {
            Date = Drawer.Import_Date();
            Drawer.remaining_Time(Date, Timer_label);
            Auth_Label.Text = "Информация о Marathon Skills 2024";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CheckPointPanel.Visible = true;
            Info_panel.Visible = false;
            CP_panel = true;
            CheckPointInfo_panel.Visible = false;
        }

        private void CP1_but_Click(object sender, EventArgs e)
        {
            CheckPoints2(1);
            
        }

        //private void CheckPoints(int CheckPointID)
        //{
        //    SqlConnection connect = new SqlConnection(Drawer.connectionString);
        //    DataSet ds = new DataSet();
        //    string sql = "SELECT [Особенность] FROM [Контрольные точки] WHERE [№] = '"+ CheckPointID + "'";
        //    ds.Tables.Clear();
        //    SqlDataAdapter adapter = new SqlDataAdapter(sql, connect);
        //    adapter.Fill(ds);
        //    dataGridView1.DataSource = ds.Tables[0].DefaultView;
        //    adapter.Dispose();
        //}

        private void CheckPoints2(int CheckPointID)
        {
            Id_Check_label.Text = "Checkpoint " + CheckPointID;
            CheckPointInfo_panel.Visible = true;
        }

        private void CP2_but_Click(object sender, EventArgs e)
        {
            CheckPoints2(2);
        }

        private void CP3_but_Click(object sender, EventArgs e)
        {
            CheckPoints2(3);
        }

        private void CP4_but_Click(object sender, EventArgs e)
        {
            CheckPoints2(4);
        }

        private void CP5_but_Click(object sender, EventArgs e)
        {
            CheckPoints2(5);
        }

        private void CP6_but_Click(object sender, EventArgs e)
        {
            CheckPoints2(6);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (CP_panel)
            {
                CP_panel = false;
                CheckPointPanel.Visible = false;
                Info_panel.Visible = true;
            }
            else
            {
                Main main = new Main();
                drw.FormSwitch(main, this);

            }
        }

        private void drawer1_Click(object sender, EventArgs e)
        {
            CheckPointInfo_panel.Visible = false;
        }


    }
}
