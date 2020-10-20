using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class EmisijaIspis : DecoratorClass
    {
        string naziv_emisije;
        int trajanje;
        string vrsta;
        string osobe;
        string uloge;
        Controller controller = Controller.Instance;

        public EmisijaIspis(Decorator t, string n, int tr, string v, List<Osoba> l_o, List<Uloga> l_u) : base(t)
        {
            naziv_emisije = n;
            trajanje = tr;
            vrsta = v;
            foreach (var item in l_o)
            {
                osobe = osobe + item.ime_prezime + ", ";
            }
            foreach (var item in l_u)
            {
                uloge = uloge + item.opis + ", ";
            }
        }

        public override void Crtaj()
        {
            controller.Dodaj(String.Format("|{0,-30}|{1,5}|{2,-15}|{3,-45}|{4,-45}|", naziv_emisije, trajanje, vrsta, osobe, uloge));
            tablica.Crtaj();
        }
    }
}
