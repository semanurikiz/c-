using System;
using System.Collections.Generic;

// Kitap sınıfı
class Kitap
{
    public string KitapAdi { get; set; }
    public string YazarAdi { get; set; }
    public string ISBN { get; set; }
    public int YayinYili { get; set; }

    public Kitap(string kitapAdi, string yazarAdi, string isbn, int yayinYili)
    {
        KitapAdi = kitapAdi;
        YazarAdi = yazarAdi;
        ISBN = isbn;
        YayinYili = yayinYili;
    }

    public void KitapBilgisiGoster()
    {
        Console.WriteLine($"Kitap Adı: {KitapAdi}, Yazar: {YazarAdi}, ISBN: {ISBN}, Yayın Yılı: {YayinYili}");
    }
}

// Kütüphane Yönetim Sistemi sınıfı
class KutuphaneYonetimSistemi
{
    private List<Kitap> kitaplar = new List<Kitap>();

    public void KitapEkle(string kitapAdi, string yazarAdi, string isbn, int yayinYili)
    {
        Kitap yeniKitap = new Kitap(kitapAdi, yazarAdi, isbn, yayinYili);
        kitaplar.Add(yeniKitap);
        Console.WriteLine("Kitap başarıyla eklendi!");
    }

    public void KitaplariListele()
    {
        if (kitaplar.Count == 0)
        {
            Console.WriteLine("Kütüphanede hiç kitap yok.");
            return;
        }

        foreach (Kitap kitap in kitaplar)
        {
            kitap.KitapBilgisiGoster();
        }
    }

    public void KitapAra(string isbn)
    {
        Kitap bulunanKitap = kitaplar.Find(kitap => kitap.ISBN == isbn);
        if (bulunanKitap != null)
        {
            bulunanKitap.KitapBilgisiGoster();
        }
        else
        {
            Console.WriteLine("Kitap bulunamadı.");
        }
    }

    public void KitapSil(string isbn)
    {
        Kitap silinecekKitap = kitaplar.Find(kitap => kitap.ISBN == isbn);
        if (silinecekKitap != null)
        {
            kitaplar.Remove(silinecekKitap);
            Console.WriteLine("Kitap başarıyla silindi.");
        }
        else
        {
            Console.WriteLine("Kitap bulunamadı.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        KutuphaneYonetimSistemi kutuphane = new KutuphaneYonetimSistemi();
        bool cikis = false;

        while (!cikis)
        {
            Console.WriteLine("\n--- Kütüphane Yönetim Sistemi ---");
            Console.WriteLine("1. Kitap Ekle");
            Console.WriteLine("2. Kitapları Listele");
            Console.WriteLine("3. Kitap Ara");
            Console.WriteLine("4. Kitap Sil");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Console.Write("Kitap Adı: ");
                    string kitapAdi = Console.ReadLine();
                    Console.Write("Yazar Adı: ");
                    string yazarAdi = Console.ReadLine();
                    Console.Write("ISBN: ");
                    string isbn = Console.ReadLine();
                    Console.Write("Yayın Yılı: ");
                    int yayinYili = int.Parse(Console.ReadLine());
                    kutuphane.KitapEkle(kitapAdi, yazarAdi, isbn, yayinYili);
                    break;

                case "2":
                    kutuphane.KitaplariListele();
                    break;

                case "3":
                    Console.Write("Aramak istediğiniz kitabın ISBN numarasını girin: ");
                    string aranacakIsbn = Console.ReadLine();
                    kutuphane.KitapAra(aranacakIsbn);
                    break;

                case "4":
                    Console.Write("Silmek istediğiniz kitabın ISBN numarasını girin: ");
                    string silinecekIsbn = Console.ReadLine();
                    kutuphane.KitapSil(silinecekIsbn);
                    break;

                case "5":
                    Console.WriteLine("Çıkış yapılıyor...");
                    cikis = true;
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
