using UnityEngine;
public class EffectActor : MonoBehaviour
{
    // Fields
    public UnityEngine.Transform spawnLocator;
    public EffectActor.projectile[] bombList;
    private string FauxName;
    public UnityEngine.UI.Text UiText;
    public int bombType;
    public float min;
    public float max;
    public bool MinorRotate;
    public bool MajorRotate;
    private int seq;
    
    // Methods
    private void Start()
    {
        int val_4;
        object[] val_1 = new object[4];
        val_1[0] = "#";
        int val_3 = this.bombType;
        val_3 = val_3 + 1;
        val_4 = val_1.Length;
        val_1[1] = val_3;
        val_4 = val_1.Length;
        val_1[2] = ". ";
        projectile val_4 = this.bombList[this.bombType];
        val_1[3] = this.bombList[this.bombType][0].name;
        string val_2 = +val_1;
    }
    private void Update()
    {
        if((UnityEngine.Input.GetKeyDown(key:  113)) != false)
        {
                this.Switch(value:  0);
        }
        
        if((UnityEngine.Input.GetButtonDown(buttonName:  "Fire2")) != true)
        {
                if((UnityEngine.Input.GetKeyDown(key:  101)) == false)
        {
            goto label_3;
        }
        
        }
        
        this.Switch(value:  1);
        label_3:
        if((UnityEngine.Input.GetButtonDown(buttonName:  "Fire1")) == false)
        {
                return;
        }
        
        this.Fire();
    }
    public void Switch(int value)
    {
        int val_3;
        int val_5;
        val_3 = this.bombType + value;
        this.bombType = val_3;
        if(val_3 > 0)
        {
                if(this.bombList != null)
        {
            goto label_2;
        }
        
        }
        
        val_3 = this.bombList.Length - 1;
        this.bombType = val_3;
        label_2:
        if(val_3 >= this.bombList.Length)
        {
                this.bombType = 0;
        }
        
        object[] val_1 = new object[4];
        val_1[0] = "#";
        int val_3 = this.bombType;
        val_3 = val_3 + 1;
        val_5 = val_1.Length;
        val_1[1] = val_3;
        val_5 = val_1.Length;
        val_1[2] = ". ";
        projectile val_4 = this.bombList[this.bombType];
        val_1[3] = this.bombList[this.bombType][0].name;
        string val_2 = +val_1;
    }
    public void Fire()
    {
        projectile val_4 = this.bombList[this.bombType];
        UnityEngine.Vector3 val_1 = this.bombList[this.bombType][0].bombPrefabTransform.position;
        projectile val_5 = this.bombList[this.bombType];
        UnityEngine.Quaternion val_2 = this.bombList[this.bombType][0].bombPrefabTransform.rotation;
        UnityEngine.GameObject val_3 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.bombList[this.bombType][0].bombPrefab, position:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, rotation:  new UnityEngine.Quaternion() {x = val_2.x, y = val_2.y, z = val_2.z, w = val_2.w});
        if(this.MinorRotate != false)
        {
                this.RandomizeRotation();
        }
        
        if(this.MajorRotate == false)
        {
                return;
        }
        
        this.Major_RandomizeRotation();
    }
    private void RandomizeRotation()
    {
        if(this.seq > 5)
        {
                return;
        }
        
        var val_9 = 11320556 + (this.seq) << 2;
        val_9 = val_9 + 11320556;
        goto (11320556 + (this.seq) << 2 + 11320556);
    }
    private void Major_RandomizeRotation()
    {
        if(this.seq > 5)
        {
                return;
        }
        
        var val_5 = 11320580 + (this.seq) << 2;
        val_5 = val_5 + 11320580;
        goto (11320580 + (this.seq) << 2 + 11320580);
    }
    public EffectActor()
    {
    
    }

}
