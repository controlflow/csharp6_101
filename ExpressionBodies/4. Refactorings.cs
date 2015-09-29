namespace CSharp6Samples.ExpressionBodies
{
  public class Refactorings
  {
    // Function2Property
    // Property2Function
    // Introduce variable
    public int GetValue() => 42;

    public int Calc() => GetValue() + 1;


    // Rename: derived element
    private int myBackingField;
    public int BackingField => myBackingField;

    // SSR support: '=> e' is equal to 'return e;'
  }
}