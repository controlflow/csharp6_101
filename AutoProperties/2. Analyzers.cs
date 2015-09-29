using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable UnusedAutoPropertyAccessor.Local
#pragma warning disable 169

namespace CSharp6Samples.AutoProperties
{
  public class Analyzers
  {
    // QF 'Initialize from ctor'
    public int NotInitialzedGetOnly { get; }

    // Initialized by default value
    int DefaultValue { get; } = 0;
    HashSet<string> Set { get; } = new HashSet<string>();

    public Analyzers(HashSet<string> set)
    {
      DefaultValue = 42;
      Set = set;
    }

    int MutableAutoProperty { get; set; }

    public override int GetHashCode()
    {
      // non-readonly auto-property
      // referenced in GetHashCode()
      return MutableAutoProperty;
    }

    // statics initialization order:
    public static int StaticField1 = StaticField2;
    public static int StaticField2 = StaticField1;

    public static int StaticProp1 { get; } = StaticProp2;
    public static int StaticProp2 { get; } = StaticProp1;

    // collection usage:
    private List<int> Values { get; } = new List<int>();

    public void M()
    {
      Values.Add(42);
    }

    // static auto-property in generic type
    public class Generic<T>
    {
      public static List<T> UsesT;
      public static StringBuilder NotUsesT1;
      public static StringBuilder NotUsesT2 { get; }
    }

    // definite assignment in structs
    struct Point
    {
      public Point(int x, int y) //: this()
      {
        X = x;
        Y = y;
      }

      public int X { get; private set; }
      public int Y { get; private set; }
    }

    // 'Redundant property setter' + bulk QF + code cleanup
    public class RedundantSetter
    {
      public string Name { get; private set; } = string.Empty;

      public string MrName() => "Mr. " + Name;
    }

    // 'Convert to auto-property'
    public class ToAutoProper
    {
      private readonly int myField = 42;

      public int Field
      {
        get { return myField; }
      }
    }
  }
}