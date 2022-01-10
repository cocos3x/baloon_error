using UnityEngine;
public class BalloonRocket : Balloon
{
    // Fields
    private UnityEngine.Renderer _renderer;
    private UnityEngine.Vector3 _targetPos;
    private UnityEngine.Quaternion _targetRotation;
    private float _speed;
    private float _rotate;
    private System.Action _onKilledPlayer;
    private UnityEngine.Camera _camera;
    
    // Methods
    public void Init(System.Action onKilledPlayer)
    {
        this._onKilledPlayer = onKilledPlayer;
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.up;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, d:  0.5f);
        this._targetPos = val_2;
        mem[1152921507351341780] = val_2.y;
        mem[1152921507351341784] = val_2.z;
        this._speed = UnityEngine.Random.Range(min:  1f, max:  2f);
        this._rotate = UnityEngine.Random.Range(min:  50f, max:  100f);
    }
    private void Update()
    {
        if(this._renderer.isVisible != true)
        {
                UnityEngine.Object.Destroy(obj:  this.gameObject);
        }
        
        this.<Update>g__UpdateRotation|8_0();
        UnityEngine.Transform val_3 = this.transform;
        UnityEngine.Vector3 val_4 = val_3.position;
        UnityEngine.Vector3 val_7 = this.transform.forward;
        float val_8 = UnityEngine.Time.deltaTime * this._speed;
        val_8 = val_8 + val_8;
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.op_Multiply(d:  val_8, a:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
        UnityEngine.Vector3 val_10 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, b:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
        val_3.position = new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z};
        UnityEngine.Vector3 val_12 = this.transform.position;
        if((UnityEngine.Vector3.Distance(a:  new UnityEngine.Vector3() {x = this._targetPos, y = val_4.y, z = val_4.z}, b:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z})) >= 0)
        {
                return;
        }
        
        if(this._onKilledPlayer != null)
        {
                this._onKilledPlayer.Invoke();
        }
        
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public BalloonRocket()
    {
    
    }
    private void <Update>g__UpdateRotation|8_0()
    {
        UnityEngine.Vector3 val_2 = this.transform.position;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = this._targetPos, y = V9.16B, z = V10.16B}, b:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        UnityEngine.Quaternion val_6 = this.transform.rotation;
        UnityEngine.Quaternion val_7 = UnityEngine.Quaternion.LookRotation(forward:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
        float val_8 = UnityEngine.Time.deltaTime;
        val_8 = this._rotate * val_8;
        val_8 = val_8 + val_8;
        UnityEngine.Quaternion val_9 = UnityEngine.Quaternion.RotateTowards(from:  new UnityEngine.Quaternion() {x = val_6.x, y = val_6.y, z = val_6.z, w = val_6.w}, to:  new UnityEngine.Quaternion() {x = val_7.x, y = val_7.y, z = val_7.z, w = val_7.w}, maxDegreesDelta:  val_8);
        this.transform.rotation = new UnityEngine.Quaternion() {x = val_9.x, y = val_9.y, z = val_9.z, w = val_9.w};
    }

}
