using UnityEngine;
private class FirebaseWrapper.UserProperty
{
    // Fields
    private bool <Sent>k__BackingField;
    private System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>> pairs;
    
    // Properties
    public bool Sent { get; set; }
    
    // Methods
    public FirebaseWrapper.UserProperty(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>> keyValuePairs)
    {
        this.pairs = keyValuePairs;
        this.<Sent>k__BackingField = false;
    }
    public void Send()
    {
        string val_13;
        System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>> val_14;
        var val_16;
        if((this.<Sent>k__BackingField) != false)
        {
                return;
        }
        
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        val_13 = "[FirebaseManager.UserProperty.Send]";
        System.Text.StringBuilder val_2 = val_1.AppendLine(value:  val_13);
        val_14 = this.pairs;
        if(val_14 == null)
        {
            goto label_3;
        }
        
        var val_16 = 0;
        val_16 = val_16 + 1;
        System.Collections.Generic.IEnumerator<T> val_4 = val_14.GetEnumerator();
        val_16 = val_4;
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        label_20:
        var val_17 = 0;
        val_17 = val_17 + 1;
        val_13 = public System.Boolean System.Collections.IEnumerator::MoveNext();
        if(val_16.MoveNext() == false)
        {
            goto label_13;
        }
        
        var val_18 = 0;
        val_18 = val_18 + 1;
        T val_8 = val_16.Current;
        Firebase.Analytics.FirebaseAnalytics.SetUserProperty(name:  val_8, property:  public T System.Collections.Generic.IEnumerator<T>::get_Current());
        System.Text.StringBuilder val_9 = val_1.AppendFormat(format:  "\t{0} = {1}\n", arg0:  val_8, arg1:  public T System.Collections.Generic.IEnumerator<T>::get_Current());
        goto label_20;
        label_13:
        if(val_16 != null)
        {
                var val_19 = 0;
            val_19 = val_19 + 1;
            val_13 = public System.Void System.IDisposable::Dispose();
            val_16.Dispose();
        }
        
        if(0 != 0)
        {
                throw X22;
        }
        
        label_3:
        this.<Sent>k__BackingField = true;
        UnityEngine.Debug.Log(message:  val_1);
        return;
        label_56:
        if( >= ((X22 + 16 + 24) << ))
        {
            goto label_50;
        }
        
        mem2[0] = (X22 + 16) + ;
         =  + 1;
         =  + 32;
        if((X22 + 16) != 0)
        {
            goto label_56;
        }
        
        throw new NullReferenceException();
        label_50:
        Firebase.Analytics.FirebaseAnalytics.LogEvent(name:  null, parameters:  null);
    }
    public bool get_Sent()
    {
        return (bool)this.<Sent>k__BackingField;
    }
    private void set_Sent(bool value)
    {
        this.<Sent>k__BackingField = value;
    }

}
