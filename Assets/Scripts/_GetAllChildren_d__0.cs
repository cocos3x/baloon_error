using UnityEngine;
private sealed class TransformExtensions.<GetAllChildren>d__0 : IEnumerable<UnityEngine.Transform>, IEnumerable, IEnumerator<UnityEngine.Transform>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private UnityEngine.Transform <>2__current;
    private int <>l__initialThreadId;
    private UnityEngine.Transform self;
    public UnityEngine.Transform <>3__self;
    private string name;
    public string <>3__name;
    private System.Collections.Generic.IEnumerator<UnityEngine.Transform> <>7__wrap1;
    
    // Properties
    private UnityEngine.Transform System.Collections.Generic.IEnumerator<UnityEngine.Transform>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TransformExtensions.<GetAllChildren>d__0(int <>1__state)
    {
        this.<>1__state = <>1__state;
        this.<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
    }
    private void System.IDisposable.Dispose()
    {
        if((this.<>1__state) != 1)
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
        var val_7;
        System.Collections.Generic.IEnumerator<UnityEngine.Transform> val_9;
        var val_10;
        System.Collections.Generic.IEnumerator<UnityEngine.Transform> val_11;
        var val_12;
        var val_13;
        int val_14;
        val_7 = 11215;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        var val_8 = 0;
        val_8 = val_8 + 1;
        goto label_7;
        label_1:
        val_9 = this.<>7__wrap1;
        goto label_8;
        label_7:
        val_10 = public System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>::GetEnumerator();
        val_7 = TransformExtensions.GetAllChildren(self:  this.self);
        val_9 = this;
        this.<>7__wrap1 = val_7.GetEnumerator();
        label_8:
        this.<>1__state = -3;
        label_21:
        val_11 = this.<>7__wrap1;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_11 = mem[val_3];
        if((mem[val_3] + 294) == 0)
        {
            goto label_13;
        }
        
        var val_9 = mem[val_3] + 176;
        var val_10 = 0;
        val_9 = val_9 + 8;
        label_12:
        if(((mem[val_3] + 176 + 8) + -8) == null)
        {
            goto label_11;
        }
        
        val_10 = val_10 + 1;
        val_9 = val_9 + 16;
        if(val_10 < (mem[val_3] + 294))
        {
            goto label_12;
        }
        
        goto label_13;
        label_11:
        val_11 = val_11 + (((mem[val_3] + 176 + 8)) << 4);
        val_12 = val_11 + 304;
        label_13:
        val_10 = public System.Boolean System.Collections.IEnumerator::MoveNext();
        val_7 = val_11;
        if(val_7.MoveNext() == false)
        {
            goto label_14;
        }
        
        val_11 = this.<>7__wrap1;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_14 = mem[val_3];
        if((mem[val_3] + 294) == 0)
        {
            goto label_19;
        }
        
        var val_12 = mem[val_3] + 176;
        var val_13 = 0;
        val_12 = val_12 + 8;
        label_18:
        if(((mem[val_3] + 176 + 8) + -8) == null)
        {
            goto label_17;
        }
        
        val_13 = val_13 + 1;
        val_12 = val_12 + 16;
        if(val_13 < (mem[val_3] + 294))
        {
            goto label_18;
        }
        
        goto label_19;
        label_17:
        val_14 = val_14 + (((mem[val_3] + 176 + 8)) << 4);
        val_13 = val_14 + 304;
        label_19:
        val_10 = public T System.Collections.Generic.IEnumerator<T>::get_Current();
        val_7 = val_11;
        T val_5 = val_7.Current;
        val_11 = val_5;
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.op_Equality(a:  val_11.name, b:  this.name)) == false)
        {
            goto label_21;
        }
        
        val_14 = 1;
        this.<>2__current = val_11;
        this.<>1__state = val_14;
        return (bool)val_14;
        label_14:
        this.<>m__Finally1();
        val_14 = 0;
        this.<>7__wrap1 = 0;
        return (bool)val_14;
        label_2:
        val_14 = 0;
        return (bool)val_14;
    }
    private void <>m__Finally1()
    {
        this.<>1__state = 0;
        if((this.<>7__wrap1) == null)
        {
                return;
        }
        
        var val_2 = 0;
        val_2 = val_2 + 1;
        this.<>7__wrap1.Dispose();
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
                TransformExtensions.<GetAllChildren>d__0 val_2 = null;
            val_4 = val_2;
            val_2 = new TransformExtensions.<GetAllChildren>d__0();
            .<>1__state = 0;
            .<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
        }
        
        .self = this.<>3__self;
        .name = this.<>3__name;
        return (System.Collections.Generic.IEnumerator<UnityEngine.Transform>)val_4;
    }
    private System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.System.Collections.Generic.IEnumerable<UnityEngine.Transform>.GetEnumerator();
    }

}
