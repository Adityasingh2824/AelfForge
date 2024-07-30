using AElf.Sdk.CSharp;

public class SafeMath
{
    /// <summary>
    /// Adds two numbers, throws on overflow.
    /// </summary>
    public static ulong Add(ulong a, ulong b)
    {
        ulong c = a + b;
        Assert(c >= a, "SafeMath: addition overflow");
        return c;
    }

    /// <summary>
    /// Subtracts two numbers, throws on overflow (i.e. if subtrahend is greater than minuend).
    /// </summary>
    public static ulong Sub(ulong a, ulong b)
    {
        Assert(b <= a, "SafeMath: subtraction overflow");
        return a - b;
    }

    /// <summary>
    /// Multiplies two numbers, throws on overflow.
    /// </summary>
    public static ulong Mul(ulong a, ulong b)
    {
        if (a == 0) return 0;
        ulong c = a * b;
        Assert(c / a == b, "SafeMath: multiplication overflow");
        return c;
    }

    /// <summary>
    /// Integer division of two numbers, truncating the quotient.
    /// </summary>
    public static ulong Div(ulong a, ulong b)
    {
        Assert(b > 0, "SafeMath: division by zero");
        return a / b;
    }

    /// <summary>
    /// Modulus of two numbers, throws on division by zero
    /// </summary>
    public static ulong Mod(ulong a, ulong b)
    {
        Assert(b > 0, "SafeMath: modulo by zero");
        return a % b;
    }
}
