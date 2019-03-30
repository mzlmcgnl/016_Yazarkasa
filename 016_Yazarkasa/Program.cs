using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _016_Yazarkasa
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal Bakiye = 100,
                    Tutar;
            string[] Hareketler = null,
                     Yedek = null;
            anaMenu:

            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                          Bankamatik                           ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ 1. Para Yatır                                                 ║");
            Console.WriteLine("║ 2. Para Çek                                                   ║");
            Console.WriteLine("║ 3. Hareketler                                                 ║");
            Console.WriteLine("║ 4. Çıkış                                                      ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");

            Console.WriteLine("Bir Menü Seçiniz");

            switch (Console.ReadLine())
            {

                case "1":
                    paraYatir:
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════════════════════╗");
                    Console.WriteLine("║                 Para Yatır                    ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════╝");

                    Console.Write("Yatırmak istediğiniz miktarı giriniz : ");

                    Tutar = decimal.Parse(Console.ReadLine());

                    if (Hareketler == null)
                        Hareketler = new string[1];
                    else
                    {
                        Yedek = Hareketler;
                        Hareketler = new string[Hareketler.Length + 1];
                        for (int i = 0; i < Yedek.Length; i++) Hareketler[i] = Yedek[i];
                    }
                    Hareketler[Hareketler.Length - 1] = $"+\t{Tutar}\t{DateTime.Now.ToShortTimeString()}";
                    Bakiye += Tutar;

                    Console.WriteLine($"Hesabınızda şuan {Bakiye} TL vardır\nBaşka işlem yapmak ister misiniz <e/h> ");
                    secim:
                    switch (Console.ReadLine().ToLower())
                    {
                        case "e": goto paraYatir;
                        case "h": goto anaMenu;
                        default: goto secim;
                    }

                case "2":
                    paraCek:
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════════════════════╗");
                    Console.WriteLine("║                 Para Çek                      ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════╝");

                    Console.Write("Çekmek istediğiniz miktarı giriniz : ");

                    Tutar = decimal.Parse(Console.ReadLine());

                  

                    if (Tutar <= Bakiye)
                    {
                        if (Hareketler == null)
                            Hareketler = new string[1];
                        else
                        {
                            Yedek = Hareketler;
                            Hareketler = new string[Hareketler.Length + 1];
                            for (int i = 0; i < Yedek.Length; i++) Hareketler[i] = Yedek[i];
                        }
                        Hareketler[Hareketler.Length - 1] = $"-\t{Tutar}\t{DateTime.Now.ToShortTimeString()}";
                        Bakiye -= Tutar;


                        Console.WriteLine($"Hesabınızda şuan {Bakiye} TL vardır\nBaşka işlem yapmak ister misiniz <e/h> ");
                        secim1:
                        switch (Console.ReadLine().ToLower())
                        {
                            case "e": goto paraCek;
                            case "h": goto anaMenu;

                            default: goto secim1;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Hesabınızda yeterli bakiye bulunmamaktadır\nBakiyeniz : {Bakiye}\nTekrar denemek ister misiniz? <e/h>");
                        secim2:
                        switch (Console.ReadLine().ToLower())
                        {
                            case "e": goto paraCek;
                            case "h": goto anaMenu;
                            default: goto secim2;
                        }
                    }

                case "3":
                    Console.Clear();
                    Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                      Hareketler                       ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

                    Console.WriteLine("TİP\tTUTAR\tTARİH");
                    Console.WriteLine("═════════════════════════════════════════════════════════");

                    foreach (var item in Hareketler)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "4": break;
                default:
                    goto anaMenu;

                    
            }
            Thread.Sleep(2000);
        }
    }
}
