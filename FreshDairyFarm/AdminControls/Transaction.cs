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

namespace FreshDairyFarm.AdminControls
{
    public partial class Transaction : UserControl
    {
        string connectionString = @"Data Source=LAPTOP-4IGS1BDP\SQLEXPRESS;Initial Catalog=FreshDairyFarm;Integrated Security=True";
        public Transaction()
        {
            InitializeComponent();
            BindGridView();
        }
        void BindGridView()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Transactions";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);

            DataTable data = new DataTable();
            sqlDataAdapter.Fill(data);
            dataGridView.DataSource = data;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
