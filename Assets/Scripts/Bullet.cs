using UnityEngine;
public class Bullet : MonoBehaviour
{
    // Fields
    private UnityEngine.Rigidbody _rigidbody;
    private Explosion _explosion;
    private UnityEngine.TrailRenderer _trailRenderer;
    protected float _power;
    private UnityEngine.MeshRenderer _bulletMesh;
    private UnityEngine.Collider _collider;
    private UnityEngine.ParticleSystem _hitFX;
    private float _lifeTime;
    private bool _isExplosion;
    private bool _canUse;
    
    // Properties
    public bool CanUse { get; }
    
    // Methods
    public bool get_CanUse()
    {
        return (bool)this._canUse;
    }
    public void Fire(UnityEngine.Vector3 direction, float lifeTime, bool isExplosion, UnityEngine.Vector3 muzzlePos)
    {
        this._bulletMesh.enabled = false;
        this._canUse = false;
        this.gameObject.SetActive(value:  true);
        this._trailRenderer.Clear();
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.CoEnableMesh());
        this._collider.enabled = (this._canUse == false) ? 1 : 0;
        this._lifeTime = lifeTime;
        this._isExplosion = isExplosion;
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = muzzlePos.x, y = muzzlePos.y, z = muzzlePos.z}, b:  new UnityEngine.Vector3() {x = direction.x, y = direction.y, z = direction.z});
        this._rigidbody.transform.LookAt(worldPosition:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, d:  this._power);
        this._rigidbody.AddForce(force:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, mode:  1);
    }
    private System.Collections.IEnumerator CoEnableMesh()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new Bullet.<CoEnableMesh>d__13();
    }
    private void Update()
    {
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = this._lifeTime - val_1;
        this._lifeTime = val_1;
        if(val_1 >= 0)
        {
                return;
        }
        
        this.Disable();
    }
    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        if(this._isExplosion != false)
        {
                Sound.Play(self:  8);
            UnityEngine.Vector3 val_2 = this.transform.position;
            UnityEngine.Quaternion val_3 = UnityEngine.Quaternion.identity;
            Explosion val_4 = UnityEngine.Object.Instantiate<Explosion>(original:  this._explosion, position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, rotation:  new UnityEngine.Quaternion() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w});
        }
        
        if((other.gameObject.TryGetComponent<Balloon>(component: out  0)) != false)
        {
                val_6.OnHit(isAddForce:  true);
        }
        
        this.Disable();
    }
    private void Disable()
    {
        this._canUse = true;
        this._bulletMesh.enabled = false;
        this._collider.enabled = (this._canUse == false) ? 1 : 0;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        this._rigidbody.velocity = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        this._rigidbody.angularVelocity = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        this.gameObject.SetActive(value:  false);
    }
    public Bullet()
    {
    
    }

}
