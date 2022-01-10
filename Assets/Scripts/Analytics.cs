using UnityEngine;
public class Analytics
{
    // Fields
    private float _levelFrameTimeSum;
    private Kayac.FirebaseWrapper _firebase;
    
    // Methods
    public void Update()
    {
        float val_1 = UnityEngine.Time.unscaledDeltaTime;
        val_1 = this._levelFrameTimeSum + val_1;
        this._levelFrameTimeSum = val_1;
    }
    public Analytics(Kayac.FirebaseWrapper firebase)
    {
        this._firebase = firebase;
    }
    public void OnLevelStart(int levelIndex)
    {
        Param[] val_1 = new Param[1];
        val_1[0] = 0;
        val_1[2] = 0;
        this._firebase.AddEvent(eventType:  1, parameters:  val_1);
        UnityEngine.Debug.Log(message:  "FirebaseEvent levelStart: index="("FirebaseEvent levelStart: index=") + levelIndex);
        this._levelFrameTimeSum = 0f;
    }
    public void OnLevelFailed(int levelIndex)
    {
        Param[] val_1 = new Param[1];
        val_1[0] = 0;
        val_1[2] = 0;
        this._firebase.AddEvent(customEventName:  "ky_level_failed", parameters:  val_1);
        UnityEngine.Debug.Log(message:  "FirebaseEvent LevelFailed: index="("FirebaseEvent LevelFailed: index=") + levelIndex);
    }
    public void OnLevelEnd(int levelIndex, float fps, string levelName)
    {
        int val_7;
        int val_8;
        fps = fps * 1000f;
        int val_1 = UnityEngine.Mathf.RoundToInt(f:  fps);
        Param[] val_2 = new Param[5];
        val_2[0] = 0;
        val_2[2] = 0;
        val_2[4] = 0;
        val_2[6] = 0;
        double val_3 = SaveData.__il2cppRuntimeField_byval_arg * 1000;
        val_2[8] = 0;
        val_2[10] = 0;
        val_2[12] = 0;
        val_2[14] = 0;
        val_2[16] = 0;
        val_2[18] = 0;
        this._firebase.AddEvent(eventType:  2, parameters:  val_2);
        object[] val_5 = new object[8];
        val_5[0] = "FirebaseEvent levelEnd: index=";
        val_7 = val_5.Length;
        val_5[1] = levelIndex;
        val_7 = val_5.Length;
        val_5[2] = "LevelName:";
        if(levelName != null)
        {
                val_7 = val_5.Length;
        }
        
        val_5[3] = levelName;
        val_7 = val_5.Length;
        val_5[4] = " fps:";
        val_8 = val_5.Length;
        val_5[5] = fps;
        val_8 = val_5.Length;
        val_5[6] = "level_timeMs: ";
        val_5[7] = (int)this._levelFrameTimeSum * 1000f;
        UnityEngine.Debug.Log(message:  +val_5);
    }
    public void OnAdRevenue(string placement, double value)
    {
        float val_2;
        float val_7;
        double val_8;
        double val_7 = value;
        val_7 = (val_7 * 1000) * 1000;
        if(val_7 >= 0f)
        {
            goto label_3;
        }
        
        if(val_7 != (-0.5))
        {
            goto label_4;
        }
        
        val_7 = val_2;
        val_8 = -1;
        goto label_5;
        label_3:
        if(val_7 != 0.5)
        {
            goto label_6;
        }
        
        val_7 = val_2;
        val_8 = 1;
        label_5:
        val_8 = val_7 + val_8;
        var val_3 = (((long)val_7 & 1) != 0) ? (val_7) : (val_8);
        goto label_8;
        label_4:
        double val_4 = val_7 + (-0.5);
        goto label_8;
        label_6:
        double val_5 = val_7 + 0.5;
        label_8:
        Param[] val_6 = new Param[2];
        val_2 = 0;
        val_6[0] = val_2;
        val_6[2] = 0;
        val_6[4] = 0;
        val_6[6] = 0;
        this._firebase.AddEvent(customEventName:  "ky_ad_revenue", parameters:  val_6);
    }
    public void OnAdComplete(string placement)
    {
        Param[] val_1 = new Param[1];
        val_1[0] = 0;
        val_1[2] = 0;
        this._firebase.AddEvent(customEventName:  "ad_complete", parameters:  val_1);
    }
    public void OnRequestStoreReview()
    {
        var val_1 = mem[public static T[] System.Array::Empty<Param>().__il2cppRuntimeField_30 + 302];
        val_1 = public static T[] System.Array::Empty<Param>().__il2cppRuntimeField_30 + 302;
        val_1 = mem[public static T[] System.Array::Empty<Param>().__il2cppRuntimeField_30 + 302];
        val_1 = public static T[] System.Array::Empty<Param>().__il2cppRuntimeField_30 + 302;
        this._firebase.AddEvent(customEventName:  "ky_store_review", parameters:  public static T[] System.Array::Empty<Param>().__il2cppRuntimeField_30 + 184);
    }
    public void OnAcceptGdpr()
    {
        var val_1 = mem[public static T[] System.Array::Empty<Param>().__il2cppRuntimeField_30 + 302];
        val_1 = public static T[] System.Array::Empty<Param>().__il2cppRuntimeField_30 + 302;
        val_1 = mem[public static T[] System.Array::Empty<Param>().__il2cppRuntimeField_30 + 302];
        val_1 = public static T[] System.Array::Empty<Param>().__il2cppRuntimeField_30 + 302;
        this._firebase.AddEvent(customEventName:  "gdpr_accept", parameters:  public static T[] System.Array::Empty<Param>().__il2cppRuntimeField_30 + 184);
    }

}
