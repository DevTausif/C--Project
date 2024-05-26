using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshDairyFarm.ManagerControls
{
    public partial class ManagerProductMilk : UserControl
    {
        string connectionString = @"Data Source=LAPTOP-4IGS1BDP\SQLEXPRESS;Initial Catalog=FreshDairyFarm;Integrated Security=True";
        public ManagerProductMilk()
        {
            InitializeComponent();
            BindGridView();
        }
        void BindGridView()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Milk";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);

            DataTable data = new DataTable();
            sqlDataAdapter.Fill(data);
            dataGridView.DataSource = data;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void ResetControl()
        {
            textBoxId.Clear();
            textBoxLitre.Clear();
            textBoxPrice.Clear();
        }
        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxId.Text = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBoxLitre.Text = dataGridView.Rows[0].Cells[1].Value.ToString();
            textBoxPrice.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            comboBoxType.Text = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Milk (Id, Litre, Price, Type) " +
                               "VALUES (@Id, @Litre, @Price, @Type)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", textBoxId.Text);
                    cmd.Parameters.AddWithValue("@Litre", textBoxLitre.Text);
                    cmd.Parameters.AddWithValue("@Price", textBoxPrice.Text);
                    cmd.Parameters.AddWithValue("@Type", comboBoxType.Text);

                    connection.Open();
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Data Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGridView();
                        ResetControl();
                    }
                    else
                    {
                        MessageBox.Show("Data Not Inserted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Milk SET Litre=@Litre, Price=@Price, Type=@Type WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Litre", textBoxLitre.Text);
                    cmd.Parameters.AddWithValue("@Price", textBoxPrice.Text);
                    cmd.Parameters.AddWithValue("@Type", comboBoxType.Text);
                    cmd.Parameters.AddWithValue("@Id", textBoxId.Text);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGridView();
                        ResetControl();
                    }
                    else
                    {
                        MessageBox.Show("Data Not Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Milk WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", textBoxId.Text);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGridView();
                        ResetControl();
                    }
                    else
                    {
                        MessageBox.Show("Data Not Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
    }
}
