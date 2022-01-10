using UnityEngine;
private sealed class FailedManager.<CoPlay>d__7 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public FailedManager <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public FailedManager.<CoPlay>d__7(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_4;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_7;
        }
        
        this.<>1__state = 0;
        val_4 = 1;
        this.<>4__this._failedCanvasGroup.blocksRaycasts = true;
        UnityEngine.YieldInstruction val_2 = DG.Tweening.TweenExtensions.WaitForCompletion(t:  DG.Tweening.DOTweenModuleUI.DOFade(target:  this.<>4__this._failedCanvasGroup, endValue:  0.7f, duration:  0.3f));
        this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  1f);
        this.<>1__state = val_4;
        return (bool)val_4;
        label_1:
        this.<>1__state = 0;
        if((this.<>4__this._decline) != null)
        {
                this.<>4__this._decline.Invoke();
        }
        
        label_7:
        val_4 = 0;
        return (bool)val_4;
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
