using UnityEngine;
public struct RemoteConfig.InterstitialData
{
    // Fields
    public readonly char Letter;
    public readonly float Value;
    public readonly float Modifier;
    
    // Methods
    public RemoteConfig.InterstitialData(char letter, float value, float modifier)
    {
        mem[1152921507392890816] = letter;
        mem[1152921507392890820] = value;
        mem[1152921507392890824] = modifier;
    }

}
