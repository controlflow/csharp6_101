// code completion, keyword
// unused using static
// optimize, sort, grouping
using System;
using static System.Console;

// QF "Fix using directive"
using System.Text.StringBuilder;
using static System.Collections;

namespace CSharp6Samples.UsingStatic
{
  public class Support
  {
    public void M()
    {
      // CA "Insert full qualification"
      // CA "Qualify static members"
      // CA "Import static members"
      WriteLine();
    }

    // Missing:
    // - refactoring support is :|
    // - extension method import style preference
  }
}