using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Action
    {
        public void Exchange(ref int first, ref int second)
        {
            first = first + second;
            second = first - second;
            first = first - second;
        }
        public float FindMean(params float[] numbers)
        {
            return numbers.Sum() / numbers.Length;
        }
        public int FindSymbolMention(string[] strings)
        {
            return strings.Where(s => s.Contains("=")).Sum(s => s.Length);
        }
    }
}
