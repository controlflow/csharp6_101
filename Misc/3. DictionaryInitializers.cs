using System.Collections.Generic;
// ReSharper disable UnusedVariable
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace CSharp6Samples.Misc
{
  public class DictionaryInitializers
  {
    class Foo : List<int>
    {
      public string Property1 { get; set; }
      public string Property2 { get; set; }
    }

    public void M()
    {
      var collectionInit = new Foo { 42, 43 };
      var objectInit = new Foo {
        Property1 = "abc",
        Property2 = "def"
      };

      var indexerInit = new Foo {
        [0] = 42,
        [1] = 43,
        Property1 = "abc"
      };
    }

    public void M2()
    {
      var collectionInit = new Dictionary<int, string> {
        {42, "abc"},
        {56, "def"}
      };

      // CA 'To assignment statements'
      // QF 'Use object initializer'
      var indexerInit = new Dictionary<int, string> {
        [42] = "abc",
        [56] = "def"
      };

      // semantic is different,
      // 'd.Add(key, value)' vs 'd[key] = value'
    }

    public void M3()
    {
      // nested object initializer
      // no CA 'To assignment statement'
      new Bar {
        [GetIndex()] = {
          Value = 42,
          Text = "abc"
        }
      };

      // QF 'To object initializer' is weird
      var bar = new Bar();
      bar[GetIndex()].Value = 42;
      bar[GetIndex()].Text = "abc";
    }

    private static int GetIndex()
    {
      return 42;
    }

    class Bar
    {
      public Bar this[int index]
      {
        get { return this; }
        set { } // unused!
      }

      public int Value { get; set; }
      public string Text { get; set; }
    }
  }
}