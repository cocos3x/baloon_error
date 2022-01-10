using UnityEngine;
private sealed class GunManager.<CoFadeoutSight>d__24 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public GunManager <>4__this;
    private float <alpha>5__2;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public GunManager.<CoFadeoutSight>d__24(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_3;
        float val_4;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_3;
        }
        
        this.<>1__state = 0;
        val_3 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.5f);
        this.<>1__state = val_3;
        return (bool)val_3;
        label_2:
        this.<>1__state = 0;
        this.<alpha>5__2 = 1f;
        val_4 = 1f;
        if((this.<>4__this) != null)
        {
            goto label_5;
        }
        
        label_1:
        val_4 = this.<alpha>5__2;
        this.<>1__state = 0;
        label_5:
        if(val_4 > 0f)
        {
            goto label_8;
        }
        
        Kayac.HyperCasual.Util.SetAlpha(self:  this.<>4__this._targetSightImage, a:  0f);
        label_3:
        val_3 = 0;
        return (bool)val_3;
        label_8:
        Kayac.HyperCasual.Util.SetAlpha(self:  this.<>4__this._targetSightImage, a:  val_4);
        float val_3 = this.<alpha>5__2;
        val_3 = val_3 + (-0.1f);
        this.<alpha>5__2 = val_3;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.01f);
        this.<>1__state = 2;
        val_3 = 1;
        return (bool)val_3;
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
