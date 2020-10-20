using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca1
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = Controller.Instance;
            controller.PostaviView(0);
            if (args.Count() == 0)
                args = new string[10] { "-t", "DZ_3_tvkuca.txt", "-e", "DZ_3_emisije.txt", "-o", "DZ_3_osobe.txt", "-u", "DZ_3_uloge.txt", "-v", "DZ_3_te.txt" };
            if (args.Count() == 10)
            {
                if (args[0].StartsWith("-") && args[2].StartsWith("-") && args[4].StartsWith("-") && args[6].StartsWith("-") && args[8].StartsWith("-"))
                {
                    if(args[1].EndsWith(".txt") && args[3].EndsWith(".txt") && args[5].EndsWith(".txt") && args[7].EndsWith(".txt") && args[9].EndsWith(".txt"))
                    {
                        CitacDatoteka citac = CitacDatoteka.Instance;
                        Tv_kuca tv_Kuca = Tv_kuca.Instance;
                        

                        Console.WriteLine();

                        if (citac.PostaviPutanja(args))
                        {
                            RasporedDirector rasporedDirector = new RasporedDirector();
                            RasporedBuilder rasporedBuilder = new RasporedBuilder();

                            int x = 1;
                            try
                            {                                
                                rasporedDirector.Builder = rasporedBuilder;
                                rasporedDirector.buildRaspored();

                            }
                            catch(Exception e)
                            {
                                x = 0;
                            }

                            FunkcijeIzbornika funkcijeIzbornika = new FunkcijeIzbornika();
                            
                            while (x == 1)
                            {
                                funkcijeIzbornika.IspisIzbornika();

                                try{
                                    string s = Console.ReadLine();
                                    int izbor = int.Parse(s);
                                    if (izbor == 1)
                                    {
                                        controller.IspisA("Unesite ID programa i dan u tjednu(1-7) u formatu x-y");
                                        string str = Console.ReadLine();
                                        string[] split = str.Split('-');
                                        funkcijeIzbornika.IspisVremenskogPlana(int.Parse(split[0]), int.Parse(split[1]));
                                    }
                                    else if (izbor == 2)
                                    {
                                        controller.IspisA("Unesite ID programa i dan u tjednu(1-7) u formatu x-y");
                                        string str = Console.ReadLine();
                                        string[] split = str.Split('-');
                                        funkcijeIzbornika.IspisZaradeReklama(int.Parse(split[0]), int.Parse(split[1]));
                                    }
                                    else if (izbor == 3)
                                    {
                                        controller.IspisA("Unesite ID vrste emisije");
                                        string str = Console.ReadLine();
                                        funkcijeIzbornika.IspisEmisijaPoVrsti(int.Parse(str));
                                    }
                                    else if (izbor == 4)
                                    {
                                        controller.IspisA("Unesite ID osobe i ID postojece uloga i ID nove uloge u formatu x-y-z");
                                        string str = Console.ReadLine();
                                        string[] split = str.Split('-');
                                        funkcijeIzbornika.ZamjenaUloga(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
                                    }
                                    else if (izbor == 5)
                                    {
                                        controller.IspisA("Unesite jedinstveni broj emisije za obrisati");
                                        string str = Console.ReadLine();
                                        funkcijeIzbornika.BrisanjeEmisije(int.Parse(str));
                                    }
                                    else if (izbor == 6)
                                    {
                                        controller.IspisA("Unesite jedinstveni broj pohrane za vratiti");
                                        string str = Console.ReadLine();
                                        funkcijeIzbornika.VracanjePodataka(int.Parse(str));
                                    }
                                    else if (izbor == 7)
                                    {
                                        controller.IspisA("");
                                        funkcijeIzbornika.IspisPodatakaPohrane();
                                    }
                                    else if (izbor == 8)
                                    {
                                        controller.IspisA("Unesite jedinstveni broj emisije za pretražiti");
                                        string str = Console.ReadLine();
                                        funkcijeIzbornika.EmisijaPoBroju(int.Parse(str));
                                    }
                                    else if (izbor == 9)
                                    {
                                        controller.IspisA("Unesite 0 za ispis bez brojeva reda ili 1 za ispis sa brojevima reda");
                                        string str = Console.ReadLine();
                                        funkcijeIzbornika.PromjenaPogleda(int.Parse(str));
                                    }
                                    else if (izbor == 10)
                                    {
                                        File.Delete("data.dat");
                                        x = 0;
                                    }
                                }
                                catch (Exception e)
                                {
                                    controller.Ispis("");
                                    controller.Ispis("Neispravan unos");
                                    controller.Ispis(e.Message);
                                    controller.Ispis(e.TargetSite.ToString());
                                }
                            }
                        }
                        else
                        {
                            controller.Ispis("Neispravna zastavica");
                        }
                    }
                    else
                    {
                        controller.Ispis("Neispravne argumenti(datoteke nisu txt oblika)");
                    }
                }
                else
                {
                    controller.Ispis("Neispravan argumenti(nedostaje zastavica zastavice)");
                }
            }
            else
            {
                controller.Ispis("Nema dovoljno argumenata");
            }
        }
    }
}
