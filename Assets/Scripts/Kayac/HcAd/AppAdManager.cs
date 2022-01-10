using UnityEngine;

namespace Kayac.HcAd
{
    public class AppAdManager
    {
        // Fields
        private Kayac.AdManager _adManager;
        private Analytics _analytics;
        private float _interstitialFrequency;
        private float _interstitialTimer;
        private bool <isInterstitialTimerEnabled>k__BackingField;
        
        // Properties
        public bool isInterstitialTimerEnabled { get; set; }
        public bool sdkReady { get; }
        public System.Nullable<bool> needsGdprConsent { get; }
        public bool playing { get; }
        public bool InterstitialReady { get; }
        public bool RewardedReady { get; }
        
        // Methods
        public bool get_isInterstitialTimerEnabled()
        {
            return (bool)this.<isInterstitialTimerEnabled>k__BackingField;
        }
        public void set_isInterstitialTimerEnabled(bool value)
        {
            this.<isInterstitialTimerEnabled>k__BackingField = value;
        }
        public bool get_sdkReady()
        {
            if(this._adManager != null)
            {
                    if(this._adManager.maxSdkWrapper == null)
            {
                    return (bool)this._adManager.maxSdkWrapper;
            }
            
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public System.Nullable<bool> get_needsGdprConsent()
        {
            System.Nullable<System.Boolean> val_1 = this._adManager.NeedsGdprConsent;
            val_1.HasValue = val_1.HasValue & 65535;
            return (System.Nullable<System.Boolean>)val_1.HasValue;
        }
        public AppAdManager(UnityEngine.Transform parentTransform, Analytics analytics, Kayac.FirebaseWrapper firebase)
        {
            val_1 = new System.Object();
            this._analytics = val_1;
            this._adManager = new Kayac.AdManager(firebase:  firebase);
            Kayac.HcAd.SecretConfig val_3 = new Kayac.HcAd.SecretConfig();
            this._adManager.Initialize(maxSdkKey:  val_3, maxInterstitialUnitId:  val_3, maxRewardedUnitId:  val_3, maxBannerUnitId:  val_3, tenjinApiKey:  val_3);
            this._adManager.onRevenuePaid = new System.Action<AdType, System.Double>(object:  this, method:  System.Void Kayac.HcAd.AppAdManager::OnRevenuePaid(Kayac.AdManager.AdType adType, double value));
        }
        public void Update()
        {
            if((this.<isInterstitialTimerEnabled>k__BackingField) != false)
            {
                    float val_1 = UnityEngine.Time.deltaTime;
                val_1 = this._interstitialTimer + val_1;
                this._interstitialTimer = val_1;
            }
            
            this._adManager.Update();
        }
        public void Start()
        {
            ErrorType val_1 = this._adManager.Start(loadExponentialSteps:  0);
            if(val_1 != 0)
            {
                    UnityEngine.Debug.LogError(message:  "AdManager.Start() : error="("AdManager.Start() : error=") + val_1);
            }
            
            ErrorType val_3 = this._adManager.StartBanner();
            if(val_3 == 0)
            {
                    return;
            }
            
            this = "AdManager.StartBanner() : error="("AdManager.StartBanner() : error=") + val_3;
            UnityEngine.Debug.LogError(message:  this);
        }
        private void OnRevenuePaid(Kayac.AdManager.AdType adType, double value)
        {
            this._analytics.OnAdRevenue(placement:  this.GetPlacement(type:  adType), value:  value);
        }
        public void ShowMediationDebugger()
        {
            if(this._adManager != null)
            {
                    ErrorType val_1 = this._adManager.ShowMediationDebugger();
                return;
            }
            
            throw new NullReferenceException();
        }
        public void ShowInterstitial(System.Action onEnd, System.Action onBegin)
        {
            .<>4__this = this;
            .onEnd = onEnd;
            if(this._interstitialTimer < this._interstitialFrequency)
            {
                    if(onEnd == null)
            {
                    return;
            }
            
                onEnd.Invoke();
                return;
            }
            
            ErrorType val_3 = this._adManager.ShowInterstitial(onBegin:  onBegin, onEnd:  new System.Action<ErrorType>(object:  new AppAdManager.<>c__DisplayClass17_0(), method:  System.Void AppAdManager.<>c__DisplayClass17_0::<ShowInterstitial>b__0(Kayac.AdManager.ErrorType error)));
        }
        public void ShowRewarded(System.Action onEnd, string placement)
        {
            .<>4__this = this;
            .placement = placement;
            .onEnd = onEnd;
            ErrorType val_3 = this._adManager.ShowRewarded(onBegin:  0, onEnd:  new System.Action<ErrorType>(object:  new AppAdManager.<>c__DisplayClass18_0(), method:  System.Void AppAdManager.<>c__DisplayClass18_0::<ShowRewarded>b__0(Kayac.AdManager.ErrorType error)));
        }
        public bool get_playing()
        {
            if(this._adManager != null)
            {
                    StateType val_2 = this._adManager.<State>k__BackingField;
                val_2 = val_2 | 2;
                if(val_2 != 7)
            {
                    return (bool)(val_2 == 6) ? 1 : 0;
            }
            
                return true;
            }
            
            throw new NullReferenceException();
        }
        public bool get_InterstitialReady()
        {
            if(this._adManager != null)
            {
                    return this._adManager.InterstitialReady;
            }
            
            throw new NullReferenceException();
        }
        public bool get_RewardedReady()
        {
            if(this._adManager != null)
            {
                    return this._adManager.RewardedReady;
            }
            
            throw new NullReferenceException();
        }
        public void SetInterstitialInterval(float second)
        {
            this._interstitialFrequency = second;
        }
        public void ResetInterstitialTimer()
        {
            this._interstitialTimer = 0f;
        }
        private string GetPlacement(Kayac.AdManager.AdType type)
        {
            var val_1;
            var val_2;
            if(type == 2)
            {
                goto label_1;
            }
            
            if(type == 1)
            {
                goto label_2;
            }
            
            if(type != 0)
            {
                goto label_3;
            }
            
            val_1 = "Interstitial";
            return (string)val_2;
            label_1:
            val_1 = "Banner";
            return (string)val_2;
            label_2:
            val_1 = "Reward";
            return (string)val_2;
            label_3:
            val_2 = 0;
            return (string)val_2;
        }
    
    }

}
