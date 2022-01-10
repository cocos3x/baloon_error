using UnityEngine;

namespace Kayac.HcAd
{
    public class SecretConfig : SecretConfig
    {
        // Properties
        public override string maxSdkKey { get; }
        public override string maxInterstitialAdUnitId { get; }
        public override string maxRewardedAdUnitId { get; }
        public override string maxBannerAdUnitId { get; }
        public override string tenjinApiKey { get; }
        
        // Methods
        public override string get_maxSdkKey()
        {
            return "iLhXBDT_eaF2_e5CFtsxvVBQTU82ItcHF7ZrNK4vlz0gH7wqbiBE9AN1t9mFd9K-TZ7UJzbKqxXkKlHR0sFHRr";
        }
        public override string get_maxInterstitialAdUnitId()
        {
            return "4f27ba1d69c8a109";
        }
        public override string get_maxRewardedAdUnitId()
        {
            return "c1bf3767cd4a39ea";
        }
        public override string get_maxBannerAdUnitId()
        {
            return "80ed4bab34408fb8";
        }
        public override string get_tenjinApiKey()
        {
            return "YEQOYSUYDYEENIZHFTPJEWAE3SMBYNQF";
        }
        public SecretConfig()
        {
            val_1 = new System.Object();
        }
    
    }

}
