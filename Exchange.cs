 class Exchange
    {
        public void Make(ref int firstVariable, ref int secondVariable)
        {
            firstVariable = firstVariable + secondVariable;
            secondVariable = firstVariable - secondVariable;
            firstVariable = firstVariable - secondVariable;
        }
    }
