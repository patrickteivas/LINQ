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
            string Text = System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "/../../../tekst.txt");
            
            //1
            Console.WriteLine("1) Sõnu tekstis: " + Text.Split(' ').ToList().Count);
            
            //2
            Console.WriteLine("\n2) Erinevat tähte tekstis: " + Text.ToLower().Where(Char.IsLetter).Distinct().Count());

            //3
            Console.WriteLine("\n3) Mitu korda esineb erinevat tähte tekstis (Suuremast väiksemani):");
            var CharactersCount = Text.ToUpper().Where(Char.IsLetter).GroupBy(x => x).Select(x => new { Char = x.Key, Count = x.Count() });
            foreach (var item in CharactersCount.OrderByDescending(x => x.Count))
            {
                Console.WriteLine(item.Char + " " + item.Count);
            }
            
            //4
            Console.WriteLine("\n4)Sõnad ei kordu:");
            string NonSpecialCharactersText = new string (Text.Where(x => char.IsLetter(x) || char.IsWhiteSpace(x)).ToArray());
            var Words = NonSpecialCharactersText.ToLower().Split(' ').ToList();
            var NonRepeatableWords = new List<string> { };
            foreach (var item in Words)
            {
                if (!NonRepeatableWords.Contains(item)) NonRepeatableWords.Add(item);
            }
            foreach (var item in NonRepeatableWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
