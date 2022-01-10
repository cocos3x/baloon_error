using UnityEngine;
private sealed class CoreServices.<CoWaitRemoteConfig>d__38 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public CoreServices <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public CoreServices.<CoWaitRemoteConfig>d__38(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_2;
        if((this.<>1__state) < 2)
        {
                this.<>1__state = 0;
            if((this.<>4__this._firebase.<RemoteConfigInitializing>k__BackingField) != false)
        {
                val_2 = 1;
            this.<>2__current = 0;
            this.<>1__state = val_2;
            return (bool)val_2;
        }
        
            if((this.<>4__this.<saveData>k__BackingField.testGroupAssigned) != true)
        {
                this.<>4__this.<remoteConfig>k__BackingField.FixTestGroup();
        }
        
        }
        
        val_2 = 0;
        return (bool)val_2;
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
