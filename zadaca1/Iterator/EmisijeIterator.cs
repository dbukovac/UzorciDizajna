using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class EmisijeIterator : ObjektIterator
    {
        private Programi rasporedi;
        private int current = 0;
        private int step = 1;

        public EmisijeIterator(Programi r)
        {
            rasporedi = r;
        }

        public override Component First()
        {
            current = 0;
            return rasporedi[current] as Raspored;
        }

        public override Component Next()
        {
            current += step;
            if (!IsDone)
                return rasporedi[current] as Component;
            else
                return null;
        }

        public Component CurrentComponent
        {
            get { return  rasporedi[current] as Component;  }
        }

        public bool IsDone
        {
            get { return current >= rasporedi.Count; }
        }
    }
}
