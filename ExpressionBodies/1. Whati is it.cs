using System;

namespace CSharp6Samples.ExpressionBodies
{
  public class WhatIsIt
  {
    // get-only property
    public string Name => "aaa";

    // get-only indexer
    public int this[int index] => index;

    // method
    public string M(string arg) => arg;
    public void M() => Console.WriteLine();

    // sign operator
    public static WhatIsIt operator-(WhatIsIt w) => w;

    // conversion operator
    public static implicit operator bool(WhatIsIt w) => true;
  }
}