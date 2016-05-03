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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("C:\\Users\\" + System.Environment.UserName + "\\Documents\\Sudoku\\High_Scores.txt"))
            {
                System.IO.Directory.CreateDirectory("C:\\Users\\" + System.Environment.UserName + "\\Documents\\Sudoku");
                System.IO.File.WriteAllText(@"C:\\Users\\" + System.Environment.UserName + "\\Documents\\Sudoku\\High_Scores.txt", "Easy: 00:00 \nMedium: 00:00 \nHard: 00:00");
            }
            if (!File.Exists("C:\\Users\\" + System.Environment.UserName + "\\Documents\\Sudoku\\High_Scores.txt"))
            {
                System.IO.File.WriteAllText(@"C:\\Users\\" + System.Environment.UserName + "\\Documents\\Sudoku\\High_Scores.txt", "Easy: 00:00 \nMedium: 00:00 \nHard: 00:00");
            }
        }
    }
}
