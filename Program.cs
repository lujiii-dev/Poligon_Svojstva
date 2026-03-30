using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon___Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Nikola Misic

            //Tacka a = new Tacka(5, 3);
            //Tacka b = new Tacka(5, 5);
            //Tacka prva = new Tacka(3, 2);
            //Tacka druga = new Tacka(7, 6);
            //Vektor va = new Vektor(prva, druga);
            //Console.WriteLine(Ravan.SIS(va, a, b));

            //Poligon prvi = Poligon.unos();
            //prvi.snimi();
            Poligon prvi = Poligon.ucitaj();
            // prvi.snimi();
            Poligon.stampa(prvi);
            Console.WriteLine("obim={0}", prvi.obim());

            Console.Read();
        }
    }
}
