using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    abstract class ObjektCreator
    {
        private List<Objekt> lista;

        public ObjektCreator()
        {
            lista = Kreiraj();
        }

        public List<Objekt> VratiListu()
        {
            return lista;
        }

        public Objekt VratiObjekt(int id)
        {
            return lista.Single(a => id == a.id);
        }

        public abstract List<Objekt> Kreiraj();
    }
}
