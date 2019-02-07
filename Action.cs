using System;
using System.Linq;			
 class Action
    {
        public void Exchange(ref int first, ref int second)
        {
            first = first + second;
            second = first - second;
            first= first - second;
        }
        public float FindMean(params float[] numbers)
        {
            return numbers.Sum()/numbers.Length;
        }

        
        public int FindSymbolMention(params string[] strings)
        {
		int symbolvalue = 0;
            foreach(string eachstring in strings)
            {
                if(eachstring.Contains("="))
                {
                    symbolvalue++;
                }
            };
            return symbolvalue;
        }
    }
