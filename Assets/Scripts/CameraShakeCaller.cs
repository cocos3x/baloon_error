using UnityEngine;
public class CameraShakeCaller : MonoBehaviour
{
    // Fields
    public float ProjectileShakeDuration;
    public float ProjectileShakeAmount;
    
    // Methods
    private void Start()
    {
        null = null;
        CameraShake.shakeDuration = this.ProjectileShakeDuration;
        CameraShake.shakeAmount = this.ProjectileShakeAmount;
    }
    private void Update()
    {
    
    }
    public CameraShakeCaller()
    {
        this.ProjectileShakeDuration = 0.08f;
        this.ProjectileShakeAmount = 0.1f;
    }

}
