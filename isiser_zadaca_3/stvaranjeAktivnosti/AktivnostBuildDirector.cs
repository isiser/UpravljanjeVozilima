using isiser_zadaca_3.modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.stvaranjeAktivnosti
{
    class AktivnostBuildDirector
    {
        private AktivnostBuilder builder;

        public AktivnostBuildDirector(AktivnostBuilder builder)
        {
            this.builder = builder;
        }

        public Aktivnost construct(String line, int counter)
        {
            String[] args = line.Split(new string[] { "; " }, StringSplitOptions.None);
            Aktivnost aktivnost = null;

            switch (args[0])
            {
                case "0":
                    try {
                        aktivnost = builder.setIdAktivnosti(0).setVrijeme(args[1]).build();
                    } catch (Exception ex) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Aktivnost 0 u redu [" + counter + "] nije ispravna");
                        Console.ResetColor();
                    }
                    break;
                case "1":
                    try
                    {
                        aktivnost = builder.setIdAktivnosti(1).setVrijeme(args[1]).setIdKorisnika(args[2]).setIdLokacije(args[3]).setIdVozila(args[4]).build();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Aktivnost 1 u redu [" + counter + "] nije ispravna");
                        Console.ResetColor();
                    }
                    break;
                case "2":
                    aktivnost = builder.setIdAktivnosti(2).setVrijeme(args[1]).setIdKorisnika(args[2]).setIdLokacije(args[3]).setIdVozila(args[4]).build();
                    break;
                case "3":
                    aktivnost = builder.setIdAktivnosti(3).setVrijeme(args[1]).setIdKorisnika(args[2]).setIdLokacije(args[3]).setIdVozila(args[4]).build();
                    break;
                case "4":
                    if (args.Length.Equals(7))
                    {
                        aktivnost = builder.setIdAktivnosti(4).setVrijeme(args[1]).setIdKorisnika(args[2]).setIdLokacije(args[3]).setIdVozila(args[4]).setBrojKm(args[5]).setProblemKvara(args[6]).build();
                    }
                    else{
                        aktivnost = builder.setIdAktivnosti(4).setVrijeme(args[1]).setIdKorisnika(args[2]).setIdLokacije(args[3]).setIdVozila(args[4]).setBrojKm(args[5]).build();
                    }
                    break;
                case "5":
                    aktivnost = builder.setIdAktivnosti(5).setDatoteka(args[1]).build();
                    break;
                case "6":
                    bool struktura = false, stanje = false;
                    int orgJedinica = 0;
                    String[] opcije = args[1].Split(new string[] { " " }, StringSplitOptions.None);
                    foreach (String i in opcije) {
                        if (i.Equals("struktura"))
                            struktura = true;
                        else if (i.Equals("stanje"))
                            stanje = true;
                        int.TryParse(i, out orgJedinica);
                    }
                    aktivnost = builder.setIdAktivnosti(6).setStruktura(struktura).setStanje(stanje).setOrgJedinicaID(orgJedinica).build();
                    break;
                case "7":
                    bool struktura2 = false, najam = false, zarada = false;
                    int orgJedinica2 = 0;
                    String[] opcije2 = args[1].Split(new string[] { " " }, StringSplitOptions.None);
                    foreach (String i in opcije2)
                    {
                        if (i.Equals("najam"))
                            najam = true;
                        else if (i.Equals("zarada"))
                            zarada = true;
                        else if (i.Equals("struktura"))
                            struktura2 = true;
                        int.TryParse(i, out orgJedinica2);
                    }
                    aktivnost = builder.setIdAktivnosti(7).setStruktura(struktura2).setNajam(najam).setZarada(zarada).setOrgJedinicaID(orgJedinica2).build();
                    break;
                case "8":
                    aktivnost = builder.setIdAktivnosti(8).build();
                    break;
                case "9":
                    aktivnost = builder.setIdAktivnosti(9).build();
                    break;
                case "10":
                    String ostatak = args[1].Trim();
                    String[] argumenti = ostatak.Split(new string[] { " " }, StringSplitOptions.None);
                    aktivnost = builder.setIdAktivnosti(10).setIdKorisnika(argumenti[0]).setDatumOd(argumenti[1]).setDatumDo(argumenti[2]).build();
                    break;
                case "11":
                    String ostatak2 = args[1].Trim();
                    String[] argumenti2 = ostatak2.Split(new string[] { " " }, StringSplitOptions.None);
                    aktivnost = builder.setIdAktivnosti(11).setIdKorisnika(argumenti2[0]).setUplata(Double.Parse(argumenti2[1])).build();
                    break;
                default:
                    aktivnost = null;
                    break;
            }
            return aktivnost;
        }
    }
}
