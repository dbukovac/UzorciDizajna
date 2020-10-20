using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    [Serializable]
    class Uloga : Objekt
    {
        public string opis;

        public Uloga(int i, string o)
        {
            id = i;
            opis = o;
        }
    }
}
