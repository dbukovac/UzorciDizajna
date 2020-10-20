using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    [Serializable]
    class Memento
    {
        private List<Component> stanje;

        public Memento(List<Component> s)
        {
            stanje = new List<Component>(s);
        }

        public List<Component> getSavedState()
        {
            return stanje;
        }
    }
}
