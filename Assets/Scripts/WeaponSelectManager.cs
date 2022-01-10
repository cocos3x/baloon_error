using UnityEngine;
public class WeaponSelectManager : MonoBehaviour
{
    // Fields
    private UnityEngine.Transform _scrollContentTransform;
    private UnityEngine.RectTransform _menuRectTransform;
    private UnityEngine.GameObject _closeAreaGameObject;
    private UnityEngine.UI.Button _closeArea;
    private UnityEngine.UI.Button _closeButton;
    private UnityEngine.UI.Image _patternImage;
    private System.Collections.Generic.List<WeaponButton> _skinButtons;
    private UnityEngine.Sprite[] _skinIcons;
    private CoreServices _core;
    private bool _isTransitioning;
    private System.Action _onClose;
    private static readonly int _tiling;
    private bool _initilized;
    
    // Methods
    public void Init(System.Action onClose)
    {
        var val_6;
        System.Collections.Generic.List<WeaponButton> val_7;
        var val_8;
        if(this._initilized == true)
        {
                return;
        }
        
        this._closeAreaGameObject.SetActive(value:  false);
        this._onClose = onClose;
        val_7 = this._skinButtons;
        this._core = CoreServices.<instance>k__BackingField;
        if((CoreServices.<instance>k__BackingField) == null)
        {
                UnityEngine.Events.UnityAction val_1 = null;
            val_8 = 1152921507410164464;
            val_1 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WeaponSelectManager::OnClickClose());
            this._closeButton.m_OnClick.AddListener(call:  val_1);
            this._closeArea.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WeaponSelectManager::OnClickClose()));
            this._skinIcons = this._closeArea.m_OnClick.GetSkinImages();
            if(this._skinIcons.Length >= 1)
        {
                do
        {
            this._skinButtons.Add(item:  UnityEngine.Object.Instantiate<WeaponButton>(original:  UnityEngine.Resources.Load<WeaponButton>(path:  "Prefabs/WeaponButton"), parent:  this._scrollContentTransform));
            val_8 = 0 + 1;
        }
        while(val_8 < this._skinIcons.Length);
        
        }
        
            val_7 = this._skinButtons;
        }
        
        val_6 = 4;
        label_24:
        int val_6 = val_6 - 4;
        if(val_6 >= this._skinIcons.Length)
        {
            goto label_18;
        }
        
        if(this._skinIcons.Length <= val_6)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this._skinIcons.Length + 32.Init(id:  val_6, saveData:  this._core.<saveData>k__BackingField, manager:  this, icon:  this._skinIcons[0]);
        val_6 = val_6 + 1;
        if(this._skinButtons != null)
        {
            goto label_24;
        }
        
        throw new NullReferenceException();
        label_18:
        this.AllButtonUpdateState();
        this._initilized = true;
    }
    public void OnClickButton()
    {
        Sound.Play(self:  3);
        this.AllButtonUpdateState();
    }
    private void AllButtonUpdateState()
    {
        List.Enumerator<T> val_1 = this._skinButtons.GetEnumerator();
        label_4:
        if(((-1491058424) & 1) == 0)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        0.UpdateState();
        goto label_4;
        label_2:
        UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
    }
    public void Show()
    {
        this.gameObject.SetActive(value:  true);
        this.AllButtonUpdateState();
        if(this._isTransitioning == true)
        {
                return;
        }
        
        Sound.Play(self:  3);
        UnityEngine.Time.timeScale = 0f;
        this._isTransitioning = true;
        int val_2 = UnityEngine.Screen.height;
        this._menuRectTransform.localPosition = new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f};
        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> val_6 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>>(t:  DG.Tweening.TweenSettingsExtensions.SetUpdate<DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>>(t:  DG.Tweening.DOTweenModuleUI.DOAnchorPosY(target:  this._menuRectTransform, endValue:  0f, duration:  0.3f, snapping:  false), isIndependentUpdate:  true), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WeaponSelectManager::<Show>b__16_0()));
    }
    private void OnClickClose()
    {
        if(this._isTransitioning != false)
        {
                return;
        }
        
        Sound.Play(self:  3);
        if(this._onClose != null)
        {
                this._onClose.Invoke();
        }
        
        UnityEngine.Time.timeScale = 1f;
        this._core.<saveData>k__BackingField.Save();
        this._closeAreaGameObject.SetActive(value:  false);
        DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> val_3 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>>(t:  DG.Tweening.DOTweenModuleUI.DOAnchorPosY(target:  this._menuRectTransform, endValue:  -500f, duration:  0.3f, snapping:  false), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WeaponSelectManager::<OnClickClose>b__17_0()));
    }
    private UnityEngine.Sprite[] GetSkinImages()
    {
        return UnityEngine.Resources.LoadAll<UnityEngine.Sprite>(path:  "SkinIcons");
    }
    private void Update()
    {
        var val_3;
        if(UnityEngine.Time.timeScale != 0f)
        {
                return;
        }
        
        val_3 = null;
        val_3 = null;
        this._patternImage.SetFloat(nameID:  WeaponSelectManager._tiling, value:  UnityEngine.Time.unscaledTime);
    }
    public WeaponSelectManager()
    {
        this._skinButtons = new System.Collections.Generic.List<WeaponButton>();
    }
    private static WeaponSelectManager()
    {
        WeaponSelectManager._tiling = UnityEngine.Shader.PropertyToID(name:  "ScrollSpeed");
    }
    private void <Show>b__16_0()
    {
        this._isTransitioning = false;
        if(this._closeAreaGameObject != null)
        {
                this._closeAreaGameObject.SetActive(value:  true);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void <OnClickClose>b__17_0()
    {
        this._isTransitioning = false;
        this.gameObject.SetActive(value:  false);
    }

}
