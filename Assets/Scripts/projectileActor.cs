using UnityEngine;
public class projectileActor : MonoBehaviour
{
    // Fields
    public UnityEngine.Transform spawnLocator;
    public UnityEngine.Transform spawnLocatorMuzzleFlare;
    public UnityEngine.Transform shellLocator;
    public UnityEngine.Animator recoilAnimator;
    public UnityEngine.Transform[] shotgunLocator;
    public projectileActor.projectile[] bombList;
    private string FauxName;
    public UnityEngine.UI.Text UiText;
    public bool UImaster;
    public bool CameraShake;
    public float rapidFireDelay;
    public CameraShakeProjectile CameraShakeCaller;
    private float firingTimer;
    public bool firing;
    public int bombType;
    public bool swarmMissileLauncher;
    public bool Torque;
    public float Tor_min;
    public float Tor_max;
    public bool MinorRotate;
    public bool MajorRotate;
    private int seq;
    
    // Methods
    private void Start()
    {
        if(this.UImaster == false)
        {
                return;
        }
        
        projectile val_4 = this.bombList[this.bombType];
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void Update()
    {
        float val_18;
        float val_19;
        float val_20;
        float val_22;
        float val_23;
        if((UnityEngine.Input.GetButton(buttonName:  "Horizontal")) != false)
        {
                if((UnityEngine.Input.GetAxis(axisName:  "Horizontal")) < 0)
        {
                UnityEngine.Vector3 val_5 = UnityEngine.Vector3.up;
            val_18 = val_5.x;
            val_19 = val_5.y;
            val_20 = val_5.z;
            float val_6 = UnityEngine.Time.deltaTime;
            val_22 = -25f;
        }
        else
        {
                UnityEngine.Vector3 val_7 = UnityEngine.Vector3.up;
            val_18 = val_7.x;
            val_19 = val_7.y;
            val_20 = val_7.z;
            val_22 = 25f;
        }
        
            val_23 = val_18;
            this.gameObject.transform.Rotate(axis:  new UnityEngine.Vector3() {x = val_23, y = val_19, z = val_20}, angle:  UnityEngine.Time.deltaTime * val_22);
        }
        
        if((UnityEngine.Input.GetKeyDown(key:  113)) != false)
        {
                this.Switch(value:  0);
        }
        
        if((UnityEngine.Input.GetButtonDown(buttonName:  "Fire2")) != true)
        {
                if((UnityEngine.Input.GetKeyDown(key:  101)) == false)
        {
            goto label_13;
        }
        
        }
        
        this.Switch(value:  1);
        label_13:
        if((UnityEngine.Input.GetButtonDown(buttonName:  "Fire1")) != false)
        {
                this.firing = true;
            this.Fire();
        }
        
        if((UnityEngine.Input.GetButtonUp(buttonName:  "Fire1")) != false)
        {
                this.firing = false;
            this.firingTimer = 0f;
        }
        
        projectile val_16 = this.bombList[this.bombType];
        if(this.bombList[this.bombType][0].rapidFire != false)
        {
                if(this.firing == false)
        {
                return;
        }
        
            val_23 = this.bombList[this.bombType][0].rapidFireCooldown + this.rapidFireDelay;
            if(this.firingTimer > val_23)
        {
                this.Fire();
            this.firingTimer = 0f;
        }
        
        }
        
        if(this.firing == false)
        {
                return;
        }
        
        val_18 = this.firingTimer;
        float val_15 = UnityEngine.Time.deltaTime;
        val_15 = val_18 + val_15;
        this.firingTimer = val_15;
    }
    public void Switch(int value)
    {
        int val_4 = this.bombType + value;
        this.bombType = val_4;
        if(<0)
        {
            goto label_0;
        }
        
        if(val_4 < this.bombList.Length)
        {
            goto label_2;
        }
        
        val_4 = 0;
        goto label_3;
        label_0:
        val_4 = this.bombList.Length - 1;
        label_3:
        this.bombType = val_4;
        label_2:
        if(this.UImaster == false)
        {
                return;
        }
        
        projectile val_4 = this.bombList[val_4];
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void Fire()
    {
        var val_22;
        float val_23;
        float val_24;
        float val_25;
        float val_26;
        float val_28;
        float val_29;
        float val_30;
        float val_31;
        float val_32;
        float val_33;
        var val_34;
        if(this.CameraShake != false)
        {
                this.CameraShakeCaller.ShakeCamera();
        }
        
        projectile val_22 = this.bombList[this.bombType];
        UnityEngine.Vector3 val_1 = this.spawnLocatorMuzzleFlare.position;
        UnityEngine.Quaternion val_2 = this.spawnLocatorMuzzleFlare.rotation;
        val_22 = 1152921507344305472;
        val_23 = val_1.x;
        val_24 = val_1.y;
        val_25 = val_1.z;
        val_26 = val_2.x;
        UnityEngine.GameObject val_3 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.bombList[this.bombType][0].muzzleflare, position:  new UnityEngine.Vector3() {x = val_23, y = val_24, z = val_25}, rotation:  new UnityEngine.Quaternion() {x = val_26, y = val_2.y, z = val_2.z, w = val_2.w});
        projectile val_23 = this.bombList[this.bombType];
        if(this.bombList[this.bombType][0].hasShells != false)
        {
                UnityEngine.Vector3 val_4 = this.shellLocator.position;
            UnityEngine.Quaternion val_5 = this.shellLocator.rotation;
            val_23 = val_4.x;
            val_24 = val_4.y;
            val_25 = val_4.z;
            val_26 = val_5.x;
            UnityEngine.GameObject val_6 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.bombList[this.bombType][0].shellPrefab, position:  new UnityEngine.Vector3() {x = val_23, y = val_24, z = val_25}, rotation:  new UnityEngine.Quaternion() {x = val_26, y = val_5.y, z = val_5.z, w = val_5.w});
        }
        
        this.recoilAnimator.SetTrigger(name:  "recoil_trigger");
        projectile val_24 = this.bombList[this.bombType];
        UnityEngine.Vector3 val_7 = this.spawnLocator.position;
        UnityEngine.Quaternion val_8 = this.spawnLocator.rotation;
        val_28 = val_8.y;
        UnityEngine.Rigidbody val_9 = UnityEngine.Object.Instantiate<UnityEngine.Rigidbody>(original:  this.bombList[this.bombType][0].bombPrefab, position:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, rotation:  new UnityEngine.Quaternion() {x = val_8.x, y = val_28, z = val_8.z, w = val_8.w});
        UnityEngine.Vector3 val_10 = this.spawnLocator.forward;
        projectile val_25 = this.bombList[this.bombType];
        val_29 = val_10.x;
        val_30 = val_10.z;
        val_31 = val_29;
        val_32 = val_10.y;
        val_33 = val_30;
        UnityEngine.Vector3 val_12 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_31, y = val_32, z = val_33}, d:  UnityEngine.Random.Range(min:  this.bombList[this.bombType][0].min, max:  this.bombList[this.bombType][0].max));
        val_9.AddForce(force:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z});
        projectile val_26 = this.bombList[(long)this.bombType];
        if(this.bombList[(long)(int)(this.bombType)][0].shotgunBehavior == false)
        {
            goto label_39;
        }
        
        val_34 = 0;
        label_58:
        projectile val_27 = this.bombList[this.bombType];
        if(val_34 >= this.bombList[this.bombType][0].shotgunPellets)
        {
            goto label_39;
        }
        
        UnityEngine.Vector3 val_13 = this.shotgunLocator[0].position;
        UnityEngine.Quaternion val_14 = this.shotgunLocator[0].rotation;
        val_28 = val_14.y;
        val_22 = UnityEngine.Object.Instantiate<UnityEngine.Rigidbody>(original:  this.bombList[this.bombType][0].bombPrefab, position:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, rotation:  new UnityEngine.Quaternion() {x = val_14.x, y = val_28, z = val_14.z, w = val_14.w});
        UnityEngine.Vector3 val_16 = this.shotgunLocator[0].forward;
        projectile val_31 = this.bombList[this.bombType];
        val_29 = val_16.x;
        val_30 = val_16.z;
        val_31 = val_29;
        val_32 = val_16.y;
        val_33 = val_30;
        UnityEngine.Vector3 val_18 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_31, y = val_32, z = val_33}, d:  UnityEngine.Random.Range(min:  this.bombList[this.bombType][0].min, max:  this.bombList[this.bombType][0].max));
        val_22.AddForce(force:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z});
        val_34 = val_34 + 1;
        if(this.bombType < this.bombList.Length)
        {
            goto label_58;
        }
        
        throw new IndexOutOfRangeException();
        label_39:
        if(this.Torque != false)
        {
                UnityEngine.Vector3 val_19 = this.spawnLocator.up;
            val_29 = val_19.x;
            val_30 = val_19.z;
            UnityEngine.Vector3 val_21 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_29, y = val_19.y, z = val_30}, d:  UnityEngine.Random.Range(min:  this.Tor_min, max:  this.Tor_max));
            val_9.AddTorque(torque:  new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z});
        }
        
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
        
        var val_9 = 11543304 + (this.seq) << 2;
        val_9 = val_9 + 11543304;
        goto (11543304 + (this.seq) << 2 + 11543304);
    }
    private void Major_RandomizeRotation()
    {
        if(this.seq > 5)
        {
                return;
        }
        
        var val_5 = 11543328 + (this.seq) << 2;
        val_5 = val_5 + 11543328;
        goto (11543328 + (this.seq) << 2 + 11543328);
    }
    public projectileActor()
    {
        this.UImaster = true;
        this.CameraShake = true;
    }

}
