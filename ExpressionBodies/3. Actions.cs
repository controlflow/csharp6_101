using System;

namespace CSharp6Samples.ExpressionBodies
{
  public class Actions
  {
    // CA 'To statement body'
    public Action M() => Console.WriteLine;

    public static Action P => Console.WriteLine;

    
    // CA 'Check for null'
    // CA 'Assert not null'
    public int Check(string s) => s.Length;


    // CA 'Add setter'
    public int GetOnlyProperty => 42;
    


    // what's missing:
    // Code style
    // Value tracking
  }
}