using UnityEngine;
public sealed class Tenjin.DeferredDeeplinkDelegate : MulticastDelegate
{
    // Methods
    public Tenjin.DeferredDeeplinkDelegate(object object, IntPtr method)
    {
        mem[1152921507421017936] = object;
        mem[1152921507421017944] = method;
        mem[1152921507421017920] = method;
    }
    public virtual void Invoke(System.Collections.Generic.Dictionary<string, string> deferredLinkData)
    {
        var val_14;
        var val_15;
        var val_16;
        var val_18;
        var val_19;
        var val_20;
        if(X8 != 0)
        {
                val_14 = mem[X8 + 24];
            val_14 = X8 + 24;
            if(val_14 == 0)
        {
                return;
        }
        
            val_15 = X8 + 32;
        }
        else
        {
                val_14 = 1;
        }
        
        var val_23 = 0;
        System.Collections.Generic.Dictionary<System.String, System.String> val_1 = deferredLinkData - 16;
        goto label_46;
        label_39:
        val_16 = mem[X22 + 72];
        val_16 = X22 + 72;
        if((this & 1) == 0)
        {
            goto label_4;
        }
        
        UnityEngine.Sprite val_2 = X22.pressedSprite;
        var val_12 = 0;
        val_12 = val_12 + 1;
        goto label_25;
        label_40:
        System.Collections.Generic.Dictionary<System.String, System.String> val_3 = 1152921504670797824 + ((X22 + 72) << 4);
        val_18 = mem[(1152921504670797824 + (X22 + 72) << 4) + 312];
        goto label_25;
        label_4:
        System.Collections.Generic.Dictionary<System.String, System.String> val_4 = 1152921504670797824 + val_16;
        goto label_25;
        label_31:
        if((deferredLinkData.Equals(obj:  mem[(1152921504670797824 + X22 + 72) + 304 + 8])) == false)
        {
            goto label_11;
        }
        
        var val_19 = val_16;
        if((X22 + 72 + 294) == 0)
        {
            goto label_25;
        }
        
        var val_13 = X22 + 72 + 176;
        var val_14 = 0;
        val_13 = val_13 + 8;
        label_14:
        if(((X22 + 72 + 176 + 8) + -8) == X22.pressedSprite)
        {
            goto label_13;
        }
        
        val_14 = val_14 + 1;
        val_13 = val_13 + 16;
        if(val_14 < (X22 + 72 + 294))
        {
            goto label_14;
        }
        
        goto label_25;
        label_32:
        var val_7 = val_16 + ((X22 + 72) << 4);
        val_20 = mem[(X22 + 72 + (X22 + 72) << 4) + 312];
        val_20 = (X22 + 72 + (X22 + 72) << 4) + 312;
        goto label_25;
        label_44:
        val_18 = mem[(((X22 + 72 + (X22 + 72) << 4) + (((X22 + 72 + 176 + 8) + 16) + X22 + 72)) + 304) + 8];
        val_18 = (((X22 + 72 + (X22 + 72) << 4) + (((X22 + 72 + 176 + 8) + 16) + X22 + 72)) + 304) + 8;
        goto label_25;
        label_11:
        var val_16 = val_16;
        val_16 = val_16 + (X22 + 72);
        goto label_25;
        label_34:
        var val_17 = X11;
        val_17 = val_17 + ((X22 + 72 + X22 + 72) + 304 + 8);
        val_16 = val_16 + val_17;
        var val_10 = val_16 + 304;
        label_36:
        val_20 = mem[(((X22 + 72 + X22 + 72) + (X11 + (X22 + 72 + X22 + 72) + 304 + 8)) + 304) + 8];
        val_20 = (((X22 + 72 + X22 + 72) + (X11 + (X22 + 72 + X22 + 72) + 304 + 8)) + 304) + 8;
        goto label_25;
        label_13:
        var val_18 = val_13;
        val_18 = val_18 + (X22 + 72);
        val_19 = val_19 + val_18;
        val_19 = val_19 + 304;
        goto label_25;
        label_46:
        val_16 = mem[1152921507421150416];
        if((mem[1152921507421150424] & 1) == 0)
        {
            goto label_23;
        }
        
        if((mem[1152921507421150424] + 74) == 1)
        {
            goto label_45;
        }
        
        goto label_25;
        label_23:
        if((mem[1152921507421150424] + 74) != 1)
        {
            goto label_26;
        }
        
        if(val_16 == 0)
        {
            goto label_27;
        }
        
        if((((mem[1152921507421150424] + 72) == 1) || (((mem[1152921507421150416] + 273) & 1) != 0)) || ((mem[1152921507421150416] + 273) == 0))
        {
            goto label_25;
        }
        
        if((mem[1152921507421150424] & 1) == 0)
        {
            goto label_31;
        }
        
        if((mem[1152921507421150424] & 1) == 0)
        {
            goto label_32;
        }
        
        if((mem[1152921507421150416] + 294) == 0)
        {
            goto label_36;
        }
        
        var val_20 = mem[1152921507421150416] + 176;
        var val_21 = 0;
        val_20 = val_20 + 8;
        label_35:
        if(((mem[1152921507421150416] + 176 + 8) + -8) == (mem[1152921507421150424] + 24))
        {
            goto label_34;
        }
        
        val_21 = val_21 + 1;
        val_20 = val_20 + 16;
        if(val_21 < (mem[1152921507421150416] + 294))
        {
            goto label_35;
        }
        
        goto label_36;
        label_26:
        if(((mem[1152921507421150424] + 72) == 1) || ((mem[1152921507421150424] + 72) == 0))
        {
            goto label_45;
        }
        
        if((mem[1152921507421150424] & 1) == 0)
        {
            goto label_39;
        }
        
        if((mem[1152921507421150424] & 1) == 0)
        {
            goto label_40;
        }
        
        var val_22 = 0;
        val_22 = val_22 + 1;
        goto label_44;
        label_27:
        UnityEngine.Sprite val_11 = mem[1152921507421150424].pressedSprite;
        label_45:
        label_25:
        val_23 = val_23 + 1;
        if(val_23 != val_14)
        {
            goto label_46;
        }
    
    }
    public virtual System.IAsyncResult BeginInvoke(System.Collections.Generic.Dictionary<string, string> deferredLinkData, System.AsyncCallback callback, object object)
    {
        return (System.IAsyncResult)this;
    }
    public virtual void EndInvoke(System.IAsyncResult result)
    {
    
    }

}
