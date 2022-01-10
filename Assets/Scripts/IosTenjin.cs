using UnityEngine;
public class IosTenjin : BaseTenjin
{
    // Methods
    public override void Init(string apiKey)
    {
        UnityEngine.Debug.Log(message:  "iOS Initializing");
        mem[1152921507418153656] = apiKey;
    }
    public override void InitWithSharedSecret(string apiKey, string sharedSecret)
    {
        UnityEngine.Debug.Log(message:  "iOS Initializing with Shared Secret");
        mem[1152921507418278088] = apiKey;
        mem[1152921507418278096] = sharedSecret;
    }
    public override void InitWithAppSubversion(string apiKey, int appSubversion)
    {
        var val_1 = null;
        UnityEngine.Debug.Log(message:  null);
        mem[1152921507418402520] = apiKey;
        mem[1152921507418402540] = appSubversion;
    }
    public override void InitWithSharedSecretAppSubversion(string apiKey, string sharedSecret, int appSubversion)
    {
        UnityEngine.Debug.Log(message:  "iOS Initializing with Shared Secret + App Subversion");
        mem[1152921507418526984] = apiKey;
        mem[1152921507418526992] = sharedSecret;
        mem[1152921507418527004] = appSubversion;
    }
    public override void Connect()
    {
        UnityEngine.Debug.Log(message:  "iOS Connecting");
    }
    public override void Connect(string deferredDeeplink)
    {
        UnityEngine.Debug.Log(message:  "Connecting with deferredDeeplink " + deferredDeeplink);
    }
    public override void SendEvent(string eventName)
    {
        UnityEngine.Debug.Log(message:  "iOS Sending Event " + eventName);
    }
    public override void SendEvent(string eventName, string eventValue)
    {
        UnityEngine.Debug.Log(message:  "iOS Sending Event " + eventName + " : "(" : ") + eventValue);
    }
    public override void Transaction(string productId, string currencyCode, int quantity, double unitPrice, string transactionId, string receipt, string signature)
    {
        int val_3;
        int val_4;
        int val_5;
        object[] val_1 = new object[14];
        val_3 = val_1.Length;
        val_1[0] = "iOS Transaction ";
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
        UnityEngine.Debug.Log(message:  "Sending IosTenjin::GetDeeplink");
    }
    public override void OptIn()
    {
        UnityEngine.Debug.Log(message:  "iOS OptIn");
    }
    public override void OptOut()
    {
        UnityEngine.Debug.Log(message:  "iOS OptOut");
    }
    public override void OptInParams(System.Collections.Generic.List<string> parameters)
    {
        UnityEngine.Debug.Log(message:  "iOS OptInParams");
    }
    public override void OptOutParams(System.Collections.Generic.List<string> parameters)
    {
        UnityEngine.Debug.Log(message:  "iOS OptOutParams");
    }
    public override void AppendAppSubversion(int subversion)
    {
        UnityEngine.Debug.Log(message:  "iOS AppendAppSubversion");
    }
    public IosTenjin()
    {
    
    }

}
