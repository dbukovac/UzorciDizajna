using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    [Serializable]
    class Tv_kuca : Component
    {
        private string naziv;
        private List<Component> programi;
        private List<Osoba> osobe;
        private Caretaker caretaker;
        private int rbr = 1;

        private Tv_kuca()
        {
            naziv = "FOI-TV";
            programi = new List<Component>();
            osobe = new List<Osoba>();
            caretaker = new Caretaker();
        }

        private static Tv_kuca CreateSingleton()
        {
            if (Instance == null)
            {
                Instance = new Tv_kuca();
            }

            return Instance;
        }

        public static Tv_kuca Instance { get; private set; } = CreateSingleton();

        public void DodajOsobu(Osoba o, Component e, int i)
        {
            if(osobe.Contains(o))
            {
                osobe[osobe.IndexOf(o)].Attach(e, i);
            }
            else
            {
                o.Attach(e, i);
                osobe.Add(o);
            }
        }

        public override void Dodaj(Component c)
        {
            programi.Add(c);
        }

        public override void Ispis(int id)
        {
            caretaker.Ispis();
        }

        public override int VratiTrajanje()
        {
            throw new NotImplementedException();
        }

        public override List<Component> VratiListu()
        {
            return programi;
        }

        public Osoba VratiOsobu(int i)
        {
            return osobe.Single(a => i == a.id);
        }

        public override Component VratiObjekt(int i, int k)
        {       
            foreach (Programi item in programi)
            {
                if (item.id == i)
                {
                    return item;
                }
            }

            return null;
        }

        public override ObjektIterator GetIterator(int i, int id)
        {
            throw new NotImplementedException();
        }

        public override void IspisTablica(Decorator d)
        {
            throw new NotImplementedException();
        }

        public override void accept(Visitor visitor)
        {
            throw new NotImplementedException();
        }

        public void saveToMemento()
        {
            caretaker.saveMemento(new Memento(programi), rbr);
            rbr++;
        }

        public void restoreFromMemento(int br)
        {
            programi = caretaker.GetMemento(br).getSavedState();
        }

        public override void Makni(Component c)
        {
            throw new NotImplementedException();
        }

        public void TraziEmisiju(int i)
        {
            foreach (var item in programi)
            {
                ProgramHandler programHandler = new ProgramHandler();
                RasporedHandler rasporedHandler = new RasporedHandler();
                EmisijeHandler emisijeHandler = new EmisijeHandler();
                programHandler.NextChain(rasporedHandler);
                rasporedHandler.NextChain(emisijeHandler);
                programHandler.Handle(item, i);
            }
        }
    }
}
