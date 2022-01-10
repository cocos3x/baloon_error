using UnityEngine;
public static class Tenjin
{
    // Fields
    private static System.Collections.Generic.Dictionary<string, BaseTenjin> _instances;
    
    // Methods
    public static BaseTenjin getInstance(string apiKey)
    {
        var val_3;
        var val_4;
        var val_5;
        val_3 = null;
        val_3 = null;
        if((Tenjin._instances.ContainsKey(key:  apiKey)) != true)
        {
                val_4 = null;
            val_4 = null;
            Tenjin._instances.Add(key:  apiKey, value:  Tenjin.createTenjin(apiKey:  apiKey, sharedSecret:  0, appSubversion:  0));
        }
        
        val_5 = null;
        val_5 = null;
        return Tenjin._instances.Item[apiKey];
    }
    public static BaseTenjin getInstanceWithSharedSecret(string apiKey, string sharedSecret)
    {
        var val_4;
        var val_5;
        var val_6;
        string val_1 = apiKey + "." + sharedSecret;
        val_4 = null;
        val_4 = null;
        if((Tenjin._instances.ContainsKey(key:  val_1)) != true)
        {
                val_5 = null;
            val_5 = null;
            Tenjin._instances.Add(key:  val_1, value:  Tenjin.createTenjin(apiKey:  apiKey, sharedSecret:  sharedSecret, appSubversion:  0));
        }
        
        val_6 = null;
        val_6 = null;
        return Tenjin._instances.Item[val_1];
    }
    public static BaseTenjin getInstanceWithAppSubversion(string apiKey, int appSubversion)
    {
        var val_5;
        var val_6;
        var val_7;
        string val_1 = apiKey + "." + appSubversion;
        val_5 = null;
        val_5 = null;
        if((Tenjin._instances.ContainsKey(key:  val_1)) != true)
        {
                val_6 = null;
            val_6 = null;
            Tenjin._instances.Add(key:  val_1, value:  Tenjin.createTenjin(apiKey:  apiKey, sharedSecret:  0, appSubversion:  appSubversion));
        }
        
        val_7 = null;
        val_7 = null;
        return (BaseTenjin)Tenjin._instances.Item[val_1];
    }
    public static BaseTenjin getInstanceWithSharedSecretAppSubversion(string apiKey, string sharedSecret, int appSubversion)
    {
        int val_6;
        object val_7;
        var val_8;
        var val_9;
        var val_10;
        object[] val_1 = new object[5];
        val_6 = val_1.Length;
        val_1[0] = apiKey;
        val_6 = val_1.Length;
        val_1[1] = ".";
        if(sharedSecret != null)
        {
                val_6 = val_1.Length;
        }
        
        val_1[2] = sharedSecret;
        val_6 = val_1.Length;
        val_1[3] = ".";
        val_7 = appSubversion;
        val_1[4] = val_7;
        string val_2 = +val_1;
        val_8 = null;
        val_8 = null;
        if((Tenjin._instances.ContainsKey(key:  val_2)) != true)
        {
                val_9 = null;
            val_9 = null;
            val_7 = Tenjin._instances;
            val_7.Add(key:  val_2, value:  Tenjin.createTenjin(apiKey:  apiKey, sharedSecret:  sharedSecret, appSubversion:  appSubversion));
        }
        
        val_10 = null;
        val_10 = null;
        return (BaseTenjin)Tenjin._instances.Item[val_2];
    }
    private static BaseTenjin createTenjin(string apiKey, string sharedSecret, int appSubversion)
    {
        UnityEngine.GameObject val_1 = new UnityEngine.GameObject(name:  "Tenjin");
        val_1.hideFlags = 61;
        UnityEngine.Object.DontDestroyOnLoad(target:  val_1);
        if((appSubversion != 0) && ((System.String.IsNullOrEmpty(value:  sharedSecret)) != true))
        {
                return (BaseTenjin)val_1.AddComponent<AndroidTenjin>();
        }
        
        if((System.String.IsNullOrEmpty(value:  sharedSecret)) == false)
        {
                return (BaseTenjin)val_1.AddComponent<AndroidTenjin>();
        }
        
        if(appSubversion != 0)
        {
                return (BaseTenjin)val_1.AddComponent<AndroidTenjin>();
        }
        
        return (BaseTenjin)val_1.AddComponent<AndroidTenjin>();
    }
    private static Tenjin()
    {
        Tenjin._instances = new System.Collections.Generic.Dictionary<System.String, BaseTenjin>();
    }

}
