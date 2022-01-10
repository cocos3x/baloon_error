using UnityEngine;
public class Enemy : MonoBehaviour
{
    // Fields
    private float _speed;
    private float _explosionPower;
    private UnityEngine.Rigidbody _spine;
    private UnityEngine.Rigidbody _head;
    private UnityEngine.Transform _aimTransform;
    private UnityEngine.Animator _animator;
    private UnityEngine.MeshRenderer _faceMeshRenderer;
    private UnityEngine.Transform _rootTransform;
    private BalloonRocket _balloonRocket;
    private bool _useRocket;
    private bool _isKilled;
    private bool _isBoss;
    private int _balloonCount;
    private float _attackTimer;
    private float _faceTimer;
    private UnityEngine.Transform _playerTransform;
    private Level _level;
    private System.Collections.Generic.List<BalloonRocket> _balloonRockets;
    private CoreServices _core;
    private UnityEngine.Texture[] _faceTextures;
    private UnityEngine.Texture[] _damagedFaceTextures;
    private System.Action _onKilled;
    
    // Properties
    public bool IsBoss { get; }
    public UnityEngine.Transform AimTransform { get; }
    
    // Methods
    public bool get_IsBoss()
    {
        return (bool)this._isBoss;
    }
    public UnityEngine.Transform get_AimTransform()
    {
        return (UnityEngine.Transform)this._aimTransform;
    }
    public void Init(UnityEngine.Color[] colors, bool isBoss, System.Action onKilledBoss, Level level, UnityEngine.Texture[] faceTextures, UnityEngine.Texture[] damagedFaceTextures, UnityEngine.Texture dieFaceTexture)
    {
        this._onKilled = onKilledBoss;
        this._isBoss = isBoss;
        this._level = level;
        this._faceTextures[0] = faceTextures[UnityEngine.Random.Range(min:  0, max:  faceTextures.Length)];
        this._faceTextures[2] = dieFaceTexture;
        this._damagedFaceTextures = damagedFaceTextures;
        this._core = CoreServices.<instance>k__BackingField;
        Balloon val_4 = this._spine.gameObject.GetComponent<Balloon>();
        int val_5 = UnityEngine.Random.Range(min:  0, max:  colors.Length);
        UnityEngine.Color val_8 = colors[((long)(int)(val_5)) << 4];
        UnityEngine.Color val_9 = colors[((long)(int)(val_5)) << 4];
        UnityEngine.Color val_10 = colors[((long)(int)(val_5)) << 4];
        UnityEngine.Color val_11 = colors[((long)(int)(val_5)) << 4];
        val_4.BalloonSetUp(currentNode:  val_4.transform, parent:  val_4, randomColor:  new UnityEngine.Color() {r = val_8, g = val_9, b = val_10, a = val_11}, enemy:  this);
        val_4.Init(enemy:  this, randomColor:  new UnityEngine.Color() {r = val_8, g = val_9, b = val_10, a = val_11});
        this.ChangeFace(faceType:  0);
    }
    public void OnClosePlayer(UnityEngine.Transform playerTransform)
    {
        this._animator.Play(stateName:  "Walking");
        this._playerTransform = playerTransform;
    }
    public void ContactPlayer()
    {
        this._animator.Play(stateName:  "Idle");
        this._playerTransform = 0;
    }
    private void ChangeFace(Enemy.FaceType faceType)
    {
        FaceType val_6 = faceType;
        if(this._faceMeshRenderer == 0)
        {
                return;
        }
        
        if(val_6 == 1)
        {
            goto label_4;
        }
        
        if(val_6 != 0)
        {
            goto label_6;
        }
        
        val_6 = ((this._balloonCount > 5) ? 1 : 0) << 1;
        goto label_6;
        label_4:
        this._faceTextures[1] = this._damagedFaceTextures[UnityEngine.Random.Range(min:  0, max:  this._damagedFaceTextures.Length)];
        val_6 = 1;
        this._faceTimer = 1f;
        label_6:
        this._faceMeshRenderer.material.mainTexture = this._faceTextures[val_6];
    }
    public void OnHit(Balloon balloon, bool isAddForce)
    {
        bool val_9 = isAddForce;
        Sound.Play(self:  0);
        if(this._faceTimer > 1f)
        {
                this.ChangeFace(faceType:  1);
        }
        
        int val_9 = this._balloonCount;
        val_9 = val_9 + 1;
        this._balloonCount = val_9;
        if(val_9 == false)
        {
                return;
        }
        
        val_9 = this._spine;
        if(val_9 == 0)
        {
                return;
        }
        
        UnityEngine.Vector3 val_3 = this._spine.transform.position;
        UnityEngine.Vector3 val_5 = balloon.transform.position;
        UnityEngine.Vector3 val_6 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, b:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z});
        val_6.x = val_6.x * 0.2f;
        val_6.y = val_6.y * 1.15f;
        val_6.z = val_6.z * 0.2f;
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, d:  2f);
        UnityEngine.Vector3 val_8 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, d:  this._explosionPower);
        this._spine.AddForce(force:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, mode:  1);
    }
    private void Update()
    {
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = this._faceTimer - val_1;
        this._faceTimer = val_1;
        if(val_1 < 0)
        {
                this.ChangeFace(faceType:  0);
            this._faceTimer = -1.175494E-38f;
        }
        
        if(this._core == null)
        {
                return;
        }
        
        if((this._core.<saveData>k__BackingField._lastLevelIndex) < 40)
        {
                return;
        }
        
        this.<Update>g__RocketUprate|32_0();
    }
    private void FixedUpdate()
    {
        if(this._isKilled != false)
        {
                return;
        }
        
        if(this._aimTransform == 0)
        {
                if(this._head != 0)
        {
                UnityEngine.Vector3 val_3 = UnityEngine.Vector3.up;
            UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, d:  5f);
            this._head.AddForce(force:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, mode:  1);
            this._aimTransform = this._head.transform;
        }
        
        }
        
        if(this._spine == 0)
        {
                if(this._head == 0)
        {
                this.OnKilled();
            return;
        }
        
        }
        
        if(this._spine == 0)
        {
                return;
        }
        
        UnityEngine.Vector3 val_10 = this._spine.transform.forward;
        UnityEngine.Vector3 val_11 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, d:  this._speed);
        this._spine.AddForce(force:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z});
        if(this._playerTransform == 0)
        {
                return;
        }
        
        UnityEngine.Vector3 val_14 = this._spine.transform.position;
        UnityEngine.Vector3 val_16 = this._playerTransform.transform.position;
        UnityEngine.Vector3 val_17 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, b:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z});
        UnityEngine.Quaternion val_18 = UnityEngine.Quaternion.LookRotation(forward:  new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z});
        UnityEngine.Quaternion val_19 = this._rootTransform.localRotation;
        float val_20 = UnityEngine.Time.deltaTime;
        val_20 = val_20 * 0.5f;
        UnityEngine.Quaternion val_21 = UnityEngine.Quaternion.Lerp(a:  new UnityEngine.Quaternion() {x = val_19.x, y = val_19.y, z = val_19.z, w = val_19.w}, b:  new UnityEngine.Quaternion() {x = val_18.x, y = val_18.y, z = val_18.z, w = val_18.w}, t:  val_20);
        this._rootTransform.localRotation = new UnityEngine.Quaternion() {x = val_21.x, y = val_21.y, z = val_21.z, w = val_21.w};
    }
    private void OnKilled()
    {
        List.Enumerator<T> val_1 = this._balloonRockets.GetEnumerator();
        label_7:
        if(((-1523658296) & 1) == 0)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
            goto label_7;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        0.OnHit(isAddForce:  false);
        goto label_7;
        label_2:
        UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
        if(this._onKilled != null)
        {
                this._onKilled.Invoke();
        }
        
        this._isKilled = true;
    }
    public void LaunchRocket(System.Action onKilledPlayer)
    {
        this._animator.Play(stateName:  "Attack");
        UnityEngine.Vector3 val_1 = this._aimTransform.position;
        float val_2 = UnityEngine.Random.Range(min:  -90f, max:  0f);
        float val_3 = UnityEngine.Random.Range(min:  0f, max:  180f);
        UnityEngine.Quaternion val_4 = UnityEngine.Quaternion.Euler(euler:  new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f});
        BalloonRocket val_6 = UnityEngine.Object.Instantiate<BalloonRocket>(original:  this._balloonRocket, position:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, rotation:  new UnityEngine.Quaternion() {x = val_4.x, y = val_4.y, z = val_4.z, w = val_4.w}, parent:  this.transform);
        val_6.Init(onKilledPlayer:  onKilledPlayer);
        this._balloonRockets.Add(item:  val_6);
    }
    public Enemy()
    {
        this._faceTimer = -1.175494E-38f;
        this._balloonRockets = new System.Collections.Generic.List<BalloonRocket>();
        this._faceTextures = new UnityEngine.Texture[3];
    }
    private void <Update>g__RocketUprate|32_0()
    {
        if(this._useRocket == false)
        {
                return;
        }
        
        if(this._isKilled == true)
        {
                return;
        }
        
        if(this._playerTransform == 0)
        {
                return;
        }
        
        float val_2 = UnityEngine.Time.deltaTime;
        val_2 = val_2 + val_2;
        val_2 = this._attackTimer - val_2;
        this._attackTimer = val_2;
        if(val_2 >= 0)
        {
                return;
        }
        
        this._attackTimer = UnityEngine.Random.Range(min:  2f, max:  4f);
        this.LaunchRocket(onKilledPlayer:  new System.Action(object:  this, method:  System.Void Enemy::<Update>b__32_1()));
    }
    private void <Update>b__32_1()
    {
        if(this._level != null)
        {
                this._level.OnKilledPlayer();
            return;
        }
        
        throw new NullReferenceException();
    }

}
