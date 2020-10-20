using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    [Serializable]
    class Raspored : Component, ObserverInterface
    {
        public int rbr;
        public Component emisija;
        public int dan_u_tjednu;
        public TimeSpan pocetak;
        public List<Osoba> osoba;
        public List<Uloga> uloga;
        Controller controller = Controller.Instance;

        public Raspored(int r, Component c, int d, TimeSpan p)
        {
            rbr = r;
            emisija = c;
            dan_u_tjednu = d;
            pocetak = p;
            osoba = new List<Osoba>();
            uloga = new List<Uloga>();
        }

        public override void accept(Visitor visitor)
        {
            throw new NotImplementedException();
        }

        public override void Dodaj(Component c)
        {
            Console.WriteLine("Nije implementirano");
        }

        public override ObjektIterator GetIterator(int i, int id)
        {
            throw new NotImplementedException();
        }

        public override void Ispis(int x)
        {
            if(dan_u_tjednu == x || x == 0)
            {
                TablicaRed tablicaRed = new TablicaRed();

                RasporedIspis rasporedIspis = new RasporedIspis(tablicaRed, dan_u_tjednu, pocetak, osoba, uloga, rbr);

                emisija.IspisTablica(rasporedIspis);
            }
        }

        public override void IspisTablica(Decorator d)
        {
            throw new NotImplementedException();
        }

        public override void Makni(Component c)
        {
            throw new NotImplementedException();
        }

        public void Update(Uloga u_stara, Uloga u_nova)
        {
            foreach (var item in uloga)
            {
                if (item.id == u_stara.id)
                {
                    int index = uloga.IndexOf(item);
                    uloga[index] = u_nova;
                    controller.Ispis("Osobi:" + osoba[index].ime_prezime + " je promijenjena uloga:" + u_stara.opis + " u:" + u_nova.opis + " u emisiji:" + ((Emisija)emisija).naziv_emisije + " u danu:"+dan_u_tjednu);
                }
            }
        }

        public override List<Component> VratiListu()
        {
            throw new NotImplementedException();
        }

        public override Component VratiObjekt(int i, int k)
        {
            if(k == 0)
            {
                if (dan_u_tjednu == i)
                {
                    return emisija;
                }
                else
                    return null;
            }
            else
            {
                if (rbr == i)
                {
                    return this;
                }
                else
                    return null;
            }
        }

        public override int VratiTrajanje()
        {
            return emisija.VratiTrajanje();
        }
    }
}
