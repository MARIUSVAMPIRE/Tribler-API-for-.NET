using System;

namespace Tribler.API.Test.WinFrom;

public static class LongExtension
{
    public static string SizeString(this long size)
    {
        string[] unitString = ["By", "KB", "MB", "GB", "TB", "PB", "EB", "YB"];
        double unit = Math.Pow(2, 10);
        double sizeDouble = Convert.ToDouble(size);

        var loop = 0;
        while (sizeDouble > unit)
        {
            sizeDouble /= unit;
            loop++;
        }

        return sizeDouble.ToString("0.000") + " " + unitString[loop];
    }
}
