using UnityEngine;
public class CameraShake : MonoBehaviour
{
    // Fields
    public UnityEngine.Transform camTransform;
    public static float shakeDuration;
    public static float shakeAmount;
    public float decreaseFactor;
    private UnityEngine.Vector3 originalPos;
    
    // Methods
    private void Awake()
    {
        var val_5;
        if(this.camTransform != 0)
        {
                return;
        }
        
        UnityEngine.Component val_3 = this.GetComponent(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_5 = 0;
        this.camTransform = ;
    }
    private void OnEnable()
    {
        UnityEngine.Vector3 val_1 = this.camTransform.localPosition;
        this.originalPos = val_1;
        mem[1152921507342318664] = val_1.y;
        mem[1152921507342318668] = val_1.z;
    }
    private void Update()
    {
        var val_7;
        float val_8;
        var val_9;
        var val_11;
        var val_12;
        float val_13;
        val_7 = null;
        val_7 = null;
        val_8 = CameraShake.shakeDuration;
        if(val_8 > 0f)
        {
                UnityEngine.Vector3 val_1 = UnityEngine.Random.insideUnitSphere;
            val_9 = null;
            val_9 = null;
            UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, d:  CameraShake.shakeAmount);
            UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = this.originalPos, y = V9.16B, z = V10.16B}, b:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
            this.camTransform.localPosition = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
            float val_4 = UnityEngine.Time.deltaTime;
            val_4 = val_4 * this.decreaseFactor;
            val_8 = CameraShake.shakeDuration - val_4;
            CameraShake.shakeDuration = val_8;
            val_7 = null;
        }
        
        val_11 = 0;
        val_13 = CameraShake.shakeAmount;
        if(val_13 > 0f)
        {
                val_13 = CameraShake.shakeAmount;
            float val_5 = UnityEngine.Time.deltaTime;
            val_5 = val_5 * this.decreaseFactor;
            val_5 = val_13 - val_5;
            CameraShake.shakeAmount = val_5;
            return;
        }
        
        val_12 = 1152921504785178628;
        CameraShake.shakeAmount = 0f;
        CameraShake.shakeDuration = 0f;
        this.camTransform.localPosition = new UnityEngine.Vector3() {x = this.originalPos, y = this.decreaseFactor, z = val_3.z};
    }
    public CameraShake()
    {
        this.decreaseFactor = 1f;
    }
    private static CameraShake()
    {
        CameraShake.shakeDuration = 0f;
        CameraShake.shakeAmount = 0.7f;
    }

}
