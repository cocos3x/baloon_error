using UnityEngine;
public class Explosion : MonoBehaviour
{
    // Fields
    private float _lifeTime;
    
    // Methods
    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        if((other.gameObject.TryGetComponent<Balloon>(component: out  0)) == false)
        {
                return;
        }
        
        val_2.OnHit(isAddForce:  true);
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
        
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public Explosion()
    {
    
    }

}
