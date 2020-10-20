using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class PohranaIspis : DecoratorClass
    {
        int id;
        int broj_emisija;
        DateTime vrijeme;
        Controller controller = Controller.Instance;

        public PohranaIspis(Decorator t, int i, int br, DateTime d) : base(t)
        {
            id = i;
            broj_emisija = br;
            vrijeme = d;
        }

        public override void Crtaj()
        {
            controller.Dodaj(String.Format("{0,-5}|{1,-24}|{2,15}|", id, vrijeme, broj_emisija));
            controller.Azuriraj();
            tablica.Crtaj();
        }
    }
}
