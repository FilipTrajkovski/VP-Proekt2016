using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Proekt2016
{
    class Sudoku
    {
        private static int RED_MAX = 9;
        private static int KOL_MAX = 9;
        private static int SUB_MATRICA_GOL = 3;

        private int[][] resenie = new int[RED_MAX][];
        int[][] tekovnoResavanje = new int[RED_MAX][];
        private int[][] DefaultSet = new int[RED_MAX][];

        private int[] setirajRedPoz = { 0, 0, 0, 3, 3, 3, 6, 6, 6 };
        private int[] setirajKolonaPoz = { 0, 3, 6, 0, 3, 6, 0, 3, 6 };

        private bool redica = true;
        Random global;

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

            int pozicija = global.Next(1, 3);
            int setNumber = global.Next(1, 3);

            if (redica)
            {
                zameniRedKolona(setNumber, pozicija, "ROWS");
                redica = false;
            }
            else
            {
                zameniRedKolona(setNumber, pozicija, "COLS");
                redica = true;
            }
            setNumber = global.Next(1, 3);
            zameniRedKolona(setNumber, pozicija, "SETS");


        }
        private void zameniRedKolona(int setNumber, int pozicija, String type)
        {
            int redKol1, redKol2 = 0;
            switch (type)
            {
                case "ROWS":
                    redKol1 = setirajRedPoz[setNumber*3]*pozicija;
                    if (pozicija == 2)
                    {
                        redKol2 = setirajRedPoz[setNumber * 3];
                    }
                    else
                    {
                        redKol2 = redKol1 + 1;
                    }
                    for (int i = 0; i < RED_MAX; i++)
                    {
                        resenie[i][redKol1] = DefaultSet[i][redKol2];
                        resenie[i][redKol2] = DefaultSet[i][redKol1];
                    }
                    break;
                case "COLS":
                    redKol1 = setirajKolonaPoz[setNumber * 3] + pozicija;
                    if (pozicija == 2)
                    {
                        redKol2 = setirajKolonaPoz[setNumber * 3];
                    }
                    else
                    {
                        redKol2 = redKol1 + 1;
                    }
                    for (int i = 0; i < KOL_MAX; i++)
                    {
                        resenie[redKol1][i] = DefaultSet[redKol2][i];
                        resenie[redKol2][i] = DefaultSet[redKol1][i];
                    }
                    break;
                case "SETS":
                    redKol1 = setNumber;
                    if (setNumber == 2)
                    {
                        redKol2 = 0;
                    }
                    else
                    {
                        redKol2 = redKol1 + 1;
                    }
                    if (redica)
                    {    
                        for (int i = 0; i < KOL_MAX; i++)
                        {
                            for (int j = 0; j < SUB_MATRICA_GOL; j++)
                            {
                                int temp = resenie[redKol2 * 3 + i][j];
                                resenie[redKol2 * 3 + i][j] = resenie[redKol1 * 3 + i][j];
                                resenie[redKol1 * 3 + i][j] = temp;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < KOL_MAX; i++)
                        {
                            for (int j = 0; j < SUB_MATRICA_GOL; j++)
                            {
                                int temp = resenie[j][redKol1 * 3 + i];
                                resenie[j][redKol1 * 3 + i] = resenie[j][redKol2 * 3 + i];
                                resenie[j][redKol2 * 3 + i] = temp;
                            }
                        }    
                    }
                    break;
                default:
                    break;
            }
        }

    }
}

