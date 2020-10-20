using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadaca1;

namespace zadaca1
{
    [Serializable]
    class Caretaker
    {
        public List<Memento> memento;
        public List<int> id;
        public List<DateTime> vrijeme;
        Controller controller = Controller.Instance;

        public Caretaker()
        {
            memento = new List<Memento>();
            id = new List<int>();
            vrijeme = new List<DateTime>();
        }

        public void saveMemento(Memento m, int rbr)
        {
            memento.Add(m);
            id.Add(rbr);
            vrijeme.Add(DateTime.Now);
            Serializator.Serialize("data.dat", memento);
        }

        public Memento GetMemento(int rbr)
        {
            memento = Serializator.Deserialize<List<Memento>>("data.dat");
            for (int i = 0; i < id.Count; i++)
            {
                if (id[i] == rbr)
                    return memento[i];
            }
            return null;
        }

        public void Ispis()
        {
            memento = Serializator.Deserialize<List<Memento>>("data.dat");
            for (int i = 0; i < memento.Count; i++)
            {
                foreach (var item in memento[i].getSavedState())
                {
                    item.Ispis(100);
                    controller.Ispis(new string('-', 47));
                    controller.Dodaj(String.Format("{0,-5}|{1,-24}|{2,15}|", "ID", "Vrijeme pohrane", "Broje emisija"));
                    controller.Azuriraj();
                    controller.Ispis(new string('-', 47));
                    TablicaReklame tablicaRed = new TablicaReklame();
                    PohranaIspis pohranaIspis = new PohranaIspis(tablicaRed, id[i], item.VratiListu().Count, vrijeme[i]);
                    pohranaIspis.Crtaj();
                }
            }
        }
    }
}
