using UnityEngine;
public static class Sound
{
    // Methods
    public static string FilePath(Sound.Se self)
    {
        return "Sounds/Se/"("Sounds/Se/") + Sound.FileName(self:  self)(Sound.FileName(self:  self));
    }
    public static string FileName(Sound.Se self)
    {
        if(self >= 11)
        {
                throw new System.ArgumentOutOfRangeException(paramName:  "self", actualValue:  self, message:  0);
        }
        
        return (string)14968656 + (self) << 3;
    }
    public static void Play(Sound.Se self)
    {
        PlaySe(name:  Sound.FilePath(self:  self), volume:  0f, loop:  false, stopSame:  true, pitch:  1f, delay:  0f);
    }
    public static void PlayLoop(Sound.Se self)
    {
        PlaySe(name:  Sound.FilePath(self:  self), volume:  0f, loop:  true, stopSame:  true, pitch:  1f, delay:  0f);
    }
    public static void Stop(Sound.Se self)
    {
        StopSe(name:  Sound.FilePath(self:  self), fadeDuration:  0f);
    }

}
