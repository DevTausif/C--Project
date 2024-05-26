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
    public partial class Registration : Form
    {
        string connectionString = @"Data Source=LAPTOP-4IGS1BDP\SQLEXPRESS;Initial Catalog=FreshDairyFarm;Integrated Security=True";

        public Registration()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Hide();
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        void clear()
        {
            registerName.Text = string.Empty;
            registerEmail.Text = string.Empty;
            registerPass.Text = string.Empty;
            registerConfirmPass.Text = string.Empty;
            registerPhone.Text = string.Empty;
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool status = showPassword.Checked;
            switch (status)
            {
                case true:
                    registerPass.UseSystemPasswordChar = false;
                    break;
                default:
                    registerPass.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void showConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool status = showConfirmPassword.Checked;
            switch (status)
            {
                case true:
                    registerConfirmPass.UseSystemPasswordChar = false;
                    break;
                default:
                    registerConfirmPass.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(registerName.Text) || string.IsNullOrWhiteSpace(registerEmail.Text) ||
                string.IsNullOrWhiteSpace(registerPass.Text) || string.IsNullOrWhiteSpace(registerConfirmPass.Text) ||
                string.IsNullOrWhiteSpace(registerPhone.Text))
            {
                MessageBox.Show("Please fill all mandatory fields.", "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (registerPass.Text != registerConfirmPass.Text)
            {
                MessageBox.Show("Password do not match! Please try again.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "SELECT COUNT(1) FROM Registration WHERE Email = @Email";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Email", registerEmail.Text); 
                    int emailCount = (int)sqlCmd.ExecuteScalar();

                    if (emailCount > 0)
                    {
                        MessageBox.Show("Email is already taken!", "Email Taken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        query = "INSERT INTO Registration (Username, Password, Email, PhoneNumber, Role) VALUES (@Username, @Password, @Email, @PhoneNumber, @Role)";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Username", registerName.Text); 
                        sqlCmd.Parameters.AddWithValue("@Password", registerPass.Text); 
                        sqlCmd.Parameters.AddWithValue("@Email", registerEmail.Text); 
                        sqlCmd.Parameters.AddWithValue("@PhoneNumber", registerPhone.Text); 
                        sqlCmd.Parameters.AddWithValue("@Role", selectRole.Text); 
                        sqlCmd.ExecuteNonQuery();

                        MessageBox.Show("Registration is successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                }
                new LogIn().Show();
                this.Hide();
            }
        }
    }
}
