using System.Collections;
using System.Collections.Generic;
// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedVariable

namespace CSharp6Samples.Misc
{
  public class CollectionInitializers
  {
    class WithCollectionInitializer : IEnumerable
    {
      public void Add(int value) { }
      public void Add(string key, int value) { }

      public IEnumerator GetEnumerator()
      {
        yield break;
      }
    }

    public void M()
    {
      var initializer = new WithCollectionInitializer {
        1,
        2, 3,
        { "abc", 4 }
      };
    }

    public void M2()
    {
      // import
      var stack = new Stack<int> {1, 2, 3};

      // CA "To Add() calls"
      // QF "Use collection initializer"
    }
  }

  namespace StackExtensions
  {
    static class StackExtensions
    {
      public static void Add<T>(this Stack<T> stack, T value)
      {
        stack.Push(value);
      }
    }
  }
}