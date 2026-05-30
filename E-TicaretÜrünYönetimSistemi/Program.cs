using System;
using System.Collections.Generic;

namespace ETicaretUrunSistemi
{
    // ABSTRACT BASE CLASS
    abstract class Urun
    {
        // Encapsulation
        private string ad;
        private double fiyat;

        protected int stokMiktari; // protected üye

        public string Ad
        {
            get { return ad; }
            set { ad = value; }
        }

        public double Fiyat
        {
            get { return fiyat; }
            set { fiyat = value > 0 ? value : 0; }
        }

        // Constructor
        public Urun(string ad, double fiyat, int stok)
        {
            Ad = ad;
            Fiyat = fiyat;
            stokMiktari = stok;
        }

        // Ortak davranış
        public virtual double KdvHesapla()
        {
            return Fiyat * 0.18;
        }

        // Soyut metot
        public abstract void UrunBilgisiGoster();
    }

    // ELEKTRONİK
    class Elektronik : Urun
    {
        public string Marka { get; set; }
        public int GarantiSuresi { get; set; }

        public Elektronik(string ad, double fiyat, int stok, string marka, int garanti)
            : base(ad, fiyat, stok)
        {
            Marka = marka;
            GarantiSuresi = garanti;
        }

        public override double KdvHesapla()
        {
            return Fiyat * 0.20;
        }

        public override void UrunBilgisiGoster()
        {
            Console.WriteLine($"[Elektronik] {Ad} | Marka: {Marka} | Fiyat: {Fiyat}₺ | Garanti: {GarantiSuresi} yıl | Stok: {stokMiktari}");
        }
    }

    // GİYİM
    class Giyim : Urun
    {
        public string Beden { get; set; }
        public string Renk { get; set; }
        public string KumasTipi { get; set; }

        public Giyim(string ad, double fiyat, int stok, string beden, string renk, string kumas)
            : base(ad, fiyat, stok)
        {
            Beden = beden;
            Renk = renk;
            KumasTipi = kumas;
        }

        public override void UrunBilgisiGoster()
        {
            Console.WriteLine($"[Giyim] {Ad} | Beden: {Beden} | Renk: {Renk} | Kumaş: {KumasTipi} | Fiyat: {Fiyat}₺ | Stok: {stokMiktari}");
        }
    }

    // KİTAP
    class Kitap : Urun
    {
        public string Yazar { get; set; }
        public string Yayinevi { get; set; }
        public int SayfaSayisi { get; set; }

        public Kitap(string ad, double fiyat, int stok, string yazar, string yayinevi, int sayfa)
            : base(ad, fiyat, stok)
        {
            Yazar = yazar;
            Yayinevi = yayinevi;
            SayfaSayisi = sayfa;
        }

        public override void UrunBilgisiGoster()
        {
            Console.WriteLine($"[Kitap] {Ad} | Yazar: {Yazar} | YayınEvi: {Yayinevi} | Sayfa: {SayfaSayisi} | Fiyat: {Fiyat}₺ | Stok: {stokMiktari}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Koleksiyon
            List<Urun> urunler = new List<Urun>();

            // 3 farklı ürün
            urunler.Add(new Elektronik("Laptop", 25000, 5, "Dell", 2));
            urunler.Add(new Giyim("Tişört", 350, 20, "M", "Siyah", "Pamuk"));
            urunler.Add(new Kitap("Clean Code", 450, 10, "Robert C. Martin", "Prentice Hall", 464));

            Console.WriteLine("---- ÜRÜN LİSTESİ ----\n");

            // Polymorphism
            foreach (Urun urun in urunler)
            {
                urun.UrunBilgisiGoster();
                Console.WriteLine($"KDV: {urun.KdvHesapla()}₺");
                Console.WriteLine("----------------------");
            }

            Console.ReadLine();
        }
    }
}
