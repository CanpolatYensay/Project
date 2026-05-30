


Console.WriteLine("----- Akıllı Ev Sistemine Hoşgeldiniz ------");


Isik lamba = new Isik(){Ad="Lamba",Parlaklik=60};
Isitici isitici = new Isitici(){Ad="Isıtıcı"};
Kamera kamera = new Kamera(){Ad="Kamera"};

bool devam = true;

while (devam)
{
    Console.WriteLine("Hangi cihazla işlem yapmak istersiniz? : ");
    Console.WriteLine("1- Lamba");
    Console.WriteLine("2- Isıtıcı");
    Console.WriteLine("3- Kamera");
    Console.WriteLine("4- Çıkış");

    string islem=Console.ReadLine();

    switch (islem)
    {
        case "1":
            Console.WriteLine("Ne yapmak istiyorsunuz?");
            Console.WriteLine("1- Işığı Aç");
            Console.WriteLine("2- Işığı Kapat");
            Console.WriteLine("3- Işığı Parlaklık Ayarla");
            Console.WriteLine("4- Durum Göster");
            Console.WriteLine("5- Çıkış");
            string secim1 = Console.ReadLine();
            switch (secim1)
            {
                case "1":
                    lamba.Ac();
                    break;
                case "2":
                    lamba.Kapat();
                    break;
                case "3":
                    Console.WriteLine("Yeni Parlaklık Değeri: ");
                    int p = int.Parse(Console.ReadLine());
                    lamba.Parlaklik=p;
                    Console.WriteLine("Parlaklık " + lamba.Parlaklik + " olarak ayarlandı.");
                    break;
                case "4":
                    lamba.DurumGoster();
                    break;
                case "5":
                    Console.WriteLine("Çıkış Yapılıyor..");
                    devam = false;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçenek!");
                    break;
                    
            }

            break;
        case "2":
            Console.WriteLine("Ne yapmak istiyorsunuz?");
            Console.WriteLine("1- Isıtıcıyı Aç");
            Console.WriteLine("2- Isıtıcıyı Kapat");
            Console.WriteLine("3- Durum Göster");
            Console.WriteLine("4- Çıkış");
            string secim2 = Console.ReadLine();

            switch (secim2)
            {
                case "1":
                    isitici.Ac();
                    break;
                case "2":
                    isitici.Kapat();
                    break;
                case "3":
                    isitici.DurumGoster();
                    break;
                case "4":
                    Console.WriteLine("Çıkış Yapılıyor..");
                    devam = false;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçenek!");
                    break;
            }
            break;
        case "3":
            Console.WriteLine("Ne yapmak istiyorsunuz?");
            Console.WriteLine("1- Kamera Aç");
            Console.WriteLine("2- Kamera Kapat");
            Console.WriteLine("3- Durumu Göster");
            Console.WriteLine("4- Çıkış");
            string secim3 = Console.ReadLine();

            switch (secim3)
            {
                case "1":
                    kamera.Ac();
                    break;
                case "2":
                    kamera.Kapat();
                    break;
                case "3":
                    kamera.DurumGoster();
                    break;
                case "4":
                    Console.WriteLine("Çıkış Yapılıyor..");
                    devam = false;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçenek!");
                    break;

            }
            break;
        case "4":
            Console.WriteLine("Çıkış Yapılıyor..");
            devam = false;
            break;
        default:
            Console.WriteLine("Geçersiz seçenek!");
            break;       
                    
    }
    

}

Console.WriteLine("Çıkış Yapıldı");



public class Cihaz
{
    
    public string Ad{get; set;}
    public bool AcikMi{get; set;}

    public void Ac()
    {
        AcikMi = true;
        Console.WriteLine(Ad + " Açıldı..");

    }
    public void Kapat()
    {
        AcikMi = false;
        Console.WriteLine(Ad + " Kapatıldı..");
    }

    public void DurumGoster()
    {
        if (AcikMi)
            Console.WriteLine(Ad + " Açık");
        else
            Console.WriteLine(Ad + " Kapalı");
    }
    

}

public class Isik: Cihaz
{
    public int Parlaklik{get; set;}
}

public class Isitici: Cihaz
{
    
}

public class Kamera: Cihaz
{
    
}



