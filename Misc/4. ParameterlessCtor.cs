namespace CSharp6Samples.Misc
{
  public class ParameterlessCtor
  {
    public struct S
    {
      public S() { } // ok now!
      public S(int dummy) { }

      // can't be private
    }

    void M(S s = new S())
    {
      var s1 = new S(); // invoked
      var s2 = default(S); // 000000
    }

    public struct Weird
    {
      private int myField;

      //public Weird() { myField = -1; }
      public Weird(int value)
      {
        this.InstanceMember();
      }

      void InstanceMember() { }

      // intersection
      public int Field { get { return myField; } }
    }
  }
}