using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    [Serializable]
    class Vrsta : Objekt
    {
        public string naziv;
        public int ima_reklame;
        public int max_trajanje_reklama;

        public Vrsta(int i, string n, int r, int t)
        {
            id = i;
            naziv = n;
            ima_reklame = r;
            max_trajanje_reklama = t;
        }
    }
}
