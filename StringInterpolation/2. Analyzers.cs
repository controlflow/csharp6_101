namespace CSharp6Samples.StringInterpolation
{
  public class Analyzers
  {
    // QF "Use string interpolation"
    public string M(string text)
    {
      return $"text: {text}" + $"\r\nvalue: {42}";
    }

    // redundant .ToString()
    public string M()
    {
      return $"42 is {42.ToString()}";
    }

    public string M(int id)
    {
      // matching braces
      // escaped characters highlight
      return $"User(id={id:D5})\r\n";
    }

    public string RedundantInterpolation()
    {
      var format = string.Format(
        "redundant string.format {{ aaa }}");

      // QF "To string literal"
      return $"redundant interpolation {{ aaa }}";
    }

    public void M(int id, string text)
    {
      // QF "Remove line breaks"
      // QF "Convert to verbatim interpolation"
      var str1 = $"id: {
          id
        }, text: {text}";
    }
  }
}