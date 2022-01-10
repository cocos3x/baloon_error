using UnityEngine;
public class RemoteConfig : RemoteConfigBase
{
    // Fields
    private RemoteConfig.InterstitialData <interstitialData>k__BackingField;
    private int <LevelBundle>k__BackingField;
    private SaveData _saveData;
    
    // Properties
    public RemoteConfig.InterstitialData interstitialData { get; set; }
    public int LevelBundle { get; set; }
    
    // Methods
    public RemoteConfig.InterstitialData get_interstitialData()
    {
        return new InterstitialData() {Letter = this.<interstitialData>k__BackingField, Value = this.<interstitialData>k__BackingField};
    }
    private void set_interstitialData(RemoteConfig.InterstitialData value)
    {
        this.<interstitialData>k__BackingField = value.Letter;
        mem[1152921507391434352] = value.Modifier;
    }
    public int get_LevelBundle()
    {
        return (int)this.<LevelBundle>k__BackingField;
    }
    private void set_LevelBundle(int value)
    {
        this.<LevelBundle>k__BackingField = value;
    }
    public RemoteConfig(Kayac.FirebaseWrapper firebase, SaveData saveData)
    {
        val_1 = new System.Object();
        mem[1152921507391778528] = firebase;
        this._saveData = val_1;
        this.<LevelBundle>k__BackingField = 0;
        this.Load();
    }
    public void FixTestGroup()
    {
        if(this._saveData.testGroupAssigned != false)
        {
                return;
        }
        
        if((X8 + 19) != 0)
        {
                this.AssignTestGroup();
        }
        
        if(this._saveData.testGroupAssigned != true)
        {
                this.AssignTestGroupNone();
        }
        
        this.Load();
    }
    private void Load()
    {
        var val_8;
        string val_1 = this.GetTestGroupOption(group:  0);
        int val_2 = Kayac.RemoteConfigBase.GetIntFromOption(option:  val_1, min:  0, max:  5, defaultValue:  this.<LevelBundle>k__BackingField);
        this.<LevelBundle>k__BackingField = val_2;
        UnityEngine.Debug.Log(message:  System.String.Format(format:  "A/B Test : LevelBundle : {0} -> {1}", arg0:  val_1, arg1:  val_2));
        if(this._saveData.testGroupAssigned == false)
        {
                return;
        }
        
        System.Collections.Generic.List<System.String> val_5 = new System.Collections.Generic.List<System.String>();
        val_8 = 0;
        label_9:
        if(val_8 >= this._saveData.testGroupCount)
        {
            goto label_6;
        }
        
        val_5.Add(item:  this._saveData.GetTestGroup(index:  0));
        val_8 = val_8 + 1;
        if(this._saveData != null)
        {
            goto label_9;
        }
        
        throw new NullReferenceException();
        label_6:
        this.SetUserProperties(values:  val_5);
    }
    private void AssignTestGroup()
    {
        string val_5;
        UnityEngine.Debug.Log(message:  "AssignTestGroup called.");
        this._saveData.SetTestGroupCount(count:  1);
        do
        {
            string val_3 = 0;
            if((GetConfig(key:  "TestGroup" + 0.ToString(), value: out  val_3)) != false)
        {
                val_5 = val_3;
        }
        else
        {
                val_5 = 0;
        }
        
            this._saveData.SetTestGroup(index:  0, value:  val_5);
        }
        while(1 < 1);
    
    }
    private void AssignTestGroupNone()
    {
        UnityEngine.Debug.Log(message:  "AssignTestGroupNone called.");
        this._saveData.SetTestGroupCount(count:  1);
        this._saveData.SetTestGroup(index:  0, value:  0);
    }
    private string GetTestGroupOption(RemoteConfig.TestGroup group)
    {
        var val_6;
        string val_7;
        string val_1 = this._saveData.GetTestGroup(index:  group);
        val_6 = "";
        val_7 = group;
        UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
        if(val_1 == null)
        {
                return (string)val_6;
        }
        
        val_7 = group.ToString() + "_";
        if((val_1.StartsWith(value:  val_7)) == false)
        {
                return (string)val_6;
        }
        
        val_6 = val_1.Substring(startIndex:  val_3.m_stringLength);
        return (string)val_6;
    }
    private static RemoteConfig.InterstitialData GetInterstitialDataFromOption(string option)
    {
        string val_11;
        var val_12;
        var val_13;
        var val_14;
        val_11 = option;
        if((System.String.IsNullOrEmpty(value:  val_11)) != true)
        {
                char[] val_2 = new char[1];
            val_2[0] = '-';
            val_11 = val_11.Split(separator:  val_2);
            if((System.Single.TryParse(s:  val_11[0].Substring(startIndex:  1, length:  val_3[0].m_stringLength - 1), result: out  float val_6 = -4.885836E-16f)) != false)
        {
                val_12 = val_11[0].Chars[0];
            if(val_3.Length < 2)
        {
                return new InterstitialData() {Letter = ' ', Value = 1f, Modifier = 0f};
        }
        
            if((System.Single.TryParse(s:  val_11[1], result: out  float val_9 = -4.885834E-16f)) == false)
        {
                return new InterstitialData() {Letter = ' ', Value = 1f, Modifier = 0f};
        }
        
            val_14 = 0;
            val_13 = 0;
            return new InterstitialData() {Letter = ' ', Value = 1f, Modifier = 0f};
        }
        
        }
        
        val_14 = 0;
        val_12 = 32;
        val_13 = 1065353216;
        return new InterstitialData() {Letter = ' ', Value = 1f, Modifier = 0f};
    }

}
