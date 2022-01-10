using UnityEngine;
public class ExplodingProjectile : MonoBehaviour
{
    // Fields
    public UnityEngine.GameObject impactPrefab;
    public UnityEngine.GameObject explosionPrefab;
    public float thrust;
    public UnityEngine.Rigidbody thisRigidbody;
    public UnityEngine.GameObject particleKillGroup;
    private UnityEngine.Collider thisCollider;
    public bool LookRotation;
    public bool Missile;
    public UnityEngine.Transform missileTarget;
    public float projectileSpeed;
    public float projectileSpeedMultiplier;
    public bool ignorePrevRotation;
    public bool explodeOnTimer;
    public float explosionTimer;
    private float timer;
    private UnityEngine.Vector3 previousPosition;
    
    // Methods
    private void Start()
    {
        this.thisRigidbody = this.GetComponent<UnityEngine.Rigidbody>();
        if(this.Missile != false)
        {
                this.missileTarget = UnityEngine.GameObject.FindWithTag(tag:  "Target").transform;
        }
        
        this.thisCollider = this.GetComponent<UnityEngine.Collider>();
        UnityEngine.Vector3 val_6 = this.transform.position;
        this.previousPosition = val_6;
        mem[1152921507345097536] = val_6.y;
        mem[1152921507345097540] = val_6.z;
    }
    private void Update()
    {
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = this.timer + val_1;
        this.timer = val_1;
        if(val_1 < this.explosionTimer)
        {
                return;
        }
        
        if(this.explodeOnTimer == false)
        {
                return;
        }
        
        this.Explode();
    }
    private void FixedUpdate()
    {
        float val_10;
        float val_11;
        float val_12;
        if(this.Missile != false)
        {
                float val_11 = this.projectileSpeed;
            float val_10 = this.projectileSpeedMultiplier;
            val_10 = val_11 * val_10;
            val_11 = val_11 + val_10;
            this.projectileSpeed = val_11;
            this.transform.LookAt(target:  this.missileTarget);
            UnityEngine.Vector3 val_3 = this.transform.forward;
            val_10 = this.projectileSpeed;
            val_11 = val_3.x;
            val_12 = val_3.y;
            UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_11, y = val_12, z = val_3.z}, d:  val_10);
            this.thisRigidbody.AddForce(force:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
        }
        
        if(this.LookRotation != false)
        {
                val_12 = 0.05f;
            if(this.timer >= val_12)
        {
                UnityEngine.Vector3 val_6 = this.thisRigidbody.velocity;
            val_11 = val_6.x;
            val_10 = val_6.z;
            val_12 = val_6.y;
            UnityEngine.Quaternion val_7 = UnityEngine.Quaternion.LookRotation(forward:  new UnityEngine.Vector3() {x = val_11, y = val_12, z = val_10});
            this.transform.rotation = new UnityEngine.Quaternion() {x = val_7.x, y = val_7.y, z = val_7.z, w = val_7.w};
        }
        
        }
        
