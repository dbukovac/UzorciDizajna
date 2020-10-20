using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class FunkcijeIzbornika
    {
        Tv_kuca tvKuca = Tv_kuca.Instance;
        Controller controller = Controller.Instance;

        public void IspisIzbornika()
        {
            controller.Ispis("");
            controller.Ispis("Izbornik");
            controller.Ispis("1. ispis vremenskog plana za program i dan");
            controller.Ispis("2. ispis podataka o zaradi reklama za program i dan");
            controller.Ispis("3. ispis podataka za vrstu emisije");
            controller.Ispis("4. zamjena uloge za osobu");
            controller.Ispis("5. brisanje emisije");
            controller.Ispis("6. vraćanje podataka");
            controller.Ispis("7. ispis podataka pohrane");
            controller.Ispis("8. pretraga emisije po broju");
            controller.Ispis("9. Promjena pogleda");
            controller.Ispis("10. izlaz iz aplikacije");
            controller.IspisA("");
        }

        public void IspisVremenskogPlana(int id_programa, int dan_u_tjednu)
        {
            Component program = tvKuca.VratiObjekt(id_programa, 0);
            program.Ispis(dan_u_tjednu);
        }

        public void IspisZaradeReklama(int id_programa, int dan_u_tjednu)
        {
            Component program = tvKuca.VratiObjekt(id_programa, 0);
            EmisijeIterator iterator = (EmisijeIterator)program.GetIterator(1,0);
            EmisijaVisitor emisijaVisitor = new EmisijaVisitor();

            for (Component r = iterator.First(); !iterator.IsDone; r = iterator.Next())
            {
                if (r != null && r.VratiObjekt(dan_u_tjednu, 0) != null)
                    emisijaVisitor.visitRaspored(r, dan_u_tjednu);
            }

            program.Ispis(98);
            TablicaReklame tablicaRed = new TablicaReklame();
            ReklameIspis reklameIspis = new ReklameIspis(tablicaRed, dan_u_tjednu, emisijaVisitor.trajanje);
            reklameIspis.Crtaj();
        }

        public void IspisEmisijaPoVrsti(int id_vrsta)
        {
            foreach (var item in tvKuca.VratiListu())
            {
                VrsteIterator iterator = (VrsteIterator)item.GetIterator(0, id_vrsta);

                item.Ispis(99);

                for (Component r = iterator.First(); !iterator.IsDone; r = iterator.Next())
                {
                    if(r != null)
                        r.Ispis(0);
                }
            }
        }

        public void ZamjenaUloga(int id_osoba, int id_uloga_postojeca, int id_uloga_nova)
        {
            factory.UlogaCreator u = new factory.UlogaCreator();
            foreach (Programi item in tvKuca.VratiListu())
            {
                try
                {
                    Uloga postojeca = (Uloga)u.VratiObjekt(id_uloga_postojeca);
                    Uloga nova = (Uloga)u.VratiObjekt(id_uloga_nova);
                    foreach (var i in item.osobe)
                    {
                        if (i.id == id_osoba)
                        {
                            i.Notify(postojeca, nova);
                        }
                    }
                    //tvKuca.VratiOsobu(id_osoba).Notify(postojeca, nova);
                }
                catch (Exception e)
                {
                }
            }
        }

        public void BrisanjeEmisije(int id)
        {
            foreach (var item in tvKuca.VratiListu())
            {
                EmisijeIterator iterator = (EmisijeIterator)item.GetIterator(1, 0);

                for (Component r = iterator.First(); !iterator.IsDone; r = iterator.Next())
                {
                    if (r != null && r.VratiObjekt(id, 1) != null)
                    {
                        tvKuca.saveToMemento();
                        item.Makni(r);
                        controller.Ispis("Obrisana je emisija sa jednistvenim brojem: " + id);
                    }
                }
            }
        }

        public void VracanjePodataka(int i)
        {
            tvKuca.restoreFromMemento(i);
            controller.Ispis("Vraćeni su podaci iz pohrane rednog broja: " + i);
        }

        public void IspisPodatakaPohrane()
        {
            tvKuca.Ispis(0);
        }

        public void EmisijaPoBroju(int i)
        {
            tvKuca.TraziEmisiju(i);
        }

        public void PromjenaPogleda(int i)
        {
            controller.PostaviView(i);
        }
    }
}
