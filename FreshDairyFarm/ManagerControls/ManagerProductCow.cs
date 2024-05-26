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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FreshDairyFarm.ManagerControls
{
    public partial class ManagerProductCow : UserControl
    {
        string connectionString = @"Data Source=LAPTOP-4IGS1BDP\SQLEXPRESS;Initial Catalog=FreshDairyFarm;Integrated Security=True";
        public ManagerProductCow()
        {
            InitializeComponent();
            BindGridView();
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            showImage.Image.Save(ms, showImage.Image.RawFormat);
            return ms.GetBuffer();
        }
        void BindGridView()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Cow";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);

            DataTable data = new DataTable();
            sqlDataAdapter.Fill(data);
            dataGridView.DataSource = data;

            DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn();
            dataGridViewImageColumn = (DataGridViewImageColumn)dataGridView.Columns[6];
            dataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void ResetControl()
        {
            textBoxId.Clear();
            textBoxColor.Clear();
            textBoxWeight.Clear();
            textBoxType.Clear();
            textBoxPrice.Clear();
            numericUpDownAge.Value = 0;
            showImage.Image = Properties.Resources.no_image_avaiable;
        }
        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxId.Text = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBoxColor.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBoxWeight.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            numericUpDownAge.Value = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[3].Value);
            textBoxType.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBoxPrice.Text = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
            showImage.Image = GetPhoto((byte[])dataGridView.SelectedRows[0].Cells[6].Value);
        }
        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Image";
            
            openFileDialog.Filter = "ALL IMAGE FILE (*.*) | *.*";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                showImage.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Cow (Id, Color, Weight, Age, Type, Price, Picture) " +
                               "VALUES (@Id, @Color, @Weight, @Age, @Type, @Price, @Pic)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", textBoxId.Text);
                    cmd.Parameters.AddWithValue("@Color", textBoxColor.Text);
                    cmd.Parameters.AddWithValue("@Age", numericUpDownAge.Value);
                    cmd.Parameters.AddWithValue("@Weight", textBoxWeight.Text);
                    cmd.Parameters.AddWithValue("@Type", textBoxType.Text);
                    cmd.Parameters.AddWithValue("@Price", textBoxPrice.Text);
                    cmd.Parameters.AddWithValue("@Pic", SavePhoto());

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
                string query = "UPDATE Cow SET Color=@Color, Weight=@Weight, Age=@Age, Type=@Type, Price=@Price, Picture=@Pic WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Color", textBoxColor.Text);
                    cmd.Parameters.AddWithValue("@Age", numericUpDownAge.Value);
                    cmd.Parameters.AddWithValue("@Weight", textBoxWeight.Text);
                    cmd.Parameters.AddWithValue("@Type", textBoxType.Text);
                    cmd.Parameters.AddWithValue("@Price", textBoxPrice.Text);
                    cmd.Parameters.AddWithValue("@Pic", SavePhoto());
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
                string query = "DELETE FROM Cow WHERE Id=@Id";
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
