using UnityEngine;
private struct FirebaseWrapper.Event
{
    // Fields
    private Kayac.FirebaseWrapper.EventType type;
    private string customName;
    private Kayac.FirebaseWrapper.Param[] parameters;
    
    // Methods
    public FirebaseWrapper.Event(Kayac.FirebaseWrapper.EventType type, Kayac.FirebaseWrapper.Param[] parameters)
    {
        this.parameters = type;
        mem[1152921507470411000] = 0;
        mem[1152921507470411008] = parameters;
    }
    public FirebaseWrapper.Event(string customName, Kayac.FirebaseWrapper.Param[] parameters)
    {
        this.parameters = 3;
        mem[1152921507470604920] = customName;
        mem[1152921507470604928] = parameters;
    }
    public void Send()
    {
    
    }

}
