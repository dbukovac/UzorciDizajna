using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class RasporedIspis : DecoratorClass
    {
        int dan_u_tjednu;
        TimeSpan pocetak;
        string osobe;
        string uloge;
        int rbr;
        Controller controller = Controller.Instance;

        public RasporedIspis(Decorator t, int d, TimeSpan p, List<Osoba> l_o, List<Uloga> l_u, int r) : base(t)
        {
            dan_u_tjednu = d;
            pocetak = p;
            rbr = r;
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
            controller.Dodaj(String.Format("{0,3}|{1,10}|{2,-30}|{3,-30}|{4,3}|", dan_u_tjednu, pocetak, osobe, uloge, rbr));
            controller.Azuriraj();
            tablica.Crtaj();
        }
    }
}
