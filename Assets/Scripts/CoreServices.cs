using UnityEngine;
public class CoreServices
{
    // Fields
    private Kayac.SoundManager <soundManager>k__BackingField;
    private SaveData <saveData>k__BackingField;
    private RemoteConfig <remoteConfig>k__BackingField;
    private Kayac.HcAd.AppAdManager <adManager>k__BackingField;
    private Analytics <analytics>k__BackingField;
    private static CoreServices <instance>k__BackingField;
    private Kayac.FirebaseWrapper _firebase;
    private Kayac.FileWriter _fileWriter;
    private Kayac.FrameRateWatcher _frameRateWatcher;
    private int _currentRendererLevel;
    private UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset _renderSetting;
    
    // Properties
    public Kayac.SoundManager soundManager { get; set; }
    public SaveData saveData { get; set; }
    public RemoteConfig remoteConfig { get; set; }
    public Kayac.HcAd.AppAdManager adManager { get; set; }
    public Analytics analytics { get; set; }
    public static CoreServices instance { get; set; }
    public bool StoreReviewReady { get; }
    
    // Methods
    public Kayac.SoundManager get_soundManager()
    {
        return (Kayac.SoundManager)this.<soundManager>k__BackingField;
    }
    private void set_soundManager(Kayac.SoundManager value)
    {
        this.<soundManager>k__BackingField = value;
    }
    public SaveData get_saveData()
    {
        return (SaveData)this.<saveData>k__BackingField;
    }
    private void set_saveData(SaveData value)
    {
        this.<saveData>k__BackingField = value;
    }
    public RemoteConfig get_remoteConfig()
    {
        return (RemoteConfig)this.<remoteConfig>k__BackingField;
    }
    private void set_remoteConfig(RemoteConfig value)
    {
        this.<remoteConfig>k__BackingField = value;
    }
    public Kayac.HcAd.AppAdManager get_adManager()
    {
        return (Kayac.HcAd.AppAdManager)this.<adManager>k__BackingField;
    }
    private void set_adManager(Kayac.HcAd.AppAdManager value)
    {
        this.<adManager>k__BackingField = value;
    }
    public Analytics get_analytics()
    {
        return (Analytics)this.<analytics>k__BackingField;
    }
    private void set_analytics(Analytics value)
    {
        this.<analytics>k__BackingField = value;
    }
    public static CoreServices get_instance()
    {
        return (CoreServices)CoreServices.<instance>k__BackingField;
    }
    private static void set_instance(CoreServices value)
    {
        CoreServices.<instance>k__BackingField = value;
    }
    private CoreServices()
    {
        Kayac.FileWriter val_1 = new Kayac.FileWriter();
        this._fileWriter = val_1;
        this._firebase = new Kayac.FirebaseWrapper(fileWriter:  val_1, remoteConfigCachePath:  0);
        SaveData val_3 = SaveData.Load();
        this.<saveData>k__BackingField = val_3;
        this.<remoteConfig>k__BackingField = new RemoteConfig(firebase:  this._firebase, saveData:  val_3);
        this._renderSetting = UnityEngine.Resources.Load<UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset>(path:  "RenderSetting");
        UnityEngine.Application.targetFrameRate = 60;
        UnityEngine.Input.multiTouchEnabled = false;
        Kayac.SoundManager val_7 = UnityEngine.Object.Instantiate<Kayac.SoundManager>(original:  UnityEngine.Resources.Load<Kayac.SoundManager>(path:  "Prefabs/SoundManager"));
        this.<soundManager>k__BackingField = val_7;
        UnityEngine.Object.DontDestroyOnLoad(target:  val_7);
        this._frameRateWatcher = new Kayac.FrameRateWatcher(lowThresholdFrameTime:  24.4949f, onLow:  new System.Action<System.Single>(object:  this, method:  System.Void CoreServices::OnLowPerformance(float fps)), highThresholdFrameTime:  55f, onHigh:  new System.Action<System.Single>(object:  this, method:  System.Void CoreServices::OnHighPerformance(float fps)));
    }
    public void InitializeFirebase()
    {
        if(this._firebase != null)
        {
                this._firebase.Initialize(fetchForced:  false);
            return;
        }
        
        throw new NullReferenceException();
    }
    public void InitializeAd(UnityEngine.Transform dummyParentTransform)
    {
        Analytics val_1 = new Analytics();
        ._firebase = this._firebase;
        this.<analytics>k__BackingField = val_1;
        this.<adManager>k__BackingField = new Kayac.HcAd.AppAdManager(parentTransform:  dummyParentTransform, analytics:  val_1, firebase:  this._firebase);
    }
    public void Update()
    {
        this.<adManager>k__BackingField.Update();
        if((this.<adManager>k__BackingField.playing) != true)
        {
                this.<saveData>k__BackingField.UpdatePlayTime();
        }
        
        if(this._frameRateWatcher != null)
        {
                this._frameRateWatcher.Update();
        }
        
        if((this.<analytics>k__BackingField) == null)
        {
                return;
        }
        
        float val_2 = UnityEngine.Time.unscaledDeltaTime;
        val_2 = (this.<analytics>k__BackingField._levelFrameTimeSum) + val_2;
        this.<analytics>k__BackingField._levelFrameTimeSum = val_2;
    }
    public void SetResolution(int delayFrame)
    {
        if(this._frameRateWatcher != null)
        {
                this._frameRateWatcher.Check(delayFrames:  delayFrame);
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_StoreReviewReady()
    {
        if((this.<saveData>k__BackingField) != null)
        {
                if((this.<saveData>k__BackingField._storeReviewRequested) == false)
        {
                return (bool)((this.<saveData>k__BackingField._playTime) >= 1200) ? 1 : 0;
        }
        
            return false;
        }
        
        throw new NullReferenceException();
    }
    public System.Collections.IEnumerator CoRequestStoreReview()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new CoreServices.<CoRequestStoreReview>d__36();
    }
    public System.Collections.IEnumerator CoWaitAdReady()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new CoreServices.<CoWaitAdReady>d__37();
    }
    public System.Collections.IEnumerator CoWaitRemoteConfig()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new CoreServices.<CoWaitRemoteConfig>d__38();
    }
    private static void BeforeSplashScreen()
    {
        UnityEngine.Debug.Log(message:  "BeforeSplashScreen t="("BeforeSplashScreen t=") + UnityEngine.Time.realtimeSinceStartup);
    }
    private static void AfterAssembliesLoaded()
    {
        UnityEngine.Debug.Log(message:  "AfterAssembliesLoaded t="("AfterAssembliesLoaded t=") + UnityEngine.Time.realtimeSinceStartup);
    }
    private static void BeforeSceneLoad()
    {
        UnityEngine.Debug.Log(message:  "BeforeSceneLoad t="("BeforeSceneLoad t=") + UnityEngine.Time.realtimeSinceStartup);
        CoreServices.TryCreateInstance();
    }
    private static void TryCreateInstance()
    {
        CoreServices val_2;
        if((CoreServices.<instance>k__BackingField) != null)
        {
                return;
        }
        
        CoreServices val_1 = null;
        val_2 = val_1;
        val_1 = new CoreServices();
        CoreServices.<instance>k__BackingField = val_2;
    }
    private void OnLowPerformance(float fps)
    {
        UnityEngine.Debug.Log(message:  "OnLowPerformance : "("OnLowPerformance : ") + fps);
        this.SetRendererLevel(newLevel:  (this.<saveData>k__BackingField._rendererLevel) + ((fps < 0) ? -3 : ((fps < 0) ? -2 : (!0))));
    }
    private void OnHighPerformance(float fps)
    {
        UnityEngine.Debug.Log(message:  "OnHighPerformance : "("OnHighPerformance : ") + fps);
        this.SetRendererLevel(newLevel:  (this.<saveData>k__BackingField._rendererLevel) + 1);
    }
    public void SetRendererLevel(int newLevel)
    {
        int val_1 = UnityEngine.Mathf.Clamp(value:  newLevel, min:  -3, max:  0);
        UnityEngine.Debug.Log(message:  "SetRendererLevel " + val_1);
        if((val_1 != 3) && (val_1 != 2))
        {
                if(val_1 == 1)
        {
            
        }
        
        }
        
        this._renderSetting.renderScale = 1f;
        this.<saveData>k__BackingField._rendererLevel = val_1;
    }

}
