using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class ReklameIspis : DecoratorClass
    {
        int dan_u_tjednu;
        int max_trajanje;
        Controller controller = Controller.Instance;

        public ReklameIspis(Decorator t, int d, int tr) : base(t)
        {
            dan_u_tjednu = d;
            max_trajanje = tr;
        }

        public override void Crtaj()
        {
            controller.Dodaj(String.Format("{0,-30}|{1,15}|", max_trajanje, dan_u_tjednu));
            controller.Azuriraj();
            tablica.Crtaj();
        }
    }
}
