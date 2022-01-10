using UnityEngine;
public class DestructibleBox : MonoBehaviour
{
    // Fields
    private UnityEngine.Collider _collider;
    private UnityEngine.Rigidbody _rigidbody;
    private UnityEngine.Transform _boxParentTransform;
    
    // Methods
    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        if(this._collider.enabled == false)
        {
                return;
        }
        
        if((other.gameObject.TryGetComponent<Bullet>(component: out  0)) == false)
        {
                return;
        }
        
        Sound.Play(self:  10);
        this.Destroy();
    }
    private void Destroy()
    {
        var val_9;
        var val_10;
        var val_13;
        if(this._collider == null)
        {
                throw new NullReferenceException();
        }
        
        this._collider.enabled = false;
        if(this._rigidbody == null)
        {
                throw new NullReferenceException();
        }
        
        this._rigidbody.isKinematic = true;
        if(this._boxParentTransform == null)
        {
                throw new NullReferenceException();
        }
        
        val_10 = this._boxParentTransform.GetEnumerator();
        label_19:
        var val_10 = 0;
        val_10 = val_10 + 1;
        if(val_10.MoveNext() == false)
        {
            goto label_9;
        }
        
        var val_11 = 0;
        val_11 = val_11 + 1;
        object val_5 = val_10.Current;
        val_9 = val_5;
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_6 = val_9.gameObject;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.BoxCollider val_7 = val_6.AddComponent<UnityEngine.BoxCollider>();
        UnityEngine.GameObject val_8 = val_9.gameObject;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Rigidbody val_9 = val_8.AddComponent<UnityEngine.Rigidbody>();
        goto label_19;
        label_9:
        val_9 = 0;
        if(X0 == false)
        {
            goto label_20;
        }
        
        var val_14 = X0;
        val_10 = X0;
        if((X0 + 294) == 0)
        {
            goto label_24;
        }
        
        var val_12 = X0 + 176;
        var val_13 = 0;
        val_12 = val_12 + 8;
        label_23:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_22;
        }
        
        val_13 = val_13 + 1;
        val_12 = val_12 + 16;
        if(val_13 < (X0 + 294))
        {
            goto label_23;
        }
        
        goto label_24;
        label_22:
        val_14 = val_14 + (((X0 + 176 + 8)) << 4);
        val_13 = val_14 + 304;
        label_24:
        val_10.Dispose();
        label_20:
        if(val_9 != 0)
        {
                throw val_9;
        }
    
    }
    public DestructibleBox()
    {
    
    }

}
