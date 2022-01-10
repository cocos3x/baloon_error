using UnityEngine;
private sealed class GunManager.<CoShoot>d__22 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public int burstCount;
    public GunManager <>4__this;
    public UnityEngine.EventSystems.PointerEventData pointerEventData;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public GunManager.<CoShoot>d__22(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        var val_3;
        int val_4;
        int val_5;
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
            goto label_15;
        }
        
        val_3 = this;
        val_4 = this.burstCount;
        this.<>1__state = 0;
        if(val_4 != 0)
        {
            goto label_4;
        }
        
        goto label_5;
        label_1:
        val_3 = this;
        val_4 = this.burstCount;
        this.<>1__state = 0;
        label_4:
        if(val_4 <= 0)
        {
                if((this.<>4__this._taped) == false)
        {
            goto label_15;
        }
        
        }
        
        this.<>4__this.Shoot(pointerPos:  new UnityEngine.Vector2() {x = this.pointerEventData.<position>k__BackingField}, shootType:  this.<>4__this._gun.shootType);
        int val_3 = val_4;
        val_3 = val_3 - 1;
        this.burstCount = val_3;
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  this.<>4__this._gun.fireInterval);
        this.<>1__state = 2;
        val_5 = 1;
        return (bool)val_5;
        label_2:
        this.<>1__state = 0;
        label_5:
        if((this.<>4__this._taped) != false)
        {
                this.<>4__this.Shoot(pointerPos:  new UnityEngine.Vector2() {x = this.pointerEventData.<position>k__BackingField}, shootType:  this.<>4__this._gun.shootType);
            val_5 = 1;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  this.<>4__this._gun.fireInterval);
            this.<>1__state = val_5;
            return (bool)val_5;
        }
        
        label_15:
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
