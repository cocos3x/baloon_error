using UnityEngine;
public class BulletManager : MonoBehaviour
{
    // Fields
    private Bullet _bulletPrefab;
    private System.Collections.Generic.List<Bullet> _bullets;
    
    // Methods
    public void Init()
    {
        this._bulletPrefab = UnityEngine.Resources.Load<Bullet>(path:  "Bullet");
    }
    public void Shoot(UnityEngine.Vector3 direction, UnityEngine.Transform muzzleTransform, bool explosion)
    {
        Bullet val_1 = this.GetBullet();
        UnityEngine.Vector3 val_3 = muzzleTransform.position;
        val_1.transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        UnityEngine.Vector3 val_4 = muzzleTransform.position;
        val_1.Fire(direction:  new UnityEngine.Vector3() {x = direction.x, y = direction.y, z = direction.z}, lifeTime:  2f, isExplosion:  explosion, muzzlePos:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
    }
    private Bullet GetBullet()
    {
        Bullet val_3;
        List.Enumerator<T> val_1 = this._bullets.GetEnumerator();
        label_4:
        if(((-1549671304) & 1) == 0)
        {
            goto label_2;
        }
        
        val_3 = 0;
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(0 == 0)
        {
            goto label_4;
        }
        
        UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
        return val_3;
        label_2:
        UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
        val_3 = UnityEngine.Object.Instantiate<Bullet>(original:  this._bulletPrefab, parent:  0);
        this._bullets.Add(item:  val_3);
        return val_3;
    }
    public BulletManager()
    {
        this._bullets = new System.Collections.Generic.List<Bullet>();
    }

}
