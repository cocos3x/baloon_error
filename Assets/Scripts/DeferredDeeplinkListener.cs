using UnityEngine;
private class AndroidTenjin.DeferredDeeplinkListener : AndroidJavaProxy
{
    // Fields
    private Tenjin.DeferredDeeplinkDelegate callback;
    
    // Methods
    public AndroidTenjin.DeferredDeeplinkListener(Tenjin.DeferredDeeplinkDelegate deferredDeeplinkCallback)
    {
        this.callback = deferredDeeplinkCallback;
    }
    public void onSuccess(bool clickedTenjinLink, bool isFirstSession, UnityEngine.AndroidJavaObject data)
    {
        System.Collections.Generic.Dictionary<System.String, System.String> val_1 = new System.Collections.Generic.Dictionary<System.String, System.String>();
        object[] val_2 = new object[1];
        val_2[0] = "ad_network";
        string val_3 = data.Call<System.String>(methodName:  "get", args:  val_2);
        object[] val_4 = new object[1];
        val_4[0] = "campaign_id";
        string val_5 = data.Call<System.String>(methodName:  "get", args:  val_4);
        object[] val_6 = new object[1];
        val_6[0] = "advertising_id";
        string val_7 = data.Call<System.String>(methodName:  "get", args:  val_6);
        object[] val_8 = new object[1];
        val_8[0] = "deferred_deeplink_url";
        string val_9 = data.Call<System.String>(methodName:  "get", args:  val_8);
        if((System.String.IsNullOrEmpty(value:  val_3)) != true)
        {
                val_1.set_Item(key:  "ad_network", value:  val_3);
        }
        
        if((System.String.IsNullOrEmpty(value:  val_5)) != true)
        {
                val_1.set_Item(key:  "campaign_id", value:  val_5);
        }
        
        if((System.String.IsNullOrEmpty(value:  val_7)) != true)
        {
                val_1.set_Item(key:  "advertising_id", value:  val_7);
        }
        
        if((System.String.IsNullOrEmpty(value:  val_9)) != true)
        {
                val_1.set_Item(key:  "deferred_deeplink_url", value:  val_9);
        }
        
        val_1.Add(key:  "clicked_tenjin_link", value:  System.Convert.ToString(value:  clickedTenjinLink));
        val_1.Add(key:  "is_first_session", value:  System.Convert.ToString(value:  isFirstSession));
        mem[1152921507415115536].Invoke(deferredLinkData:  val_1);
    }

}
