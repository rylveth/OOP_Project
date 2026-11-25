//Week 1 

public enum CihazTuru
{
    Lamba,
    Klima,
    GuvenlikSistemi
}

public class Cihaz
{
    public string Kimlik { get; private set; }
    public string Ad { get; set; }
    public bool AcikMi { get; set; }
    public CihazTuru Tur { get; set; }

    public Cihaz(string kimlik, string ad, CihazTuru cihazTuru)
    {
        Kimlik = kimlik;
        Ad = ad;
        AcikMi = false;
        Tur = cihazTuru;
    }

    public void Ac()
    {
        AcikMi = true;
    }

    public void Kapat()
    {
        AcikMi = false;
    }

    public void BilgileriGoster()
    {
        Console.WriteLine($"Kimlik: {Kimlik}");
        Console.WriteLine($"Ad: {Ad}");
        Console.WriteLine($"Tür: {Tur}");
        Console.WriteLine($"Durum: {AcikMi}");
    }
    
}

class week1
{
    static void Main()
    {
        List<Cihaz> cihazlar = new List<Cihaz>();

        while (true)
        {
            Console.WriteLine("MENÜ\n1. Cihazları Listele\n2. Yeni Cihaz Ekle\n3. Cihazı Aç\n4. Cihazı Kapat\n0. Çıkış");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();
            Console.WriteLine();

            switch (secim)
            {
                case "1":
                    if (cihazlar.Count == 0)
                    {
                        Console.WriteLine("Kayıtlı cihaz bulunmamaktadır.");
                    }
                    else
                    {
                        foreach (Cihaz cihaz in cihazlar)
                        {
                            cihaz.BilgileriGoster();
                        }
                    }

                    break;
                case "2":
                    try
                    {
                        Console.Write("Cihaz Kimliği: ");
                        string yeniKimlik = Console.ReadLine();
                        foreach (Cihaz c in cihazlar)
                        {
                            if (c.Kimlik == yeniKimlik)
                            {
                                throw new Exception("Bu kimliğe sahip bir cihaz var.");
                            }
                        }

                        Console.Write("Cihaz Adı: ");
                        string yeniAd = Console.ReadLine();

                        Console.Write("Cihaz Türü Seçiniz (1: Lamba, 2: Klima, 3: Güvenlik Sistemi): ");
                        string turSecim = Console.ReadLine();

                        CihazTuru secilenTur;

                        switch (turSecim)
                        {
                            case "1":
                                secilenTur = CihazTuru.Lamba;
                                break;
                            case "2":
                                secilenTur = CihazTuru.Klima;
                                break;
                            case "3":
                                secilenTur = CihazTuru.GuvenlikSistemi;
                                break;
                            default:
                                throw new Exception("Geçersiz cihaz türü seçtiniz.");
                        }

                        Cihaz yeniCihaz = new Cihaz(yeniKimlik, yeniAd, secilenTur);
                        cihazlar.Add(yeniCihaz);
                        Console.WriteLine("Cihaz başarıyla eklendi.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"HATA: {ex.Message}");
                    }

                    break;
                case "3":
                    try
                    {
                        Console.Write("Açmak istediğiniz cihazın kimliğini giriniz: ");
                        string acKimlik = Console.ReadLine();
                        bool bulunduMu = false;

                        foreach (Cihaz cihaz in cihazlar)
                        {
                            if (cihaz.Kimlik == acKimlik)
                            {
                                cihaz.Ac();
                                Console.WriteLine($"{cihaz.Ad} açıldı.");
                                bulunduMu = true;
                                break;
                            }
                        }

                        if (!bulunduMu) throw new Exception("Belirtilen kimliğe sahip bir cihaz bulunamadı!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"HATA: {ex.Message}");
                    }

                    break;
                case "4":
                    try
                    {
                        Console.Write("Kapatmak istediğiniz cihazın kimliğini giriniz: ");
                        string kapatKimlik = Console.ReadLine();
                        bool bulunduMu = false;

                        foreach (Cihaz cihaz in cihazlar)
                        {
                            if (cihaz.Kimlik == kapatKimlik)
                            {
                                cihaz.Kapat();
                                Console.WriteLine($"{cihaz.Ad} kapandi.");
                                bulunduMu = true;
                                break;
                            }
                        }

                        if (!bulunduMu) throw new Exception("Belirtilen kimliğe sahip bir cihaz bulunamadı!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"HATA: {ex.Message}");
                    }

                    break;
                case "0":
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;
                default:
                    Console.WriteLine("Gecersiz secim.");
                    break;
            }
        }
    }
}