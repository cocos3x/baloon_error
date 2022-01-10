using UnityEngine;
public class FPSCounter : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text _fpsText;
    private float _frameTimeAvg;
    private float _frameTimeSpike;
    
    // Methods
    public void Init()
    {
        this.SetFpsViewEnabled(enable:  false);
    }
    private void Update()
    {
        this.UpdateFpsView();
    }
    public void SetFpsViewEnabled(bool enable)
    {
        if(this._fpsText == 0)
        {
                return;
        }
        
        this._fpsText.enabled = enable;
    }
    private void UpdateFpsView()
    {
        if(this._fpsText == 0)
        {
                return;
        }
        
        if(this._fpsText.enabled == false)
        {
                return;
        }
        
        float val_3 = UnityEngine.Time.unscaledDeltaTime;
        this._frameTimeAvg = UnityEngine.Mathf.Lerp(a:  this._frameTimeAvg, b:  val_3, t:  0.05f);
        float val_5 = UnityEngine.Mathf.Lerp(a:  this._frameTimeSpike, b:  val_3, t:  0.05f);
        float val_9 = this._frameTimeAvg;
        this._frameTimeSpike = val_5;
        val_9 = 1f / val_9;
        val_5 = 1f / val_5;
        this = this._fpsText;
        string val_8 = System.String.Format(format:  "AVG  : {0}\nSpike: {1}", arg0:  val_9.ToString(format:  "F1"), arg1:  val_5.ToString(format:  "F1"));
    }
    public FPSCounter()
    {
    
    }

}
