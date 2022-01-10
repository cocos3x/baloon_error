using UnityEngine;
public class CameraShakeProjectile : MonoBehaviour
{
    // Fields
    public UnityEngine.Animator CamerShakeAnimator;
    
    // Methods
    private void Start()
    {
    
    }
    private void Update()
    {
    
    }
    public void ShakeCamera()
    {
        this.CamerShakeAnimator.SetTrigger(name:  "CameraShakeTrigger");
    }
    public CameraShakeProjectile()
    {
    
    }

}
