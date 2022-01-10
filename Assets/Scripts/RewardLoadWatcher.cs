using UnityEngine;
public class RewardLoadWatcher : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button _button;
    private UnityEngine.EventSystems.EventTrigger _eventTrigger;
    private UnityEngine.RectTransform _grayOutTransform;
    private UnityEngine.RectTransform _loadImageTransform;
    private UnityEngine.RectTransform[] _ottherTransform;
    
    // Methods
    private void Awake()
    {
        DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions> val_4 = DG.Tweening.TweenSettingsExtensions.SetRelative<DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>>(t:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>>(t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  this._loadImageTransform, endValue:  new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, duration:  2f, mode:  0), ease:  1), loops:  0), isRelative:  true);
    }
    private void Update()
    {
        this.SetState(b:  RewardedReady);
    }
    private void SetState(bool b)
    {
        bool val_12 = b;
        if(this._button != 0)
        {
                this._button.enabled = val_12;
        }
        
        if(this._eventTrigger != 0)
        {
                this._eventTrigger.enabled = val_12;
        }
        
        if((this._ottherTransform.Length != 0) && (this._ottherTransform.Length >= 1))
        {
                var val_11 = 0;
            do
        {
            1152921505922835088.gameObject.SetActive(value:  val_12);
            val_11 = val_11 + 1;
        }
        while(val_11 < this._ottherTransform.Length);
        
        }
        
        val_12 = val_12 ^ 1;
        this._grayOutTransform.gameObject.SetActive(value:  val_12);
        this._loadImageTransform.gameObject.SetActive(value:  val_12);
    }
    public RewardLoadWatcher()
    {
    
    }

}
