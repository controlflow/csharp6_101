using System;
using System.ComponentModel;
using JetBrains.Annotations;
using System.Diagnostics;

namespace CSharp6Samples.NameofExpression
{
  public class Analyzers
  {
    // [InvokerParameterName]
    public void M(string s)
    {
      if (s == null)
        throw new ArgumentNullException("s");
    }

    // [NotifyPropertyChangedInvocator]
    public sealed class ObservableObject : INotifyPropertyChanged
    {
      private string myName;

      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      private void OnPropertyChanged(string propertyName)
      {
        var handler = PropertyChanged;
        if (handler != null)
          handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

      public string Name
      {
        get { return myName; }
        set
        {
          myName = value;
          OnPropertyChanged("Name");
        }
      }

      // generate
    }

    // switch generation
    public void M(SomeEnum e)
    {
      switch (e)
      {
        
      }
    }

    // [DebuggerDisplay] support
    [DebuggerDisplay("{Value}")]
    public class DebuggerDisplay
    {
      public int Value { get; } = 42;
    }

    public enum SomeEnum
    {
      A, B, C
    }

  }
}