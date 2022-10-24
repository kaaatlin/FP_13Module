using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sec_FP_13Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "C:\\Users\\admin\\Desktop\\Text1.txt";
            string line;
            using (var reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    ParseLine(line);
                }
            }
            // Сортировка по значениям
            var items = from pair in Words
                        orderby pair.Value descending
                        select pair;


            int n = 0;
            int i = 1;
            foreach (KeyValuePair<string, int> pair in items)
            {
                if (n < 11 && i <= 10)// 10 слов
                {
                    Console.WriteLine("{2}: {0} = {1}", pair.Key, pair.Value, i);
                    n++;
                    i++;
                }
                else break;
            }

            Console.ReadKey();

        }

        static Dictionary<string, int> Words = new Dictionary<string, int>();
        static void ParseLine(string s)
        {
            string word = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    word += s[i];
                }
                else
                {
                    word = word.ToLower();
                    if (Words.ContainsKey(word))
                    {
                        Words[word]++;
                    }
                    else
                    {
                        if (word.Length > 2)
                        {
                            Words.Add(word, 1);
                        }
                    }
                    word = "";
                }
            }
        }
    }
}