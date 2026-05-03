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

        public double obim()
        {
            Vektor a;
            double obim = 0;
            for (int i = 0; i < br_temena - 1; i++)
            {
                a = new Vektor(teme[i], teme[i + 1]);
                obim += a.duzina();
            }
            a = new Vektor(teme[br_temena - 1], teme[0]);
            obim += a.duzina();
            return obim;
        }

        public bool prost()
        {
            for (int i = 0; i < br_temena - 1; i++)
            {
                for (int j = i + 1; j < br_temena; j++)
                {
                    if (Tacka.jednaka(teme[i], teme[j]))
                    {
                        return false;
                    }
                }
            }
            Vektor[] stranica = new Vektor[br_temena];
            for (int i = 0; i < br_temena - 1; i++)
            {
                stranica[i] = new Vektor(teme[i], teme[i + 1]);
            }
            stranica[br_temena - 1] = new Vektor(teme[br_temena - 1], teme[0]);
            for (int i = 0; i < br_temena; i++)
            {
                int kraj;
                if (i == 0) kraj = br_temena - 1;
                else kraj = br_temena;
                for (int j = i + 2; j < kraj; j++)
                {
                    if (Vektor.sekuSe(stranica[i], stranica[j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool tackaUnutar(Tacka P)
        {
            int brojPreseka = 0;
            
            for (int i = 0; i < br_temena; i++)
            {
                    Tacka A = teme[i];
                    Tacka B = teme[(i + 1) % br_temena];
                    if ((A.y <= P.y && B.y > P.y) || (B.y <= P.y && A.y > P.y))
                    {
                        float t = (P.y - A.y) / (B.y - A.y);
                        float xPresek = A.x + t * (B.x - A.x);
                        if (P.x < xPresek)
                        {
                            brojPreseka++;
                        }
                    }
            }
            return (brojPreseka % 2) != 0;
        }
        public bool proveriDeltoid()
        {
            if (br_temena != 4) return false;

            Vektor[] stranice = new Vektor[4];
            stranice[0] = new Vektor(teme[0], teme[1]);
            stranice[1] = new Vektor(teme[1], teme[2]);
            stranice[2] = new Vektor(teme[2], teme[3]);
            stranice[3] = new Vektor(teme[3], teme[0]);

            double[] duzine = new double[4];
            for (int i = 0; i < 4; i++)
            {
                duzine[i] = stranice[i].duzina();
            }

            bool check = false;
            if (duzine[0] == duzine[3] && duzine[1] == duzine[2]) check = true;
            if (duzine[0] == duzine[1] && duzine[2] == duzine[3]) check = true;

            return check;
        }
        public bool proveriPravougaonik()
        {
            if (br_temena != 4) return false;

            Vektor[] stranice = new Vektor[4];
            stranice[0] = new Vektor(teme[0], teme[1]);
            stranice[1] = new Vektor(teme[1], teme[2]);
            stranice[2] = new Vektor(teme[2], teme[3]);
            stranice[3] = new Vektor(teme[3], teme[0]);

            double[] duzine = new double[4];
            for (int i = 0; i < 4; i++)
            {
                duzine[i] = stranice[i].duzina();
            }

            bool check = false;
            if (duzine[0] == duzine[3] && duzine[1] == duzine[2]) check = true;
            if (duzine[0] == duzine[1] && duzine[2] == duzine[3]) check = true;

            if (Vektor.SP(stranice[0], stranice[1]) == 0 &&
                Vektor.SP(stranice[1], stranice[2]) == 0 &&
                Vektor.SP(stranice[2], stranice[3]) == 0 &&
                check == true)
                return true;
            else return false;
        }
        public bool proveriPravougliTrapez()
        {
            if (br_temena != 4) return false;

            Vektor[] stranice = new Vektor[4];
            stranice[0] = new Vektor(teme[0], teme[1]);
            stranice[1] = new Vektor(teme[1], teme[2]);
            stranice[2] = new Vektor(teme[2], teme[3]);
            stranice[3] = new Vektor(teme[3], teme[0]);

            int brojac = 0;

            for (int i = 0; i < 4; i++)
                if (Vektor.SP(stranice[i], stranice[(i + 1) % 4]) == 0) brojac++;

            return brojac == 2;
        }
    }
}
