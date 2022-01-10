using UnityEngine;

namespace Kayac
{
    public class MaxSdkWrapperDummy : MaxSdkWrapperBase
    {
        // Fields
        private UnityEngine.Canvas canvas;
        private UnityEngine.UI.Image image;
        private UnityEngine.UI.Image bannerImage;
        private System.Nullable<bool> needsGdprConsent;
        private UnityEngine.Transform parentTransform;
        private Kayac.MaxSdkWrapperDummy.LoadState interstitialLoadState;
        private Kayac.MaxSdkWrapperDummy.LoadState rewardedLoadState;
        private float interstitialLoadTimer;
        private float rewardedLoadTimer;
        private bool interstitialRequested;
        private bool rewardedRequested;
        private float startTimer;
        private float endTimer;
        private bool forSkip;
        private bool sdkReady;
        private const float loadFailureProbability = 0.2;
        private const float displayFailureProbability = 0.2;
        private const float rewardAcceptProbability = 0.8;
        
        // Properties
        public override bool SdkReady { get; }
        public override bool InterstitialReady { get; }
        public override bool RewardedReady { get; }
        public override System.Nullable<bool> NeedsGdprConsent { get; }
        
        // Methods
        public MaxSdkWrapperDummy(Kayac.MaxSdkWrapperBase.Callbacks callbacks, UnityEngine.Transform parentTransform, bool needsGdprConsent)
        {
            this = new System.Object();
            this.parentTransform = parentTransform;
            if(UnityEngine.Application.internetReachability == 0)
            {
                    return;
            }
            
            bool val_3 = needsGdprConsent;
            this.needsGdprConsent = 0;
        }
        public override bool StartBanner()
        {
            this.bannerImage.enabled = true;
            return true;
        }
        public override void HideBanner()
        {
            UnityEngine.Debug.Log(message:  "Disable banner");
            this.bannerImage.enabled = false;
        }
        public override bool get_SdkReady()
        {
            bool val_3;
            if(this.sdkReady != false)
            {
                    val_3 = 1;
                return (bool)(this.sdkReady == true) ? 1 : 0;
            }
            
            if(UnityEngine.Random.value >= 0)
            {
                    return (bool)(this.sdkReady == true) ? 1 : 0;
            }
            
            val_3 = true;
            this.sdkReady = val_3;
            return (bool)(this.sdkReady == true) ? 1 : 0;
        }
        public override bool get_InterstitialReady()
        {
            return (bool)(this.interstitialLoadState == 2) ? 1 : 0;
        }
        public override bool get_RewardedReady()
        {
            return (bool)(this.rewardedLoadState == 2) ? 1 : 0;
        }
        public override void ShowInterstitial()
        {
            if((this & 1) == 0)
            {
                    return;
            }
            
            this.interstitialRequested = true;
        }
        public override void ShowRewarded()
        {
            if((this & 1) == 0)
            {
                    return;
            }
            
            this.rewardedRequested = true;
        }
        public override void LoadInterstitial()
        {
            if(this.interstitialLoadState != 0)
            {
                    this = "MaxSdkWrapperDummy.LoadInterstitial : busy! "("MaxSdkWrapperDummy.LoadInterstitial : busy! ") + this.interstitialLoadState;
                UnityEngine.Debug.LogError(message:  this);
                return;
            }
            
            this.interstitialLoadState = 1;
            this.interstitialLoadTimer = UnityEngine.Random.Range(min:  0.5f, max:  2f);
        }
        public override void LoadRewarded()
        {
            if(this.rewardedLoadState != 0)
            {
                    this = "MaxSdkWrapperDummy.LoadRewarded : busy! "("MaxSdkWrapperDummy.LoadRewarded : busy! ") + this.rewardedLoadState;
                UnityEngine.Debug.LogError(message:  this);
                return;
            }
            
            this.rewardedLoadState = 1;
            this.rewardedLoadTimer = UnityEngine.Random.Range(min:  0.5f, max:  2f);
        }
        public override void Start()
        {
            UnityEngine.GameObject val_1 = new UnityEngine.GameObject(name:  "dummyAdCanvas");
            UnityEngine.Canvas val_2 = val_1.AddComponent<UnityEngine.Canvas>();
            this.canvas = val_2;
            val_2.transform.SetParent(p:  this.parentTransform);
            this.canvas.renderMode = 0;
            this.canvas.sortingOrder = 32767;
            UnityEngine.UI.GraphicRaycaster val_4 = val_1.AddComponent<UnityEngine.UI.GraphicRaycaster>();
            UnityEngine.UI.Image val_6 = new UnityEngine.GameObject(name:  "dummyAdImage").AddComponent<UnityEngine.UI.Image>();
            this.image = val_6;
            val_6.transform.SetParent(p:  this.canvas.transform);
            UnityEngine.RectTransform val_9 = this.image.rectTransform;
            UnityEngine.Vector2 val_10 = new UnityEngine.Vector2(x:  0.1f, y:  0.1f);
            val_9.anchorMin = new UnityEngine.Vector2() {x = val_10.x, y = val_10.y};
            UnityEngine.Vector2 val_11 = new UnityEngine.Vector2(x:  0.9f, y:  0.9f);
            val_9.anchorMax = new UnityEngine.Vector2() {x = val_11.x, y = val_11.y};
            UnityEngine.Vector2 val_12 = new UnityEngine.Vector2(x:  0f, y:  0f);
            val_9.offsetMin = new UnityEngine.Vector2() {x = val_12.x, y = val_12.y};
            UnityEngine.Vector2 val_13 = new UnityEngine.Vector2(x:  0f, y:  0f);
            val_9.offsetMax = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
            UnityEngine.Vector2 val_14 = new UnityEngine.Vector2(x:  0f, y:  0f);
            val_9.sizeDelta = new UnityEngine.Vector2() {x = val_14.x, y = val_14.y};
            UnityEngine.Vector2 val_15 = new UnityEngine.Vector2(x:  0.5f, y:  0.5f);
            val_9.pivot = new UnityEngine.Vector2() {x = val_15.x, y = val_15.y};
            this.image.color = new UnityEngine.Color() {r = 0f, g = 0f, b = 0f, a = 0f};
            this.image.enabled = false;
            this.image.raycastTarget = true;
            UnityEngine.UI.Image val_17 = new UnityEngine.GameObject(name:  "dummyBannerImage").AddComponent<UnityEngine.UI.Image>();
            this.bannerImage = val_17;
            val_17.transform.SetParent(p:  this.canvas.transform);
            UnityEngine.RectTransform val_20 = this.bannerImage.rectTransform;
            UnityEngine.Vector2 val_21 = new UnityEngine.Vector2(x:  0f, y:  0f);
            val_20.anchorMin = new UnityEngine.Vector2() {x = val_21.x, y = val_21.y};
            UnityEngine.Vector2 val_22 = new UnityEngine.Vector2(x:  1f, y:  0.1f);
            val_20.anchorMax = new UnityEngine.Vector2() {x = val_22.x, y = val_22.y};
            UnityEngine.Vector2 val_23 = new UnityEngine.Vector2(x:  0f, y:  0f);
            val_20.offsetMin = new UnityEngine.Vector2() {x = val_23.x, y = val_23.y};
            UnityEngine.Vector2 val_24 = new UnityEngine.Vector2(x:  0f, y:  0f);
            val_20.offsetMax = new UnityEngine.Vector2() {x = val_24.x, y = val_24.y};
            UnityEngine.Vector2 val_25 = new UnityEngine.Vector2(x:  0f, y:  0f);
            val_20.sizeDelta = new UnityEngine.Vector2() {x = val_25.x, y = val_25.y};
            UnityEngine.Vector2 val_26 = new UnityEngine.Vector2(x:  0.5f, y:  0f);
            val_20.pivot = new UnityEngine.Vector2() {x = val_26.x, y = val_26.y};
            this.bannerImage.color = new UnityEngine.Color() {r = 0f, g = 0f, b = 0f, a = 0f};
            this.bannerImage.enabled = false;
            this.bannerImage.raycastTarget = true;
        }
        public override System.Nullable<bool> get_NeedsGdprConsent()
        {
            return (System.Nullable<System.Boolean>)this.needsGdprConsent;
        }
        public override void Update()
        {
            if(this.sdkReady == false)
            {
                    return;
            }
            
            float val_1 = UnityEngine.Time.unscaledDeltaTime;
            if(this.interstitialLoadState != 1)
            {
                goto label_6;
            }
            
            float val_8 = this.interstitialLoadTimer;
            val_8 = val_8 - val_1;
            this.interstitialLoadTimer = val_8;
            if(val_8 > 0f)
            {
                goto label_6;
            }
            
            if(UnityEngine.Random.value >= 0)
            {
                goto label_4;
            }
            
            this.interstitialLoadState = 0;
            if(0 == 0)
            {
                goto label_6;
            }
            
            0.Invoke();
            goto label_6;
            label_4:
            UnityEngine.Debug.Log(message:  "Dummy Interstitial Loaded.");
            this.interstitialLoadState = 2;
            label_6:
            if(this.rewardedLoadState != 1)
            {
                goto label_13;
            }
            
            float val_9 = this.rewardedLoadTimer;
            val_9 = val_9 - val_1;
            this.rewardedLoadTimer = val_9;
            if(val_9 > 0f)
            {
                goto label_13;
            }
            
            if(UnityEngine.Random.value >= 0)
            {
                goto label_11;
            }
            
            this.rewardedLoadState = 0;
            if(0 == 0)
            {
                goto label_13;
            }
            
            0.Invoke();
            goto label_13;
            label_11:
            UnityEngine.Debug.Log(message:  "Dummy Rewarded Loaded.");
            this.rewardedLoadState = 2;
            label_13:
            float val_10 = this.startTimer;
            if(val_10 <= 0f)
            {
                goto label_16;
            }
            
            val_10 = val_10 - val_1;
            this.startTimer = val_10;
            if(val_10 >= 0)
            {
                    return;
            }
            
            float val_4 = UnityEngine.Random.value;
            if(this.interstitialRequested == false)
            {
                goto label_18;
            }
            
            if(val_4 >= 0)
            {
                goto label_19;
            }
            
            if(0 != 0)
            {
                    0.Invoke();
            }
            
            this.interstitialRequested = false;
            return;
            label_16:
            float val_11 = this.endTimer;
            if(val_11 <= 0f)
            {
                goto label_22;
            }
            
            val_11 = val_11 - val_1;
            this.endTimer = val_11;
            if(val_11 > 0f)
            {
                    return;
            }
            
            this.image.enabled = false;
            if(this.interstitialRequested == false)
            {
                goto label_25;
            }
            
            if(this.image != null)
            {
                    this.image.Invoke();
            }
            
            this.interstitialRequested = false;
            label_46:
            this.interstitialRequested = false;
            this.rewardedRequested = false;
            return;
            label_22:
            if(this.interstitialRequested == false)
            {
                goto label_28;
            }
            
            if(this.interstitialLoadState != 2)
            {
                    return;
            }
            
            this.interstitialLoadState = 0;
            this.startTimer = 0.5f;
            return;
            label_18:
            if(val_4 >= 0)
            {
                goto label_31;
            }
            
            if(0 != 0)
            {
                    0.Invoke();
            }
            
            this.rewardedRequested = false;
            return;
            label_28:
            if(this.rewardedRequested == false)
            {
                    return;
            }
            
            if(this.rewardedLoadState != 2)
            {
                    return;
            }
            
            this.rewardedLoadState = 0;
            this.startTimer = (this.forSkip == false) ? 1f : 0.1f;
            return;
            label_19:
            if(0 != 0)
            {
                    0.Invoke();
            }
            
            this.image.enabled = true;
            this.endTimer = 2f;
            return;
            label_31:
            if(0 != 0)
            {
                    0.Invoke();
            }
            
            this.image.enabled = true;
            this.endTimer = (this.forSkip == false) ? 2f : 0.1f;
            return;
            label_25:
            if(this.rewardedRequested == false)
            {
                goto label_46;
            }
            
            this.rewardedRequested = false;
            if((UnityEngine.Random.value < 0) && (0 != 0))
            {
                    0.Invoke();
            }
            
            if(0 == 0)
            {
                goto label_46;
            }
            
            0.Invoke();
            goto label_46;
        }
    
    }

}