        this.CheckCollision(prevPos:  new UnityEngine.Vector3() {x = this.previousPosition, y = val_7.y, z = val_7.z});
        UnityEngine.Vector3 val_9 = this.transform.position;
        this.previousPosition = val_9;
        mem[1152921507345370688] = val_9.y;
        mem[1152921507345370692] = val_9.z;
    }
    private void CheckCollision(UnityEngine.Vector3 prevPos)
    {
        float val_15;
        float val_16;
        UnityEngine.Object val_17;
        float val_18;
        val_15 = prevPos.z;
        val_16 = prevPos.x;
        val_17 = this;
        UnityEngine.Vector3 val_2 = this.transform.position;
        val_18 = val_2.y;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_2.x, y = val_18, z = val_2.z}, b:  new UnityEngine.Vector3() {x = val_16, y = prevPos.y, z = val_15});
        UnityEngine.Vector3 val_5 = this.transform.position;
        float val_6 = UnityEngine.Vector3.Distance(a:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, b:  new UnityEngine.Vector3() {x = val_16, y = prevPos.y, z = val_15});
        if((UnityEngine.Physics.Raycast(ray:  new UnityEngine.Ray() {m_Origin = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, m_Direction = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}}, hitInfo: out  new UnityEngine.RaycastHit() {m_Point = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, m_Normal = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, m_Distance = 0f, m_UV = new UnityEngine.Vector2() {x = 0f, y = 0f}}, maxDistance:  val_6)) == false)
        {
                return;
        }
        
        this.transform.position = new UnityEngine.Vector3() {x = val_6, y = 0f, z = val_5.z};
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.forward;
        UnityEngine.Quaternion val_10 = UnityEngine.Quaternion.FromToRotation(fromDirection:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, toDirection:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
        val_15 = val_10.x;
        val_16 = val_10.z;
        val_18 = val_10.x;
        UnityEngine.GameObject val_11 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.impactPrefab, position:  new UnityEngine.Vector3() {x = val_18, y = val_10.y, z = val_10.z}, rotation:  new UnityEngine.Quaternion() {x = val_15, y = val_10.y, z = val_16, w = val_10.w});
        if(this.explodeOnTimer == false)
        {
            goto label_13;
        }
        
        if(this.Missile == true)
        {
            goto label_14;
        }
        
        return;
        label_13:
        if(this.Missile == false)
        {
            goto label_16;
        }
        
        label_14:
        this.thisCollider.enabled = false;
        this.particleKillGroup.SetActive(value:  false);
        UnityEngine.Vector3 val_12 = UnityEngine.Vector3.zero;
        this.thisRigidbody.velocity = new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z};
        val_17 = this.gameObject;
        UnityEngine.Object.Destroy(obj:  val_17, t:  5f);
        return;
        label_16:
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        var val_12;
        UnityEngine.Object val_13;
        float val_14;
        float val_15;
        float val_16;
        val_13 = this;
        if((System.String.op_Inequality(a:  collision.gameObject.tag, b:  "FX")) == false)
        {
                return;
        }
        
        UnityEngine.ContactPoint[] val_4 = collision.contacts;
        UnityEngine.ContactPoint val_12 = val_4[4];
        UnityEngine.ContactPoint val_13 = val_4[0];
        UnityEngine.ContactPoint val_14 = val_4[2];
        val_12 = 1152921504694919168;
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.forward;
        val_14 = val_5.x;
        val_15 = val_5.y;
        val_16 = val_5.z;
        UnityEngine.Quaternion val_6 = UnityEngine.Quaternion.FromToRotation(fromDirection:  new UnityEngine.Vector3() {x = val_14, y = val_15, z = val_16}, toDirection:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
        if(this.ignorePrevRotation != false)
        {
                val_14 = 0f;
            val_15 = 0f;
            val_16 = 0f;
            UnityEngine.Quaternion val_7 = UnityEngine.Quaternion.Euler(x:  val_14, y:  val_15, z:  val_16);
        }
        
        UnityEngine.GameObject val_8 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.impactPrefab, position:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, rotation:  new UnityEngine.Quaternion() {x = val_7.x, y = val_7.y, z = val_7.z, w = val_7.w});
        if(this.explodeOnTimer == false)
        {
            goto label_15;
        }
        
        if(this.Missile == true)
        {
            goto label_16;
        }
        
        return;
        label_15:
        if(this.Missile == false)
        {
            goto label_18;
        }
        
        label_16:
        this.thisCollider.enabled = false;
        this.particleKillGroup.SetActive(value:  false);
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.zero;
        this.thisRigidbody.velocity = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
        val_13 = this.gameObject;
        UnityEngine.Object.Destroy(obj:  val_13, t:  5f);
        return;
        label_18:
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private void Explode()
    {
        UnityEngine.Vector3 val_3 = this.gameObject.transform.position;
        UnityEngine.Quaternion val_4 = UnityEngine.Quaternion.Euler(x:  0f, y:  0f, z:  0f);
        UnityEngine.GameObject val_5 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.explosionPrefab, position:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, rotation:  new UnityEngine.Quaternion() {x = val_4.x, y = val_4.y, z = val_4.z, w = val_4.w});
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public ExplodingProjectile()
    {
        this.LookRotation = true;
    }

}
