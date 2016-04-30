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
    public partial class Main_Form : Form
    {
        Sudoku test = new Sudoku();
        
        public Main_Form()
        {
            InitializeComponent();
        }
        
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (cbDif.SelectedItem == null)
            {
                lblSelect.Text = "Please select difficulty";
            }
            else
            {
                lblSelect.Text = "";
                string level = cbDif.SelectedItem.ToString();
                lblTest.Text=test.GenerirajSet();
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
