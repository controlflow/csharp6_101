namespace CSharp6Samples.AutoProperties
{
  public class Actions
  {
    // code completion, generate
    class CtorpCtorpf
    {
      private int myField;
      public string Property { get; }

      // ctorp
    }


    // CA "Move initializer"
    // Extend selection
    class MoveInitializer
    {
      public string Name { get; set; } = string.Empty;
    }

    // CA "To property with backing field
    public class ToBackingField
    {
      public ToBackingField(string text)
      {
        KindOfImmutable = text;
      }

      public string KindOfImmutable { get; private set; }

      public string Name { get; } = string.Empty;

      public string MrName() => "Mr. " + Name;
    }

    // CA "To computed property"
    public int WantToBeComputed { get; }

    // new 'Encapsulate field'
    public class Encapsulate
    {
      public readonly int ReadonlyValue;
    }
  }
}