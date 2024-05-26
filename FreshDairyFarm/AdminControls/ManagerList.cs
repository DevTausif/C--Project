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
    public partial class ManagerList : UserControl
    {
        string connectionString = @"Data Source=LAPTOP-4IGS1BDP\SQLEXPRESS;Initial Catalog=FreshDairyFarm;Integrated Security=True";
        public ManagerList()
        {
            InitializeComponent();
            BindGridView();
        }
        void BindGridView()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Username, Email, PhoneNumber FROM Registration WHERE Role = 'Manager'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);

            DataTable data = new DataTable();
            sqlDataAdapter.Fill(data);
            dataGridView.DataSource = data;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void ResetControl()
        {
            textBoxName.Clear();
            textBoxEmail.Clear();
            textBoxNumber.Clear();
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxName.Text = dataGridView.Rows[e.RowIndex].Cells["Username"].Value.ToString();
            textBoxEmail.Text = dataGridView.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            textBoxNumber.Text = dataGridView.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
        }

        private void btnMakeAdmin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please select a manager from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to promote this manager an admin?", "Confirm Promotion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string updateQuery = "UPDATE Registration SET Role = 'Admin' WHERE Username = @Username";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Username", textBoxName.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Manager promoted to Admin successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindGridView();
                                ResetControl();
                            }
                            else
                            {
                                MessageBox.Show("Failed to promote Manager to Admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please select a manager from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this manager?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM Registration WHERE Username = @Username";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Username", textBoxName.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Manager deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindGridView();
                                ResetControl();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete manager.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
