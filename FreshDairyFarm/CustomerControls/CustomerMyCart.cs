using System;
using System.Collections;
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
    public partial class CustomerMyCart : UserControl
    {
        string connectionString = @"Data Source=LAPTOP-4IGS1BDP\SQLEXPRESS;Initial Catalog=FreshDairyFarm;Integrated Security=True";
        public int userId;
        public CustomerMyCart(int userId)
        {
            InitializeComponent();
            BindGridView(userId);
            this.userId = userId;
        }
        void BindGridView(int userId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                string cowQuery = "SELECT Id, NULL as Litre, Color, Weight, Age, Type, Price FROM CowCart WHERE UserId = @userIdCow";
                string goatQuery = "SELECT Id, NULL as Litre, Color, Weight, Age, NULL AS Type, Price FROM GoatCart WHERE UserId = @userIdGoat";
                string milkQuery = "SELECT Id, Litre, NULL as Color, NULL as Weight, NULL as Age, Type, Price FROM MilkCart WHERE UserId = @userIdMilk";

                SqlDataAdapter cowDataAdapter = new SqlDataAdapter(cowQuery, connection);
                SqlDataAdapter goatDataAdapter = new SqlDataAdapter(goatQuery, connection);
                SqlDataAdapter milkDataAdapter = new SqlDataAdapter(milkQuery, connection);

                cowDataAdapter.SelectCommand.Parameters.AddWithValue("@userIdCow", userId);
                goatDataAdapter.SelectCommand.Parameters.AddWithValue("@userIdGoat", userId);
                milkDataAdapter.SelectCommand.Parameters.AddWithValue("@userIdMilk", userId);

                DataTable cowData = new DataTable();
                cowDataAdapter.Fill(cowData);

                DataTable goatData = new DataTable();
                goatDataAdapter.Fill(goatData);

                DataTable milkData = new DataTable();
                milkDataAdapter.Fill(milkData);

                
                DataTable combinedData = new DataTable();
                combinedData.Columns.Add("Id");
                combinedData.Columns.Add("Litre");
                combinedData.Columns.Add("Color");
                combinedData.Columns.Add("Weight");
                combinedData.Columns.Add("Age");
                combinedData.Columns.Add("Type");
                combinedData.Columns.Add("Price");
                combinedData.Columns.Add("Product");

                foreach (DataRow row in cowData.Rows)
                {
                    combinedData.Rows.Add(row.ItemArray).SetField("Product", "Cow");
                }
                foreach (DataRow row in goatData.Rows)
                {
                    combinedData.Rows.Add(row.ItemArray).SetField("Product", "Goat");
                }
                foreach (DataRow row in milkData.Rows)
                {
                    combinedData.Rows.Add(row.ItemArray).SetField("Product", "Milk");
                }

                dataGridView.DataSource = combinedData;

               
                dataGridView.Columns["Id"].Width = 30;
                dataGridView.Columns["Litre"].Width = 40;
                dataGridView.Columns["Color"].Width = 50;
                dataGridView.Columns["Weight"].Width = 60;
                dataGridView.Columns["Age"].Width = 30;
                dataGridView.Columns["Type"].Width = 50;
                dataGridView.Columns["Price"].Width = 65;
                dataGridView.Columns["Product"].Width = 50;

                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ResetControl()
        {
            textBoxId.Clear();
            textBoxLitre.Clear();
            textBoxColor.Clear();
            textBoxWeight.Clear();
            textBoxAge.Clear();
            textBoxType.Clear();
            textBoxPrice.Clear();
        }
        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count)
            {
                textBoxId.Text = dataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                textBoxLitre.Text = dataGridView.Rows[e.RowIndex].Cells["Litre"].Value.ToString();
                textBoxColor.Text = dataGridView.Rows[e.RowIndex].Cells["Color"].Value.ToString();
                textBoxWeight.Text = dataGridView.Rows[e.RowIndex].Cells["Weight"].Value.ToString();
                textBoxAge.Text = dataGridView.Rows[e.RowIndex].Cells["Age"].Value.ToString();

                if (dataGridView.Rows[e.RowIndex].Cells["Type"].Value != DBNull.Value)
                {
                    textBoxType.Text = dataGridView.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                }
                else
                {
                    textBoxType.Text = "";
                }

                textBoxPrice.Text = dataGridView.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxId.Text))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string tableName = "CowCart";

                    if (dataGridView.SelectedRows[0].Cells["Product"].Value.ToString() == "Goat")
                    {
                        tableName = "GoatCart";
                    }
                    else if (dataGridView.SelectedRows[0].Cells["Product"].Value.ToString() == "Milk")
                    {
                        tableName = "MilkCart";
                    }

                    string query = $"DELETE FROM {tableName} WHERE Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", textBoxId.Text);

                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            string productName = dataGridView.SelectedRows[0].Cells["Product"].Value.ToString();
                            MessageBox.Show($"{productName} removed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindGridView(userId);
                            ResetControl();
                        }
                        else
                        {
                            string productName = dataGridView.SelectedRows[0].Cells["Product"].Value.ToString();
                            MessageBox.Show($"{productName} Not Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private void buttonBuy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxId.Text))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string productType = dataGridView.SelectedRows[0].Cells["Product"].Value.ToString();
                        
                        string insertQuery = "INSERT INTO Transactions (UserId, ProductId, ProductType, Litre, Color, Weight, Age, Price) " +
                                            "VALUES (@UserId, @ProductId, @ProductType, @Litre, @Color, @Weight, @Age, @Price)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.Parameters.AddWithValue("@ProductId", textBoxId.Text);
                            cmd.Parameters.AddWithValue("@ProductType", productType);
                            cmd.Parameters.AddWithValue("@Litre", textBoxLitre.Text);
                            cmd.Parameters.AddWithValue("@Color", textBoxColor.Text);
                            cmd.Parameters.AddWithValue("@Weight", textBoxWeight.Text);
                            cmd.Parameters.AddWithValue("@Age", textBoxAge.Text);
                            cmd.Parameters.AddWithValue("@Price", textBoxPrice.Text);

                            cmd.ExecuteNonQuery();
                        }

                        string tableName = $"{productType}Cart";
                        string deleteQuery = $"DELETE FROM {tableName} WHERE Id=@Id";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id", textBoxId.Text);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Purchase completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGridView(userId);
                        ResetControl();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
