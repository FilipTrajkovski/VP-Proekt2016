using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Proekt2016
{
    public partial class High_Scores : Form
    {
        private Label[] list;
        public High_Scores()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Do you really want to reset the High Scores?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                File.Delete(@"C:\\Users\\" + System.Environment.UserName + "\\Documents\\Sudoku\\High_Scores.txt");
                System.IO.File.WriteAllText(@"C:\\Users\\" + System.Environment.UserName + "\\Documents\\Sudoku\\High_Scores.txt", "Easy: 00:00 \nMedium: 00:00 \nHard: 00:00");
                lblEasy.Text = "00:00";
                lblMedium.Text = "00:00";
                lblHard.Text = "00:00";
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void High_Scores_Load(object sender, EventArgs e)
        {
            Label[] list1= {lblEasy, lblMedium, lblHard};
            list = list1;
            string temp = "";
            string line;
            int counter = 0;
            System.IO.StreamReader file=null;
            try {
                file =
            new System.IO.StreamReader("C:\\Users\\" + System.Environment.UserName + "\\Documents\\Sudoku\\High_Scores.txt");
                while ((line = file.ReadLine()) != null)
                {
                    temp += line;
                    string[] tmp = line.Split(' ');
                    list[counter].Text = tmp[1];
                    counter++;
                }
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }

    }
}