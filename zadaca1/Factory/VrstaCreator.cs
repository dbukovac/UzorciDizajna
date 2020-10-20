using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class VrstaCreator : ObjektCreator
    {
        public override List<Objekt> Kreiraj()
        {
            List<Objekt> lista = new List<Objekt>();
            CitacDatoteka citac = CitacDatoteka.Instance;
            citac.CitajDatoteku(citac.vrste);
            List<string[]> lista_redaka = citac.DohvatiListuRedaka();
            for (int i = 0; i < lista_redaka.Count; i++)
            {
                if (lista_redaka[i].Length == 4)
                {
                    try
                    {
                        Vrsta vrsta = new Vrsta(int.Parse(lista_redaka[i][0]), lista_redaka[i][1], int.Parse(lista_redaka[i][2]), int.Parse(lista_redaka[i][3]));
                        lista.Add(vrsta);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Neispravni podaci u retku: " + (i + 1));
                    }
                }
                else
                {
                    Console.WriteLine("Neispravan redak: " + (i + 1) + " u datoteci: " + citac.vrste);
                }
            }
            return lista;
        }
    }
}
