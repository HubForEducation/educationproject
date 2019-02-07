 class Exchange
    {
        public void Make(ref int first, ref int second)
        {
            first = first + second;
            second = first - second;
            first= first - second;
        }
    }
