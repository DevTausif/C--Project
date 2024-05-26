using FreshDairyFarm.CustomerControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshDairyFarm.ManagerControls
{
    public partial class ManagerHome : UserControl
    {
        string connectionString = @"Data Source=LAPTOP-4IGS1BDP\SQLEXPRESS;Initial Catalog=FreshDairyFarm;Integrated Security=True";

        public ManagerHome(string loggedInUsername)
        {
            InitializeComponent();
            managerName.Text = loggedInUsername;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

               
                string queryCow = "SELECT COUNT(*) FROM Cow";
                SqlCommand sqlCmdCow = new SqlCommand(queryCow, sqlConnection);
                int cowCount = (int)sqlCmdCow.ExecuteScalar();
                labelCow.Text = cowCount.ToString();

                
                string queryGoat = "SELECT COUNT(*) FROM Goat";
                SqlCommand sqlCmdGoat = new SqlCommand(queryGoat, sqlConnection);
                int goatCount = (int)sqlCmdGoat.ExecuteScalar();
                labelGoat.Text = goatCount.ToString();

                
                string queryMilk = "SELECT COUNT(*) FROM Milk";
                SqlCommand sqlCmdMilk = new SqlCommand(queryMilk, sqlConnection);
                int milkCount = (int)sqlCmdMilk.ExecuteScalar();
                labelMilk.Text = milkCount.ToString();
            }
        }
    }
}
