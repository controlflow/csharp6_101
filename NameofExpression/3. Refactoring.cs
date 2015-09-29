namespace CSharp6Samples.NameofExpression
{
  public class Refactoring
  {
    public void M()
    {
      var t = nameof(this.M);
    }

    public void Overloaded()
    {
      var u = nameof(Overloaded);
    }

    public void Overloaded(int x) { }
  }
}