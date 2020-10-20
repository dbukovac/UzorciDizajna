using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class EmisijeHandler : Handler
    {
        Controller controller = Controller.Instance;
        public void Handle(Component component, int i)
        {
            Emisija emisija = (Emisija)component;
            controller.Ispis("Emisija broja: " + i + " je: " + emisija.naziv_emisije);
        }

        public void NextChain(Handler next)
        {
            throw new NotImplementedException();
        }
    }
}
