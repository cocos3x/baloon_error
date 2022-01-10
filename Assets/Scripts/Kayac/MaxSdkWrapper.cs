using UnityEngine;

namespace Kayac
{
    public class MaxSdkWrapper : MaxSdkWrapperBase
    {
        // Fields
        private bool sdkInitialized;
        private bool interstitialInitialized;
        private bool rewardedInitialized;
        private string interstitialUnitId;
        private string rewardedUnitId;
        private string bannerUnitId;
        private System.Nullable<bool> needsConsentDialog;
        
        // Properties
        public override bool SdkReady { get; }
        public override System.Nullable<bool> NeedsGdprConsent { get; }
        public override bool InterstitialReady { get; }
        public override bool RewardedReady { get; }
        
        // Methods
        public MaxSdkWrapper(Kayac.MaxSdkWrapperBase.Callbacks callbacks, string sdkKey, string interstitialUnitId, string rewardedUnitId, string bannerUnitId)
        {
            val_1 = new System.Object();
            if((System.String.IsNullOrEmpty(value:  sdkKey)) != false)
            {
                    UnityEngine.Debug.LogError(message:  "MaxSdkWrapper: key is empty.");
                this.sdkInitialized = true;
                return;
            }
            
            this.interstitialUnitId = val_1;
            this.rewardedUnitId = rewardedUnitId;
            this.bannerUnitId = bannerUnitId;
            MaxSdkCallbacks.add_OnSdkInitializedEvent(value:  new System.Action<SdkConfiguration>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnSdkInitialized(MaxSdkBase.SdkConfiguration config)));
            MaxSdkAndroid.SetSdkKey(sdkKey:  sdkKey);
            MaxSdkAndroid.InitializeSdk(adUnitIds:  0);
        }
        public override bool StartBanner()
        {
            if(this.sdkInitialized == false)
            {
                    return false;
            }
            
            if((System.String.IsNullOrEmpty(value:  this.bannerUnitId)) == true)
            {
                    return false;
            }
            
            MaxSdkCallbacks.Banner.add_OnAdClickedEvent(value:  new System.Action<System.String, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnBannerAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo info)));
            MaxSdkCallbacks.Banner.add_OnAdLoadedEvent(value:  new System.Action<System.String, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnBannerAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo info)));
            MaxSdkCallbacks.Banner.add_OnAdRevenuePaidEvent(value:  new System.Action<System.String, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnBannerAdRevenuePaid(string adUnitId, MaxSdkBase.AdInfo info)));
            MaxSdkAndroid.CreateBanner(adUnitIdentifier:  this.bannerUnitId, bannerPosition:  7);
            UnityEngine.Color val_5 = UnityEngine.Color.white;
            MaxSdkAndroid.SetBannerBackgroundColor(adUnitIdentifier:  this.bannerUnitId, color:  new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = val_5.a});
            MaxSdkAndroid.ShowBanner(adUnitIdentifier:  this.bannerUnitId);
            return false;
        }
        public override void HideBanner()
        {
            if(this.sdkInitialized == false)
            {
                    return;
            }
            
            if((System.String.IsNullOrEmpty(value:  this.bannerUnitId)) != false)
            {
                    return;
            }
            
            MaxSdkAndroid.HideBanner(adUnitIdentifier:  this.bannerUnitId);
        }
        public override bool get_SdkReady()
        {
            return (bool)this.sdkInitialized;
        }
        public override System.Nullable<bool> get_NeedsGdprConsent()
        {
            return (System.Nullable<System.Boolean>)this.needsConsentDialog;
        }
        public override bool get_InterstitialReady()
        {
            if(this.interstitialInitialized == false)
            {
                    return false;
            }
            
            return MaxSdkAndroid.IsInterstitialReady(adUnitIdentifier:  this.interstitialUnitId);
        }
        public override bool get_RewardedReady()
        {
            if(this.rewardedInitialized == false)
            {
                    return false;
            }
            
            return MaxSdkAndroid.IsRewardedAdReady(adUnitIdentifier:  this.rewardedUnitId);
        }
        public override void ShowInterstitial()
        {
            if((this & 1) != 0)
            {
                    UnityEngine.Debug.Log(message:  "MaxSdk.ShowInterstitial");
                MaxSdkAndroid.ShowInterstitial(adUnitIdentifier:  this.interstitialUnitId);
                return;
            }
            
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        public override void ShowRewarded()
        {
            if((this & 1) != 0)
            {
                    UnityEngine.Debug.Log(message:  "MaxSdk.ShowRewarded");
                MaxSdkAndroid.ShowRewardedAd(adUnitIdentifier:  this.rewardedUnitId);
                return;
            }
            
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        public override void LoadInterstitial()
        {
            if(this.interstitialInitialized == false)
            {
                    return;
            }
            
            MaxSdkAndroid.LoadInterstitial(adUnitIdentifier:  this.interstitialUnitId);
        }
        public override void LoadRewarded()
        {
            if(this.rewardedInitialized == false)
            {
                    return;
            }
            
            MaxSdkAndroid.LoadRewardedAd(adUnitIdentifier:  this.rewardedUnitId);
        }
        public override void ShowMediationDebugger()
        {
            if(this.sdkInitialized == false)
            {
                    return;
            }
            
            MaxSdkAndroid.ShowMediationDebugger();
        }
        public override void Start()
        {
            if((this & 255) == 0)
            {
                    UnityEngine.Debug.Log(message:  "MaxSdkWrapper.Start() : MaxSdk.SetHasUserConsent(true)");
                MaxSdkAndroid.SetHasUserConsent(hasUserConsent:  true);
            }
            
            this.InitializeInterstitial();
            this.InitializeRewarded();
        }
        private void InitializeInterstitial()
        {
            if(this.sdkInitialized == false)
            {
                    return;
            }
            
            if((System.String.IsNullOrEmpty(value:  this.interstitialUnitId)) == true)
            {
                    return;
            }
            
            MaxSdkCallbacks.Interstitial.add_OnAdLoadFailedEvent(value:  new System.Action<System.String, ErrorInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo error)));
            MaxSdkCallbacks.Interstitial.add_OnAdDisplayFailedEvent(value:  new System.Action<System.String, ErrorInfo, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo error, MaxSdkBase.AdInfo info)));
            MaxSdkCallbacks.Interstitial.add_OnAdDisplayedEvent(value:  new System.Action<System.String, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo info)));
            MaxSdkCallbacks.Interstitial.add_OnAdClickedEvent(value:  new System.Action<System.String, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo info)));
            MaxSdkCallbacks.Interstitial.add_OnAdHiddenEvent(value:  new System.Action<System.String, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo info)));
            MaxSdkCallbacks.Interstitial.add_OnAdRevenuePaidEvent(value:  new System.Action<System.String, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnInterstitialRevenuePaid(string adUnitId, MaxSdkBase.AdInfo info)));
            this.interstitialInitialized = true;
        }
        private void InitializeRewarded()
        {
            if(this.sdkInitialized == false)
            {
                    return;
            }
            
            if((System.String.IsNullOrEmpty(value:  this.rewardedUnitId)) == true)
            {
                    return;
            }
            
            MaxSdkCallbacks.Rewarded.add_OnAdLoadFailedEvent(value:  new System.Action<System.String, ErrorInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo error)));
            MaxSdkCallbacks.Rewarded.add_OnAdDisplayFailedEvent(value:  new System.Action<System.String, ErrorInfo, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo error, MaxSdkBase.AdInfo info)));
            MaxSdkCallbacks.Rewarded.add_OnAdDisplayedEvent(value:  new System.Action<System.String, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo info)));
            MaxSdkCallbacks.Rewarded.add_OnAdClickedEvent(value:  new System.Action<System.String, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo info)));
            MaxSdkCallbacks.Rewarded.add_OnAdReceivedRewardEvent(value:  new System.Action<System.String, Reward, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdkBase.Reward reward, MaxSdkBase.AdInfo info)));
            MaxSdkCallbacks.Rewarded.add_OnAdHiddenEvent(value:  new System.Action<System.String, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo info)));
            MaxSdkCallbacks.Rewarded.add_OnAdRevenuePaidEvent(value:  new System.Action<System.String, AdInfo>(object:  this, method:  System.Void Kayac.MaxSdkWrapper::OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)));
            this.rewardedInitialized = true;
        }
        private void OnBannerAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo info)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnBannerAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo info)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnBannerAdRevenuePaid(string adUnitId, MaxSdkBase.AdInfo info)
        {
            if((info.<Revenue>k__BackingField) <= 0f)
            {
                    return;
            }
            
            if(6811 == 0)
            {
                    return;
            }
            
            6811.Invoke(obj:  info.<Revenue>k__BackingField);
        }
        private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo error)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo error, MaxSdkBase.AdInfo info)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo info)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo info)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo info)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnInterstitialRevenuePaid(string adUnitId, MaxSdkBase.AdInfo info)
        {
            if((info.<Revenue>k__BackingField) <= 0f)
            {
                    return;
            }
            
            if(6812 == 0)
            {
                    return;
            }
            
            6812.Invoke(obj:  info.<Revenue>k__BackingField);
        }
        private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo error)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo error, MaxSdkBase.AdInfo info)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo info)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo info)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdkBase.Reward reward, MaxSdkBase.AdInfo info)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo info)
        {
            if(this == null)
            {
                    return;
            }
            
            this.Invoke();
        }
        private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
        {
            if((info.<Revenue>k__BackingField) <= 0f)
            {
                    return;
            }
            
            if(6813 == 0)
            {
                    return;
            }
            
            6813.Invoke(obj:  info.<Revenue>k__BackingField);
        }
        private void OnSdkInitialized(MaxSdkBase.SdkConfiguration config)
        {
            System.Nullable<System.Boolean> val_2;
            UnityEngine.Debug.Log(message:  "MaxSdkBase.ConsentDialogState= "("MaxSdkBase.ConsentDialogState= ") + config.ConsentDialogState);
            if(config.ConsentDialogState == 0)
            {
                goto label_4;
            }
            
            if(config.ConsentDialogState == 1)
            {
                goto label_5;
            }
            
            if(config.ConsentDialogState != 2)
            {
                goto label_8;
            }
            
            val_2 = 0;
            goto label_7;
            label_5:
            val_2 = 0;
            label_7:
            this.needsConsentDialog = val_2;
            goto label_8;
            label_4:
            this.needsConsentDialog = 0;
            label_8:
            this.sdkInitialized = true;
        }
    
    }

}
