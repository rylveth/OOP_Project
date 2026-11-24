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