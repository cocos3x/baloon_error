using UnityEngine;
public class Manager : Manager
{
    // Fields
    private UnityEngine.Transform _completeLabel;
    private CameraManager _cameraManager;
    private Kayac.HiddenCommand _command;
    private UnityEngine.Canvas _canvas;
    private FPSCounter _fpsCounter;
    private OverRayManager _overRayManager;
    private WeaponSelectManager _weaponSelectManager;
    private UnityEngine.UI.Button _weaponMenuButton;
    private ProgressGaugeManager _progressGaugeManager;
    private FailedManager _failedManager;
    private UnityEngine.GameObject _loadGameObject;
    private UnityEngine.UI.Image _loadGaugeImage;
    private int _levelFrames;
    private float _levelTime;
    private bool _needPlayAdAfterGameStart;
    private DebugMenu _debugMenu;
    private CoreServices _core;
    private Skin _skin;
    private UnityEngine.Material[] _skyBoxes;
    
    // Properties
    private Level _level { get; }
    
    // Methods
    private Level get__level()
    {
        if(6493 == 0)
        {
                return 6493;
        }
        
        return 6493;
    }
    private void Awake()
    {
        this._core = CoreServices.<instance>k__BackingField;
        this._skin = new Skin();
        this._core.<saveData>k__BackingField.SetSkinIds(ids:  (Skin)[1152921507364504528]._ids);
        this._core.<saveData>k__BackingField.Save();
        this._weaponMenuButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void Manager::OnWeaponMenuButtonClick()));
        this._command.<onMatch>k__BackingField = new System.Action(object:  this, method:  System.Void Manager::OnHiddenCommandEnter());
        this._fpsCounter.SetFpsViewEnabled(enable:  false);
    }
    protected override void Prepare()
    {
        this.Prepare();
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
        localPosition = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
        this._progressGaugeManager.Init(currentLevelIndex:  (this._core.<saveData>k__BackingField._lastLevelIndex) + 1);
        this._progressGaugeManager.gameObject.SetActive(value:  true);
        EnemyData val_4 = UnityEngine.Resources.Load<EnemyData>(path:  "ScriptableObjects/EnemyData");
        this._level.Init(manager:  this, cameraManager:  this._cameraManager, enemyColors:  val_4._colors, faceTextures:  UnityEngine.Resources.LoadAll<UnityEngine.Texture>(path:  "FaceTextures"), damagedFaceTextures:  UnityEngine.Resources.LoadAll<UnityEngine.Texture>(path:  "DamagedFaceTexture"), dieFaceTextures:  UnityEngine.Resources.Load<UnityEngine.Texture>(path:  "DieFaceTexture/face_dead"));
        this._failedManager.Prepare();
        UnityEngine.GameObject val_9 = this._completeLabel.gameObject;
        val_9.SetActive(value:  false);
        val_9.localPosition = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
        if(this.GetAvailableWeaponCount() >= 2)
        {
                if((this._core.<saveData>k__BackingField._isTrial) == false)
        {
            goto label_18;
        }
        
        }
        
        label_23:
        this._weaponMenuButton.gameObject.SetActive(value:  false);
        this.ChangeBackGround();
        return;
        label_18:
        UnityEngine.GameObject val_12 = this._weaponMenuButton.gameObject;
        goto label_23;
    }
    private int GetAvailableWeaponCount()
    {
        var val_3;
        if(((this._core.<saveData>k__BackingField._skinStates.Length) << 32) >= 1)
        {
                var val_3 = 0;
            do
        {
            val_3 = val_3 + 1;
            var val_2 = (1152921505923071375 < 2) ? (0 + 1) : 0;
        }
        while(val_3 < ((long)this._core.<saveData>k__BackingField._skinStates.Length));
        
            return (int)val_3;
        }
        
        val_3 = 0;
        return (int)val_3;
    }
    private void Start()
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.CoBoot());
    }
    private void Update()
    {
        this._core.Update();
        int val_2 = this._levelFrames;
        val_2 = val_2 + 1;
        this._levelFrames = val_2;
        float val_1 = UnityEngine.Time.unscaledDeltaTime;
        val_1 = this._levelTime + val_1;
        this._levelTime = val_1;
    }
    private System.Collections.IEnumerator CoBoot()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new Manager.<CoBoot>d__26();
    }
    protected override void GameStart()
    {
        this._core.<analytics>k__BackingField.OnLevelStart(levelIndex:  this._core.<saveData>k__BackingField._lastLevelIndex);
        this.GameStart();
        this._level.GameStart();
        if(this._needPlayAdAfterGameStart == false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.<GameStart>g__CoShowAd|27_0());
    }
    protected override System.Collections.IEnumerator CoGameOver(string levelName)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .levelName = levelName;
        return (System.Collections.IEnumerator)new Manager.<CoGameOver>d__28();
    }
    private void PlayOverRay()
    {
        this._overRayManager.PlaySurprisedReward(core:  this._core);
        this._completeLabel.gameObject.SetActive(value:  false);
    }
    public override void Failed()
    {
        this._core.<analytics>k__BackingField.OnLevelFailed(levelIndex:  this._core.<saveData>k__BackingField._lastLevelIndex);
        UnityEngine.Coroutine val_3 = this._failedManager.StartCoroutine(routine:  this._failedManager.CoPlay());
        this._failedManager._decline = new System.Action(object:  this, method:  System.Void Manager::<Failed>g__Decline|30_0());
    }
    private void OnWeaponMenuButtonClick()
    {
        this._weaponSelectManager.Init(onClose:  new System.Action(object:  this, method:  System.Void Manager::<OnWeaponMenuButtonClick>b__31_0()));
        this._weaponSelectManager.Show();
    }
    private void OnHiddenCommandEnter()
    {
        if(this._debugMenu == 0)
        {
                DebugMenu val_4 = UnityEngine.Object.Instantiate<DebugMenu>(original:  UnityEngine.Resources.Load<DebugMenu>(path:  "Prefabs/DebugMenu"), parent:  this._canvas.transform, worldPositionStays:  false);
            this._debugMenu = val_4;
            val_4.Init(core:  this._core, manager:  this, fpsCounter:  this._fpsCounter);
        }
        
        this._debugMenu.Show();
    }
    private void ChangeBackGround()
    {
        var val_6;
        UnityEngine.Material[] val_7;
        val_6 = 0;
        var val_6 = 1;
        label_4:
        if(val_6 > (this._core.<saveData>k__BackingField._lastLevelIndex))
        {
            goto label_3;
        }
        
        var val_2 = X12 >> 33;
        val_2 = val_2 + (X12 >> 63);
        val_2 = val_2 + (val_2 << 2);
        var val_3 = (val_6 == val_2) ? (val_6 + 1) : (val_6);
        val_6 = val_6 + 1;
        if((this._core.<saveData>k__BackingField) != null)
        {
            goto label_4;
        }
        
        throw new NullReferenceException();
        label_3:
        val_7 = this._skyBoxes;
        if(val_7 == null)
        {
                T[] val_4 = UnityEngine.Resources.LoadAll<UnityEngine.Material>(path:  "Skyboxes");
            this._skyBoxes = val_4;
        }
        
        int val_5 = val_3 / val_4.Length;
        val_5 = val_3 - (val_5 * val_4.Length);
        UnityEngine.RenderSettings.skybox = val_4[val_5];
    }
    public Manager()
    {
    
    }
    private System.Collections.IEnumerator <GameStart>g__CoShowAd|27_0()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new Manager.<<GameStart>g__CoShowAd|27_0>d();
    }
    private void <GameStart>b__27_1()
    {
        this._needPlayAdAfterGameStart = false;
        Level val_1 = this._level;
        this._core.SetResolution(delayFrame:  120);
        this._levelFrames = 0;
        this._levelTime = 0f;
    }
    private void <Failed>g__Decline|30_0()
    {
        this._core.<adManager>k__BackingField.ShowInterstitial(onEnd:  new System.Action(object:  this, method:  System.Void Manager::<Failed>g__Restart|30_1()), onBegin:  0);
    }
    private void <Failed>g__Restart|30_1()
    {
        goto typeof(Manager).__il2cppRuntimeField_180;
    }
    private void <OnWeaponMenuButtonClick>b__31_0()
    {
        if(this._cameraManager != null)
        {
                this._cameraManager.ChangeGun();
            return;
        }
        
        throw new NullReferenceException();
    }

}
