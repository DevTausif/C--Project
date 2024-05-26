using FreshDairyFarm.CustomerControls;
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
    public partial class CustomerHome : Form
    {
        private string loggedInUsername;
        private int userId;
        public CustomerHome(string username, int userId)
        {
            InitializeComponent();
            loggedInUsername = username;
            this.userId = userId;
        }
        public CustomerHome()
        {
            InitializeComponent();
        }

        private void CustomerHomeForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnHome.Height;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;

            ClearPanelContainer();

            var uc = new CustomerControls.CustomerHome(loggedInUsername) { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCategory.Height;
            pnlNav.Top = btnCategory.Top;
            pnlNav.Left = btnCategory.Left;

           
            ClearPanelContainer();

            
            var uc = new CustomerCategory(panelContainer, userId) { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCart.Height;
            pnlNav.Top = btnCart.Top;
            pnlNav.Left = btnCart.Left;

            
            ClearPanelContainer();

            
            var uc = new CustomerMyCart(userId) { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
        }

        private void CustomerHomeForm_Load(object sender, EventArgs e)
        {
            pnlNav.Height = btnHome.Height;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;

           
            ClearPanelContainer();

            
            var uc = new CustomerControls.CustomerHome(loggedInUsername) { Dock = DockStyle.Fill };
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
