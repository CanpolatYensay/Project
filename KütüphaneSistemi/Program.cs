using System;
using System.Collections.Generic;

class Kitap
{
    // Static sayaç (kaç kitap oluşturulduğunu tutar)
    public static int Sayac = 0;

    // Properties
    public int Id { get; private set; }
    public string Ad { get; set; }
    public string Yazar { get; set; }
    public int SayfaSayisi { get; set; }

    // Constructor
    public Kitap(string ad, string yazar, int sayfaSayisi)
    {
        Sayac++;
        Id = Sayac;
        Ad = ad;
        Yazar = yazar;
        SayfaSayisi = sayfaSayisi;
    }
}

class Program
{
    static List<Kitap> kitaplar = new List<Kitap>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- KÜTÜPHANE YÖNETİM SİSTEMİ ---");
            Console.WriteLine("1- Kitap Ekle");
            Console.WriteLine("2- Kitap Listele");
            Console.WriteLine("3- Kitap Ara");
            Console.WriteLine("4- Çıkış");
            Console.Write("Seçim: ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    KitapEkle();
                    break;
                case "2":
                    KitapListele();
                    break;
                case "3":
                    KitapAra();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Hatalı seçim!");
                    break;
            }
        }
    }

    static void KitapEkle()
    {
        Console.Write("Kitap adı: ");
        string ad = Console.ReadLine();

        Console.Write("Yazar: ");
        string yazar = Console.ReadLine();

        Console.Write("Sayfa sayısı: ");
        int sayfa = int.Parse(Console.ReadLine());

        Kitap yeniKitap = new Kitap(ad, yazar, sayfa);
        kitaplar.Add(yeniKitap);

        Console.WriteLine($"Kitap eklendi! (ID: {yeniKitap.Id})");
    }

    static void KitapListele()
    {
        Console.WriteLine("\n--- KİTAP LİSTESİ ---");

        if (kitaplar.Count == 0)
        {
            Console.WriteLine("Hiç kitap yok.");
            return;
        }

        foreach (var k in kitaplar)
        {
            Console.WriteLine($"ID: {k.Id} | {k.Ad} - {k.Yazar} ({k.SayfaSayisi} sayfa)");
        }
    }

    static void KitapAra()
    {
        Console.Write("Aranacak kitap adı: ");
        string arama = Console.ReadLine().ToLower();

        var bulunanlar = kitaplar.FindAll(k => k.Ad.ToLower().Contains(arama));

        if (bulunanlar.Count == 0)
        {
            Console.WriteLine("Kitap bulunamadı.");
            return;
        }

        Console.WriteLine("\n--- Arama Sonuçları ---");
        foreach (var k in bulunanlar)
        {
            Console.WriteLine($"ID: {k.Id} | {k.Ad} - {k.Yazar}");
        }
    }
}

