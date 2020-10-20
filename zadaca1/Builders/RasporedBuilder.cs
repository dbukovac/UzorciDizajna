using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class RasporedBuilder : IRasporedBuilder
    {
        CitacDatoteka citac = CitacDatoteka.Instance;
        Tv_kuca tvKuca = Tv_kuca.Instance;
        factory.OsobaCreator osobaCreator = new factory.OsobaCreator();
        factory.UlogaCreator ulogaCreator = new factory.UlogaCreator();
        VrstaCreator vrstaCreator = new VrstaCreator();
        List<Emisija> lista_emisija = new List<Emisija>();
        List<Raspored> lista_rasporeda;
        int rbr = 1;

        public void BuildProgrami()
        {
            citac.CitajDatoteku(citac.tvkuca);
            List<string[]> lista_redaka = citac.DohvatiListuRedaka();
            for (int i = 0; i < lista_redaka.Count; i++)
            {
                if (lista_redaka[i].Length == 5)
                {
                    try
                    {
                        Programi program = new Programi(int.Parse(lista_redaka[i][0]), lista_redaka[i][1], lista_redaka[i][4]);
                        if (lista_redaka[i][2] != "")
                        {
                            program.pocetak = TimeSpan.Parse(lista_redaka[i][2]);
                        }
                        else
                        {
                            program.pocetak = TimeSpan.Parse("00:00");
                        }
                        if (lista_redaka[i][3] != "")
                        {
                            program.kraj = TimeSpan.Parse(lista_redaka[i][3]);
                        }
                        else
                        {
                            program.kraj = TimeSpan.Parse("23:59");
                        }
                        tvKuca.Dodaj(BuildRaspored(program));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Neispravni podaci u retku: " + (i + 1));
                    }
                }
                else
                {
                    Console.WriteLine("Neispravan redak: " + (i + 1) + " u datoteci: " + citac.tvkuca);
                }
            }
        }

        public void BuildEmisije()
        {
            citac.CitajDatoteku(citac.emisije);
            List<string[]> lista_redaka = citac.DohvatiListuRedaka();
            for (int i = 0; i < lista_redaka.Count; i++)
            {
                if (lista_redaka[i].Length == 5)
                {
                    try
                    {
                        Vrsta vrsta = (Vrsta)vrstaCreator.VratiObjekt(int.Parse(lista_redaka[i][2]));
                        Emisija emisija = new Emisija(int.Parse(lista_redaka[i][0]), lista_redaka[i][1], int.Parse(lista_redaka[i][3]), vrsta);
                        string[] osoba_uloga = lista_redaka[i][4].Split(',');
                        if (osoba_uloga.Length > 0)
                        {
                            foreach (var item in osoba_uloga)
                            {
                                string[] split = item.Split('-');
                                if (split.Length == 2)
                                {
                                    Osoba o = (Osoba) osobaCreator.VratiObjekt(int.Parse(split[0]));
                                    Uloga u = (Uloga) ulogaCreator.VratiObjekt(int.Parse(split[1]));
                                    tvKuca.DodajOsobu(o, emisija, 1);
                                    emisija.osobe.Add(o);
                                    emisija.uloge.Add(u);
                                }
                            }
                        }
                        lista_emisija.Add(emisija);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Neispravni podaci u retku: " + (i + 1));
                    }
                }
                else
                {
                    Console.WriteLine("Neispravan redak: " + (i + 1) + " u datoteci: " + citac.emisije);
                }
            }
        }

        public Programi BuildRaspored(Programi program)
        {
            lista_rasporeda = new List<Raspored>();
            citac.CitajDatoteku(program.naziv_datoteke);
            List<string[]> lista_redaka = citac.DohvatiListuRedaka();

            DanIVrijeme(lista_redaka, program);
            DanBezVremena(lista_redaka, program);
            BezDanaIVremena(lista_redaka, program);

            foreach (var item in lista_rasporeda)
            {
                program.Dodaj(item);
            }

            return program;
        }

        private void DanIVrijeme(List<string[]> lista_redaka, Programi program)
        {
            for (int i = 0; i < lista_redaka.Count; i++)
            {
                try
                {
                    Emisija emisija = lista_emisija.Single(a => int.Parse(lista_redaka[i][0]) == a.id);
                    if (lista_redaka[i].Length == 4)
                    {
                        if (lista_redaka[i][1].Contains("-"))
                        {
                            DaniCrtica(lista_redaka, i, emisija, program, 1);
                        }
                        if (lista_redaka[i][1].Contains(","))
                        {
                            DaniZarez(lista_redaka, i, emisija, program, 1);
                        }
                        if (lista_redaka[i][1].Length <= 2)
                        {
                            ProvjeriRasporediGradi(int.Parse(lista_redaka[i][1]), i, emisija, program, lista_redaka);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Greška prilikom kreiranja rasporeda, Program: " + program.naziv_programa + " Emisija: " + lista_redaka[i][0]);
                }
            }
        }

        private void DanBezVremena(List<string[]> lista_redaka, Programi program)
        {
            for (int i = 0; i < lista_redaka.Count; i++)
            {
                try
                {
                    Emisija emisija = lista_emisija.Single(a => int.Parse(lista_redaka[i][0]) == a.id);
                    if (lista_redaka[i].Length == 3)
                    {
                        if (lista_redaka[i][1].Contains("-"))
                        {
                            DaniCrtica(lista_redaka, i, emisija, program, 2);
                        }
                        if (lista_redaka[i][1].Contains(","))
                        {
                            DaniZarez(lista_redaka, i, emisija, program, 2);
                        }
                        if (lista_redaka[i][1].Length <= 2)
                        {
                            KreirajRasporediGradi(int.Parse(lista_redaka[i][1]), i, emisija, program, lista_redaka);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Greška prilikom kreiranja rasporeda, Program: " + program.naziv_programa + " Emisija: " + lista_redaka[i][0]);
                }
            }
        }

        private void BezDanaIVremena(List<string[]> lista_redaka, Programi program)
        {
            for (int i = 0; i < lista_redaka.Count; i++)
            {
                try
                {
                    Emisija emisija = lista_emisija.Single(a => int.Parse(lista_redaka[i][0]) == a.id);
                    if (lista_redaka[i].Length == 2)
                    {
                        PronađiTerminiGradi(i, emisija, program, lista_redaka);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Greška prilikom kreiranja rasporeda, Program: " + program.naziv_programa + " Emisija: " + lista_redaka[i][0]);
                }
            }
        }

        private void ProvjeriRasporediGradi(int dan, int i, Emisija emisija, Programi program, List<string[]> lista_redaka)
        {
            int kontrola = 0;
            TimeSpan pocetak = TimeSpan.Parse(lista_redaka[i][2]);
            TimeSpan kraj = pocetak.Add(TimeSpan.FromMinutes(emisija.trajanje));
            List<Raspored> rasporedi = lista_rasporeda.FindAll(a => dan == a.dan_u_tjednu);
            if(rasporedi.Count > 0)
            {
                if (rasporedi.Any(a => pocetak > a.pocetak && pocetak < a.pocetak.Add(TimeSpan.FromMinutes(emisija.trajanje))))
                    kontrola = 1;
                if (rasporedi.Any(a => kraj > a.pocetak && kraj < a.pocetak.Add(TimeSpan.FromMinutes(emisija.trajanje))))
                    kontrola = 1;
            }
            if(kontrola == 0)
            {
                Gradi(lista_redaka, dan, emisija, program, i, pocetak);
            }
            else
            {
                Console.WriteLine("Kolizija u terminima emisija: "+emisija.naziv_emisije+" s početkom u: "+pocetak+" trajanja: "+emisija.trajanje+" u danu: "+dan+" na programu: "+program.naziv_programa);
            }
        }

        private void KreirajRasporediGradi(int dan, int i, Emisija emisija, Programi program, List<string[]> lista_redaka)
        {
            List<Raspored> rasporedi = lista_rasporeda.FindAll(a => dan == a.dan_u_tjednu);
            TimeSpan pocetak = PronađiTermin(rasporedi, emisija, program);
            if(pocetak != TimeSpan.Parse("23:59"))
            {
                Gradi(lista_redaka, dan, emisija, program, i, pocetak);
            }
            else
            {
                Console.WriteLine("Nema prigodnog termina za emisiju");
            }
        }

        private void PronađiTerminiGradi(int i, Emisija emisija, Programi program, List<string[]> lista_redaka)
        {
            int x = 0;
            for (int j = 1; j <= 7; j++)
            {
                TimeSpan pocetak;
                List<Raspored> rasporedi = lista_rasporeda.FindAll(a => j == a.dan_u_tjednu);
                if(rasporedi.Count == 0)
                {
                    pocetak = program.pocetak;
                    Gradi(lista_redaka, j, emisija, program, i, pocetak);
                    x = 1;
                    break;
                }
                else
                {
                    pocetak = PronađiTermin(rasporedi, emisija, program);

                    if (pocetak != TimeSpan.Parse("23:59"))
                    {
                        Gradi(lista_redaka, j, emisija, program, i, pocetak);
                        x = 1;
                        break;
                    }
                }
                
            }
            if (x == 0)
                Console.WriteLine("Nije bilo mogućeg termina za emisiju");
        }

        private TimeSpan PronađiTermin(List<Raspored> rasporedi, Emisija emisija, Programi program)
        {
            TimeSpan pocetak = TimeSpan.Parse("23:59");
            int kontrola = 0;
            if (program.pocetak.Add(TimeSpan.FromMinutes(emisija.trajanje)) < rasporedi[0].pocetak)
            {
                pocetak = program.pocetak;
                kontrola = 1;
            }
            if (kontrola == 0)
            {
                for (int j = 0; j < rasporedi.Count - 1; j++)
                {
                    TimeSpan kraj_prethodne = rasporedi[j].pocetak.Add(TimeSpan.FromMinutes(((Emisija)rasporedi[j].emisija).trajanje));
                    TimeSpan pocetak_sljedece = rasporedi[j + 1].pocetak;
                    if (kraj_prethodne.Add(TimeSpan.FromMinutes(emisija.trajanje)) < pocetak_sljedece)
                    {
                        pocetak = kraj_prethodne;
                        kontrola = 1;
                        break;
                    }
                }
            }
            if (kontrola == 0)
            {
                TimeSpan kraj_zadnje = rasporedi.Last().pocetak.Add(TimeSpan.FromMinutes(((Emisija)rasporedi.Last().emisija).trajanje));
                if (kraj_zadnje.Add(TimeSpan.FromMinutes(emisija.trajanje)) < program.kraj)
                {
                    pocetak = kraj_zadnje;
                    kontrola = 1;
                }
            }
            return pocetak;
        }

        private void DaniCrtica(List<string[]> lista_redaka, int i, Emisija emisija, Programi program, int kontrola)
        {
            string[] dan_u_tjednu1 = lista_redaka[i][1].Split('-');
            if (dan_u_tjednu1.Length == 2)
            {
                for (int j = int.Parse(dan_u_tjednu1[0]); j <= int.Parse(dan_u_tjednu1[1]); j++)
                {
                    if(kontrola == 1)
                        ProvjeriRasporediGradi(j, i, emisija, program, lista_redaka);
                    if (kontrola == 2)
                        KreirajRasporediGradi(j, i, emisija, program, lista_redaka);

                }
            }
        }

        private void DaniZarez(List<string[]> lista_redaka, int i, Emisija emisija, Programi program, int kontrola)
        {
            string[] dan_u_tjednu2 = lista_redaka[i][1].Split(',');
            if (dan_u_tjednu2.Length > 1)
            {
                for (int j = 0; j < dan_u_tjednu2.Length; j++)
                {
                    if(kontrola == 1)
                        ProvjeriRasporediGradi(int.Parse(dan_u_tjednu2[j]), i, emisija, program, lista_redaka);
                    if (kontrola == 2)
                        KreirajRasporediGradi(int.Parse(dan_u_tjednu2[j]), i, emisija, program, lista_redaka);
                }
            }
        }

        private void Gradi(List<string[]> lista_redaka, int dan_u_tjednu, Emisija emisija, Programi program, int i, TimeSpan pocetak)
        {
            Raspored raspored = new Raspored(rbr, emisija, dan_u_tjednu, pocetak);
            rbr++;
            int x = 1;
            if(lista_redaka[i].Length == 4)
            {
                x = 3;
            }
            if(lista_redaka[i].Length == 3)
            {
                x = 2;
            }
            if (lista_redaka[i][x] != "")
            {
                string[] split = lista_redaka[i][x].Split('-');
                Osoba osoba = (Osoba) osobaCreator.VratiObjekt(int.Parse(split[0]));
                Uloga uloga = (Uloga) ulogaCreator.VratiObjekt(int.Parse(split[1]));
                program.DodajOsobu(osoba, raspored, 2);
                foreach (var item in emisija.osobe)
                {
                    program.DodajOsobu(item, emisija, 1);
                }
                raspored.osoba.Add(osoba);
                raspored.uloga.Add(uloga);
            }
            lista_rasporeda.Add(raspored);
            lista_rasporeda = lista_rasporeda.OrderBy(a => a.pocetak).ToList();
        }
    }
}
