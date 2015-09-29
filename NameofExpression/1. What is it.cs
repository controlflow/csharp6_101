// ReSharper disable RedundantAssignment
// ReSharper disable ConvertToConstant.Local
// ReSharper disable UnusedVariable

using System.Collections.Generic;
using System.Text;

#pragma warning disable 219

namespace CSharp6Samples. NameofExpression
{
  using IntList = List<int>;

  public class WhatIsIt
  {
    void M(int parameter)
    {
      // locals
      var name1 = nameof(parameter);
      var name2 = nameof(name1);

      // types
      const string name3 = nameof(WhatIsIt);
      var name4 = nameof(IntList) + "";

      // members
      var name5 = nameof(StringBuilder.Length);
      var builder = new StringBuilder();
      var name6 = nameof(builder.Length);
      var name7 = nameof(this.M);
      var name8 = nameof(this.M(parameter));

      // overloads
      var name9 = nameof(OverloadedMethod);

      // expressions without a name
      var name10 = nameof(2 + 2);

      // DFA analyzer
      StringBuilder sb = null;
      var name11 = nameof(sb.Append);
                       // ^^ no 'Possible NRE'
    }

    void M(string nameof)
    {
      // context-sensitive
      var name = nameof(M);
    }

    void OverloadedMethod() { }
    void OverloadedMethod(int x) { }
    void OverloadedMethod(string x) { }
  }
}