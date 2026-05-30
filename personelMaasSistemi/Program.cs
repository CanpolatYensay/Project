using System;

namespace personelMaasSistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            Personel mudur = new Mudur("Ahmet","Mehmet",34,60000,20000);
            mudur.BilgiGöster();
            Console.WriteLine($"Toplam Maaş: {mudur.MaasHesapla()}");
        }
    }


    class Personel
    {
        public string Ad {get; private set;}
        public string Soyad{get; private set;}
        public int Yas{get; private set;}

        protected double maas;

        public Personel(string ad, string soyad, int yas)
        {
            Ad=ad;
            Soyad=soyad;
            Yas=yas;
        }

        public virtual double MaasHesapla()
        {
            return maas;
        }

        public virtual void BilgiGöster()
        {
            Console.WriteLine($"Personel: {Ad}, {Soyad}, {Yas}");
        }
    }

    class Mudur : Personel
    {
        public double Bonus{get; private set;}

        public Mudur(string ad, string soyad, int yas, double maas, double bonus):base(ad,soyad,yas)
        {
            this.maas=maas;
            this.Bonus=bonus;
        }

        public override double MaasHesapla()
        {
            return maas + Bonus;
        }

        public override void BilgiGöster()
        {
            base.BilgiGöster();
            Console.WriteLine($"Maaş: {MaasHesapla()}");
        }
    }




}