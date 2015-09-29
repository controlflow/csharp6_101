using System;

namespace CSharp6Samples.AutoProperties
{
  public class WhatIsIt
  {
    public string Initialized { get; set; } = "initializer";

    public string GetOnlyInitialized { get; } = "abc";

    public string GetOnly { get; }

    public WhatIsIt()
    {
      GetOnly = "can assign here";

      Action f = () => { GetOnly = "but not here"; };
    }

    public interface IErrors
    {
      int Prop { get; } = 42;
    }

    public class Errors
    {
      public int NotAutoProperty
      {
        get { throw new Exception(); }
      } = 42;
    }
  }
}