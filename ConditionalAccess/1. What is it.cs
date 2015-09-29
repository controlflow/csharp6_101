using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp6Samples.ConditionalAccess
{
  public struct WhatIsIt
  {
    public void M<T>(StringBuilder sb, T t)
      //where T : struct
    {
      // conditional invocation:
      sb?.Append("abc");

      // conditional element access:
      char? c = sb?[42];
      int? l = sb?.Length; // ?? -1;
      //   ^ lifted return type

      string s = sb?.ToString();
      //     ^ reference type

      // unconstrained generic type:
      var u = t?.ToString();
    }

    public void N(StringBuilder sb, WhatIsIt? value)
    {
      // chained access
      var c = sb?.Length.ToString()[0];
      var c2 = (sb?.Length).ToString()[0];

      // nullable valuetype access
      value?.M(sb, 42);

      // assignment is not allowed
      sb?.Length = 42;
      //sb.Length = 42;
      sb?[42] = 'c';
      //sb[42] = 'c';
    }

    public bool N(StringBuilder sb, Action<int> f)
    {
      //f(42);

      // delegate invocation:
      f?.Invoke(42);

      bool notInitialized;

      sb?.Append("aaaa")
         .Append(notInitialized = true)
         .Append("bbbb")
         .Append("cccc");

      return notInitialized;
    }

    public string O(Dictionary<int, string> xs)
    {
      string notInitialized; // = null;
      xs?.TryGetValue(42, out notInitialized);

      return notInitialized;
    }
  }
}