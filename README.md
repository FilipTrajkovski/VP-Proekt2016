# Sudoku
Windows Forms проект по предметот Визуелно Програмирање 2015/2016.

##1.	Опис на апликацијата

Апликацијата што ја развиваме е класичната игра Sudoku. Имлементиравме различни алгоритми соодветни за нивото на тежина на играта, прекинување на моменталната игра и започнување нова игра и High Scores за секое ниво на тежина одделно.

##2.	Упатство за користење

###2.1 Нова игра

![alt tag](http://i1376.photobucket.com/albums/ah31/Ana_Spiroska/slika1_zpsgz9s2eid.jpg)
 
На почетниот прозорец (Слика 1) при стартување на апликацијата имаме можност да започнеме нова игра (New game), да видиме листа со рекорди (High Scores) и да прочитаме нешто повеќе за тоа како се игра (Help).
Доколку сакаме да започнеме нова игра најпрво се селектира New Game. Потоа се одбира едно од трите нивоа на тежина:
*	Easy
*	Medium
*	Hard

Во секое време можеме да ја прекинеме играта и да почнеме од почеток (Stop current game). Ќе се појави нов прозорец кој прашува дали сме сигурни. Потоа можеме повторно да избереме ниво на тежина и да почнеме нова игра.

![alt tag](http://i1376.photobucket.com/albums/ah31/Ana_Spiroska/slika3_zpszozxqxfp.png)

###2.2	High Scores


![alt tag](http://i1376.photobucket.com/albums/ah31/Ana_Spiroska/slika2_zpsqgvxgboq.jpg)
  
Тука се чуваат најдобрите времиња за кои што играчот ја завршил успешно играта, за секое ниво на тежина посебно. После секоја завршена игра, ако времето за кое што играчот го решил судокуто е пократко од тоа што стои во High Scores, се запишува новото време во соодветното ниво на тежина. Исто така овозможено е бришење на сите high scores со стискање на копчето Reset High Scores, при што се појавува соодветно предупредување.


###2.3	Правила
Правилата се исти како и во секоја стандардна судоку игра:
* Не смее да има два или повеќе исти броја во една колона.
* Не смее да има два или повеќе исти броја во еден ред.
* Не смее да има два или повеќе исти броја во еден регион.

Ако корисникот сака да дознае нешто повеќе за играта, во самата игра постои опција Help.

##3.	Претставување на проблемот

###3.1	Податочни структури

Главните податоци и методи за играта се чуваат во класа ``` public class Sudoku ```.

``` c#
class Sudoku
    {
        private static int RED_MAX = 9;
        private static int KOL_MAX = 9;
        private static int SUB_MATRICA_GOL = 3;

        public int[][] resenie = new int[RED_MAX][];
        public int[][] tekovnoResavanje = new int[RED_MAX][];
        private int[][] DefaultSet = new int[RED_MAX][];

        private int[] setirajRedPoz = { 0, 0, 0, 3, 3, 3, 6, 6, 6 };
        private int[] setirajKolonaPoz = { 0, 3, 6, 0, 3, 6, 0, 3, 6 };

        private bool redica = true;
        Random global;

        public Sudoku()
        {}
        
        public void GenerirajSet(string level)
        {}
        
        private void GeneriranjeResenie()
        {}
        
        private void zameniRedKolona(int brSet, int pozicija, String type)
        {}
        
        private void tekovenSet(int brPodSet,int minPos,int maxPos)
        {}
```

###3.2	Алгоритми

Кога се почнува нова игра, најпрво се повикува методот ```GenerirajSet(String level)  ``` кој како аргумент ја прима тежината што ја избрал корисникот. Во неа се повикува методот ``` GenerirajResenie() ``` кој што од главната матрица ``` int[][] DefaultSet ``` со помош на методот ``` zameniRedKolona(int brSet, int pozicija, String type) ``` случајно избира колона или редица да си ги заменат местата неколку пати и под-матриците случајно се мешаат, со што се создава решението. Потоа во зависност од тежината што ја избрал корисникот се повикува методата ``` tekovenSet(int brPodSet, int minPos, int maxPos) ``` со што се добива тековната матрица за корисникот да ја реши. При секој tick на тајмерот во методата ``` tVreme_Tick() ``` се проверува дали точно е решена матрицата.

###3.3	Прикажување на матрицата на екран
За претставување на матрицата за судоку користевме Label контрола со нејзините готови events Click() и TextChanged() .

####Изработиле: 

Филип Трајковски 131206

Ана Спироска 131144





