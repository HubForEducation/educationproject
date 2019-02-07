 class Action
    {
        public void Exchange(ref int first, ref int second)
        {
            first = first + second;
            second = first - second;
            first= first - second;
        }

        public float arithmeticalMean(float first, float second)
        {
            return (fitst+second)/2;
        }
    }
