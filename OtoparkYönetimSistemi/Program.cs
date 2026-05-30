using System;
using System.Collections.Generic;

public class Arac
{
    public string Plaka { get; set; }
}

public class Otopark
{

    public int Kapasite { get; set; }
    public List<Arac> AracListesi { get; set; }

    public Otopark(int kapasite)
    {
        Kapasite = kapasite;
        AracListesi = new List<Arac>();
    }



    public void aracEkle(string plaka)
    {
        if (AracListesi.Count >= Kapasite)
        {
            Console.WriteLine("Otopark Dolu");
            return;
        }

        foreach (Arac a in AracListesi)
        {
            if (a.Plaka == plaka)
            {
                Console.WriteLine("Bu Araç Zaten İçeride !!");
                return;
            }
        }



        Arac yeniArac = new Arac();
        yeniArac.Plaka = plaka;

        AracListesi.Add(yeniArac);

        Console.WriteLine("Araç Otoparka Eklendi");



    }

    public void aracCıkar(string plaka)
    {

        foreach (Arac a in AracListesi)
        {

            if (a.Plaka == plaka)
            {
                AracListesi.Remove(a);
                Console.WriteLine("Araç Otoparktan Çıkarıldı");
                return;
            }

        }

        Console.WriteLine("Araç Bulunamadı");


    }

    public void durumGöster()
    {
        Console.WriteLine("Toplam Araç Sayısı : " + AracListesi.Count);

        foreach (Arac a in AracListesi)
        {
            Console.WriteLine("Plaka : " + a.Plaka);
        }

    }



}

class Program
{
    static void Main(string[] args)
    {


        Otopark otopark = new Otopark(5);

        bool devam = true;



        while (devam)
        {

            Console.WriteLine("\n===== OTOPARK TAKİP SİSTEMİ =====");
            Console.WriteLine("1- Araç Ekle");
            Console.WriteLine("2- Araç Çıkar");
            Console.WriteLine("3- Durum Göster");
            Console.WriteLine("4- Çıkış");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine();


            switch (secim)
            {
                case "1":
                    Console.Write("Plaka Giriniz: ");
                    string plakaEkle = Console.ReadLine();
                    otopark.aracEkle(plakaEkle);
                    break;


                case "2":
                    Console.Write("Çıkarılacak Aracın Plakası: ");
                    string plakaCikar = Console.ReadLine();
                    otopark.aracCıkar(plakaCikar);
                    break;


                case "3":
                    otopark.durumGöster();
                    break;


                case "4":
                    devam = false;
                    Console.WriteLine("Program Sonlandırılıyor...");
                    break;
                    

                default:
                    Console.WriteLine("Geçersiz Seçim!");
                    break;
            }


        }



    }


}