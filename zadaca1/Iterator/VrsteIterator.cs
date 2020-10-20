using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class VrsteIterator : ObjektIterator
    {
        private Programi rasporedi;
        private int current = 0;
        private int step = 1;
        private int id;

        public VrsteIterator(Programi r, int i)
        {
            rasporedi = r;
            id = i;
        }

        public override Component First()
        {
            current = 0;
            int i = ((Emisija)(((Raspored)rasporedi[current]).emisija)).vrsta.id;
            if (id == i)
                return rasporedi[current] as Component;
            else
                return null;
        }

        public override Component Next()
        {
            current += step;
            if (!IsDone)
            {
                int i = ((Emisija)(((Raspored)rasporedi[current]).emisija)).vrsta.id;
                if (id == i)
                    return rasporedi[current] as Component;
                else
                    return null;
            }
            else
                return null;
        }

        public Component CurrentComponent
        {
            get { return rasporedi[current] as Component; }
        }

        public bool IsDone
        {
            get { return current >= rasporedi.Count; }
        }
    }
}
