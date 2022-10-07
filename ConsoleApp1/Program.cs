using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KarakterDekodolo
{
    internal class Program
    {
        static char betu = '-';
       
        static List<Karakter> karakterek = new List<Karakter>();
        static void Main(string[] args)
        {
            KarakterekBeolvasasa();
            Feladat05();
            Feladat06();
            Feladat07();


        }

        private static void Feladat07()
        {
            int i = 0;
            while (i <karakterek.Count && karakterek[i].Betu != betu)
            {
                i++;
            }
            if (i< karakterek.Count)
            {
                Console.WriteLine("Nincs ilyen karakter a bankban!");
                
            }
            else
            {
                Console.WriteLine("7. Feladat:");
                for (int s = 0; s < karakterek[i].Matrix.GetLength(0); s++)
                {
                    for (int o = 0; o < karakterek[i].Matrix.GetLength(1); o++)
                    {
                        if (karakterek[i].Matrix[s,o] == 1)
                        {
                            Console.WriteLine("X");
                        }
                        else
                        {
                            Console.WriteLine(" ");
                        }
                    }
                }
            }
        }

        private static void Feladat06()
        {
            string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Console.WriteLine();
            while(!valid.Contains(betu))
            {
                Console.Write("6. Feladat: Kérek egy angol nagybetűt:");
                string angolNagybetu = Console.ReadLine();
                if (angolNagybetu.Length == 1 )
                {
                    betu = char.Parse(angolNagybetu);
                }



            } 
        }

        private static void Feladat05()
        {
            Console.WriteLine($"5. Feladat: Karakterek száma: {karakterek.Count}");
        }

        private static void KarakterekBeolvasasa()
        {
            var sr = new StreamReader(@"..\..\..\src\bank.txt");
            while (!sr.EndOfStream)
            {
                char betu = char.Parse(sr.ReadLine());
                int[,] matrix = new int[7, 4];
                for (int s = 0; s < matrix.GetLength(0); s++)
                {
                    string teljesSor = sr.ReadLine();
                    for (int o = 0; o < teljesSor.Length; o++)
                    {
                        matrix[s,o] = teljesSor[o];
                    }
                }
                karakterek.Add(new Karakter(matrix, betu));
            }
            sr.Close();
            
        }        
    }
}