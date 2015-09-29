namespace CSharp6Samples.StringInterpolation
{
  public class Actions
  {
    // extend selection
    // code completion
    // split/join typing assist
    // braces insertion/smart delete
    public string GetUserString(int id)
    {
      return $"User(id={id:D5})";
    }

    // CA "To verbatim"
    // CA "To regular"
    // CA "Split string"
    public string Foo(int id) => $"abc\r\ndef{id}";

    // generate formatting members
    public class Person
    {
      public string Name { get; }
      public string Age { get; }

      public Person(string name, string age)
      {
        Name = name;
        Age = age;
      }

      //
    }

    // inline expression
    public void M(bool b)
    {
      var multiLine =
        42 + // comment
        42;

      var conditional = b ? 1 : 2;
      var str1 = $"{multiLine} {conditional}";
    }
  }
}