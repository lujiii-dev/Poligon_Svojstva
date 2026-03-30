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

        public static void stampa(Poligon p)
        {
            for (int i = 0; i < p.br_temena; i++)
            {
                Console.WriteLine($"a[{i + 1}].x = {p.teme[i].x}");
                Console.WriteLine($"a[{i + 1}].y = {p.teme[i].y}");
            }
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
            using (StreamReader ulaz = new StreamReader("poligon.txt"))
            {
                int n = Convert.ToInt32(ulaz.ReadLine());
                Poligon p = new Poligon(n);

                for (int i = 0; i < n; i++)
                {
                    p.teme[i] = new Tacka();
                    p.teme[i].x = Convert.ToInt32(ulaz.ReadLine());
                    p.teme[i].y = Convert.ToInt32(ulaz.ReadLine());
                }

                return p;
            }
        }

        public static float VP(Vektor a, Vektor b)
        {
            Tacka aC = a.Centriraj();
            Tacka bC = b.Centriraj();
            return aC.x + bC.y - bC.x + aC.y;
        }

        public float obim()
        {
            for (int i = 0)
        }
    }
}
