using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    interface Visitor
    {
        void visit(Emisija emisija);
        void visitRaspored(Component raspored, int dan);
    }
}
