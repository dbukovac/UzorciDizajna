using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    interface IObjektCollection
    {
        ObjektIterator GetIterator(int i, int id);
    }
}
