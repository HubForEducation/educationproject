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
        public float FindSymbolMention(params string[] strings)
        {
            int i = 0;
            foreach(int eachstring in strings)
            {
                if(eachstring.Contains("="))
                i++;
            };
            return i;
        }
    }
