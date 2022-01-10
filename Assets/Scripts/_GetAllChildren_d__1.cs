using UnityEngine;
private sealed class TransformExtensions.<GetAllChildren>d__1 : IEnumerable<UnityEngine.Transform>, IEnumerable, IEnumerator<UnityEngine.Transform>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private UnityEngine.Transform <>2__current;
    private int <>l__initialThreadId;
    private UnityEngine.Transform self;
    public UnityEngine.Transform <>3__self;
    private int <i>5__2;
    private UnityEngine.Transform <child>5__3;
    private System.Collections.Generic.IEnumerator<UnityEngine.Transform> <>7__wrap3;
    
    // Properties
    private UnityEngine.Transform System.Collections.Generic.IEnumerator<UnityEngine.Transform>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TransformExtensions.<GetAllChildren>d__1(int <>1__state)
    {
        this.<>1__state = <>1__state;
        this.<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
    }
    private void System.IDisposable.Dispose()
    {
        if((this.<>1__state) != 2)
        {
                if((this.<>1__state) != 3)
        {
                return;
        }
        
        }
        
        this.<>m__Finally1();
    }
    private bool MoveNext()
    {
        UnityEngine.Transform val_10;
        var val_11;
        System.Collections.Generic.IEnumerator<UnityEngine.Transform> val_12;
        int val_14;
        var val_15;
        var val_17;
        int val_18;
        val_10 = 11219;
        if((this.<>1__state) == 0)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 2)
        {
            goto label_24;
        }
        
        val_11 = this;
        val_12 = this.<>7__wrap3;
        goto label_4;
        label_2:
        this.<>1__state = 0;
        System.Collections.Generic.IEnumerable<UnityEngine.Transform> val_1 = TransformExtensions.GetAllChildren(self:  this.<child>5__3);
        val_12 = val_1;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_11 = 0;
        val_11 = val_11 + 1;
        goto label_9;
        label_1:
        val_12 = this;
        val_14 = 0;
        this.<i>5__2 = 0;
        this.<>1__state = 0;
        goto label_10;
        label_9:
        val_15 = public System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>::GetEnumerator();
        val_10 = val_12;
        System.Collections.Generic.IEnumerator<T> val_3 = val_10.GetEnumerator();
        val_11 = this;
        val_12 = val_3;
        this.<>7__wrap3 = val_3;
        label_4:
        this.<>1__state = -3;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_12 = 0;
        val_12 = val_12 + 1;
        val_15 = public System.Boolean System.Collections.IEnumerator::MoveNext();
        val_10 = val_12;
        if(val_10.MoveNext() == false)
        {
            goto label_16;
        }
        
        val_12 = this.<>7__wrap3;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_15 = mem[val_3];
        if((mem[val_3] + 294) == 0)
        {
            goto label_21;
        }
        
        var val_13 = mem[val_3] + 176;
        var val_14 = 0;
        val_13 = val_13 + 8;
        label_20:
        if(((mem[val_3] + 176 + 8) + -8) == null)
        {
            goto label_19;
        }
        
        val_14 = val_14 + 1;
        val_13 = val_13 + 16;
        if(val_14 < (mem[val_3] + 294))
        {
            goto label_20;
        }
        
        goto label_21;
        label_16:
        this.<>m__Finally1();
        val_12 = this;
        val_14 = (this.<i>5__2) + 1;
        this.<child>5__3 = 0;
        this.<>7__wrap3 = 0;
        this.<i>5__2 = val_14;
        label_10:
        val_10 = this.self;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = 0;
        UnityEngine.Transform val_6 = val_10.transform;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15 = 0;
        if(val_14 >= val_6.childCount)
        {
            goto label_24;
        }
        
        val_10 = this.self;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_9 = val_10.transform.GetChild(index:  this.<i>5__2);
        this.<child>5__3 = val_9;
        this.<>2__current = val_9;
        val_18 = 1;
        this.<>1__state = val_18;
        return (bool)val_18;
        label_19:
        val_15 = val_15 + (((mem[val_3] + 176 + 8)) << 4);
        val_17 = val_15 + 304;
        label_21:
        this.<>2__current = val_12.Current;
        val_18 = 1;
        this.<>1__state = 2;
        return (bool)val_18;
        label_24:
        val_18 = 0;
        return (bool)val_18;
    }
    private void <>m__Finally1()
    {
        this.<>1__state = 0;
        if((this.<>7__wrap3) == null)
        {
                return;
        }
        
        var val_2 = 0;
        val_2 = val_2 + 1;
        this.<>7__wrap3.Dispose();
    }
    private UnityEngine.Transform System.Collections.Generic.IEnumerator<UnityEngine.Transform>.get_Current()
    {
        return (UnityEngine.Transform)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }
    private System.Collections.Generic.IEnumerator<UnityEngine.Transform> System.Collections.Generic.IEnumerable<UnityEngine.Transform>.GetEnumerator()
    {
        var val_4;
        if(((this.<>1__state) == 2) && ((this.<>l__initialThreadId) == System.Environment.CurrentManagedThreadId))
        {
                this.<>1__state = 0;
            val_4 = this;
        }
        else
        {
                TransformExtensions.<GetAllChildren>d__1 val_2 = null;
            val_4 = val_2;
            val_2 = new TransformExtensions.<GetAllChildren>d__1();
            .<>1__state = 0;
            .<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
        }
        
        .self = this.<>3__self;
        return (System.Collections.Generic.IEnumerator<UnityEngine.Transform>)val_4;
    }
    private System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.System.Collections.Generic.IEnumerable<UnityEngine.Transform>.GetEnumerator();
    }

}
