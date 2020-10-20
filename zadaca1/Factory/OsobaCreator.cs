using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1.factory
{
    class OsobaCreator : ObjektCreator
    {
        public override List<Objekt> Kreiraj()
        {
            List<Objekt> lista = new List<Objekt>();
            CitacDatoteka citac = CitacDatoteka.Instance;
            citac.CitajDatoteku(citac.osobe);
            List<string[]> lista_redaka = citac.DohvatiListuRedaka();
            for (int i = 0; i < lista_redaka.Count; i++)
            {
                if (lista_redaka[i].Length == 2)
                {
                    try
                    {
                        Osoba osoba = new Osoba(int.Parse(lista_redaka[i][0]), lista_redaka[i][1]);
                        lista.Add(osoba);
                    }
                    catch
                    {
                        Console.WriteLine("Neispravni podaci u retku: " + (i + 1));
                    }
                }
                else
                {
                    Console.WriteLine("Neispravan redak: " + (i + 1) + " u datoteci: " + citac.osobe);
                }
            }
            return lista;
        }
    }
}
