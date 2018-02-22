using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = System.IO.Directory.GetCurrentDirectory();
            string Text = System.IO.File.ReadAllText(Path + "/../../../tekst.txt");
            var CharactersCount = Text.ToUpper().Where(Char.IsLetter).GroupBy(x => x).Select(x => new { Char = x.Key, Count = x.Count() });
            var CharactersCountDescending = (from element in CharactersCount
                                            orderby element.Count descending
                                            select element).ToList();

            Console.WriteLine("1) Sõnu tekstis: " + Text.Split(' ').ToList().Count);
            Console.WriteLine("2) Erinevat tähte tekstis: " + Text.ToLower().Where(Char.IsLetter).Distinct().Count());
            Console.WriteLine("3) Mitu korda esineb erinevat tähte tekstis:");
            foreach (var item in CharactersCountDescending)
            {
                Console.WriteLine(item.Char + " " + item.Count);
            }
        }
    }
}
