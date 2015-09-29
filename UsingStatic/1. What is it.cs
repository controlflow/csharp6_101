using System;
using static System.Console;
using static System.String;

using static System.Linq.Enumerable;

using static NoAliasSupport = System.Console;
// ReSharper disable UseStringInterpolation

namespace CSharp6Samples.UsingStatic
{
  public class WhatIsIt
  {
    public void M()
    {
      WriteLine(42);
      WriteLine("abc");
      WriteLine("{0}", 42);

      var fmt = Format("{0:d4}", 42);
    }

    public int[] Extensions()
    {
      var xs = Range(0, 100);

      Where(xs, x => x > 0); // error!

      return xs
        .Where(x => x > 0)
        .ToArray();
    }
  }
}