using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    [Serializable]
    class Programi : Component, IObjektCollection
    {
        public int id;
        public string naziv_programa;
        public TimeSpan pocetak;
        public TimeSpan kraj;
        public string naziv_datoteke;
        public List<Component> raspored_emisija;
        public List<Osoba> osobe;

        public Programi(int i, string n_p, string n_d)
        {
            id = i;
            naziv_programa = n_p;
            naziv_datoteke = n_d;
            raspored_emisija = new List<Component>();
            osobe = new List<Osoba>();
        }

        public Programi(Programi drugi)
        {
            id = drugi.id;
            naziv_programa =drugi.naziv_programa;
            naziv_datoteke = drugi.naziv_datoteke;
            raspored_emisija = drugi.raspored_emisija;
            pocetak = drugi.pocetak;
            kraj = drugi.kraj;
        }

        public Programi()
        {
            raspored_emisija = new List<Component>();
        }

        public override void Dodaj(Component c)
        {
            raspored_emisija.Add(c);
        }

        public override void Ispis(int x)
        {
            Controller controller = Controller.Instance;
            controller.Ispis("");
            controller.Ispis("Naziv programa: " + naziv_programa);


            if (x < 8)
            {
                controller.Ispis("Početak: " + pocetak + " Kraj: " + kraj);
                controller.Ispis(new string('-', 227));
                controller.Dodaj(String.Format("|{0,-30}|{1,-5}|{2,-15}|{3,-45}|{4,-45}|", "Naziv emisije", "(min)", "Vrsta emisije", "Osobe", "Uloge"));
                controller.Dodaj(String.Format("{0,3}|{1,10}|{2,-30}|{3,-30}|{4,3}|", "Dan", "Početak", "Osobe", "Uloge","Rbr"));
                controller.Azuriraj();
                controller.Ispis(new string('-', 227));
                foreach (Component item in raspored_emisija)
                {
                    item.Ispis(x);
                }
            }
            if(x == 99)
            {
                controller.Ispis(new string('-', 227));
                controller.Dodaj(String.Format("|{0,-30}|{1,-5}|{2,-15}|{3,-45}|{4,-45}|", "Naziv emisije", "(min)", "Vrsta emisije", "Osobe", "Uloge"));
                controller.Dodaj(String.Format("{0,3}|{1,10}|{2,-30}|{3,-30}|{4,3}|", "Dan", "Početak", "Osobe", "Uloge", "Rbr"));
                controller.Azuriraj();
                controller.Ispis(new string('-', 227));
            }
            if(x == 98)
            {
                controller.Ispis(new string('-', 47));
                controller.Dodaj(String.Format("{0,-30}|{1,15}|", "Max trajanje reklama (min)", "Dan u tjednu"));
                controller.Azuriraj();
                controller.Ispis(new string('-', 47));
            }
        }

        public override int VratiTrajanje()
        {
            throw new NotImplementedException();
        }

        public override List<Component> VratiListu()
        {
            return raspored_emisija;
        }

        public override Component VratiObjekt(int i, int k)
        {
            throw new NotImplementedException();
        }

        public override ObjektIterator GetIterator(int i, int id)
        {
            if(i == 1)
                return new EmisijeIterator(this);
            else
                return new VrsteIterator(this, id);
        }

        public override void IspisTablica(Decorator d)
        {
            throw new NotImplementedException();
        }

        public override void accept(Visitor visitor)
        {
            throw new NotImplementedException();
        }

        public override void Makni(Component c)
        {
            raspored_emisija.Remove(c);
        }

        public object this[int index]
        {
            get { return raspored_emisija[index];  }
        }

        public int Count
        {
            get { return raspored_emisija.Count; }
        }

        public void DodajOsobu(Osoba o, Component e, int i)
        {
            if (osobe.Contains(o))
            {
                osobe[osobe.IndexOf(o)].Attach(e, i);
            }
            else
            {
                o.Attach(e, i);
                osobe.Add(o);
            }
        }
    }
}
