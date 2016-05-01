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
        Label[][] grid = new Label[9][];
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
                test.GenerirajSet(level);
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (test.tekovnoResavanje[i][j] != 0)
                        {
                            grid[i][j].Text = test.tekovnoResavanje[i][j].ToString();
                        }
                    }
                }
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            Label[] temp1 = { Matrix_1_1, Matrix_1_2, Matrix_1_3, Matrix_1_4, Matrix_1_5, Matrix_1_6, Matrix_1_7, Matrix_1_8, Matrix_1_9 };
            Label[] temp2 = { Matrix_2_1, Matrix_2_2, Matrix_2_3, Matrix_2_4, Matrix_2_5, Matrix_2_6, Matrix_2_7, Matrix_2_8, Matrix_2_9 };
            Label[] temp3 = { Matrix_3_1, Matrix_3_2, Matrix_3_3, Matrix_3_4, Matrix_3_5, Matrix_3_6, Matrix_3_7, Matrix_3_8, Matrix_3_9 };
            Label[] temp4 = { Matrix_4_1, Matrix_4_2, Matrix_4_3, Matrix_4_4, Matrix_4_5, Matrix_4_6, Matrix_4_7, Matrix_4_8, Matrix_4_9 };
            Label[] temp5 = { Matrix_5_1, Matrix_5_2, Matrix_5_3, Matrix_5_4, Matrix_5_5, Matrix_5_6, Matrix_5_7, Matrix_5_8, Matrix_5_9 };
            Label[] temp6 = { Matrix_6_1, Matrix_6_2, Matrix_6_3, Matrix_6_4, Matrix_6_5, Matrix_6_6, Matrix_6_7, Matrix_6_8, Matrix_6_9 };
            Label[] temp7 = { Matrix_7_1, Matrix_7_2, Matrix_7_3, Matrix_7_4, Matrix_7_5, Matrix_7_6, Matrix_7_7, Matrix_7_8, Matrix_7_9 };
            Label[] temp8 = { Matrix_8_1, Matrix_8_2, Matrix_8_3, Matrix_8_4, Matrix_8_5, Matrix_8_6, Matrix_8_7, Matrix_8_8, Matrix_8_9 };
            Label[] temp9 = { Matrix_9_1, Matrix_9_2, Matrix_9_3, Matrix_9_4, Matrix_9_5, Matrix_9_6, Matrix_9_7, Matrix_9_8, Matrix_9_9 };

            grid[0] = temp1;
            grid[1] = temp2;
            grid[2] = temp3;
            grid[3] = temp4;
            grid[4] = temp5;
            grid[5] = temp6;
            grid[6] = temp7;
            grid[7] = temp8;
            grid[8] = temp9;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void label75_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }
    }
}
