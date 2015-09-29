using System;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
#pragma warning disable 1998

namespace CSharp6Samples.ExpressionBodies
{
  public class Analyzers
  {
    // 'To expression body' QF + bulk
    public int Value
    {
      get { return 42; }
    }

    public int this[int index]
    {
      get { return index; }
    }

    public int Property
    {
      get // comment
      {
        ; // comment
        { }

        // #warning 123

        {
          return 42;
        }
      } // comment
    }

    // no suggestion here:
    public Func<int, string> GetSelector()
    {
      return x => x.ToString();
    }

    public void WriteLine()
    {
      Console.WriteLine();
    }

    public void Init(out int value)
    {
      value = 42;
    }

    // 'To expression body' QF
    public int M()
    {
      42;
    }

    // QF 'Change type'
    // QF 'Make void'
    // QF 'Introduce variable'
    public void F() => 42;


    // convert to auto-property:
    private int myBackingField;

    public int BackingField => myBackingField;


    // QF "Use this body for implementations"
    interface I
    {
      int Calc() => 42;
    }

    class C : I { }



    // value is ignored
    void ValueIsIgnored()
    {
      Pure();
      new StringBuilder();

      Action a = () => Pure();
      Action b = () => new StringBuilder();
    }



    void ValueIsIgnored2() => Pure();



    async Task ValueIsIgnored3() => Pure();



    void ValueIsIgnored4()
    {
      Func<Task> f = async () => Pure();
    }



    void ValueIsIgnored5()
    {
      for (Pure(), Pure(); ; Pure(), Pure())
      {
        
      }
    }


    [Pure] // return value is unused (bug)
    private int Pure() => 42;
  }
}