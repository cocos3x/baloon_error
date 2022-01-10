using UnityEngine;
private struct FileWriter.<Process>d__5 : IAsyncStateMachine
{
    // Fields
    public int <>1__state;
    public System.Runtime.CompilerServices.AsyncVoidMethodBuilder <>t__builder;
    public Kayac.FileWriter <>4__this;
    private Kayac.FileWriter.Item <item>5__2;
    private System.Exception <exception>5__3;
    private System.IO.FileStream <stream>5__4;
    private System.Runtime.CompilerServices.TaskAwaiter <>u__1;
    
    // Methods
    private void MoveNext()
    {
    
    }
    private void SetStateMachine(System.Runtime.CompilerServices.IAsyncStateMachine stateMachine)
    {
        var val_6;
        var val_7;
        var val_8;
        var val_9;
        mem2[0] = null;
        mem2[0] = 1152921507458757400;
        if((this.<>4__this) == null)
        {
            goto label_0;
        }
        
        val_7 = X21 << 5;
        mem2[0] = val_7;
        if(W21 < 1)
        {
                return;
        }
        
        var val_1 = X21 & 4294967295;
        val_8 = 0;
        val_9 = val_1 - 1;
        goto label_2;
        label_3:
        val_8 = 32;
        val_9 = val_9 - 1;
        label_2:
        var val_2 = val_7 + val_8;
        var val_3 = val_1 + val_8;
        val_6 = mem[((X21 & 4294967295) + val_8) + 40 + 8];
        val_6 = ((X21 & 4294967295) + val_8) + 40 + 8;
        mem2[0] = ((X21 & 4294967295) + val_8) + 32;
        mem2[0] = ((X21 & 4294967295) + val_8) + 40;
        mem2[0] = val_6;
        mem2[0] = ((X21 & 4294967295) + val_8) + 56;
        if(val_9 != 0)
        {
            goto label_3;
        }
        
        return;
        label_0:
        mem2[0] = 0;
    }

}
