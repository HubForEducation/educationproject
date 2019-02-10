using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class RomanNumerals
    {
        private readonly Dictionary<int, string> _numberCollection = new Dictionary<int, string>
        { { 1000, "M" },  { 900, "CM" },  { 500, "D" },  { 400, "CD" },  { 100, "C" },
            { 90 , "XC" },  { 50 , "L" },  { 40 , "XL" },  { 10 , "X" },
            { 9  , "IX" },  { 5  , "V" },  { 4  , "IV" },  { 1  , "I" } };
        public string ToRoman(int number)
        {
            if (!(number > 0))
            {
                throw new AggregateException("Bad imput params!");
            }
            else
            {
                return _numberCollection
                    .Where(d => number >= d.Key)
                    .Select(d => d.Value + ToRoman(number - d.Key))
                    .FirstOrDefault();
            }
        }
        public int ToArabic(string number)
        {
            var allowedSimbols = _numberCollection.SelectMany(i => i.Value.ToCharArray()).Distinct().ToArray();

            if (!number.All(c => allowedSimbols.Contains(c)))
            {
                throw new AggregateException("Bad imput params!");
            }
            else
            {
                return _numberCollection
                    .Where(d => number.StartsWith(d.Value))
                    .Select(d => d.Key + ToArabic(number.Substring(d.Value.Length)))
                    .FirstOrDefault();
            }
        }
    }
}
