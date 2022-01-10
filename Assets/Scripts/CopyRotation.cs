using UnityEngine;
public class CopyRotation : MonoBehaviour
{
    // Fields
    private bool _isActive;
    private UnityEngine.Transform _targetTransform;
    private UnityEngine.ConfigurableJoint _configurableJoint;
    private UnityEngine.Quaternion _startQuaternionOffset;
    
    // Methods
    private void Awake()
    {
        UnityEngine.Quaternion val_2 = this._configurableJoint.transform.localRotation;
        this._startQuaternionOffset = val_2;
        mem[1152921507381792804] = val_2.y;
        mem[1152921507381792808] = val_2.z;
        mem[1152921507381792812] = val_2.w;
    }
    private void Update()
    {
        if(this._isActive == false)
        {
                return;
        }
        
        UnityEngine.Quaternion val_1 = this._targetTransform.localRotation;
        ConfigurableJointExtensions.SetTargetRotationLocal(joint:  this._configurableJoint, targetLocalRotation:  new UnityEngine.Quaternion() {x = val_1.x, y = val_1.y, z = val_1.z, w = val_1.w}, startLocalRotation:  new UnityEngine.Quaternion() {x = this._startQuaternionOffset});
    }
    public void SetTarget(System.Collections.Generic.IEnumerable<UnityEngine.Transform> allChildren)
    {
        UnityEngine.Transform val_10;
        var val_11;
        var val_12;
        val_11 = allChildren;
        val_12 = this;
        this._configurableJoint = this.GetComponent<UnityEngine.ConfigurableJoint>();
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_13 = 0;
        val_13 = val_13 + 1;
        val_11 = val_11.GetEnumerator();
        goto label_14;
        label_19:
        var val_14 = 0;
        val_14 = val_14 + 1;
        val_10 = val_11.Current;
        UnityEngine.Transform val_6 = this.transform;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_10 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.String.op_Equality(a:  val_6.name, b:  val_10.name)) != false)
        {
                this._targetTransform = val_10;
        }
        
        label_14:
        var val_15 = 0;
        val_15 = val_15 + 1;
        if(val_11.MoveNext() == true)
        {
            goto label_19;
        }
        
        val_12 = 0;
        if(val_11 != null)
        {
                var val_16 = 0;
            val_16 = val_16 + 1;
            val_11.Dispose();
        }
        
        if(val_12 != 0)
        {
                throw val_12;
        }
    
    }
    public CopyRotation()
    {
    
    }

}
