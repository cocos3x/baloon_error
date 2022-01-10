using UnityEngine;
private sealed class Cursor.<FadeOut>d__10 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public Cinema.Cursor <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public Cursor.<FadeOut>d__10(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_3;
        if((this.<>1__state) <= 1)
        {
                this.<>1__state = 0;
            float val_1 = UnityEngine.Time.deltaTime;
            val_1 = val_1 * (this.<>4__this._settingData.fadeOutSpeed);
            val_1 = (this.<>4__this._alpha) - val_1;
            this.<>4__this._alpha = val_1;
            Cinema.ImageExt.SetAlpha(image:  this.<>4__this._cursorImage, alpha:  val_1);
            if((this.<>4__this._alpha) >= 0)
        {
                val_3 = 1;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.01f);
            this.<>1__state = val_3;
            return (bool)val_3;
        }
        
        }
        
        val_3 = 0;
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
