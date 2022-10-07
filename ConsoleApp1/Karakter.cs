using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarakterDekodolo
{
    internal class Karakter
    {
        public int[,] Matrix { get; set; }
        public char Betu { get; set; }
        public Karakter(int[,] matrix, char betu)
        {
            Matrix = matrix;
            Betu = betu;
        }
    }
}
