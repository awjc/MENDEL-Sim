using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class BrainMath
{
    /// <summary>
    /// Clamp the given value to [min, max]
    /// </summary>
    /// <param name="a"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static double Clamp(double a, double min, double max)
    {
        if (a < min)
            a = min;
        if (a > max)
            a = max;
        return a;
    }

    /// <summary>
    /// Clamp the given value to [-1, 1]
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static double Clamp1(double x)
    {
        return Clamp(x, -1, 1);
    }
}
