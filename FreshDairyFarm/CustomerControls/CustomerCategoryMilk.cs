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

namespace FreshDairyFarm.CustomerControls
{
    public partial class CustomerCategoryMilk : UserControl
    {
        string connectionString = @"Data Source=LAPTOP-4IGS1BDP\SQLEXPRESS;Initial Catalog=FreshDairyFarm;Integrated Security=True";
        private int userId; 
        public CustomerCategoryMilk(int userId)
        {
            InitializeComponent();
            BindGridView();
            this.userId = userId;
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
            textBoxType.Clear();
            textBoxPrice.Clear();
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxId.Text = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBoxLitre.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBoxType.Text = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBoxPrice.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void cartBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxId.Text))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO MilkCart (UserId, Id, Litre, Type, Price) " +
                                   "VALUES (@UserId, @Id, @Litre, @Type, @Price)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", textBoxId.Text);
                        cmd.Parameters.AddWithValue("@Litre", textBoxLitre.Text);
                        cmd.Parameters.AddWithValue("@Type", textBoxType.Text);
                        cmd.Parameters.AddWithValue("@Price", textBoxPrice.Text);
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        connection.Open();

                        
                        string checkQuery = "SELECT COUNT(*) FROM MilkCart WHERE UserId = @UserId AND Id = @Id";
                        SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                        checkCmd.Parameters.AddWithValue("@UserId", userId);
                        checkCmd.Parameters.AddWithValue("@Id", textBoxId.Text);
                        int existingCount = (int)checkCmd.ExecuteScalar();

                        if (existingCount > 0)
                        {
                            MessageBox.Show("This milk is already in the cart.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Milk added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindGridView();
                                ResetControl();
                            }
                            else
                            {
                                MessageBox.Show("Could not add!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
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
