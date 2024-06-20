using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*3. В классе Task3 создайте класс Statistic с полями для входной строки и выходного дробного числа.
Сделайте публичные свойства для чтения этих полей Input и Output.
В конструктор должен передаваться текст и сохраняться как входная строка.
После этого посчитать среднее арифметическое количество слогов во всех словах текста
(словом считать часть строки, содержащую в себе хотя бы одну букву) и сохранить в выходное значение.
Переопределите метод ToString(), чтобы он возвращал выходное значение построчно или пустую строку,
если входной текст был неверного формата.*/

namespace Variant_5
{
    public class Task3
    {
        public class Statistic
        {
            private string input;
            private double output;
            public string Input
            {
                get { return input; }
            }
            public double Output
            {
                get { return output; }
            }
            public Statistic(string text)
            {
                input = text;
                output = CalculateAverageSyllables(text);
            }
            private double CalculateAverageSyllables(string text)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return double.NaN;
                }
                string[] words = Regex.Split(text, @"\W+").Where(word => word.Any(char.IsLetter)).ToArray();
                if (words.Length == 0)
                {
                    return double.NaN;
                }
                int totalSyllables = words.Sum(word => CountSyllables(word));
                return (double)totalSyllables / words.Length;
            }
            private int CountSyllables(string word)
            {
                word = word.ToLower();
                int syllableCount = 0;
                bool prevVowel = false;
                foreach (char c in word)
                {
                    if ("aeiouy".Contains(c))
                    {
                        if (!prevVowel)
                        {
                            syllableCount++;
                        }
                        prevVowel = true;
                    }
                    else
                    {
                        prevVowel = false;
                    }
                }
                if (word.EndsWith("e"))
                {
                    syllableCount = Math.Max(1, syllableCount - 1);
                }
                return syllableCount;
            }
            public override string ToString()
            {
                if (double.IsNaN(output))
                {
                    return string.Empty;
                }
                return $"Average Syllables per Word: {output:F2}";
            }
        }
        //static void Main(string[] args)
        //{
        //    string text = "This is an example text with some words to analyze.";
        //    Statistic stat = new Statistic(text);
        //    Console.WriteLine(stat.ToString());
        //}
    }
}
