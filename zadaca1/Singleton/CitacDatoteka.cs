using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class CitacDatoteka
    {
        private string[] lines;
        private List<string[]> lista_redaka;
        public string tvkuca;
        public string emisije;
        public string osobe;
        public string uloge;
        public string vrste;

        private CitacDatoteka()
        {
        }

        private static CitacDatoteka CreateSingleton()
        {
            if (Instance == null)
            {
                Instance = new CitacDatoteka();
            }

            return Instance;
        }

        public static CitacDatoteka Instance { get; private set; } = CreateSingleton();

        public void CitajDatoteku(string putanja)
        {
            lista_redaka = new List<string[]>();

            if (File.Exists(putanja))
            {
                lines = File.ReadAllLines(putanja);
                OdvojiRetke(lines);
            }
            else
            {
                Console.WriteLine("Datoteka nije na navedenoj lokaciji "+ putanja);
                throw new System.Exception();
            }
        }

        private void OdvojiRetke(string[] lines)
        {
            for (int i = 1; i < lines.Length; i++)
            {
                string[] redak;
                redak = lines[i].Split(';');
                lista_redaka.Add(redak);
            }
        }

        public List<string[]> DohvatiListuRedaka()
        {
            return lista_redaka;
        }

        public bool PostaviPutanja(string[] args)
        {
            bool prolaz = false;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-t")
                    tvkuca = args[i + 1];
                if (args[i] == "-e")
                    emisije = args[i + 1];
                if (args[i] == "-o")
                    osobe = args[i + 1];
                if (args[i] == "-u")
                    uloge = args[i + 1];
                if (args[i] == "-v")
                    vrste = args[i + 1];
            }

            if (tvkuca != "" && emisije != "" && osobe != "" && uloge != "" && vrste != "")
                prolaz = true;

            return prolaz;
        }
    }
}
