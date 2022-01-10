using UnityEngine;
public class DebugTenjin : BaseTenjin
{
    // Methods
    public override void Connect()
    {
        UnityEngine.Debug.Log(message:  "Connecting " + null);
    }
    public override void Connect(string deferredDeeplink)
    {
        UnityEngine.Debug.Log(message:  "Connecting with deferredDeeplink " + deferredDeeplink);
    }
    public override void Init(string apiKey)
    {
        UnityEngine.Debug.Log(message:  "Initializing  with api key");
    }
    public override void InitWithSharedSecret(string apiKey, string sharedSecret)
    {
        UnityEngine.Debug.Log(message:  "Initializing with shared secret");
    }
    public override void InitWithAppSubversion(string apiKey, int appSubversion)
    {
        UnityEngine.Debug.Log(message:  "Initializing with shared secret + subversion: "("Initializing with shared secret + subversion: ") + appSubversion);
    }
    public override void InitWithSharedSecretAppSubversion(string apiKey, string sharedSecret, int appSubversion)
    {
        UnityEngine.Debug.Log(message:  "Initializing with shared secret + subversion: "("Initializing with shared secret + subversion: ") + appSubversion);
    }
    public override void SendEvent(string eventName)
    {
        UnityEngine.Debug.Log(message:  "Sending Event " + eventName);
    }
    public override void SendEvent(string eventName, string eventValue)
    {
        UnityEngine.Debug.Log(message:  "Sending Event " + eventName + " : "(" : ") + eventValue);
    }
    public override void Transaction(string productId, string currencyCode, int quantity, double unitPrice, string transactionId, string receipt, string signature)
    {
        int val_3;
        int val_4;
        int val_5;
        object[] val_1 = new object[14];
        val_3 = val_1.Length;
        val_1[0] = "Transaction ";
        if(productId != null)
        {
                val_3 = val_1.Length;
        }
        
        val_1[1] = productId;
        val_3 = val_1.Length;
        val_1[2] = ", ";
        if(currencyCode != null)
        {
                val_3 = val_1.Length;
        }
        
        val_1[3] = currencyCode;
        val_3 = val_1.Length;
        val_1[4] = ", ";
        val_4 = val_1.Length;
        val_1[5] = quantity;
        val_4 = val_1.Length;
        val_1[6] = ", ";
        val_5 = val_1.Length;
        val_1[7] = unitPrice;
        val_5 = val_1.Length;
        val_1[8] = ", ";
        if(transactionId != null)
        {
                val_5 = val_1.Length;
        }
        
        val_1[9] = transactionId;
        val_5 = val_1.Length;
        val_1[10] = ", ";
        if(receipt != null)
        {
                val_5 = val_1.Length;
        }
        
        val_1[11] = receipt;
        val_5 = val_1.Length;
        val_1[12] = ", ";
        if(signature != null)
        {
                val_5 = val_1.Length;
        }
        
        val_1[13] = signature;
        UnityEngine.Debug.Log(message:  +val_1);
    }
    public override void GetDeeplink(Tenjin.DeferredDeeplinkDelegate deferredDeeplinkDelegate)
    {
        UnityEngine.Debug.Log(message:  "Sending DebugTenjin::GetDeeplink");
    }
    public override void OptIn()
    {
        UnityEngine.Debug.Log(message:  "OptIn ");
    }
    public override void OptOut()
    {
        UnityEngine.Debug.Log(message:  "OptOut ");
    }
    public override void OptInParams(System.Collections.Generic.List<string> parameters)
    {
        UnityEngine.Debug.Log(message:  "OptInParams");
    }
    public override void OptOutParams(System.Collections.Generic.List<string> parameters)
    {
        UnityEngine.Debug.Log(message:  "OptOutParams");
    }
    public override void AppendAppSubversion(int subversion)
    {
        UnityEngine.Debug.Log(message:  "AppendAppSubversion: "("AppendAppSubversion: ") + subversion);
    }
    public DebugTenjin()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
