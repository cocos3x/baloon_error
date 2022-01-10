using UnityEngine;

namespace Kayac
{
    public class AdManager
    {
        // Fields
        private Kayac.AdManager.StateType <State>k__BackingField;
        private Kayac.AdManager.ErrorType <LastError>k__BackingField;
        private Kayac.MaxSdkWrapperBase.Callbacks callbacks;
        private Kayac.MaxSdkWrapperBase maxSdkWrapper;
        private string tenjinApiKey;
        private float interstitialDelayedLoadTimer;
        private float rewardedDelayedLoadTimer;
        private bool rewardedReadyCached;
        private float rewardedReadyFetchTimer;
        private const float rewardedReadyFetchInterval = 1;
        private Kayac.FirebaseWrapper firebase;
        private System.Action onBegin;
        private System.Action<Kayac.AdManager.ErrorType> onEnd;
        private bool bannerVisible;
        private bool lastRewardedReceived;
        private int timeoutCount;
        private int rewardedLoadFailCount;
        private int interstitialLoadFailCount;
        private int lastSendCeiledLoadFail;
        private int loadExponentialSteps;
        private System.Action<Kayac.AdManager.AdType, double> onRevenuePaid;
        
        // Properties
        public Kayac.AdManager.StateType State { get; set; }
        public Kayac.AdManager.ErrorType LastError { get; set; }
        public bool RewardedReady { get; }
        public bool SdkReady { get; }
        public bool playing { get; }
        public System.Nullable<bool> NeedsGdprConsent { get; }
        public bool InterstitialReady { get; }
        
