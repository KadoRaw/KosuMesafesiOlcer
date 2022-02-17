using System.Globalization;

var flag = true;

while (flag)
{
    
    Console.WriteLine("--Merhabalar--");
    Console.WriteLine();
    var adimUzunlugu = GetIntValue("Ortalama bir adımınız kaç santimetre ? : ");
    var adimSayisi = GetIntValue("Bir dakikada kaç adım atıyorsunuz ? : ");
    var sure = GetTimeSpan();
    Console.Clear();
    var sonuc = Calculate.CalculateValue(adimSayisi, adimUzunlugu, sure);
    Console.WriteLine($"Adım Uzunluğu = {adimUzunlugu}\nGeçen Zaman = {sure.ToString()}\nBir dakikada atılan adım sayısı = {adimSayisi}\nToplam atılan adım sayısı = {adimSayisi * sure.TotalMinutes}\n\n Toplam koşu mesafesi = {sonuc} Metre");

    flag = WannaGoAgain();
}
double GetIntValue(string caption)
{
    var flag = true;

    while (flag)
    {
        try
        {
            Console.Write(caption);
            double value = 0;
            var input = Console.ReadLine();
            if (input.Contains('.'))
            {
                value = Double.Parse(input, new CultureInfo("en-US") );    
            }
            else if (input.Contains(','))
            {
                value = Double.Parse(input, new CultureInfo("tr-TR"));
            }
            else
            {
                value = Double.Parse(input, CultureInfo.CurrentCulture);
            }

            return value;
        }
        catch (Exception)
        {
            Console.WriteLine("Girmiş olduğunuz değer bir tam sayı değildir.");
            continue;
        }
    }
    return 0;
}
TimeSpan GetTimeSpan()
{
    var flag = true;

    while (flag)
    {
        try
        {
            Console.WriteLine("Koşu sürenizi giriniz(Saat ve dakika olarak) ");
            Console.WriteLine("");
            Console.Write("Saat: ");
            var kosuSuresiSaat = Convert.ToInt32(Console.ReadLine());
            Console.Write("Dakika: ");
            var kosuSuresiDakika = Convert.ToInt32(Console.ReadLine());

            var saat = new TimeSpan(kosuSuresiSaat, kosuSuresiDakika, 0);
            return saat;
        }
        catch (Exception)
        {
            Console.WriteLine("Girmiş olduğunuz değer bir tam sayı değildir.");
            continue;
        }
    }
    return default;
}
bool WannaGoAgain()
{
    while (true)
    {
        Console.WriteLine("Tekrar denemek ister misiniz?(e,evet)(k,kapat)");
        var cevap = Console.ReadLine().ToUpper();
        if (cevap == "E" || cevap == "EVET")
        {
            Console.Clear();
            return true;
        }
        else if (cevap == "KAPAT" || cevap == "K")
        {
            Console.WriteLine("Görüşmek üzere...");
            return false;
        }
        else
        {
            Console.WriteLine("Geçersiz cevap");
        }
    }
}
public static class Calculate
{
    public static double CalculateValue(double adimSayisi, double adimUzunlugu, TimeSpan sure)
    {
        double sonuc = adimSayisi * adimUzunlugu * sure.TotalMinutes * 0.01;

        return sonuc;
    }
}
