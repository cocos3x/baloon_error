using UnityEngine;
public class AndroidTenjin : BaseTenjin
{
    // Fields
    private const string AndroidJavaTenjinClass = "com.tenjin.android.TenjinSDK";
    private UnityEngine.AndroidJavaObject tenjinJava;
    private UnityEngine.AndroidJavaObject activity;
    
    // Methods
    public override void Init(string apiKey)
    {
        int val_7;
        if(UnityEngine.Debug.isDebugBuild != false)
        {
                UnityEngine.Debug.Log(message:  "Android Initializing");
        }
        
        mem[1152921507411972200] = apiKey;
        this.initActivity();
        UnityEngine.AndroidJavaClass val_2 = new UnityEngine.AndroidJavaClass(className:  "com.tenjin.android.TenjinSDK");
        if(val_2 == null)
        {
                throw new UnityEngine.MissingReferenceException(message:  System.String.Format(format:  "AndroidTenjin failed to load {0} class", arg0:  ???));
        }
        
        object[] val_3 = new object[2];
        val_7 = val_3.Length;
        val_3[0] = this.activity;
        if(apiKey != null)
        {
                val_7 = val_3.Length;
        }
        
        val_3[1] = apiKey;
        this.tenjinJava = val_2.CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "getInstance", args:  val_3);
    }
    public override void InitWithSharedSecret(string apiKey, string sharedSecret)
    {
        int val_7;
        if(UnityEngine.Debug.isDebugBuild != false)
        {
                UnityEngine.Debug.Log(message:  "Android Initializing with Shared Secret");
        }
        
        mem[1152921507412147000] = apiKey;
        mem[1152921507412147008] = sharedSecret;
        this.initActivity();
        UnityEngine.AndroidJavaClass val_2 = new UnityEngine.AndroidJavaClass(className:  "com.tenjin.android.TenjinSDK");
        if(val_2 == null)
        {
                throw new UnityEngine.MissingReferenceException(message:  System.String.Format(format:  "AndroidTenjin failed to load {0} class", arg0:  ???));
        }
        
        object[] val_3 = new object[3];
        val_7 = val_3.Length;
        val_3[0] = this.activity;
        if(apiKey != null)
        {
                val_7 = val_3.Length;
        }
        
        val_3[1] = apiKey;
        if(sharedSecret != null)
        {
                val_7 = val_3.Length;
        }
        
        val_3[2] = sharedSecret;
        this.tenjinJava = val_2.CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "getInstanceWithSharedSecret", args:  val_3);
    }
    public override void InitWithAppSubversion(string apiKey, int appSubversion)
    {
        int val_8;
        if(UnityEngine.Debug.isDebugBuild != false)
        {
                UnityEngine.Debug.Log(message:  "Android Initializing with Subversion");
        }
        
        mem[1152921507412334216] = apiKey;
        mem[1152921507412334236] = appSubversion;
        this.initActivity();
        UnityEngine.AndroidJavaClass val_2 = new UnityEngine.AndroidJavaClass(className:  "com.tenjin.android.TenjinSDK");
        if(val_2 == null)
        {
                throw new UnityEngine.MissingReferenceException(message:  System.String.Format(format:  "AndroidTenjin failed to load {0} class", arg0:  ???));
        }
        
        object[] val_3 = new object[3];
        val_8 = val_3.Length;
        val_3[0] = this.activity;
        if(apiKey != null)
        {
                val_8 = val_3.Length;
        }
        
        val_3[1] = apiKey;
        val_3[2] = appSubversion;
        UnityEngine.AndroidJavaObject val_4 = val_2.CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "getInstanceWithAppSubversion", args:  val_3);
        this.tenjinJava = val_4;
        object[] val_5 = new object[1];
        val_5[0] = appSubversion;
        val_4.Call(methodName:  "appendAppSubversion", args:  val_5);
    }
    public override void InitWithSharedSecretAppSubversion(string apiKey, string sharedSecret, int appSubversion)
    {
        int val_8;
        if(UnityEngine.Debug.isDebugBuild != false)
        {
                UnityEngine.Debug.Log(message:  "Android Initializing with Subversion");
        }
        
        mem[1152921507412533512] = apiKey;
        mem[1152921507412533520] = sharedSecret;
        mem[1152921507412533532] = appSubversion;
        this.initActivity();
        UnityEngine.AndroidJavaClass val_2 = new UnityEngine.AndroidJavaClass(className:  "com.tenjin.android.TenjinSDK");
        if(val_2 == null)
        {
                throw new UnityEngine.MissingReferenceException(message:  System.String.Format(format:  "AndroidTenjin failed to load {0} class", arg0:  ???));
        }
        
        object[] val_3 = new object[4];
        val_8 = val_3.Length;
        val_3[0] = this.activity;
        if(apiKey != null)
        {
                val_8 = val_3.Length;
        }
        
        val_3[1] = apiKey;
        if(sharedSecret != null)
        {
                val_8 = val_3.Length;
        }
        
        val_3[2] = sharedSecret;
        val_3[3] = appSubversion;
        UnityEngine.AndroidJavaObject val_4 = val_2.CallStatic<UnityEngine.AndroidJavaObject>(methodName:  "getInstanceWithSharedSecretAppSubversion", args:  val_3);
        this.tenjinJava = val_4;
        object[] val_5 = new object[1];
        val_5[0] = appSubversion;
        val_4.Call(methodName:  "appendAppSubversion", args:  val_5);
    }
    private void initActivity()
    {
        this.activity = new UnityEngine.AndroidJavaClass(className:  "com.unity3d.player.UnityPlayer").GetStatic<UnityEngine.AndroidJavaObject>(fieldName:  "currentActivity");
    }
    public override void Connect()
    {
        object val_2;
        if(true != 0)
        {
                val_2 = "optin";
        }
        else
        {
                if(true == 0)
        {
            goto label_9;
        }
        
            val_2 = "optout";
        }
        
        label_9:
        object[] val_1 = new object[2];
        val_1[1] = val_2;
        this.tenjinJava.Call(methodName:  "connect", args:  val_1);
    }
    public override void Connect(string deferredDeeplink)
    {
        object val_2;
        int val_3;
        if(true != 0)
        {
                val_2 = "optin";
        }
        else
        {
                if(true == 0)
        {
            goto label_12;
        }
        
            val_2 = "optout";
        }
        
        label_12:
        object[] val_1 = new object[2];
        val_3 = val_1.Length;
        val_1[0] = deferredDeeplink;
        val_3 = val_1.Length;
        val_1[1] = val_2;
        this.tenjinJava.Call(methodName:  "connect", args:  val_1);
    }
    public override void SendEvent(string eventName)
    {
        object[] val_1 = new object[1];
        val_1[0] = eventName;
        this.tenjinJava.Call(methodName:  "eventWithName", args:  val_1);
    }
    public override void SendEvent(string eventName, string eventValue)
    {
        int val_2;
        object[] val_1 = new object[2];
        val_2 = val_1.Length;
        val_1[0] = eventName;
        if(eventValue != null)
        {
                val_2 = val_1.Length;
        }
        
        val_1[1] = eventValue;
        this.tenjinJava.Call(methodName:  "eventWithNameAndValue", args:  val_1);
    }
    public override void Transaction(string productId, string currencyCode, int quantity, double unitPrice, string transactionId, string receipt, string signature)
    {
        object val_9;
        object val_10;
        System.Object[] val_11;
        int val_12;
        var val_13;
        int val_14;
        int val_15;
        int val_16;
        int val_17;
        var val_19;
        int val_20;
        int val_21;
        int val_22;
        val_9 = signature;
        val_10 = productId;
        if((receipt == null) || (val_9 == null))
        {
            goto label_2;
        }
        
        val_11 = new object[6];
        val_12 = val_1.Length;
        val_11[0] = val_10;
        if(currencyCode != null)
        {
                val_12 = val_1.Length;
        }
        
        val_11[1] = currencyCode;
        val_13 = 1152921504617230336;
        val_11[2] = quantity;
        val_11[3] = unitPrice;
        val_11[4] = receipt;
        val_11[5] = val_9;
        if(UnityEngine.Debug.isDebugBuild == false)
        {
            goto label_74;
        }
        
        object[] val_3 = new object[12];
        val_14 = val_3.Length;
        val_3[0] = "Android Transaction ";
        if(val_10 != null)
        {
                val_14 = val_3.Length;
        }
        
        val_3[1] = val_10;
        val_10 = ", ";
        val_14 = val_3.Length;
        val_3[2] = ", ";
        if(currencyCode != null)
        {
                val_14 = val_3.Length;
        }
        
        val_3[3] = currencyCode;
        val_14 = val_3.Length;
        val_3[4] = ", ";
        val_15 = val_3.Length;
        val_3[5] = quantity;
        val_15 = val_3.Length;
        val_3[6] = ", ";
        val_16 = val_3.Length;
        val_3[7] = unitPrice;
        val_16 = val_3.Length;
        val_3[8] = ", ";
        val_17 = val_3.Length;
        val_3[9] = receipt;
        val_17 = val_3.Length;
        val_3[10] = ", ";
        val_3[11] = val_9;
        string val_4 = +val_3;
        val_19 = null;
        goto label_58;
        label_2:
        object[] val_5 = new object[4];
        val_11 = val_5;
        val_20 = val_5.Length;
        val_11[0] = val_10;
        if(currencyCode != null)
        {
                val_20 = val_5.Length;
        }
        
        val_11[1] = currencyCode;
        val_13 = 1152921504617230336;
        val_11[2] = quantity;
        val_9 = unitPrice;
        val_11[3] = val_9;
        if(UnityEngine.Debug.isDebugBuild == false)
        {
            goto label_74;
        }
        
        object[] val_7 = new object[8];
        val_9 = val_7;
        val_21 = val_7.Length;
        val_9[0] = "Android Transaction ";
        if(val_10 != null)
        {
                val_21 = val_7.Length;
        }
        
        val_9[1] = val_10;
        val_10 = ", ";
        val_21 = val_7.Length;
        val_9[2] = ", ";
        if(currencyCode != null)
        {
                val_21 = val_7.Length;
        }
        
        val_9[3] = currencyCode;
        val_21 = val_7.Length;
        val_9[4] = ", ";
        val_22 = val_7.Length;
        val_9[5] = quantity;
        val_22 = val_7.Length;
        val_9[6] = ", ";
        val_9[7] = unitPrice;
        val_19 = null;
        label_58:
        UnityEngine.Debug.Log(message:  +val_7);
        label_74:
        this.tenjinJava.Call(methodName:  "transaction", args:  val_5);
    }
    public override void GetDeeplink(Tenjin.DeferredDeeplinkDelegate deferredDeeplinkDelegate)
    {
        object[] val_2 = new object[1];
        val_2[0] = new AndroidTenjin.DeferredDeeplinkListener(deferredDeeplinkCallback:  deferredDeeplinkDelegate);
        this.tenjinJava.Call(methodName:  "getDeeplink", args:  val_2);
    }
    public override void OptIn()
    {
        var val_1;
        mem[1152921507413791512] = 1;
        val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        this.tenjinJava.Call(methodName:  "optIn", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
    }
    public override void OptOut()
    {
        var val_1;
        mem[1152921507413911785] = 1;
        val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_1 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_1 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        this.tenjinJava.Call(methodName:  "optOut", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
    }
    public override void OptInParams(System.Collections.Generic.List<string> parameters)
    {
        object[] val_1 = new object[1];
        val_1[0] = parameters.ToArray();
        this.tenjinJava.Call(methodName:  "optInParams", args:  val_1);
    }
    public override void OptOutParams(System.Collections.Generic.List<string> parameters)
    {
        object[] val_1 = new object[1];
        val_1[0] = parameters.ToArray();
        this.tenjinJava.Call(methodName:  "optOutParams", args:  val_1);
    }
    public override void AppendAppSubversion(int appSubversion)
    {
        object[] val_1 = new object[1];
        val_1[0] = appSubversion;
        this.tenjinJava.Call(methodName:  "appendAppSubversion", args:  val_1);
    }
    public static UnityEngine.AndroidJavaObject CreateJavaMapFromDictainary(System.Collections.Generic.IDictionary<string, string> parameters)
    {
        var val_18;
        var val_19;
        System.Object[] val_20;
        object val_24;
        int val_25;
        val_18 = parameters;
        val_19 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_19 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_19 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_19 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_20 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184];
        val_20 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184;
        UnityEngine.AndroidJavaObject val_1 = new UnityEngine.AndroidJavaObject(className:  "java.util.HashMap", args:  val_20);
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_20 = UnityEngine.AndroidJNIHelper.GetMethodID(javaClass:  val_1.GetRawClass(), methodName:  "put", signature:  "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
        object[] val_4 = new object[2];
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        var val_23 = 0;
        val_23 = val_23 + 1;
        val_18 = val_18.GetEnumerator();
        var val_26 = 0;
        label_52:
        var val_24 = 0;
        val_24 = val_24 + 1;
        if(val_18.MoveNext() == false)
        {
            goto label_18;
        }
        
        var val_25 = 0;
        val_25 = val_25 + 1;
        object[] val_11 = new object[1];
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11[0] = val_18.Current;
        UnityEngine.AndroidJavaObject val_12 = new UnityEngine.AndroidJavaObject(className:  "java.lang.String", args:  val_11);
        object[] val_13 = new object[1];
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        if((public T System.Collections.Generic.IEnumerator<T>::get_Current()) != 0)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_13.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_13[0] = public T System.Collections.Generic.IEnumerator<T>::get_Current();
        UnityEngine.AndroidJavaObject val_14 = null;
        val_24 = val_14;
        val_14 = new UnityEngine.AndroidJavaObject(className:  "java.lang.String", args:  val_13);
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_12 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_25 = val_4.Length;
        if(val_25 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_4[0] = val_12;
        if(val_24 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_25 = val_4.Length;
        }
        
        if(val_25 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_4[1] = val_24;
        IntPtr val_17 = UnityEngine.AndroidJNI.CallObjectMethod(obj:  val_1.GetRawObject(), methodID:  val_20, args:  UnityEngine.AndroidJNIHelper.CreateJNIArgArray(args:  val_4));
        val_26 = val_26 + 1;
        mem2[0] = 173;
        if(val_24 != null)
        {
                var val_27 = 0;
            val_27 = val_27 + 1;
            val_14.Dispose();
        }
        
        if(0 != 0)
        {
                throw 0;
        }
        
        val_24 = 0;
        if(val_12 != null)
        {
                var val_28 = 0;
            val_28 = val_28 + 1;
            val_12.Dispose();
        }
        
        if(val_24 != 0)
        {
                throw val_24;
        }
        
        if((val_26 == 1) || ((1152921507414639360 + ((0 + 1)) << 2) != 173))
        {
            goto label_52;
        }
        
        var val_29 = 0;
        val_29 = val_29 ^ (val_26 >> 31);
        var val_20 = val_26 + val_29;
        goto label_52;
        label_18:
        val_20 = 0;
        var val_21 = val_26 + 1;
        mem2[0] = 193;
        if(val_18 != null)
        {
                var val_30 = 0;
            val_30 = val_30 + 1;
            val_18.Dispose();
        }
        
        if(val_20 != 0)
        {
                throw val_20;
        }
        
        return val_1;
    }
    public AndroidTenjin()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
