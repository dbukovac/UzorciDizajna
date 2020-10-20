using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    interface ObserverClass
    {
        void Attach(Component c, int i);

        void Notify(Uloga u_stara, Uloga u_nova);
    }
}
