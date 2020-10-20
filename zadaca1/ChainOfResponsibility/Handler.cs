using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    interface Handler
    {
        void NextChain(Handler next);
        void Handle(Component component, int i);
    }
}
