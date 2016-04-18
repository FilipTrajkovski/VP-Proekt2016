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
        public Main_Form()
        {
            InitializeComponent();
        }
        public void GenerateLevel(string diff) {
            int minPos, maxPos, noOfSets;

            // Now unmask positions and create problem set.
            switch (diff)
            {

                case "Easy":
                    minPos = 4;
                    maxPos = 6;
                    noOfSets = 8;
                    //UnMask(minPos, maxPos, noOfSets);
                    break;
                case "Medium":
                    minPos = 3;
                    maxPos = 5;
                    noOfSets = 7;
                    //UnMask(minPos, maxPos, noOfSets);
                    break;
                case "Hard":
                    minPos = 3;
                    maxPos = 5;
                    noOfSets = 6;
                    //UnMask(minPos, maxPos, noOfSets);
                    break;
                default:
                    //UnMask(3, 6, 7);
                    
                    break;
            }
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
                GenerateLevel(level);
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
