using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

class ActionTests
{
    public void Exchange_0_and_0_0returned()
    {
        int first = 0;
        int second = 0;
        int expected = 0;

        Action action = new Action();
        int actual = action.Exchange(first, second);

        Assert.AreEqual(expected, actual);
    }
    public void Exchange_0_and_8_4returned()
    {
        int first = 0;
        int second = 8;
        int expected = 4;

        Action action = new Action();
        int actual = action.Exchange(first, second);

        Assert.AreEqual(expected, actual);
    }
    public void Exchange_8_and_0_4returned()
    {
        int first = 8;
        int second = 0;
        int expected = 4;

        Action action = new Action();
        int actual = action.Exchange(first, second);

        Assert.AreEqual(expected, actual);
    }
    public void Exchange_n88_and_0_n44returned()
    {
        int first = -88;
        int second = 0;
        int expected = -44;

        Action action = new Action();
        int actual = action.Exchange(first, second);

        Assert.AreEqual(expected, actual);
    }
}