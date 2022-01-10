using UnityEngine;
public abstract class BaseTenjin : MonoBehaviour
{
    // Fields
    protected string apiKey;
    protected string sharedSecret;
    protected bool optIn;
    protected bool optOut;
    protected int appSubversion;
    
    // Properties
    public string ApiKey { get; set; }
    public string SharedSecret { get; set; }
    public int AppSubversion { get; set; }
    
    // Methods
    public string get_ApiKey()
    {
        return (string)this.apiKey;
    }
    public void set_ApiKey(string value)
    {
        this.apiKey = value;
    }
    public string get_SharedSecret()
    {
        return (string)this.sharedSecret;
    }
    public void set_SharedSecret(string value)
    {
        this.sharedSecret = value;
    }
    public int get_AppSubversion()
    {
        return (int)this.appSubversion;
    }
    public void set_AppSubversion(int value)
    {
        this.appSubversion = value;
    }
    public abstract void Init(string apiKey); // 0
    public abstract void InitWithSharedSecret(string apiKey, string sharedSecret); // 0
    public abstract void InitWithAppSubversion(string apiKey, int appSubversion); // 0
    public abstract void InitWithSharedSecretAppSubversion(string apiKey, string sharedSecret, int appSubversion); // 0
    public abstract void Connect(); // 0
    public abstract void Connect(string deferredDeeplink); // 0
    public abstract void OptIn(); // 0
    public abstract void OptOut(); // 0
    public abstract void OptInParams(System.Collections.Generic.List<string> parameters); // 0
    public abstract void OptOutParams(System.Collections.Generic.List<string> parameters); // 0
    public abstract void AppendAppSubversion(int subversion); // 0
    public abstract void SendEvent(string eventName); // 0
    public abstract void SendEvent(string eventName, string eventValue); // 0
    public abstract void Transaction(string productId, string currencyCode, int quantity, double unitPrice, string transactionId, string receipt, string signature); // 0
    public abstract void GetDeeplink(Tenjin.DeferredDeeplinkDelegate deferredDeeplinkDelegate); // 0
    protected BaseTenjin()
    {
    
    }

}
