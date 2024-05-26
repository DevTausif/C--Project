using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshDairyFarm.CustomerControls
{
    public partial class CustomerCategory : UserControl
    {
        private Panel panelContainer;
        private int userId;
        public CustomerCategory(Panel panelContainer, int userId)
        {
            InitializeComponent();
            this.panelContainer = panelContainer;
            this.userId = userId;
        }

        private void cowBtn_Click(object sender, EventArgs e)
        {
            var uc = new CustomerCategoryCow(userId) { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void goatBtn_Click(object sender, EventArgs e)
        {
            var uc = new CustomerCategoryGoat(userId) { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void milkBtn_Click(object sender, EventArgs e)
        {
            var uc = new CustomerCategoryMilk(userId) { Dock = DockStyle.Fill };
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