        // Methods
        public Kayac.AdManager.StateType get_State()
        {
            return (StateType)this.<State>k__BackingField;
        }
        private void set_State(Kayac.AdManager.StateType value)
        {
            this.<State>k__BackingField = value;
        }
        public Kayac.AdManager.ErrorType get_LastError()
        {
            return (ErrorType)this.<LastError>k__BackingField;
        }
        private void set_LastError(Kayac.AdManager.ErrorType value)
        {
            this.<LastError>k__BackingField = value;
        }
        public AdManager(Kayac.FirebaseWrapper firebase)
        {
            this.interstitialDelayedLoadTimer = ;
            this.lastSendCeiledLoadFail = 0;
            this.firebase = firebase;
            this.<State>k__BackingField = 0;
            this.lastRewardedReceived = false;
            mem[1152921507445189696] = new System.Action(object:  this, method:  System.Void Kayac.AdManager::OnInterstitialLoadFailed());
            mem[1152921507445189704] = new System.Action(object:  this, method:  System.Void Kayac.AdManager::OnInterstitialFailedToDisplay());
            mem[1152921507445189712] = new System.Action(object:  this, method:  System.Void Kayac.AdManager::OnInterstitialDisplayed());
            mem[1152921507445189728] = new System.Action(object:  this, method:  System.Void Kayac.AdManager::OnInterstitialHidden());
            mem[1152921507445189744] = new System.Action(object:  this, method:  System.Void Kayac.AdManager::OnRewardedLoadFailed());
            mem[1152921507445189752] = new System.Action(object:  this, method:  System.Void Kayac.AdManager::OnRewardedFailedToDisplay());
            mem[1152921507445189760] = new System.Action(object:  this, method:  System.Void Kayac.AdManager::OnRewardedDisplayed());
            mem[1152921507445189776] = new System.Action(object:  this, method:  System.Void Kayac.AdManager::OnRewardedReceivedReward());
            mem[1152921507445189784] = new System.Action(object:  this, method:  System.Void Kayac.AdManager::OnRewardedHidden());
            mem[1152921507445189688] = new System.Action<System.Double>(object:  this, method:  System.Void Kayac.AdManager::OnBannerRevenuePaid(double value));
            mem[1152921507445189736] = new System.Action<System.Double>(object:  this, method:  System.Void Kayac.AdManager::OnInterstitialRevenuePaid(double value));
            mem[1152921507445189792] = new System.Action<System.Double>(object:  this, method:  System.Void Kayac.AdManager::OnRewardedRevenuePaid(double value));
        }
        public void Initialize(string maxSdkKey, string maxInterstitialUnitId, string maxRewardedUnitId, string maxBannerUnitId, string tenjinApiKey)
        {
            Kayac.MaxSdkWrapper val_1 = null;
            val_1 = new Kayac.MaxSdkWrapper(callbacks:  new Callbacks(), sdkKey:  maxSdkKey, interstitialUnitId:  maxInterstitialUnitId, rewardedUnitId:  maxRewardedUnitId, bannerUnitId:  maxBannerUnitId);
            this.maxSdkWrapper = val_1;
            this.tenjinApiKey = tenjinApiKey;
            this.<State>k__BackingField = 1;
        }
        public void InitializeDummy(UnityEngine.Transform parentTransform, bool needsGdprConsent)
        {
            Kayac.MaxSdkWrapperDummy val_2 = null;
            val_2 = new Kayac.MaxSdkWrapperDummy(callbacks:  new Callbacks(), parentTransform:  parentTransform, needsGdprConsent:  needsGdprConsent);
            this.maxSdkWrapper = val_2;
            this.<State>k__BackingField = 1;
        }
        public Kayac.AdManager.ErrorType Start(int loadExponentialSteps)
        {
            object val_2;
            ErrorType val_3;
            val_2 = this;
            this.loadExponentialSteps = loadExponentialSteps;
            if((this.<State>k__BackingField) == 0)
            {
                goto label_1;
            }
            
            if((this.<State>k__BackingField) != 1)
            {
                goto label_2;
            }
            
            if((this.maxSdkWrapper & 1) == 0)
            {
                goto label_4;
            }
            
            this.ConnectTenjin();
            this.LoadInterstitial();
            this.LoadRewarded();
            val_3 = 0;
            this.<State>k__BackingField = 3;
            return val_3;
            label_1:
            val_3 = 1;
            goto label_7;
            label_2:
            val_3 = 0;
            return val_3;
            label_4:
            val_3 = 2;
            label_7:
            this.<LastError>k__BackingField = val_3;
            val_2 = "AdManager.Start: "("AdManager.Start: ") + val_3;
            UnityEngine.Debug.LogError(message:  val_2);
            return val_3;
        }
        public Kayac.AdManager.ErrorType ShowInterstitial(System.Action onBegin, System.Action<Kayac.AdManager.ErrorType> onEnd)
        {
            var val_3;
            if((this.<State>k__BackingField) <= 7)
            {
                    var val_3 = 12339284;
                val_3 = (12339284 + (this.<State>k__BackingField) << 2) + val_3;
            }
            else
            {
                    val_3 = 12;
                this.<LastError>k__BackingField = 5;
                UnityEngine.Debug.LogError(message:  "AdManager.ShowInterstitial: "("AdManager.ShowInterstitial: ") + 5);
                if(onEnd == null)
            {
                    return 5;
            }
            
                onEnd.Invoke(obj:  5);
                return 5;
            }
        
        }
        public Kayac.AdManager.ErrorType ShowRewarded(System.Action onBegin, System.Action<Kayac.AdManager.ErrorType> onEnd)
        {
            var val_3;
            if((this.<State>k__BackingField) <= 7)
            {
                    var val_3 = 12339316;
                val_3 = (12339316 + (this.<State>k__BackingField) << 2) + val_3;
            }
            else
            {
                    val_3 = 12;
                this.<LastError>k__BackingField = 5;
                UnityEngine.Debug.LogError(message:  "AdManager.ShowRewarded: "("AdManager.ShowRewarded: ") + 5);
                if(onEnd == null)
            {
                    return 5;
            }
            
                onEnd.Invoke(obj:  5);
                return 5;
            }
        
        }
        private void TrySendLoadFail(string functionName)
        {
            UnityEngine.NetworkReachability val_1 = UnityEngine.Application.internetReachability;
            if(val_1 == 0)
            {
                    return;
            }
            
            int val_3 = val_1.CeilToLog10(x:  this.rewardedLoadFailCount + this.interstitialLoadFailCount);
            if(val_3 <= this.lastSendCeiledLoadFail)
            {
                    return;
            }
            
            this.SendError(message:  System.String.Format(format:  "{0} notLoaded failCount < {1}", arg0:  functionName, arg1:  val_3));
            this.lastSendCeiledLoadFail = val_3;
        }
        public void OnApplicationResume()
        {
            this.ConnectTenjin();
        }
        public void OnTimeout()
        {
            this.SendError(message:  "OnTimeout state="("OnTimeout state=") + this.<State>k__BackingField(this.<State>k__BackingField));
            StateType val_3 = (this.<State>k__BackingField) & 4294967294;
            this.timeoutCount = this.timeoutCount + 1;
            if(val_3 != 6)
            {
                    if(val_3 != 4)
            {
                    return;
            }
            
                this.LoadInterstitial();
            }
            else
            {
                    this.LoadRewarded();
            }
            
            this.<State>k__BackingField = 3;
            if(this.onEnd != null)
            {
                    this.onEnd.Invoke(obj:  11);
            }
            
            this.onBegin = 0;
            this.onEnd = 0;
        }
        public void Update()
        {
            float val_7;
            StateType val_6 = this.<State>k__BackingField;
            val_6 = val_6 - 3;
            if()
            {
                    return;
            }
            
            if(val_6 > 4)
            {
                    return;
            }
            
            float val_1 = UnityEngine.Time.unscaledDeltaTime;
            float val_2 = this.interstitialDelayedLoadTimer - val_1;
            val_7 = this.rewardedDelayedLoadTimer - val_1;
            val_1 = this.rewardedReadyFetchTimer - val_1;
            this.interstitialDelayedLoadTimer = val_2;
            this.rewardedDelayedLoadTimer = val_7;
            this.rewardedReadyFetchTimer = val_1;
            if(val_2 <= 0f)
            {
                    this.LoadInterstitial();
                val_7 = this.rewardedDelayedLoadTimer;
            }
            
            if(val_7 <= 0f)
            {
                    this.LoadRewarded();
            }
        
        }
        public bool get_RewardedReady()
        {
            bool val_3;
            var val_4;
            if((this.<State>k__BackingField) != 3)
            {
                goto label_0;
            }
            
            if(this.rewardedReadyFetchTimer <= 0f)
            {
                goto label_1;
            }
            
            val_3 = this.rewardedReadyCached;
            return (bool)(val_3 != 0) ? 1 : 0;
            label_0:
            val_4 = 0;
            return (bool)(val_3 != 0) ? 1 : 0;
            label_1:
            val_3 = this.maxSdkWrapper & 1;
            this.rewardedReadyCached = val_3;
            this.rewardedReadyFetchTimer = 1f;
            return (bool)(val_3 != 0) ? 1 : 0;
        }
        public bool get_SdkReady()
        {
            if(this.maxSdkWrapper == null)
            {
                    return (bool)this.maxSdkWrapper;
            }
            
            goto typeof(Kayac.MaxSdkWrapperBase).__il2cppRuntimeField_1A0;
        }
        public void SetRevenuePaidCallback(System.Action<Kayac.AdManager.AdType, double> callback)
        {
            this.onRevenuePaid = callback;
        }
        private void OnInterstitialRevenuePaid(double value)
        {
            if(this.onRevenuePaid == null)
            {
                    return;
            }
            
            this.onRevenuePaid.Invoke(arg1:  1, arg2:  value);
        }
        private void OnRewardedRevenuePaid(double value)
        {
            if(this.onRevenuePaid == null)
            {
                    return;
            }
            
            this.onRevenuePaid.Invoke(arg1:  1, arg2:  value);
        }
        private void OnBannerRevenuePaid(double value)
        {
            if(this.onRevenuePaid == null)
            {
                    return;
            }
            
            this.onRevenuePaid.Invoke(arg1:  2, arg2:  value);
        }
        public Kayac.AdManager.ErrorType StartBanner()
        {
            ErrorType val_3;
            if(((this.<State>k__BackingField) - 3) < 5)
            {
                    if(this.bannerVisible != true)
            {
                    this.bannerVisible = true;
            }
            
                val_3 = 0;
                return val_3;
            }
            
            if((this.<State>k__BackingField) < 2)
            {
                    val_3 = 1;
            }
            else
            {
                    if((this.<State>k__BackingField) == 2)
            {
                    val_3 = 3;
            }
            else
            {
                    val_3 = 12;
            }
            
            }
            
            this.<LastError>k__BackingField = val_3;
            UnityEngine.Debug.LogError(message:  "AdManager.ShowBanner: "("AdManager.ShowBanner: ") + val_3);
            return val_3;
        }
        public Kayac.AdManager.ErrorType HideBanner()
        {
            ErrorType val_3;
            if(((this.<State>k__BackingField) - 3) < 5)
            {
                    if(this.bannerVisible != false)
            {
                    this.bannerVisible = false;
            }
            
                val_3 = 0;
                return val_3;
            }
            
            if((this.<State>k__BackingField) < 2)
            {
                    val_3 = 1;
            }
            else
            {
                    if((this.<State>k__BackingField) == 2)
            {
                    val_3 = 3;
            }
            else
            {
                    val_3 = 12;
            }
            
            }
            
            this.<LastError>k__BackingField = val_3;
            UnityEngine.Debug.LogError(message:  "AdManager.HideBanner: "("AdManager.HideBanner: ") + val_3);
            return val_3;
        }
        public Kayac.AdManager.ErrorType ShowMediationDebugger()
        {
            ErrorType val_3;
            if(((this.<State>k__BackingField) - 3) >= 5)
            {
                goto label_1;
            }
            
            label_6:
            val_3 = 0;
            return val_3;
            label_1:
            if((this.<State>k__BackingField) >= 2)
            {
                goto label_4;
            }
            
            val_3 = 1;
            goto label_5;
            label_4:
            if((this.<State>k__BackingField) != 2)
            {
                goto label_6;
            }
            
            val_3 = 3;
            label_5:
            this.<LastError>k__BackingField = val_3;
            UnityEngine.Debug.LogError(message:  "AdManager.ShowMediationDebugger: "("AdManager.ShowMediationDebugger: ") + val_3);
            return val_3;
        }
        public bool get_playing()
        {
            StateType val_2 = this.<State>k__BackingField;
            val_2 = val_2 | 2;
            if(val_2 != 7)
            {
                    return (bool)(val_2 == 6) ? 1 : 0;
            }
            
            return true;
        }
        public System.Nullable<bool> get_NeedsGdprConsent()
        {
            Kayac.MaxSdkWrapperBase val_1 = this.maxSdkWrapper;
            if(val_1 == null)
            {
                    return (System.Nullable<System.Boolean>)val_1;
            }
            
            if((val_1 & 1) != 0)
            {
                    val_1 = this.maxSdkWrapper & 65535;
                return (System.Nullable<System.Boolean>)val_1;
            }
            
            val_1 = 0;
            return (System.Nullable<System.Boolean>)val_1;
        }
        public bool SendTenjinCustomEvent(string name)
        {
            object val_4;
            UnityEngine.Debug.Log(message:  "AdManager.SendTenjinCustomEvent called.");
            if((this.maxSdkWrapper == null) || ((this.maxSdkWrapper & 1) == 0))
            {
                goto label_4;
            }
            
            if((System.String.IsNullOrEmpty(value:  this.tenjinApiKey)) == false)
            {
                goto label_5;
            }
            
            val_4 = "AdManager.SendTenjinCustomEvent: tenjinApiKey is empty.";
            goto label_18;
            label_4:
            val_4 = "AdManager.SendTenjinCustomEvent: not initialized.";
            label_18:
            UnityEngine.Debug.LogError(message:  val_4);
            return false;
            label_5:
            if((Tenjin.getInstance(apiKey:  this.tenjinApiKey)) != 0)
            {
                    return false;
            }
            
            goto label_18;
        }
        private bool IsDisconnected()
        {
            return (bool)(UnityEngine.Application.internetReachability == 0) ? 1 : 0;
        }
        private int CeilToLog10(int x)
        {
            var val_2;
            if(x >= 1)
            {
                    int val_1 = UnityEngine.Mathf.CeilToInt(f:  (float)x);
                val_2 = 10;
                return (int)val_2;
            }
            
            val_2 = 0;
            return (int)val_2;
        }
        private void SendError(string message)
        {
            object val_5 = "AdManager: "("AdManager: ") + message;
            if(this.timeoutCount >= 1)
            {
                    val_5 = val_5 + " timeout="(" timeout=") + this.timeoutCount;
            }
            
            if(UnityEngine.Application.internetReachability == 0)
            {
                    val_5 = val_5 + " disconnected";
            }
            
            if(this.firebase != null)
            {
                    this.firebase.AddErrorEvent(message:  val_5);
            }
            
            UnityEngine.Debug.LogError(message:  val_5);
        }
        private void OnInterstitialLoadFailed()
        {
            float val_3;
            this.<LastError>k__BackingField = 6;
            int val_1 = this.interstitialLoadFailCount + 1;
            this.interstitialLoadFailCount = val_1;
            if(this.loadExponentialSteps >= 1)
            {
                    var val_3 = 1;
                val_3 = val_3 << (UnityEngine.Mathf.Min(a:  val_1, b:  this.loadExponentialSteps));
                val_3 = (float)val_3;
            }
            else
            {
                    val_3 = 3f;
            }
            
            this.interstitialDelayedLoadTimer = val_3;
        }
        private void OnInterstitialFailedToDisplay()
        {
            this.SendError(message:  "OnInterstitialFailedToDisplay");
            if((this.<State>k__BackingField) != 4)
            {
                    this.SendError(message:  "OnInterstitialFailedToDisplay state="("OnInterstitialFailedToDisplay state=") + this.<State>k__BackingField(this.<State>k__BackingField));
            }
            
            this.<State>k__BackingField = 3;
            this.LoadInterstitial();
            this.<LastError>k__BackingField = 8;
            if(this.onEnd != null)
            {
                    this.onEnd.Invoke(obj:  8);
            }
            
            this.onBegin = 0;
            this.onEnd = 0;
        }
        private void OnInterstitialDisplayed()
        {
            if((this.<State>k__BackingField) != 4)
            {
                    this.SendError(message:  "OnInterstitialDisplayed state="("OnInterstitialDisplayed state=") + this.<State>k__BackingField(this.<State>k__BackingField));
            }
            
            this.<State>k__BackingField = 5;
            if(this.onBegin != null)
            {
                    this.onBegin.Invoke();
            }
            
            this.onBegin = 0;
        }
        private void OnInterstitialHidden()
        {
            var val_2;
            if((this.<State>k__BackingField) == 5)
            {
                    val_2 = 0;
            }
            else
            {
                    this.SendError(message:  "OnInterstitialHidden state="("OnInterstitialHidden state=") + this.<State>k__BackingField(this.<State>k__BackingField));
                val_2 = 10;
                this.<LastError>k__BackingField = 10;
            }
            
            this.LoadInterstitial();
            this.<State>k__BackingField = 3;
            if(this.onEnd != null)
            {
                    this.onEnd.Invoke(obj:  10);
            }
            
            this.onBegin = 0;
            this.onEnd = 0;
        }
        private void OnRewardedLoadFailed()
        {
            float val_3;
            this.<LastError>k__BackingField = 7;
            int val_1 = this.rewardedLoadFailCount + 1;
            this.rewardedLoadFailCount = val_1;
            if(this.loadExponentialSteps >= 1)
            {
                    var val_3 = 1;
                val_3 = val_3 << (UnityEngine.Mathf.Min(a:  val_1, b:  this.loadExponentialSteps));
                val_3 = (float)val_3;
            }
            else
            {
                    val_3 = 3f;
            }
            
            this.rewardedDelayedLoadTimer = val_3;
        }
        private void OnRewardedFailedToDisplay()
        {
            this.SendError(message:  "OnRewardedFailedToDisplay");
            if((this.<State>k__BackingField) != 6)
            {
                    this.SendError(message:  "OnRewardedFailedToDisplay state="("OnRewardedFailedToDisplay state=") + this.<State>k__BackingField(this.<State>k__BackingField));
            }
            
            this.LoadRewarded();
            this.<State>k__BackingField = 1.90979621201696E-313;
            if(this.onEnd != null)
            {
                    this.onEnd.Invoke(obj:  9);
            }
            
            this.onBegin = 0;
            this.onEnd = 0;
        }
        private void OnRewardedDisplayed()
        {
            if((this.<State>k__BackingField) != 6)
            {
                    this.SendError(message:  "OnRewardedDisplayed state="("OnRewardedDisplayed state=") + this.<State>k__BackingField(this.<State>k__BackingField));
            }
            
            this.<State>k__BackingField = 7;
            if(this.onBegin != null)
            {
                    this.onBegin.Invoke();
            }
            
            this.onBegin = 0;
        }
        private void OnRewardedReceivedReward()
        {
            if((this.<State>k__BackingField) != 7)
            {
                    this.SendError(message:  "OnRewardedReceivedReward state="("OnRewardedReceivedReward state=") + this.<State>k__BackingField(this.<State>k__BackingField));
            }
            
            this.lastRewardedReceived = true;
        }
        private void OnRewardedHidden()
        {
            var val_3;
            if((this.<State>k__BackingField) == 7)
            {
                    var val_1 = (this.lastRewardedReceived == false) ? 10 : 0;
            }
            else
            {
                    this.SendError(message:  "OnRewardedHidden state="("OnRewardedHidden state=") + this.<State>k__BackingField(this.<State>k__BackingField));
                val_3 = 10;
                this.<LastError>k__BackingField = 10;
            }
            
            this.LoadRewarded();
            this.<State>k__BackingField = 3;
            if(this.onEnd != null)
            {
                    this.onEnd.Invoke(obj:  10);
            }
            
            this.onBegin = 0;
            this.onEnd = 0;
        }
        private void ConnectTenjin()
        {
            var val_3;
            if(this.maxSdkWrapper == null)
            {
                    return;
            }
            
            if((this.maxSdkWrapper & 1) == 0)
            {
                    return;
            }
            
            if((System.String.IsNullOrEmpty(value:  this.tenjinApiKey)) != false)
            {
                    return;
            }
            
            Kayac.MaxSdkWrapperBase val_3 = this.maxSdkWrapper;
            val_3 = 0;
            val_3 = val_3 & 255;
            BaseTenjin val_2 = Tenjin.getInstance(apiKey:  this.tenjinApiKey);
            if(val_3 != null)
            {
                
            }
        
        }
        private void LoadInterstitial()
        {
            if(UnityEngine.Application.internetReachability != 0)
            {
                    this.interstitialDelayedLoadTimer = -1.175494E-38f;
                return;
            }
            
            this.OnInterstitialLoadFailed();
        }
        private void LoadRewarded()
        {
            if(UnityEngine.Application.internetReachability != 0)
            {
                    this.rewardedDelayedLoadTimer = -1.175494E-38f;
                return;
            }
            
            this.OnRewardedLoadFailed();
        }
        public bool get_InterstitialReady()
        {
            if((this.<State>k__BackingField) != 3)
            {
                    return false;
            }
            
            if(this.maxSdkWrapper != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        private void DelayLoadInterstitial(float seconds)
        {
            this.interstitialDelayedLoadTimer = seconds;
        }
        private void DelayLoadRewarded(float seconds)
        {
            this.rewardedDelayedLoadTimer = seconds;
        }
    
    }

}
