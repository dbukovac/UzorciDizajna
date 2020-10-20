using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    [Serializable]
    class Osoba : Objekt, ObserverClass
    {
        public string ime_prezime;
        private List<Emisija> observerEmisije;
        private List<Raspored> observerRaspored;

        public Osoba(int i, string i_p)
        {
            id = i;
            ime_prezime = i_p;
            observerEmisije = new List<Emisija>();
            observerRaspored = new List<Raspored>();
        }

        public void Attach(Component c, int i)
        {
            if (i == 1)
            {
                observerEmisije.Add((Emisija)c);
            }
            if(i == 2)
            {
                observerRaspored.Add((Raspored)c);
            }
        }

        public void Notify(Uloga u_stara, Uloga u_nova)
        {
            foreach (var item in observerEmisije)
            {
                item.Update(u_stara, u_nova);
            }
            foreach (var item in observerRaspored)
            {
                item.Update(u_stara, u_nova);
            }
        }
    }
}
