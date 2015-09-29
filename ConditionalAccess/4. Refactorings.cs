using System.Text;

namespace CSharp6Samples.ConditionalAccess
{
  public class Refactorings
  {
    public void M(StringBuilder sb)
    {
      // Introduce variable
      // Inline variable
      var s = sb?.Append(42).ToString();

      // Extension2Static/Static2Extension
      sb.Extension();
      sb?.Extension();
    }

    void M(Refactorings r)
    {
      // Property2Method/Method2Property
      r?.Inner.WantToBeAProperty();
    }

    public Refactorings Inner { get { return this; } }
    public int WantToBeAProperty() { return 42; }
  }

  public static class Extensions
  {
    public static void Extension(this StringBuilder sb) { }
  }
}