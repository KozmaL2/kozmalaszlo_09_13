using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        public struct Feladat10struct
        {
            public string nev;
            public string ido;
        }
        public struct kuldetesstruct
        {
            public string kod;
            public string datum;
            public string nev;
            public int nap;
            public int ora;
            public string tamaszpont;
            public int db;
        }
        public static List<kuldetesstruct> kuldetesLista = new List<kuldetesstruct>();
        static void beolvasas()
        {
            FileStream fs = new FileStream("kuldetesek.csv", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                kuldetesstruct k = new kuldetesstruct();
                string sor = sr.ReadLine();
                string[] sordarabok = sor.Split(';');
                k.kod = sordarabok[0];
                k.datum = sordarabok[1];
                k.nev = sordarabok[2];
                k.nap = int.Parse(sordarabok[3]);
                k.ora = int.Parse(sordarabok[4]);
                k.tamaszpont = sordarabok[5];
                k.db = int.Parse(sordarabok[6]);
                kuldetesLista.Add(k);


            }
            fs.Close();
            sr.Close();

        }
        static void feladat4()
        {
            int db = 0;
            foreach (var i in kuldetesLista)
            {
                db += i.db;
            }
            Console.WriteLine($"4. Feladat: Összesen {db} utast szállítottak az STS űrsiklói");
        }
        static void feladat5()
        {
            int db = 0;
            foreach (var i in kuldetesLista)
            {
                if (i.db < 5)
                {
                    db++;
                }
            }
            Console.WriteLine($"5. Feladat: {db} alkalommal indítottak űrsiklót az űrbe, kevesebb, mint 5 fővel");
        }
        static void feladat6()
        {
            int i = 0;
            while (kuldetesLista[i].datum != "2003.01.16") 
            {
                i++;
            }
            Console.WriteLine($"6. Feladat: {kuldetesLista[i].db} utas volt a Columbia fedélzetén");
        }
        static void feladat7()
        {
            int legtobb = int.MinValue;

            for (int i = 0; i < kuldetesLista.Count; i++)
            {
                int osszido = kuldetesLista[i].ora + kuldetesLista[i].nap * 24;
                if (legtobb < osszido)
                {
                    legtobb = osszido;
                }
            }
            int n = 0;
            while (legtobb != kuldetesLista[n].ora + kuldetesLista[n].nap * 24)
            {
                n++;
            }

            Console.WriteLine($"Leghosszab utat megtett hajó: {kuldetesLista[n].nev};  {kuldetesLista[n].kod};  {legtobb}  óra");
        }
        static void feladat9()
        {
            double db = 0;
            foreach (var i in kuldetesLista)
            {
                if (i.tamaszpont == "Kennedy")
                {
                    db++;
                }
            }
            double szazalek =  db / (double)kuldetesLista.Count *100;
            Console.WriteLine($"{szazalek:0.00}%-a landolt a Kennedyn");
        }
        static void feladat10()
        {
            List<Feladat10struct> fel10list = new List<Feladat10struct>();
            
            
            StreamWriter sw = new StreamWriter("ursiklok.txt");
            
           
        }
        static void Main(string[] args)
        {
            beolvasas();
            Console.WriteLine($"3. Feladat: Összesen {kuldetesLista.Count} alkalommal küldtek a világűrbe űrhajót.");
            feladat4();
            feladat5();
            feladat6();
            feladat7();
            feladat9();
            feladat10();
            Console.ReadKey();
        }
    }
}
