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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FreshDairyFarm.AdminControls
{
    public partial class AdminList : UserControl
    {
        string connectionString = @"Data Source=LAPTOP-4IGS1BDP\SQLEXPRESS;Initial Catalog=FreshDairyFarm;Integrated Security=True";
        private int userId;
        public AdminList(int userId)
        {
            InitializeComponent();
            BindGridView();
            this.userId = userId;
        }
        void BindGridView()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Username, Email, PhoneNumber FROM Registration WHERE Role = 'Admin'";
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

        private void btnMakeManager_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please select an admin from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to demote this admin to a manager?", "Confirm Promotion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string updateQuery = "UPDATE Registration SET Role = 'Manager' WHERE Username = @Username";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Username", textBoxName.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Admin demoted to Manager successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindGridView();
                                ResetControl();
                            }
                            else
                            {
                                MessageBox.Show("Failed to demote admin to Manager.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Please select an admin from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this admin?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "SELECT Id FROM Registration WHERE Email = @Email";
                        int selectedUserId = -1;

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                            object res = cmd.ExecuteScalar();

                            if (res != null && res != DBNull.Value)
                            {
                                selectedUserId = Convert.ToInt32(result);
                            }
                        }

                        if (userId == selectedUserId)
                        {
                            MessageBox.Show("You cannot delete your own account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string deleteQuery = "DELETE FROM Registration WHERE Username = @Username";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@Username", textBoxName.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Admin deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindGridView();
                                ResetControl();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
