using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hegyekCLI
{
    internal class Program
    {
        public static List<Hegycsucs> hegycsucsok = new List<Hegycsucs>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("hegyek.csv"); // fájl beolvasása
            sr.ReadLine(); // fejléc átugrása
            while (!sr.EndOfStream)
            {
                hegycsucsok.Add(new Hegycsucs(sr.ReadLine()));
            }
            sr.Close();
            //8.feladat
            foreach (var item in hegycsucsok)
            {
                if (item.Magassag > 950)
                {
                    Console.WriteLine($"{item.Nev} {item.Hegyseg} {item.Magassag}");
                }
            }

            //11.feladat
            Console.WriteLine("Kérem a keresett szót: ");
            string keresettSzo = Console.ReadLine();
            foreach (var item in hegycsucsok)
            {
                if (item.Keres(keresettSzo))
                {
                    Console.WriteLine($"{item.Nev}");
                }
            }
            Console.ReadLine();
        }
    }
}
