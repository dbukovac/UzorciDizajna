using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    [Serializable]
    class ViewObican : ViewSucelje
    {
        public void Ispis(string str)
        {
            Console.WriteLine(str);
        }

        public void IspisA(string str)
        {
            Console.WriteLine(str);
        }
    }
}
