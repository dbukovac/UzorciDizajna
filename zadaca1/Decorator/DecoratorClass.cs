using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    abstract class DecoratorClass : Decorator
    {
        protected Decorator tablica;

        public DecoratorClass(Decorator t)
        {
            tablica = t;
        }

        public override void Crtaj()
        {
            tablica.Crtaj();
        }
    }
}
