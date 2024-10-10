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
    public partial class Organization_Info : Form
    {
        public Organization_Info()
        {
            InitializeComponent();
        }
        string organizationName;

        public void SetStringValue(string value)
        {
            organizationName = value;
        }

        SqlConnection connect = new SqlConnection(Drawer.connectionString);

        private void Organization_Info_Load(object sender, EventArgs e)
        {
            Organization_Name_label.Text = organizationName;
            
            using (connect)
            {
                string query = "SELECT Описание, Лого FROM Фонды WHERE Название = '"+organizationName+"'";

                using (SqlCommand command = new SqlCommand(query, connect))
                {

                    connect.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Organization_Info_textBox.Text = reader["Описание"].ToString().Trim();
                        pictureBox1.ImageLocation = reader["Лого"].ToString().Trim();
                    }
                    reader.Close();
                    connect.Close();
                }
            }
        }
    }
}
