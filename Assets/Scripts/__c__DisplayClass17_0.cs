using UnityEngine;
private sealed class DOTweenModuleUI.<>c__DisplayClass17_0
{
    // Fields
    public UnityEngine.RectTransform target;
    
    // Methods
    public DOTweenModuleUI.<>c__DisplayClass17_0()
    {
    
    }
    internal UnityEngine.Vector3 <DOAnchorPos3DX>b__0()
    {
        if(this.target != null)
        {
                return this.target.anchoredPosition3D;
        }
        
        throw new NullReferenceException();
    }
    internal void <DOAnchorPos3DX>b__1(UnityEngine.Vector3 x)
    {
        if(this.target != null)
        {
                this.target.anchoredPosition3D = new UnityEngine.Vector3() {x = x.x, y = x.y, z = x.z};
            return;
        }
        
        throw new NullReferenceException();
    }

}
