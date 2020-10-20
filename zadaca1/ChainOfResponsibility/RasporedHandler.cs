using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class RasporedHandler : Handler
    {
        private Handler handler;

        public void Handle(Component component, int i)
        {
            Raspored raspored = (Raspored)component;
            if (raspored.rbr == i)
                handler.Handle(raspored.emisija, i);
        }

        public void NextChain(Handler next)
        {
            handler = next;
        }
    }
}
