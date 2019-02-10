using System;
using System.Linq;
using System.Collections.Generic;

class Action
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

class RomanNumerals
{
    private readonly Dictionary<int, string> _numberCollection = new Dictionary<int, string>
    { { 1000, "M" },  { 900, "CM" },  { 500, "D" },  { 400, "CD" },  { 100, "C" },
                      { 90 , "XC" },  { 50 , "L" },  { 40 , "XL" },  { 10 , "X" },
                      { 9  , "IX" },  { 5  , "V" },  { 4  , "IV" },  { 1  , "I" } };
    public string ToRoman(int number)
    {
        if (number>0)
        {
            return _numberCollection
            .Where(d => number >= d.Key)
            .Select(d => d.Value + RomanArabicConverting(number - d.Key))
            .FirstOrDefault();
        }
        else
        {
            throw new AggregateException("Bad imput params!");
        }
    }
    public int ToArabic(string number)
    {
        var allowedSimbols = _numberCollection.SelectMany(i => i.Value.ToCharArray()).Distinct.ToCharArray();
        
        if (!number.All.(c => allowedSimbols.Contains(c)))
        {
            throw new AggregateException("Bad imput params!"); 
        }
        else
        {
            return numberCollection
            .Where(d => number.StartsWith(d.Value))
            .Select(d => d.Key + RomanArabicConverting(number.Substring(d.Value.Length)))
            .FirstOrDefault();
        }
    }
}