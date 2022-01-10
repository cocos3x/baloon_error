using UnityEngine;
[Serializable]
private class FirebaseWrapper.ConfigData
{
    // Fields
    public bool overrideEnabled;
    public System.Collections.Generic.List<Kayac.FirebaseWrapper.ConfigDataItem> items;
    
    // Methods
    public FirebaseWrapper.ConfigData()
    {
        this.items = new System.Collections.Generic.List<ConfigDataItem>();
    }

}
