using System;
using System.Linq;

namespace SifreKontrol
{
    class Program
    {
        static void Main(string[] args)
        {
        Giriniz:
            string metin;
            string _metin = "";
            bool kucuk = false;
            bool buyuk = false;
            bool sayi = false;
            bool _turkceKarakter = false;
            bool ozelKarakter = false;
            bool ardisikSayi = false;
            Console.Write("Yazı giriniz:");

            metin = Convert.ToString(Console.ReadLine());
            string turkce = "ğĞçÇşŞüÜöÖıİ ";
            var _turkce = turkce.ToCharArray();
            for (int i = 0; i < metin.Length; i++)
            {
                if (Char.IsUpper(metin[i]))
                {
                    kucuk = true;
                }

                if (Char.IsLower(metin[i]))
                {
                    buyuk = true;
                }

                if (Char.IsNumber(metin[i]))
                {
                    _metin = _metin.ToString() + metin[i];
                    sayi = true;
                    if (_metin.Length > 1)
                    {
                        for (int k = 0; k < _metin.Length; k++)
                        {
                            var sonuc = Convert.ToInt32(_metin[k] - _metin[k + 1]);
                            if (sonuc == 0 || sonuc == 1 || sonuc == -1)
                            {
                                ardisikSayi = true;
                                break;
                            }
                            else
                            {
                                _metin = _metin.Substring(1, 1);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    _metin = "";
                    if (!char.IsControl(metin[i]) && !char.IsLetter(metin[i]))
                    {
                        ozelKarakter = true;
                    }
                }

                if (_turkce.Contains(metin[i]))
                {
                    _turkceKarakter = true;
                }

            }
            if (!kucuk || !buyuk)
            {
                Console.WriteLine("En az bir büyük bir küçük harf bulanması zorunludur.");
            }
            else if (_turkceKarakter)
            {
                Console.WriteLine("Şifrenizde türkçe karakter ve boşluk kullanmayınız.'ğ, Ğ, ç, Ç, ş, Ş, ü, Ü, ö, Ö, ı, İ'");
            }
            else if (!sayi)
            {
                Console.WriteLine("En az bir sayı bulanması zorunludur.");
            }
            else if (!ozelKarakter)
            {
                Console.WriteLine("Ozel karakter bulunması zorunludur.");
            }
            else if (ardisikSayi)
            {
                Console.WriteLine("Ardışık sayı kullanmayınız.");
            }
            else
            {
                Console.Write(metin.ToString() + "\n");
            }

            goto Giriniz;

        }
    }
}
