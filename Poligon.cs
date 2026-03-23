using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Polygon___Properties
{
    internal class Poligon
    {
        public int br_temena;
        public Tacka[] teme;
        public Poligon(int n)
        {
            br_temena = n;
            teme = new Tacka[n];
        }

        public static Poligon unos()
        {
            Console.WriteLine("Koliko temena?");
            int n = Convert.ToInt32(Console.ReadLine());
            Poligon novi = new Poligon(n);
            for (int i = 0; i < n; i++)
            {
                novi.teme[i] = new Tacka();
                Console.WriteLine("a[{0}].x = ", i + 1);
                novi.teme[i].x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("a[{0}].y = ", i + 1);
                novi.teme[i].y = Convert.ToInt32(Console.ReadLine());
            }
            return novi;
        }
        
        public static void stampa()
        {
            StreamReader ulaz = new StreamReader("poligon.txt");
            string s = ulaz.ReadToEnd();
            Console.WriteLine(s);
        }

        public void snimi()
        {
            StreamWriter izlaz = new StreamWriter("poligon.txt");
            izlaz.WriteLine(br_temena);
            for (int i = 0; i < br_temena; i++)
            {
                izlaz.WriteLine(teme[i].x);
                izlaz.WriteLine(teme[i].y);
            }
            izlaz.Close();
        }

        public static Poligon ucitaj()
        {
            return null;
        }
    }
}
