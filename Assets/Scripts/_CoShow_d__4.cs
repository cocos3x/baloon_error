using UnityEngine;
private sealed class GdprDialog.<CoShow>d__4 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Kayac.GdprDialog <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public GdprDialog.<CoShow>d__4(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        if((this.<>1__state) >= 2)
        {
                return false;
        }
        
        this.<>1__state = 0;
        if((this.<>4__this) != null)
        {
                if((this.<>4__this._accepted) != false)
        {
                return false;
        }
        
            this.<>2__current = 0;
            this.<>1__state = 1;
            return false;
        }
        
        throw new NullReferenceException();
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
