using UnityEngine;

namespace Kayac.HcAd.Secret
{
    public class SecretConfig
    {
        // Properties
        public virtual string maxSdkKey { get; }
        public virtual string maxInterstitialAdUnitId { get; }
        public virtual string maxRewardedAdUnitId { get; }
        public virtual string maxBannerAdUnitId { get; }
        public virtual string tenjinApiKey { get; }
        
        // Methods
        public virtual string get_maxSdkKey()
        {
            return "";
        }
        public virtual string get_maxInterstitialAdUnitId()
        {
            return "";
        }
        public virtual string get_maxRewardedAdUnitId()
        {
            return "";
        }
        public virtual string get_maxBannerAdUnitId()
        {
            return "";
        }
        public virtual string get_tenjinApiKey()
        {
            return "";
        }
        public SecretConfig()
        {
        
        }
    
    }

}
