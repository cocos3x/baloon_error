using UnityEngine;
private sealed class Manager.<<GameStart>g__CoShowAd|27_0>d : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Manager <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Manager.<<GameStart>g__CoShowAd|27_0>d(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        Kayac.HcAd.AppAdManager val_4;
        int val_5;
        var val_6;
        System.Action val_8;
        val_4 = this;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        val_5 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>1__state = val_5;
        return (bool)val_5;
        label_1:
        this.<>1__state = 0;
        val_4 = this.<>4__this._core.<adManager>k__BackingField;
        val_6 = null;
        val_6 = null;
        val_8 = Manager.<>c.<>9__27_2;
        if(val_8 == null)
        {
                System.Action val_3 = null;
            val_8 = val_3;
            val_3 = new System.Action(object:  Manager.<>c.__il2cppRuntimeField_static_fields, method:  System.Void Manager.<>c::<GameStart>b__27_2());
            Manager.<>c.<>9__27_2 = val_8;
        }
        
        val_4.ShowInterstitial(onEnd:  new System.Action(object:  this.<>4__this, method:  System.Void Manager::<GameStart>b__27_1()), onBegin:  val_3);
        label_2:
        val_5 = 0;
        return (bool)val_5;
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
