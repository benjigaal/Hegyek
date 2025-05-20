using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hegyekCLI
{
    public class Hegycsucs
    {
        public string Nev { get; private set; }

        public string Hegyseg { get; private set; }

        public int Magassag { get; private set; }


        public Hegycsucs(string sor)
        {
            string[] darabok = sor.Split(';');
            Nev = darabok[0];
            Hegyseg = darabok[1];
            Magassag = Convert.ToInt32(darabok[2]);
        }

        //9-10.feladat
        public bool Keres(string szo) 
        {
            if (Nev.Contains(szo) || Hegyseg.Contains(szo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Név: {Nev} Hegység: {Hegyseg} Magasság: {Magassag}";
        }
    }
}
