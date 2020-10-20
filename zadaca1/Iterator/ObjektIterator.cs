using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    abstract class ObjektIterator
    {
        public abstract Component First();
        public abstract Component Next();
        bool IsDone { get; }
        Component CurrentComponent { get; }
    }
}
