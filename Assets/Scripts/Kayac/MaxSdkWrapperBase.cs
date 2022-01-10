using UnityEngine;

namespace Kayac
{
    public abstract class MaxSdkWrapperBase
    {
        // Fields
        protected Kayac.MaxSdkWrapperBase.Callbacks callbacks;
        
        // Properties
        public abstract bool SdkReady { get; }
        public abstract System.Nullable<bool> NeedsGdprConsent { get; }
        public abstract bool InterstitialReady { get; }
        public abstract bool RewardedReady { get; }
        
        // Methods
        public MaxSdkWrapperBase(Kayac.MaxSdkWrapperBase.Callbacks callbacks)
        {
        
        }
        public abstract void Start(); // 0
        public abstract bool StartBanner(); // 0
        public abstract void HideBanner(); // 0
        public abstract bool get_SdkReady(); // 0
        public abstract System.Nullable<bool> get_NeedsGdprConsent(); // 0
        public abstract bool get_InterstitialReady(); // 0
        public abstract bool get_RewardedReady(); // 0
        public abstract void LoadInterstitial(); // 0
        public abstract void LoadRewarded(); // 0
        public abstract void ShowInterstitial(); // 0
        public abstract void ShowRewarded(); // 0
        public virtual void Update()
        {
        
        }
        public virtual void ShowMediationDebugger()
        {
        
        }
    
    }

}
