using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Proekt2016
{
    class Sudoku
    {
        public static int RED_MAX = 9;
        public static int KOL_MAX = 9;
        int[][] resenie = new int[RED_MAX][];
        int[][] tekovnoResavanje = new int[RED_MAX][];
        bool redica = true;
        Random global;
        private int[][] DefaultSet = new int[RED_MAX][];
        public Sudoku()
        {
            int[] red1 = { 7, 9, 2, 3, 5, 1, 8, 4, 6 };
            int[] red2 = { 4, 6, 8, 9, 2, 7, 5, 1, 3 };
            int[] red3 = { 1, 3, 5, 6, 8, 4, 7, 9, 2 };
            int[] red4 = { 6, 2, 1, 5, 7, 9, 4, 3, 8 };
            int[] red5 = { 5, 8, 3, 2, 4, 6, 1, 7, 9 };
            int[] red6 = { 9, 7, 4, 8, 1, 3, 2, 6, 5 };
            int[] red7 = { 8, 1, 6, 4, 9, 2, 3, 5, 7 };
            int[] red8 = { 3, 5, 7, 1, 6, 8, 9, 2, 4 };
            int[] red9 = { 2, 4, 9, 7, 3, 5, 6, 8, 1 };
            for (int j = 0; j < tekovnoResavanje.Length; j++)
            {
                tekovnoResavanje[j] = new int[KOL_MAX];
            }
            for (int j = 0; j < resenie.Length; j++)
            {
                resenie[j] = new int[KOL_MAX];
            }
            DefaultSet[0] = red1;
            DefaultSet[1] = red2;
            DefaultSet[2] = red3;
            DefaultSet[3] = red4;
            DefaultSet[4] = red5;
            DefaultSet[5] = red6;
            DefaultSet[6] = red7;
            DefaultSet[7] = red8;
            DefaultSet[8] = red9;
            global = new Random();
        }
        private void GeneriranjeResenie()
        {
            for (int i = 0; i < RED_MAX; i++)
            {
                for (int j = 0; j < KOL_MAX; j++)
                {

                    resenie[i][j] = DefaultSet[i][j];
                    tekovnoResavanje[i][j] = 0;
                }
            }

            int roworcolPos = global.Next(1, 3);
            int setNumber = global.Next(1, 3);

            if (redica)
            {
                
                redica = false;
            }
            else
            {
                
                redica = true;
            }
            setNumber = global.Next(1, 3);
            


        }

    }
}

