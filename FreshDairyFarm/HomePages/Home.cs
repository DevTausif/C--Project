using FreshDairyFarm.Shared;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void hotLineBtn_Click(object sender, EventArgs e)
        {
            Hotline hotline = new Hotline();
            hotline.Show();
            this.Hide();
        }

        private void aboutUsBtn_Click_1(object sender, EventArgs e)
        {
            AboutUsForm aboutUsForm = new AboutUsForm();
            aboutUsForm.Show();
            this.Hide();
        }
    }
}
