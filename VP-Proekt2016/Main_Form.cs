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
    public partial class Main_Form : Form
    {
        private Sudoku test = new Sudoku();

        private Label[][] grid = new Label[9][];
        private Label[] grid_Select = new Label[9];

        private Timer timer=new Timer();
        private int duration_sec = 0;
        private int duration_min = 0;
        private int duration_hrs = 0;

        private bool flag;

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
                timer.Start();
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
                            grid[i][j].Font = new Font(grid[i][j].Font, FontStyle.Bold);
                        }
                        grid[i][j].Enabled = true;
                    }
                    grid_Select[i].Enabled = true;
                }
                cbDif.Enabled = false;
                btnPlay.Enabled = false;
                btnStop.Enabled = true;
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            Label[] grid_Select_temp = { Click_1, Click_2, Click_3, Click_4, Click_5, Click_6, Click_7, Click_8, Click_9 };
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
            grid_Select = grid_Select_temp;

            timer.Tick += new EventHandler(tVreme_Tick);
            timer.Interval = 1000;

            flag = false;
        }
        private void Resetiraj()
        {
            lbl_timer.Text = "";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i][j].Enabled = false;
                    grid[i][j].Text = "";
                    grid[i][j].Font = new Font(grid[i][j].Font, FontStyle.Regular);
                }
                grid_Select[i].Enabled = false;
            }
            cbDif.Enabled = true;
            btnPlay.Enabled = true;
            btnStop.Enabled = false;
            duration_hrs = 0;
            duration_min = 0;
            duration_sec = 0;
        }
        private void tVreme_Tick(object sender, EventArgs e)
        {
            duration_sec++;
            if (duration_sec > 59)
            {
                duration_min++;
                duration_sec = 0;
            }
            if (duration_min > 59)
            {
                duration_hrs++;
                duration_min = 0;
                flag = true;
            }
            if (flag)
            {
                lbl_timer.Text = string.Format("Timer:\n {0:00}:{1:00}:{2:00}", duration_hrs, duration_min, duration_sec);
            }
            else
            {
                lbl_timer.Text = string.Format("Timer:\n {0:00}:{1:00}", duration_min, duration_sec);
            }
            bool flag_tmp = false;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int tekoven = 0;
                    Int32.TryParse(grid[i][j].Text, out tekoven);
                    if (tekoven != test.resenie[i][j])
                    {
                        flag_tmp = true;
                        break;
                    }
                }
                if (flag_tmp)
                {
                    break;
                }
            }
            if (!flag_tmp)
            {
                timer.Stop();
                MessageBox.Show("Congratulations", "Congratulations,you completed the puzzle", MessageBoxButtons.OK);
                string tekst = File.ReadAllText("C:\\Users\\" + System.Environment.UserName + "\\Documents\\Sudoku\\High_Scores.txt");
                string[] del = tekst.Split(' ');
                string[] vreme = lbl_timer.Text.Split(' ');
                string[] vreme_prov = null;
                string[] vreme_prov_mom = vreme[1].Split(':');
                if (cbDif.SelectedItem.ToString() == "Easy")
                {
                    vreme_prov = del[1].Split(':');
                    if (Int32.Parse(vreme_prov[0]) > Int32.Parse(vreme_prov_mom[0]))
                    {
                        del[1] = vreme[1];
                    }
                    else if (Int32.Parse(vreme_prov[0]) == Int32.Parse(vreme_prov_mom[0]))
                    {
                        if (Int32.Parse(vreme_prov[1]) > Int32.Parse(vreme_prov_mom[1]))
                        {
                            del[1] = vreme[1];
                        }
                    }
                }
                else if (cbDif.SelectedItem.ToString() == "Medium")
                {
                    vreme_prov = del[3].Split(':');
                    if (Int32.Parse(vreme_prov[0]) > Int32.Parse(vreme_prov_mom[0]))
                    {
                        del[3] = vreme[1];
                    }
                    else if (Int32.Parse(vreme_prov[0]) == Int32.Parse(vreme_prov_mom[0]))
                    {
                        if (Int32.Parse(vreme_prov[1]) > Int32.Parse(vreme_prov_mom[1]))
                        {
                            del[3] = vreme[1];
                        }
                    }
                }
                else
                {
                    vreme_prov = del[5].Split(':');
                    if (Int32.Parse(vreme_prov[0]) > Int32.Parse(vreme_prov_mom[0]))
                    {
                        del[5] = vreme[1];
                    }
                    else if (Int32.Parse(vreme_prov[0]) == Int32.Parse(vreme_prov_mom[0]))
                    {
                        if (Int32.Parse(vreme_prov[1]) > Int32.Parse(vreme_prov_mom[1]))
                        {
                            del[5] = vreme[1];
                        }
                    }
                }
                tekst = "";
                for (int i = 0; i < del.Length; i++)
                {
                    tekst += del[i] + " ";
                }
                File.WriteAllText("C:\\Users\\" + System.Environment.UserName + "\\Documents\\Sudoku\\High_Scores.txt", tekst);
                Resetiraj();
            }
        }
        private void smeniSelektiran(Label tekoven)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i][j].BackColor == System.Drawing.Color.LightPink)
                    {
                        grid[i][j].BackColor = System.Drawing.Color.White;
                    }
                    
                }
            }
            if (!tekoven.Font.Bold)
            {
                tekoven.BackColor = System.Drawing.Color.LightPink;
            }
        }
        private void vnesiBroj(Label selektiran)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i][j].BackColor == System.Drawing.Color.LightPink)
                    {
                        grid[i][j].Text = selektiran.Text;
                    }

                }
            }
        }
        private void Matrix_1_1_Click(object sender, EventArgs e)
        {
            Label temp = (Label)sender;
            smeniSelektiran(temp);
        }

        private void Click_9_Click(object sender, EventArgs e)
        {
            Label temp = (Label)sender;
            vnesiBroj(temp);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Do you really wish to stop the game?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                timer.Stop();
                Resetiraj();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void Matrix_9_9_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
