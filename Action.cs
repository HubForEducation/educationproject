 class Action
    {
        public void Exchange(ref int first, ref int second)
        {
            first = first + second;
            second = first - second;
            first= first - second;
        }

        public float FindMean(float first, float second)
        {
            return (fitst+second)/2;
        }

        public float FindMean(float first, float second, float thrid)
        {
            return (fitst+second+thrid)/3;
        }
    }
