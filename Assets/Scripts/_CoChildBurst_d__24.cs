using UnityEngine;
private sealed class Balloon.<CoChildBurst>d__24 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Balloon <>4__this;
    private System.Collections.Generic.List.Enumerator<Balloon> <>7__wrap1;
    private Balloon <balloon>5__3;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Balloon.<CoChildBurst>d__24(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
        int val_1 = this.<>1__state;
        val_1 = val_1 + 3;
        if(val_1 > 5)
        {
                return;
        }
        
        val_1 = 1 << val_1;
        if((val_1 & 49) != 0)
        {
                return;
        }
        
        this.<>m__Finally1();
    }
    private bool MoveNext()
    {
        var val_6;
        List.Enumerator<Balloon> val_7;
        Balloon val_13;
        UnityEngine.Object val_14;
        List.Enumerator<Balloon> val_15;
        int val_16;
        val_13 = 11165;
        if(((this.<>1__state) - 1) >= 2)
        {
            goto label_1;
        }
        
        this.<>1__state = -3;
        val_14 = 0;
        if((this.<balloon>5__3) == val_14)
        {
            goto label_15;
        }
        
        val_13 = this.<balloon>5__3;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14 = "head";
        if((System.String.op_Inequality(a:  val_13.name, b:  val_14)) == false)
        {
            goto label_6;
        }
        
        val_13 = this.<balloon>5__3;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_13.OnHit(isAddForce:  false);
        goto label_15;
        label_1:
        if((this.<>1__state) != 0)
        {
            goto label_60;
        }
        
        this.<>1__state = 0;
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        val_13 = this.<>4__this._childBalloons;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_5 = val_13.GetEnumerator();
        val_15 = this.<>7__wrap1;
        mem[1152921507372886376] = val_6;
        this.<>7__wrap1 = val_7;
        this.<>1__state = -3;
        goto label_12;
        label_6:
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this._enemy) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this._enemy._isBoss) != false)
        {
                this.<balloon>5__3.OnHit(isAddForce:  false);
        }
        
        label_15:
        val_15 = this.<>7__wrap1;
        this.<balloon>5__3 = 0;
        label_12:
        val_14 = public System.Boolean List.Enumerator<Balloon>::MoveNext();
        val_13 = val_15;
        if((val_13 & 1) == 0)
        {
            goto label_17;
        }
        
        this.<balloon>5__3 = 1152921507371831424;
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this._enemy) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this._enemy._isBoss) == false)
        {
            goto label_20;
        }
        
        val_16 = 1;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.0001f);
        this.<>1__state = val_16;
        return (bool)val_16;
        label_17:
        val_13 = this;
        this.<>m__Finally1();
        mem2[0] = 0;
        mem2[0] = 0;
        mem2[0] = 0;
        if((this.<>4__this) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this._meshFilter) == 0)
        {
                this.<>4__this.<CoChildBurst>g__DestroyThis|24_0();
        }
        
        val_15 = this.<>4__this._enemy;
        val_13 = val_15;
        val_14 = 0;
        if(val_13 != val_14)
        {
                if((this.<>4__this._enemy) == null)
        {
                throw new NullReferenceException();
        }
        
            if((this.<>4__this._enemy._isBoss) != false)
        {
                this.<>4__this.<CoChildBurst>g__DestroyThis|24_0();
        }
        
        }
        
        label_60:
        val_16 = 0;
        return (bool)val_16;
        label_20:
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.1f);
        this.<>1__state = 2;
        return (bool)val_16;
    }
    private void <>m__Finally1()
    {
        this.<>1__state = 0;
        UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
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
