using UnityEngine;
public class CameraManager : MonoBehaviour
{
    // Fields
    private GunManager _gunManager;
    private UnityEngine.Camera _mainCamera;
    private UnityEngine.ParticleSystem _LevelCompleteFX;
    private EnemyManager _enemyManager;
    private Enemy _nearestEnemy;
    private UnityEngine.Quaternion _targetRotation;
    private System.Action _onFailed;
    private bool _isGameOver;
    private bool _isBoss;
    private DG.Tweening.Tween _shake;
    
    // Properties
    public UnityEngine.Camera MainCamera { get; }
    
    // Methods
    public UnityEngine.Camera get_MainCamera()
    {
        return (UnityEngine.Camera)this._mainCamera;
    }
    public void Init(System.Action onFailed, EnemyManager enemyManager, bool isBoss)
    {
        this._onFailed = onFailed;
        this._enemyManager = enemyManager;
        this._isBoss = isBoss;
        this._isGameOver = false;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        UnityEngine.Quaternion val_4 = UnityEngine.Quaternion.Euler(euler:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
        this._mainCamera.transform.localRotation = new UnityEngine.Quaternion() {x = val_4.x, y = val_4.y, z = val_4.z, w = val_4.w};
        this._gunManager.Init(camera:  this._mainCamera, onShoot:  new System.Action(object:  this, method:  System.Void CameraManager::ShootShake()));
    }
    public void StartProcess()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.<StartProcess>g__CoProcess|12_1());
    }
    public void OnGameOver()
    {
        this._isGameOver = true;
        this._gunManager.PlayJoy();
        this._LevelCompleteFX.Play();
    }
    public void OnFailed()
    {
        if(this._isGameOver == true)
        {
                return;
        }
        
        if(this._onFailed != null)
        {
                this._onFailed.Invoke();
        }
        
        this._isGameOver = true;
        if(this._nearestEnemy != 0)
        {
                this._nearestEnemy.ContactPlayer();
        }
        
        this._nearestEnemy = 0;
        UnityEngine.Vector3 val_3 = this._mainCamera.transform.forward;
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.zero;
        UnityEngine.Quaternion val_5 = UnityEngine.Quaternion.FromToRotation(fromDirection:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, toDirection:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z});
        this._targetRotation = val_5;
        mem[1152921507352972516] = val_5.y;
        mem[1152921507352972520] = val_5.z;
        mem[1152921507352972524] = val_5.w;
    }
    public void OnContinued()
    {
        this._isGameOver = false;
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.<StartProcess>g__CoProcess|12_1());
    }
    public void OnTap(UnityEngine.EventSystems.PointerEventData pointerEventData)
    {
        if(this._gunManager != null)
        {
                this._gunManager.OnTap(pointerEventData:  pointerEventData);
            return;
        }
        
        throw new NullReferenceException();
    }
    public void OnRelease()
    {
        if(this._gunManager != null)
        {
                this._gunManager.OnRelease();
            return;
        }
        
        throw new NullReferenceException();
    }
    public void ChangeGun()
    {
        if(this._gunManager != null)
        {
                this._gunManager.ChangeGun();
            return;
        }
        
        throw new NullReferenceException();
    }
    public void StopShoot()
    {
        if(this._gunManager != null)
        {
                this._gunManager.StopShoot();
            return;
        }
        
        throw new NullReferenceException();
    }
    private void ShootShake()
    {
        if(this._shake != null)
        {
                DG.Tweening.TweenExtensions.Complete(t:  this._shake);
        }
        
        this._shake = DG.Tweening.ShortcutExtensions.DOShakePosition(target:  this._mainCamera.transform, duration:  0.1f, strength:  0.1f, vibrato:  1, randomness:  90f, snapping:  false, fadeOut:  true);
    }
    public CameraManager()
    {
    
    }
    private void <StartProcess>g__UpdateCameraRotation|12_0()
    {
        UnityEngine.Quaternion val_3 = this._mainCamera.transform.rotation;
        float val_6 = 1.5f;
        val_6 = UnityEngine.Time.deltaTime * val_6;
        UnityEngine.Quaternion val_5 = UnityEngine.Quaternion.Lerp(a:  new UnityEngine.Quaternion() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w}, b:  new UnityEngine.Quaternion() {x = this._targetRotation, y = V12.16B, z = V13.16B, w = V14.16B}, t:  val_6);
        this._mainCamera.transform.rotation = new UnityEngine.Quaternion() {x = val_5.x, y = val_5.y, z = val_5.z, w = val_5.w};
    }
    private System.Collections.IEnumerator <StartProcess>g__CoProcess|12_1()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new CameraManager.<<StartProcess>g__CoProcess|12_1>d();
    }

}
