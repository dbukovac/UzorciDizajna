using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    [Serializable]
    class Controller
    {
        ViewSucelje view;

        Model model;

        private static Controller CreateSingleton()
        {
            if (Instance == null)
            {
                Instance = new Controller();
            }

            return Instance;
        }

        public static Controller Instance { get; private set; } = CreateSingleton();

        public void PostaviView(int i)
        {
            if(i == 0)
            {
                view = new ViewObican();
            }
            else
            {
                view = new ViewBrojevi();
            }
            model = new Model();
        }

        public void Dodaj(string str)
        {
            model.str += str;
        }

        public void Ispis(string str)
        {
            model.str = str;
            view.Ispis(model.str);
            model = new Model();
        }

        public void IspisA(string str)
        {
            model.str = str;
            view.IspisA(model.str);
            model = new Model();
        }

        public void Azuriraj()
        {
            view.Ispis(model.str);
            model = new Model();
        }
    }
}
