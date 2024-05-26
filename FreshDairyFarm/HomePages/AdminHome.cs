using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshDairyFarm
{
    public partial class AdminHome : Form
    {
        private string loggedInUsername;
        private int userId;
        public AdminHome(string username, int userId)
        {
            InitializeComponent();
            loggedInUsername = username;
            adminName.Text = loggedInUsername;
            this.userId = userId;
        }

        private void AdminHomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ClearPanelContainer()
        {
            foreach (Control control in panelContainer.Controls)
            {
                control.Dispose();
            }
            panelContainer.Controls.Clear();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            pnlNav.Height = btnAdmin.Height;
            pnlNav.Top = btnAdmin.Top;
            pnlNav.Left = btnAdmin.Left;

          
            ClearPanelContainer();

         
            var uc = new AdminControls.AdminList(userId) { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnAdmin.Height;
            pnlNav.Top = btnAdmin.Top;
            pnlNav.Left = btnAdmin.Left;

            
            ClearPanelContainer();

            var uc = new AdminControls.AdminList(userId) { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCustomer.Height;
            pnlNav.Top = btnCustomer.Top;
            pnlNav.Left = btnCustomer.Left;

            ClearPanelContainer();

            
            var uc = new AdminControls.CustomerList() { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnManager.Height;
            pnlNav.Top = btnManager.Top;
            pnlNav.Left = btnManager.Left;

            
            ClearPanelContainer();

            
            var uc = new AdminControls.ManagerList() { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnTransaction.Height;
            pnlNav.Top = btnTransaction.Top;
            pnlNav.Left = btnTransaction.Left;

           
            ClearPanelContainer();

            var uc = new AdminControls.Transaction() { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }
    }
}
