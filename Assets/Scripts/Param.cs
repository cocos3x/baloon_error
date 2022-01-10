using UnityEngine;
public struct FirebaseWrapper.Param
{
    // Fields
    private Kayac.FirebaseWrapper.Param.Type type;
    private string customName;
    private string stringValue;
    private int intValue;
    
    // Methods
    public FirebaseWrapper.Param(Kayac.FirebaseWrapper.Param.Type type, int value)
    {
        this.stringValue = type;
        mem[1152921507469765000] = value;
        this.intValue = 0;
        mem[1152921507469764988] = 0;
        mem[1152921507469764992] = 0;
    }
    public FirebaseWrapper.Param(Kayac.FirebaseWrapper.Param.Type type, string value)
    {
    
    }
    public FirebaseWrapper.Param(string customName, int value)
    {
        mem[1152921507470013576] = value;
        this.stringValue = 2;
        this.intValue = customName;
        mem[1152921507470013568] = 0;
    }
    public FirebaseWrapper.Param(string customName, string value)
    {
    
    }
    public Firebase.Analytics.Parameter CreateFirebaseParameter()
    {
        mem2[0] = mem[this.stringValue];
        mem2[0] = mem[this.stringValue + 8];
        mem2[0] = this.stringValue.m_stringLength;
        mem2[0] = mem[this.stringValue + 24];
        mem2[0] = mem[this.stringValue + 32];
        mem2[0] = mem[this.stringValue + 40];
        mem2[0] = mem[this.stringValue + 48];
        mem2[0] = mem[this.stringValue + 56];
        mem2[0] = mem[this.stringValue + 64];
        mem2[0] = mem[this.stringValue + 72];
        mem2[0] = mem[this.stringValue + 80];
        mem2[0] = mem[this.stringValue + 88];
        mem2[0] = mem[this.stringValue + 96];
        mem2[0] = mem[this.stringValue + 104];
        mem2[0] = mem[this.stringValue + 112];
        mem2[0] = mem[this.stringValue + 120];
        return (Firebase.Analytics.Parameter)mem[this.stringValue + 120];
    }

}
