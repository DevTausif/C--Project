using FreshDairyFarm.CustomerControls;
using FreshDairyFarm.ManagerControls;
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
    public partial class ManagerHome : Form
    {
        private string loggedInUsername;
        public ManagerHome(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
        }

        private void ManagerHomeForm_FormClosing(object sender, FormClosingEventArgs e)
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

          
            var uc = new ManagerControls.ManagerHome(loggedInUsername) { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnProducts.Height;
            pnlNav.Top = btnProducts.Top;
            pnlNav.Left = btnProducts.Left;

            
            ClearPanelContainer();

           
            var uc = new ManagerProduct(panelContainer) { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
        }

        private void ManagerHomeForm_Load(object sender, EventArgs e)
        {
            pnlNav.Height = btnHome.Height;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;

           
            ClearPanelContainer();

            
            var uc = new ManagerControls.ManagerHome(loggedInUsername) { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }
    }
}
