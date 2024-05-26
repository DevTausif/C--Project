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

namespace FreshDairyFarm
{
    public partial class LogIn : Form
    {
        string connectionString = @"Data Source=LAPTOP-4IGS1BDP\SQLEXPRESS;Initial Catalog=FreshDairyFarm;Integrated Security=True";

        public LogIn()
        {
            InitializeComponent();
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool status = showPassword.Checked;
            switch (status)
            {
                case true:
                    userPassword.UseSystemPasswordChar = false;
                    break;
                default:
                    userPassword.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userMail.Text) || string.IsNullOrWhiteSpace(userPassword.Text))
            {
                MessageBox.Show("Please fill all the fields.", "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string usermail = userMail.Text;
                string password = userPassword.Text;

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "SELECT Id, Username, Role FROM Registration WHERE Email = @Email AND Password = @Password";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Email", usermail);
                    sqlCmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string username = reader.GetString(1);
                            string userRole = reader.GetString(2);
                            string selectedRole = selectRole.Text;

                            if (string.IsNullOrWhiteSpace(username))
                            {
                                MessageBox.Show("Email does not exist.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (userRole != selectedRole)
                            {
                                MessageBox.Show("User role does not match the selected role.", "Invalid Role", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if (userRole == "Manager")
                                {
                                    ManagerHome managerHome = new ManagerHome(username);
                                    managerHome.Show();
                                }
                                else if (userRole == "Customer")
                                {
                                    CustomerHome customerHome = new CustomerHome(username, userId); 
                                    customerHome.Show();
                                }
                                else if (userRole == "Admin")
                                {
                                    AdminHome adminHome = new AdminHome(username, userId);
                                    adminHome.Show();
                                }

                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
