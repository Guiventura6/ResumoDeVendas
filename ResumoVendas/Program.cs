using System;
using System.IO;
using System.Globalization;

namespace ResumoVendas
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture;
            string sourcePath = @"C:\temp\ItensVendidos.txt";
            string summary = @"C:\temp\summary.csv";
            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                using StreamWriter sw = File.AppendText(summary);
                foreach (var items in lines)
                {
                    string[] s = items.Split(",");
                    string nameProduct = s[0];
                    double price = double.Parse(s[1], CI);
                    int quantity = int.Parse(s[2]);

                    double total = price * quantity;

                    sw.WriteLine($"{nameProduct},{total.ToString("F2", CI)}");                    
                }
            }
            catch (IOException e)
            {

                Console.WriteLine("Ocorreu um Erro!");
                Console.WriteLine(e.Message);
            }

        }
    }
}
