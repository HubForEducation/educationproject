using System;
using System.Linq;

namespace Task
{
    public class Action
    {
        public void Exchange(ref int first, ref int second)
        {
            if (first.GetType() != typeof(int) || second.GetType() != typeof(int))
            {
               throw new ArgumentException("Bad input params!");
            }
            else
            {
                first = first + second;
                second = first - second;
                first = first - second;               
            }
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
