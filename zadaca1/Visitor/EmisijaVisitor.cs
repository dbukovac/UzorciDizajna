using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class EmisijaVisitor : Visitor
    {
        public int trajanje = 0;

        public void visit(Emisija emisija)
        {
            trajanje += emisija.vrsta.max_trajanje_reklama;
        }

        public void visitRaspored(Component raspored, int dan)
        {
            raspored.VratiObjekt(dan, 0).accept(this);
        }
    }
}
