using System;
using System.IO;

namespace CSharp6Samples.Misc
{
  public class ExceptionFilters
  {
    public bool M()
    {
      try
      {
        // ...
      }
      // usecase #1
      catch (Exception ex) when (
         ex is DirectoryNotFoundException ||
         ex is DriveNotFoundException)
      {
        
      }
      // usecase #2
      catch (Exception ex) when (MakeMiniDump(ex))
                             // ^ show expected type
      {
        
      }
      // filter expression can affect CF
      catch (Exception ex) when (false)
      {
        M(); // unreachable
      }
      catch (Exception ex) when (true)
      {
        M();
      }
      catch // new QF
      {
        
      }

      return false;
    }

    public int M2()
    {
      try
      {
        // exception subtyping check
        return 1;
      }
      catch (Exception ex) // when (ex.Data.Count > 0)
      {
        return 2;
      }
      catch (ArgumentException ex)
      {
        return 3;
      }
    }

    public void M3()
    {
      try
      {
        // ...
      }
      catch (Exception ex)
      {
        // no transformation here by now:
        if (ex.Data.Count > 0) throw;
      }
    }

    public bool MakeMiniDump(Exception exception)
    {
      // ...
      return false;
    }
  }
}