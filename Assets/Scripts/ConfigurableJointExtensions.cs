using UnityEngine;
public static class ConfigurableJointExtensions
{
    // Methods
    public static void SetTargetRotationLocal(UnityEngine.ConfigurableJoint joint, UnityEngine.Quaternion targetLocalRotation, UnityEngine.Quaternion startLocalRotation)
    {
        float val_13;
        float val_14;
        float val_15;
        float val_16;
        val_13 = startLocalRotation.w;
        val_14 = startLocalRotation.y;
        val_15 = targetLocalRotation.w;
        val_16 = targetLocalRotation.y;
        if(joint.configuredInWorldSpace != false)
        {
                UnityEngine.Debug.LogError(message:  "configurable JointのworldSpaceにチェックが入っている。これは予期していない設定。", context:  joint);
            return;
        }
        
        UnityEngine.Vector3 val_2 = joint.axis;
        UnityEngine.Vector3 val_3 = joint.axis;
        UnityEngine.Vector3 val_4 = joint.secondaryAxis;
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.Cross(lhs:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, rhs:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.Cross(lhs:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, rhs:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        UnityEngine.Quaternion val_7 = UnityEngine.Quaternion.LookRotation(forward:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, upwards:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z});
        val_13 = val_7.x;
        val_14 = val_7.z;
        UnityEngine.Quaternion val_8 = UnityEngine.Quaternion.Inverse(rotation:  new UnityEngine.Quaternion() {x = val_7.x, y = val_7.y, z = val_7.z, w = val_7.w});
        val_15 = val_8.x;
        val_16 = val_8.z;
        UnityEngine.Quaternion val_9 = UnityEngine.Quaternion.Inverse(rotation:  new UnityEngine.Quaternion() {x = targetLocalRotation.x, y = val_16, z = targetLocalRotation.z, w = val_15});
        UnityEngine.Quaternion val_10 = UnityEngine.Quaternion.op_Multiply(lhs:  new UnityEngine.Quaternion() {x = val_9.x, y = val_9.y, z = val_9.z, w = val_9.w}, rhs:  new UnityEngine.Quaternion() {x = startLocalRotation.x, y = val_14, z = startLocalRotation.z, w = val_13});
        UnityEngine.Quaternion val_11 = UnityEngine.Quaternion.op_Multiply(lhs:  new UnityEngine.Quaternion() {x = val_15, y = val_8.y, z = val_16, w = val_8.w}, rhs:  new UnityEngine.Quaternion() {x = val_10.x, y = val_10.y, z = val_10.z, w = val_10.w});
        UnityEngine.Quaternion val_12 = UnityEngine.Quaternion.op_Multiply(lhs:  new UnityEngine.Quaternion() {x = val_11.x, y = val_11.y, z = val_11.z, w = val_11.w}, rhs:  new UnityEngine.Quaternion() {x = val_13, y = val_7.y, z = val_14, w = val_7.w});
        joint.targetRotation = new UnityEngine.Quaternion() {x = val_12.x, y = val_12.y, z = val_12.z, w = val_12.w};
    }

}
