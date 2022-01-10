using UnityEngine;
[Serializable]
private sealed class FirebaseWrapper.<>c
{
    // Fields
    public static readonly Kayac.FirebaseWrapper.<>c <>9;
    public static System.Action<System.Exception> <>9__61_0;
    
    // Methods
    private static FirebaseWrapper.<>c()
    {
        FirebaseWrapper.<>c.<>9 = new FirebaseWrapper.<>c();
    }
    public FirebaseWrapper.<>c()
    {
    
    }
    internal void <SaveCache>b__61_0(System.Exception e)
    {
        if(e == null)
        {
                return;
        }
        
        UnityEngine.Debug.LogException(exception:  e);
    }

}
