using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class ProgramHandler : Handler
    {
        private Handler handler;

        public void Handle(Component component, int i)
        {
            Programi program = (Programi)component;
            foreach (var item in program.raspored_emisija)
            {
                handler.Handle(item, i);
            }
        }

        public void NextChain(Handler next)
        {
            handler = next;
        }
    }
}
