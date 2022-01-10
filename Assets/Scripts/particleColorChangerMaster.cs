using UnityEngine;
public class particleColorChangerMaster : MonoBehaviour
{
    // Fields
    public float Speed_custom;
    public particleColorChangerMaster.colorChange[] colorChangeList;
    public bool applyChanges;
    public bool Keep_applyChanges;
    
    // Methods
    private void Update()
    {
        if(this.applyChanges != true)
        {
                if(this.Keep_applyChanges == false)
        {
                return;
        }
        
        }
        
        if(this.colorChangeList.Length < 1)
        {
            goto label_3;
        }
        
        var val_11 = 0;
        label_17:
        var val_10 = 0;
        label_15:
        colorChange val_7 = this.colorChangeList[0];
        if(val_10 >= this.colorChangeList[0x0][0].colored_ParticleSystem.Length)
        {
            goto label_8;
        }
        
        ColorOverLifetimeModule val_1 = this.colorChangeList[0x0][0].colored_ParticleSystem[val_10].colorOverLifetime;
        colorChange val_9 = this.colorChangeList[0];
        MinMaxGradient val_2 = ParticleSystem.MinMaxGradient.op_Implicit(gradient:  this.colorChangeList[0x0][0].Gradient_custom);
        val_10 = val_10 + 1;
        if(val_11 < this.colorChangeList.Length)
        {
            goto label_15;
        }
        
        label_8:
        val_11 = val_11 + 1;
        if(val_11 < this.colorChangeList.Length)
        {
            goto label_17;
        }
        
        label_3:
        this.applyChanges = false;
    }
    public particleColorChangerMaster()
    {
        this.Speed_custom = 1f;
    }

}
