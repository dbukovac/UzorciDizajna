using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    [Serializable]
    abstract class Component
    {
        public abstract void Dodaj(Component c);

        public abstract void Makni(Component c);

        public abstract void Ispis(int id);

        public abstract int VratiTrajanje();

        public abstract List<Component> VratiListu();

        public abstract Component VratiObjekt(int i, int k);

        public abstract ObjektIterator GetIterator(int i, int id);

        public abstract void IspisTablica(Decorator d);

        public abstract void accept(Visitor visitor);
    }
}
