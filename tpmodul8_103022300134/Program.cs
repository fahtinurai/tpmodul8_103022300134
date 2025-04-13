using System;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = CovidConfig.LoadFromFile("covid_config.json");

        Console.Write($"Berapa suhu badan anda saat ini? (Dalam nilai {config.satuan_suhu}): ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan anda terakhir memiliki gejala demam)? ");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        bool suhuOke = false;

        if (config.satuan_suhu == "celcius")
        {
            suhuOke = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.satuan_suhu == "fahrenheit")
        {
            suhuOke = suhu >= 97.7 && suhu <= 99.5;
        }

        if (suhuOke && hariDemam < config.batas_hari_demam)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        // Test method UbahSatuan
        config.UbahSatuan();
        Console.WriteLine("Satuan suhu diubah ke: " + config.satuan_suhu);
    }
}