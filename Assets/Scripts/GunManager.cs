using UnityEngine;
public class GunManager : MonoBehaviour
{
    // Fields
    private BulletManager _bulletManager;
    private UnityEngine.Transform _gunRotateRootTransform;
    private UnityEngine.Transform _muzzleTransform;
    private UnityEngine.ParticleSystem _muzzleFlushFX;
    private UnityEngine.Animator _gunAnimator;
    private UnityEngine.ParticleSystem _ejectionParticle;
    private UnityEngine.Transform _modelRootTransform;
    private UnityEngine.Transform _targetSight;
    private UnityEngine.UI.Image _targetSightImage;
    private GunData _gunData;
    private Gun _gun;
    private UnityEngine.Camera _mainCamera;
    private bool _taped;
    private System.Action _onShoot;
    private UnityEngine.Coroutine _sightFadeOutCoroutine;
    private UnityEngine.Coroutine _shootCoRoutine;
    
    // Methods
    public void Init(UnityEngine.Camera camera, System.Action onShoot)
    {
        this._mainCamera = camera;
        this._onShoot = onShoot;
        this._targetSight.gameObject.SetActive(value:  false);
        this._bulletManager.Init();
        if(this._gunData == 0)
        {
                this._gunData = UnityEngine.Resources.Load<GunData>(path:  "ScriptableObjects/GunData");
        }
        
        this.ChangeGun();
    }
    public void StopShoot()
    {
        this._taped = false;
    }
    public void ChangeGun()
    {
        var val_11;
        var val_12;
        if(this._modelRootTransform == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.IEnumerator val_1 = this._modelRootTransform.GetEnumerator();
        label_17:
        var val_10 = 0;
        val_10 = val_10 + 1;
        if(val_1.MoveNext() == false)
        {
            goto label_7;
        }
        
        var val_11 = 0;
        val_11 = val_11 + 1;
        object val_5 = val_1.Current;
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Object.Destroy(obj:  val_5.gameObject);
        goto label_17;
        label_7:
        val_11 = 0;
        if(X0 == false)
        {
            goto label_18;
        }
        
        var val_14 = X0;
        if((X0 + 294) == 0)
        {
            goto label_22;
        }
        
        var val_12 = X0 + 176;
        var val_13 = 0;
        val_12 = val_12 + 8;
        label_21:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_20;
        }
        
        val_13 = val_13 + 1;
        val_12 = val_12 + 16;
        if(val_13 < (X0 + 294))
        {
            goto label_21;
        }
        
        goto label_22;
        label_20:
        val_14 = val_14 + (((X0 + 176 + 8)) << 4);
        val_12 = val_14 + 304;
        label_22:
        X0.Dispose();
        label_18:
        if(val_11 != 0)
        {
                throw X21;
        }
        
        if((CoreServices.<instance>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if(null == 0)
        {
                throw new NullReferenceException();
        }
        
        if(this._gunData == null)
        {
                throw new NullReferenceException();
        }
        
        if(this._gunData.guns == null)
        {
                throw new NullReferenceException();
        }
        
        val_11 = (long)GetSelectedSkinId();
        this._gun = this._gunData.guns[val_11];
        T[] val_8 = UnityEngine.Resources.LoadAll<UnityEngine.GameObject>(path:  "Guns");
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_9 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_8[val_11], parent:  this._modelRootTransform);
    }
    public void OnTap(UnityEngine.EventSystems.PointerEventData pointerEventData)
    {
        this._taped = true;
        if(this._gun.rapidFire != false)
        {
                if(this._shootCoRoutine != null)
        {
                this.StopCoroutine(routine:  this._shootCoRoutine);
            this._gun = this._gun;
            this._shootCoRoutine = 0;
        }
        
            this._shootCoRoutine = this.StartCoroutine(routine:  this.CoShoot(pointerEventData:  pointerEventData, burstCount:  this._gun.burst));
            return;
        }
        
        this.Shoot(pointerPos:  new UnityEngine.Vector2() {x = pointerEventData.<position>k__BackingField}, shootType:  this._gun.shootType);
    }
    public void OnRelease()
    {
        this._taped = false;
    }
    private System.Collections.IEnumerator CoShoot(UnityEngine.EventSystems.PointerEventData pointerEventData, int burstCount)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .pointerEventData = pointerEventData;
        .burstCount = burstCount;
        return (System.Collections.IEnumerator)new GunManager.<CoShoot>d__22();
    }
    private void Shoot(UnityEngine.Vector2 pointerPos, GunManager.ShootType shootType)
    {
        float val_19;
        float val_20;
        float val_21;
        float val_22;
        float val_23;
        float val_24;
        int val_25;
        val_19 = pointerPos.y;
        Vibration.VibrateLight();
        Sound.Play(self:  this._gun.fireSe);
        this._gunAnimator.Play(stateName:  "GunFire");
        this._muzzleFlushFX.Play();
        if(this._onShoot != null)
        {
                this._onShoot.Invoke();
        }
        
        this._targetSight.gameObject.SetActive(value:  true);
        UnityEngine.Vector3 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = pointerPos.x, y = val_19});
        this._targetSight.position = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        if(this._sightFadeOutCoroutine != null)
        {
                this.StopCoroutine(routine:  this._sightFadeOutCoroutine);
            Kayac.HyperCasual.Util.SetAlpha(self:  this._targetSightImage, a:  1f);
        }
        
        this._sightFadeOutCoroutine = this.StartCoroutine(routine:  this.CoFadeoutSight());
        UnityEngine.Vector3 val_5 = this._mainCamera.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f});
        UnityEngine.Vector3 val_6 = this._muzzleTransform.position;
        val_20 = val_6.z;
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, b:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_20});
        val_21 = val_7.x;
        val_22 = val_7.y;
        val_23 = val_7.z;
        this._gunRotateRootTransform.transform.LookAt(worldPosition:  new UnityEngine.Vector3() {x = val_21, y = val_22, z = val_23});
        UnityEngine.Quaternion val_9 = this._gunRotateRootTransform.localRotation;
        val_24 = val_9.y;
        val_25 = this._gunRotateRootTransform.transform;
        UnityEngine.Quaternion val_11 = UnityEngine.Quaternion.Euler(euler:  new UnityEngine.Vector3() {x = 0f, y = val_24, z = val_9.z});
        val_25.localRotation = new UnityEngine.Quaternion() {x = val_11.x, y = val_11.y, z = val_11.z, w = val_11.w};
        if(shootType != 0)
        {
                if(shootType != 1)
        {
                return;
        }
        
            var val_19 = 0;
            do
        {
            val_19 = val_19 + 1;
            if(val_19 >= this._gun.bulletNum)
        {
                return;
        }
        
            this.Shoot(direction:  new UnityEngine.Vector3() {x = val_21, y = val_22, z = val_23});
            val_25 = -this._gun.diffusivity;
            UnityEngine.Vector2 val_14 = new UnityEngine.Vector2(x:  (float)UnityEngine.Random.Range(min:  val_25, max:  this._gun.diffusivity), y:  (float)UnityEngine.Random.Range(min:  val_25, max:  this._gun.diffusivity));
            UnityEngine.Vector2 val_15 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = pointerPos.x, y = val_19}, b:  new UnityEngine.Vector2() {x = val_14.x, y = val_14.y});
            val_19 = val_15.y;
            UnityEngine.Vector3 val_16 = this._mainCamera.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f});
            UnityEngine.Vector3 val_17 = this._muzzleTransform.position;
            val_24 = val_17.x;
            val_20 = val_17.z;
            UnityEngine.Vector3 val_18 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z}, b:  new UnityEngine.Vector3() {x = val_24, y = val_17.y, z = val_20});
            val_21 = val_18.x;
            val_22 = val_18.y;
            val_23 = val_18.z;
        }
        while(this._gun != null);
        
            throw new NullReferenceException();
        }
        
        this.Shoot(direction:  new UnityEngine.Vector3() {x = val_21, y = val_22, z = val_23});
    }
    private System.Collections.IEnumerator CoFadeoutSight()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new GunManager.<CoFadeoutSight>d__24();
    }
    public void SetMoving(bool moving)
    {
        string val_2;
        this._gunAnimator.SetBool(name:  "isMoving", value:  moving);
        if(moving != false)
        {
                val_2 = "Move";
        }
        else
        {
                val_2 = "Idle";
        }
        
        this._gunAnimator.CrossFade(stateName:  val_2, normalizedTransitionDuration:  0.25f);
    }
    public void PlayJoy()
    {
        this._gunAnimator.CrossFade(stateName:  "Joy1", normalizedTransitionDuration:  0.1f);
    }
    private void Shoot(UnityEngine.Vector3 direction)
    {
        this._bulletManager.Shoot(direction:  new UnityEngine.Vector3() {x = direction.x, y = direction.y, z = direction.z}, muzzleTransform:  this._muzzleTransform, explosion:  this._gun.explosion);
        this._ejectionParticle.Play(withChildren:  true);
    }
    public GunManager()
    {
    
    }

}
