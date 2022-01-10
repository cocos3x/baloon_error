using UnityEngine;
public static class Vibration
{
    // Methods
    public static void VibrateLight()
    {
        if(MoreMountains.NiceVibrations.MMVibrationManager.Android() != true)
        {
                if(MoreMountains.NiceVibrations.MMVibrationManager.HapticsSupported() == false)
        {
                return;
        }
        
        }
        
        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(type:  8, defaultToRegularVibrate:  false, alsoRumble:  false, coroutineSupport:  0);
    }
    public static void VibrateHeavy()
    {
        if(MoreMountains.NiceVibrations.MMVibrationManager.Android() != true)
        {
                if(MoreMountains.NiceVibrations.MMVibrationManager.HapticsSupported() == false)
        {
                return;
        }
        
        }
        
        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(type:  6, defaultToRegularVibrate:  false, alsoRumble:  false, coroutineSupport:  0);
    }
    public static void VibrateFailure()
    {
        if(MoreMountains.NiceVibrations.MMVibrationManager.Android() != true)
        {
                if(MoreMountains.NiceVibrations.MMVibrationManager.HapticsSupported() == false)
        {
                return;
        }
        
        }
        
        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(type:  3, defaultToRegularVibrate:  false, alsoRumble:  false, coroutineSupport:  0);
    }

}
