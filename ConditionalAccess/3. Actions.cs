using System;
using System.Linq;
using System.Text;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ReturnValueOfPureMethodIsNotUsed

// ReSharper disable UnassignedReadonlyField
// ReSharper disable TryCastAndCheckForNull.1
// ReSharper disable CanBeReplacedWithTryCastAndCheckForNull
// ReSharper disable RedundantToStringCall

namespace CSharp6Samples.ConditionalAccess
{
  public class Actions
  {
    public void M(string[] xs)
    {
      // 'To static method invocation' CA
      var ys = xs?.Select(x => x.ToString());

      // 'To normal access' CA
      // 'To conditional access' CA
      var length1 = xs?.Length;
      int? length2 = xs?.Length;
      var string1 = xs?.Length.ToString();
    }

    public readonly string Name;

    public string N(Actions a, object o)
    {
      // 'Merge sequential checks' QF/CA
      // 'Split into sequential checks' CA
      if (a != null && a.Name != null) { }
      if (a != null && a?.Name != null) { }
      if (a == null || a.Name == null) { } // inverted
      if (a != null && a.N(a, o) != null) { }
      if (o != null && o is string) { }
      if (o != null && (o as string) != null) { }
      if (o is string &&
          !string.IsNullOrEmpty((string) o)) { }

      if (o is string && ((string) o).Length > 42) { }

      return "kamri 547";
    }

    public string O(Actions a)
    {
      // 'To conditional access' QF/CA
      // 'To conditional expression' CA
      var s = a != null ? a.O(a) : null;
      var u = a != null ? a.ToString() : "bbb";
      var v = a?.Name == null ? (int?) null : a.Name.Length;

      return s + u + v;
    }

    public void P(Actions a)
    {
      // 'To conditional access' CA
      var name = a.IfNotNull(x => x.Name);
    }

    // 'Invoke event' QF
    // 'Create event invocator' CA
    public event EventHandler Event;

    // 'To null propagation' QF/CA
    public void R(StringBuilder sb, object[] xs)
    {
      if (sb != null) sb.Append(42);

      foreach (var o in xs)
      {
        var builder = o as StringBuilder;
        if (builder == null) continue;

        var text = builder.Length as int?;
        if (text == null) continue;

        text.GetType();
        // implicit continue
      }
    }
  }

  public static class ShittyExtensions
  {
    public static U IfNotNull<T, U>(this T source, Func<T, U> func)
    {
      if (source != null)
        return func(source);

      return default(U);
    }
  }
}