using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Proekt2016
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpForm tmp = new HelpForm();
            tmp.Show();
        }

        private void btnHigh_Click(object sender, EventArgs e)
        {
            High_Scores tmp = new High_Scores();
            tmp.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Main_Form tmp = new Main_Form();
            tmp.Show();
            //this.Dispose();
        }
    }
}
