using UnityEngine;
public static class TransformExtensions
{
    // Methods
    public static System.Collections.Generic.IEnumerable<UnityEngine.Transform> GetAllChildren(UnityEngine.Transform self, string name)
    {
        .<>1__state = -2;
        .<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
        .<>3__self = self;
        .<>3__name = name;
        return (System.Collections.Generic.IEnumerable<UnityEngine.Transform>)new TransformExtensions.<GetAllChildren>d__0();
    }
    public static System.Collections.Generic.IEnumerable<UnityEngine.Transform> GetAllChildren(UnityEngine.Transform self)
    {
        .<>1__state = -2;
        .<>l__initialThreadId = System.Environment.CurrentManagedThreadId;
        .<>3__self = self;
        return (System.Collections.Generic.IEnumerable<UnityEngine.Transform>)new TransformExtensions.<GetAllChildren>d__1();
    }

}
