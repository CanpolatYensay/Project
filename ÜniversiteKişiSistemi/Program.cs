

namespace ÜniversiteKişiSistemi
{
    

    class Program
    {
        static void Main(string[] args)
        {
            
            List<Kisi> kisiler = new List<Kisi>();

            Console.WriteLine("Kaç Kişi Eklenecek: ");
            int sayi = int.Parse(Console.ReadLine());

            for(int i = 0; i<sayi; i++)
            {
                Console.WriteLine("1-Öğrenci");
                Console.WriteLine("2-Akademisyen");

                Console.WriteLine("Seçim");
                int secim = int.Parse(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                    {
                        Console.WriteLine("Ad: ");
                        string ad = Console.ReadLine();
                        Console.WriteLine("Soyad: ");
                        string soyad = Console.ReadLine();
                        Console.WriteLine("Bölüm: ");
                        string bolum = Console.ReadLine();

                        kisiler.Add(new Ogrenci(ad,soyad, bolum));
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Ad: ");
                        string ad = Console.ReadLine();
                        Console.WriteLine("Soyad: ");
                        string soyad = Console.ReadLine();
                        Console.WriteLine("Branş: ");
                        string brans = Console.ReadLine();

                        kisiler.Add(new Akademisyen(ad,soyad, brans));
                        break;
                    }
                    default:
                        Console.WriteLine("Yanlış Seçim !!");
                        break;
                }   
            }

            foreach(Kisi kisi in kisiler)
            {
                kisi.RolYazdir();
                kisi.BilgiYaz();
                Console.WriteLine("-------------------");
            }

        }
        
    }


    public interface IRaporlanabilir
    {
        string RaporOlustur();
    }




    public abstract class Kisi
    {
        private string ad;
        private string soyad;
        

        public string Ad
        {
            get{return ad;}
            set{ad = value;}
        }

        public string Soyad
        {
            get{return soyad;}
            set{soyad=value;}
        }

        protected Kisi(string ad, string soyad)
        {
            Ad=ad;
            Soyad=soyad;
        }

        public virtual void BilgiYaz()
        {
            Console.WriteLine($"Ad: {Ad}");
            Console.WriteLine($"Soyad: {Soyad}");
        }
    
        public abstract void RolYazdir();
      


    }

    class Ogrenci : Kisi, IRaporlanabilir
    {
        private string bolum;

        public string Bolum
        {
            get{return bolum;}
            set{bolum=value;}
        }

        public Ogrenci(string ad, string soyad, string bolum):base(ad, soyad)
        {
            Bolum=bolum;
        }

        public override void BilgiYaz()
        {
            base.BilgiYaz();
            Console.WriteLine($"Bölüm: {Bolum}");
        }

        public override void RolYazdir()
        {
            Console.WriteLine("Rol: Öğrenci..");
        }
        
        public string RaporOlustur()
        {
            return $"Öğrenci İçin Rapor Oluştu..";
        }

    }

    class Akademisyen : Kisi, IRaporlanabilir
    {
        private string brans;

        public string Brans
        {
            get{return brans;}
            set{brans=value;}
        }

        public Akademisyen(string ad, string soyad, string brans):base(ad,soyad)
        {
            Brans=brans;
        }

        public override void BilgiYaz()
        {
            base.BilgiYaz();
            Console.WriteLine($"Branş: {Brans}");
        }

        public override void RolYazdir()
        {
            Console.WriteLine("Rol Akademisyen..");
        }
        
        public string RaporOlustur()
        {
            return $"Akademisyen İçin Rapor Oluştu..";
        }


    }




}



