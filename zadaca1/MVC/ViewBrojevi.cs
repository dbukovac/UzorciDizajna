using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    [Serializable]
    class ViewBrojevi : ViewSucelje
    {
        int brojac = 0;

        public void Ispis(string str)
        {
            Console.WriteLine("[" + brojac.ToString("D5") + "]"+str);
            brojac++;
        }

        public void IspisA(string str)
        {
            Console.WriteLine("[" + brojac.ToString("D5") + "]" + str);
            brojac++;
            Console.Write("[" + brojac.ToString("D5") + "]");
            brojac++;
        }
    }
}
