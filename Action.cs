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

        private int symbolvalue {get; set;}
        public int FindSymbolMention(params string[] strings)
        {
            foreach(int eachstring in strings)
            {
                if(eachstring.Contains("="))
                {
                    this.symbolvalue++;
                }
            };
            return symbolvalue;
        }
    }
