using System;
using System.Linq.Expressions;
using System.Text;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnassignedReadonlyField
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
// ReSharper disable RedundantToStringCall
// ReSharper disable RedundantNameQualifier

namespace CSharp6Samples.ConditionalAccess
{
  public class Analyzers
  {
    public readonly StringBuilder Builder;

    // conditional access as a source of 'Possible NRE'
    public void M(StringBuilder sb, Analyzers a)
    {
      sb?.Append("aaa");
      a.Builder?.Append("bbb");

      sb.Append("ccc");
      a.Builder.Append("ddd"); // +QF
    }

    // redundant conditional access
    public void N(StringBuilder sb, int? val)
    {
      sb.Append("aa");

      //if (sb != null) { }

      sb?.Append("bb"); // +QF

      sb?.Append(sb != null); // always true

      val.Value.ToString();
      val?.ToString(); // +QF
    }

    // constant nullness of qualifier expression
    public void O()
    {
      StringBuilder sb = null;
      sb?.Append(42).Append("abc");
    }

    // with dependent analysis
    public void P(Analyzers a)
    {
      var sb = a?.Builder;
      if (sb != null)
      {
        //if (a != null) { }
        a?.ToString(); // redundant ?.
      }
    }

    // with type analysis
    public void R(object obj)
    {
      var len = (obj as string)?.ToString().Length;
      if (len != null)
      {
        var t = obj as string; // always succeeds
        var i = (int) obj; // possible invalid cast
      }
    }

    // const can affect dataflow
    public int S()
    {
      const string s = "42";

      int x;
      s?.CompareTo(x = 42);
      return x; // definitely assigned!
    }

    // field-like events
    public event EventHandler Event;

    public void T()
    {
      Event(this, EventArgs.Empty); // +QF
    }

    // property of 'a.P == a?.P'
    public readonly string Value;

    // 'a.P' == 'a?.P'
    public void E(Analyzers a)
    {
      if (a?.Value != null) return;

      if (a != null)
      {
        var t = a.Value.Length; // possible NRE
      }
    }

    // issues: always true/false/null with conditional access
    public void F(bool b, string s)
    {
      if (b)
      {
        if (s?.ToString() != null) { } // ???
      }
      else
      {
        if (s.ToString() != null) { } // always true
      }
    }

    // some compiler errors
    public void G()
    {
      Expression<Func<string, int?>> f = (s) => s?.Length;
      System?.Console?.WriteLine();
    }
  }
}
