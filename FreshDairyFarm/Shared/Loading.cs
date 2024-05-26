using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreshDairyFarm.Shared
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Width += 3;
            loadingPer.Text = (progressBar.Width * 100 / 800).ToString() + "%";

            if (progressBar.Width >= 800)
            {
                loadingTimer.Stop();
                Home home = new Home();
                home.Show();
                this.Hide();
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            loadingTimer.Start();
        }
    }
}
