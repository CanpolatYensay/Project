
using System;
using System.Collections.Generic;

class Hesap
{
    public string HesapSahibi { get; set; }             // ilk değerini atamak için
    public decimal Bakiye { get; private set; }

    // Transaction geçmişini saklamak için liste
    public List<string> Gecmis { get; private set; }

    public Hesap(string hesapSahibi, decimal bakiye)
    {
        HesapSahibi = hesapSahibi;
        Bakiye = bakiye;
        Gecmis = new List<string>();
        Gecmis.Add($"[Başlangıç] Hesap oluşturuldu. Başlangıç bakiye: {bakiye} TL");
    }

    public void ParaYatir(decimal miktar)
    {
        Bakiye += miktar;
        Gecmis.Add($"[Yatırma] {miktar} TL yatırıldı. Yeni bakiye: {Bakiye} TL");
    }

    public bool ParaCek(decimal miktar)
    {
        if (miktar > Bakiye)
        {
            Gecmis.Add($"[Başarısız Çekim] {miktar} TL çekilemedi (yetersiz bakiye).");
            return false;
        }

        Bakiye -= miktar;
        Gecmis.Add($"[Çekim] {miktar} TL çekildi. Yeni bakiye: {Bakiye} TL");
        return true;
    }

    public void GecmisGoster()
    {
        Console.WriteLine("\n--- İşlem Geçmişi ---");
        foreach (var kayit in Gecmis)
        {
            Console.WriteLine(kayit);
        }
    }
}

class Program
{
    static void Main()
    {
        Hesap hesap = new Hesap("Canpolat", 1000); // örnek hesap

        while (true)
        {
            Console.WriteLine("\n--- BANKA HESAP SİSTEMİ ---");
            Console.WriteLine("1- Bakiye Görüntüle");
            Console.WriteLine("2- Para Yatır");
            Console.WriteLine("3- Para Çek");
            Console.WriteLine("4- İşlem Geçmişi");
            Console.WriteLine("5- Çıkış");
            Console.Write("Seçim: ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Console.WriteLine($"\nMevcut bakiye: {hesap.Bakiye} TL");
                    break;

                case "2":
                    Console.Write("\nYatırılacak miktar: ");
                    decimal yatir = Decimal.Parse(Console.ReadLine());
                    hesap.ParaYatir(yatir);
                    Console.WriteLine("Para yatırıldı!");
                    break;

                case "3":
                    Console.Write("\nÇekilecek miktar: ");
                    decimal cek = Decimal.Parse(Console.ReadLine());
                    if (hesap.ParaCek(cek))
                        Console.WriteLine("Para çekildi!");
                    else
                        Console.WriteLine("Yetersiz bakiye!");
                    break;

                case "4":
                    hesap.GecmisGoster();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Hatalı seçim!");
                    break;
            }
            Console.ReadLine();
        }
        
    }
}






