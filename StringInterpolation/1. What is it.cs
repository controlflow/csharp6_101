using System;
// ReSharper disable UnusedVariable
// ReSharper disable ConvertToConstant.Local

namespace CSharp6Samples.StringInterpolation
{
  public class WhatIsIt
  {
    public void M()
    {
      // regular interpolation
      var str1 = $"abc";
      var str2 = $"2 * 3 = {Math.Pow(2, 2)}";

      // verbatim interpolation
      var str3 = $@"verbatim
                      string
         {
           "interpolation"
         }
";

      // format and alignment specifiers
      var value = 42;
      var str4 = $"{value:D5}";
      var str5 = $"{value,-8:D3}";

      // escaping & newlines
      var str6 = $"{(value > 0 ? value : -value)}";
      var str7 = $"{(new global::System.Text.StringBuilder())}";

      // IFormattable support, culture
      double floatValue = 4.5;
      IFormattable formattable = $"value: {floatValue}";
    }
  }
}