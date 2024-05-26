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

namespace FreshDairyFarm.ManagerControls
{
    public partial class ManagerProduct : UserControl
    {
        private Panel panelContainer;
        public ManagerProduct(Panel panelContainer)
        {
            InitializeComponent();
            this.panelContainer = panelContainer;
        }

        private void cowBtnManager_Click(object sender, EventArgs e)
        {
            var uc = new ManagerProductCow() { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void goatBtnManager_Click(object sender, EventArgs e)
        {
            var uc = new ManagerProductGoat() { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void milkBtnManager_Click(object sender, EventArgs e)
        {
            var uc = new ManagerProductMilk() { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
