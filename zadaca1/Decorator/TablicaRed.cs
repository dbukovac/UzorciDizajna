﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class TablicaRed : Decorator
    {
        Controller controller = Controller.Instance;
        public override void Crtaj()
        {
            controller.Ispis(new string('-', 227));
        }
    }
}
