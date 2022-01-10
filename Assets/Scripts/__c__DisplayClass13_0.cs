using UnityEngine;
private sealed class DOTweenModuleUI.<>c__DisplayClass13_0
{
    // Fields
    public UnityEngine.RectTransform target;
    
    // Methods
    public DOTweenModuleUI.<>c__DisplayClass13_0()
    {
    
    }
    internal UnityEngine.Vector2 <DOAnchorPos>b__0()
    {
        if(this.target != null)
        {
                return this.target.anchoredPosition;
        }
        
        throw new NullReferenceException();
    }
    internal void <DOAnchorPos>b__1(UnityEngine.Vector2 x)
    {
        if(this.target != null)
        {
                this.target.anchoredPosition = new UnityEngine.Vector2() {x = x.x, y = x.y};
            return;
        }
        
        throw new NullReferenceException();
    }

}
