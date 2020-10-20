using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    [Serializable]
    class Emisija : Component, ObserverInterface
    {
        public int id;
        public string naziv_emisije;
        public int trajanje;
        public List<Osoba> osobe;
        public List<Uloga> uloge;
        public Vrsta vrsta;
        Controller controller = Controller.Instance;

        public Emisija(int i, string n, int t, Vrsta v)
        {
            id = i;
            naziv_emisije = n;
            trajanje = t;
            osobe = new List<Osoba>();
            uloge = new List<Uloga>();
            vrsta = v;
        }

        public override void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public override void Dodaj(Component c)
        {
            throw new NotImplementedException();
        }

        public override ObjektIterator GetIterator(int i, int id)
        {
            throw new NotImplementedException();
        }

        public override void Ispis(int x)
        {
            throw new NotImplementedException();
        }

        public override void IspisTablica(Decorator d)
        {
            EmisijaIspis emisijaIspis = new EmisijaIspis(d, naziv_emisije, trajanje, vrsta.naziv, osobe, uloge);

            emisijaIspis.Crtaj();
        }

        public override void Makni(Component c)
        {
            throw new NotImplementedException();
        }

        public void Update(Uloga u_stara, Uloga u_nova)
        {
            foreach (var item in uloge)
            {
                if (item.id == u_stara.id)
                {
                    int index = uloge.IndexOf(item);
                    uloge[index] = u_nova;
                    controller.Ispis("Osobi: " + osobe[index].ime_prezime + ", je promijenjena uloga: " + u_stara.opis + ", u: " + u_nova.opis+ ", u svim emisijama: "+naziv_emisije);
                }
            }
        }

        public override List<Component> VratiListu()
        {
            throw new NotImplementedException();
        }

        public override Component VratiObjekt(int i, int k)
        {
            throw new NotImplementedException();
        }

        public override int VratiTrajanje()
        {
            return vrsta.max_trajanje_reklama;
        }
    }
}
