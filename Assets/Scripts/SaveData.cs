using UnityEngine;
public class SaveData
{
    // Fields
    private const string _filename = "savedata.bin";
    private const string _encryptKey = "suOzGRkAIxk0";
    private string[] _testGroups;
    private bool _gdprAccepted;
    private bool _canSkipGdprCheck;
    private double _playTime;
    private bool _storeReviewRequested;
    private bool _testGroupNoneAssigned;
    private int _lastLevelIndex;
    private int[] _skinIds;
    private Skin.State[] _skinStates;
    private int _lastSelectedSkinId;
    private bool _isTrial;
    private bool _isVibration;
    private int _rendererLevel;
    
    // Properties
    public int lastLevelIndex { get; }
    public Skin.State[] SkinStates { get; }
    public bool IsVibration { get; set; }
    public int rendererLevel { get; set; }
    public bool isTrial { get; set; }
    public int lastSelectedSkinId { get; set; }
    public bool canSkipGdprCheck { get; }
    public bool testGroupNoneAssigned { get; }
    public bool storeReviewRequested { get; }
    public double playTime { get; }
    public int testGroupCount { get; }
    public bool testGroupAssigned { get; }
    
    // Methods
    public int get_lastLevelIndex()
    {
        return (int)this._lastLevelIndex;
    }
    public Skin.State[] get_SkinStates()
    {
        return (State[])this._skinStates;
    }
    public bool get_IsVibration()
    {
        return (bool)this._isVibration;
    }
    public void set_IsVibration(bool value)
    {
        this._isVibration = value;
    }
    public int get_rendererLevel()
    {
        return (int)this._rendererLevel;
    }
    public void set_rendererLevel(int value)
    {
        this._rendererLevel = value;
    }
    public bool get_isTrial()
    {
        return (bool)this._isTrial;
    }
    public void set_isTrial(bool value)
    {
        this._isTrial = value;
    }
    public int get_lastSelectedSkinId()
    {
        return (int)this._lastSelectedSkinId;
    }
    public void set_lastSelectedSkinId(int value)
    {
        this._lastSelectedSkinId = value;
    }
    public void IncrementLastLevelIndex()
    {
        int val_1 = this._lastLevelIndex;
        val_1 = val_1 + 1;
        this._lastLevelIndex = val_1;
    }
    public void SetSkinState(int id, Skin.State state)
    {
        State[] val_1;
        val_1 = this._skinStates;
        if(state != 1)
        {
            goto label_0;
        }
        
        var val_2 = 0;
        label_5:
        if(val_2 >= (this._skinStates.Length << ))
        {
            goto label_2;
        }
        
        if(val_1[0] == 1)
        {
                val_1[0] = 2;
            val_1 = this._skinStates;
        }
        
        val_2 = val_2 + 1;
        if(val_1 != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_0:
        label_2:
        val_1[id << 2] = state;
    }
    public void SetSkinIds(int[] ids)
    {
        System.Int32[] val_4 = this._skinIds;
        if(val_4 != null)
        {
                if(ids != null)
        {
            goto label_2;
        }
        
        }
        
        this._skinIds = ids;
        State[] val_1 = new State[0];
        this._skinStates = val_1;
        val_1[0] = 1;
        val_4 = this._skinIds;
        label_2:
        if(this._skinIds.Length == ids.Length)
        {
                return;
        }
        
        new int[1][0] = ids.Length;
        this._skinIds = ids;
        System.Array.Resize<State>(array: ref  this._skinStates, newSize:  ids.Length);
    }
    public int[] GetSkinIds(Skin.State state)
    {
        State[] val_2;
        System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
        val_2 = this._skinStates;
        var val_3 = 0;
        do
        {
            if(val_3 >= (this._skinStates.Length << ))
        {
                return val_1.ToArray();
        }
        
            if(val_2[0] == state)
        {
                val_1.Add(item:  0);
            val_2 = this._skinStates;
        }
        
            val_3 = val_3 + 1;
        }
        while(val_2 != null);
        
        throw new NullReferenceException();
    }
    public int GetSelectedSkinId()
    {
        var val_1;
        if(this._skinStates.Length >= 1)
        {
                val_1 = 0;
            do
        {
            if(this._skinStates[0] == 1)
        {
                return (int)val_1;
        }
        
            val_1 = val_1 + 1;
        }
        while(val_1 < this._skinStates.Length);
        
        }
        
        UnityEngine.Debug.LogWarning(message:  "ここには来ないはず");
        val_1 = 0;
        return (int)val_1;
    }
    public bool get_canSkipGdprCheck()
    {
        if(this._gdprAccepted == false)
        {
                return (bool)(this._canSkipGdprCheck == true) ? 1 : 0;
        }
        
        return true;
    }
    public bool get_testGroupNoneAssigned()
    {
        return (bool)this._testGroupNoneAssigned;
    }
    public bool get_storeReviewRequested()
    {
        return (bool)this._storeReviewRequested;
    }
    public void UpdatePlayTime()
    {
        double val_2 = (double)UnityEngine.Time.deltaTime;
        val_2 = this._playTime + val_2;
        this._playTime = val_2;
    }
    public double get_playTime()
    {
        return (double)this._playTime;
    }
    public void OnRequestStoreReview()
    {
        this._storeReviewRequested = true;
        this.Save();
    }
    public void AcceptGdpr()
    {
        this._gdprAccepted = true;
        this._canSkipGdprCheck = true;
        this.Save();
    }
    public void DeferGdpr()
    {
        this._canSkipGdprCheck = true;
        this.Save();
    }
    public int get_testGroupCount()
    {
        if(this._testGroups == null)
        {
                return 0;
        }
        
        return (int)this._testGroups.Length;
    }
    public bool get_testGroupAssigned()
    {
        if(this._testGroupNoneAssigned != false)
        {
                return true;
        }
        
        if(this._testGroups == null)
        {
                return false;
        }
        
        return (bool)(this._testGroups.Length > 0) ? 1 : 0;
    }
    public string GetTestGroup(int index)
    {
        string val_1;
        if(this._testGroups == null)
        {
                return 0;
        }
        
        val_1 = 0;
        if((index & 2147483648) != 0)
        {
                return val_1;
        }
        
        if(this._testGroups.Length <= index)
        {
                return val_1;
        }
        
        if(this._testGroups.Length > index)
        {
                val_1 = this._testGroups[index];
            return val_1;
        }
        
        throw new IndexOutOfRangeException();
    }
    public void AssignTestGroupNone()
    {
        this._testGroupNoneAssigned = true;
    }
    public void SetTestGroupCount(int count)
    {
        this._testGroups = new string[0];
        this._testGroupNoneAssigned = false;
    }
    public void SetTestGroup(int index, string value)
    {
        int val_2;
        if(this._testGroups == null)
        {
                return;
        }
        
        if((index & 2147483648) != 0)
        {
                return;
        }
        
        val_2 = this._testGroups.Length;
        if(val_2 < index)
        {
                return;
        }
        
        string val_1 = (value == null) ? "" : value;
        if(val_1 != 0)
        {
                val_2 = this._testGroups.Length;
        }
        
        this._testGroups[index] = val_1;
    }
    public void Save()
    {
        System.Exception val_2 = Kayac.WeakEncrypter.Save<SaveData>(obj:  this, key:  "suOzGRkAIxk0", path:  Kayac.SaveDataPathUtil.MakeFullPath(relativePath:  "savedata.bin"));
        if(val_2 == null)
        {
                return;
        }
        
        UnityEngine.Debug.LogError(message:  val_2.GetType() + " " + val_2);
    }
    public static SaveData Load()
    {
        SaveData val_7;
        System.Exception val_3 = Kayac.WeakEncrypter.Load<SaveData>(key:  "suOzGRkAIxk0", path:  Kayac.SaveDataPathUtil.MakeFullPath(relativePath:  "savedata.bin"), objOut: out  0);
        if(val_3 != null)
        {
                UnityEngine.Debug.LogError(message:  val_3.GetType() + " " + val_3);
            SaveData val_6 = null;
            val_7 = val_6;
            ._isVibration = true;
            val_6 = new SaveData();
            return val_7;
        }
        
        val_7 = val_7;
        return val_7;
    }
    public static void Delete()
    {
        System.IO.File.Delete(path:  Kayac.SaveDataPathUtil.MakeFullPath(relativePath:  "savedata.bin"));
    }
    public void GetAllGuns()
    {
        State[] val_1;
        val_1 = this._skinStates;
        var val_1 = 0;
        label_3:
        if(val_1 >= (this._skinStates.Length << ))
        {
            goto label_1;
        }
        
        val_1[0] = 2;
        val_1 = this._skinStates;
        val_1 = val_1 + 1;
        if(val_1 != null)
        {
            goto label_3;
        }
        
        throw new NullReferenceException();
        label_1:
        val_1[0] = 1;
    }
    public SaveData()
    {
        this._isVibration = true;
    }

}
