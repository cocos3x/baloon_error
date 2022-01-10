using UnityEngine;
public class RewardOverRay : MonoBehaviour
{
    // Fields
    private UnityEngine.Transform _rewardRoot;
    private UnityEngine.GameObject _openedRoot;
    private UnityEngine.Transform _itemRoot;
    private UnityEngine.SpriteRenderer _shine1;
    private UnityEngine.SpriteRenderer _shine2;
    private UnityEngine.SpriteRenderer _flash;
    private UnityEngine.GameObject _newWeapon;
    private UnityEngine.GameObject _rewardSelect;
    private UnityEngine.SpriteRenderer[] _backgrounds;
    private UnityEngine.UI.Graphic _claimButton;
    private UnityEngine.UI.Graphic _declineButton;
    private UnityEngine.UI.Button _claim;
    private UnityEngine.UI.Button _decline;
    private UnityEngine.Camera _overayCamera;
    private UnityEngine.GameObject _yellowBanner;
    private UnityEngine.GameObject _blueBanner;
    private UnityEngine.Transform _rewardTransform;
    private UnityEngine.Transform _shineRoot;
    private RewardOverRay.ClaimDelegete _onClaim;
    private RewardOverRay.DeclineDelegate _onDecline;
    private RewardOverRay.CompleteDelegate _onComplete;
    private RewardOverRay.State _state;
    private UnityEngine.GameObject _item;
    public RewardOverRay.SeDelegate onOpenedItemSe;
    
    // Methods
    private void Awake()
    {
        UnityEngine.Rendering.Universal.CameraExtensions.GetUniversalAdditionalCameraData(camera:  UnityEngine.Camera.main).cameraStack.Add(item:  this._overayCamera);
    }
    private void Format()
    {
        this._state = 0;
        this.ClearItem();
        this.gameObject.SetActive(value:  false);
        if(this._backgrounds.Length >= 1)
        {
                var val_14 = 0;
            do
        {
            this._backgrounds[val_14].gameObject.SetActive(value:  false);
            val_14 = val_14 + 1;
        }
        while(val_14 < this._backgrounds.Length);
        
        }
        
        this._rewardRoot.gameObject.SetActive(value:  false);
        this._openedRoot.gameObject.SetActive(value:  false);
        this._openedRoot.SetActive(value:  false);
        this._itemRoot.gameObject.SetActive(value:  false);
        int val_7 = DG.Tweening.ShortcutExtensions.DOKill(target:  this._shine1.transform, complete:  false);
        this._shine1.gameObject.SetActive(value:  false);
        this._shine2.gameObject.SetActive(value:  false);
        this._flash.gameObject.SetActive(value:  false);
        this._claimButton.gameObject.SetActive(value:  false);
        this._declineButton.gameObject.SetActive(value:  false);
        this._newWeapon.SetActive(value:  false);
        this._rewardSelect.SetActive(value:  false);
    }
    public void PrepareByOpenedItem()
    {
        this.Format();
    }
    public UnityEngine.Coroutine Play(RewardOverRay.ClaimDelegete onClaim, RewardOverRay.DeclineDelegate onDecline, RewardOverRay.CompleteDelegate onComplete)
    {
        this._onClaim = onClaim;
        this._onDecline = onDecline;
        this._onComplete = onComplete;
        this._claim.m_OnClick.RemoveAllListeners();
        this._decline.m_OnClick.RemoveAllListeners();
        this._claim.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void RewardOverRay::OnClickClaim()));
        this._decline.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void RewardOverRay::OnClickDecline()));
        this.gameObject.SetActive(value:  true);
        return this.StartCoroutine(routine:  this.CoPlay());
    }
    private System.Collections.IEnumerator CoPlay()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new RewardOverRay.<CoPlay>d__33();
    }
    private void ShowRewardObject()
    {
        this._rewardRoot.gameObject.SetActive(value:  true);
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        this._rewardRoot.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> val_4 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this._rewardRoot, endValue:  1f, duration:  0.35f), ease:  27);
        this._shine1.gameObject.SetActive(value:  true);
        this._shine2.gameObject.SetActive(value:  true);
        Kayac.HyperCasual.Util.SetAlpha(self:  this._shine1, a:  0f);
        Kayac.HyperCasual.Util.SetAlpha(self:  this._shine2, a:  0f);
        DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions> val_11 = DG.Tweening.TweenSettingsExtensions.SetRelative<DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>>(t:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>>(t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  this._shine1.transform, endValue:  new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, duration:  11f, mode:  0), ease:  1), loops:  0), isRelative:  true);
        DG.Tweening.Core.TweenerCore<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions> val_12 = DG.Tweening.DOTweenModuleSprite.DOFade(target:  this._shine1, endValue:  0.5f, duration:  0.5f);
        DG.Tweening.Core.TweenerCore<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions> val_13 = DG.Tweening.DOTweenModuleSprite.DOFade(target:  this._shine2, endValue:  0.5f, duration:  0.5f);
        DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions> val_17 = DG.Tweening.TweenSettingsExtensions.SetRelative<DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>>(t:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>>(t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  this._rewardRoot, endValue:  new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f}, duration:  1.5f, mode:  0), ease:  7), loops:  0, loopType:  1), isRelative:  true);
        UnityEngine.Vector3[] val_18 = new UnityEngine.Vector3[2];
        UnityEngine.Vector3 val_19 = UnityEngine.Vector3.up;
        UnityEngine.Vector3 val_20 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z}, d:  0.05f);
        val_18[0] = val_20;
        val_18[0] = val_20.y;
        val_18[1] = val_20.z;
        UnityEngine.Vector3 val_21 = UnityEngine.Vector3.zero;
        val_18[1] = val_21;
        val_18[2] = val_21.y;
        val_18[2] = val_21.z;
        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> val_24 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>(t:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>(t:  DG.Tweening.ShortcutExtensions.DOLocalPath(target:  this._rewardRoot, path:  val_18, duration:  1.2f, pathType:  0, pathMode:  1, resolution:  10, gizmoColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}), loops:  0, loopType:  1), ease:  7);
    }
    public void SetReward(UnityEngine.GameObject prefab)
    {
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.one;
        this.SetReward(prefab:  prefab, offsetPosition:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, rotation:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, scale:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.z, z = ???});
    }
    private void SetReward(UnityEngine.GameObject prefab, UnityEngine.Vector3 offsetPosition, UnityEngine.Vector3 rotation, UnityEngine.Vector3 scale)
    {
        float val_1;
        this.ClearItem();
        this._item = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  prefab, parent:  this._itemRoot);
        this._itemRoot.gameObject.SetActive(value:  true);
        Kayac.HyperCasual.Util.ChangeLayerWithChildren(self:  this._item, layer:  this._itemRoot.gameObject.layer);
        this._item.transform.localPosition = new UnityEngine.Vector3() {x = offsetPosition.x, y = offsetPosition.y, z = offsetPosition.z};
        UnityEngine.Quaternion val_8 = UnityEngine.Quaternion.Euler(euler:  new UnityEngine.Vector3() {x = rotation.x, y = rotation.y, z = rotation.z});
        this._item.transform.localRotation = new UnityEngine.Quaternion() {x = val_8.x, y = val_8.y, z = val_8.z, w = val_8.w};
        this._item.transform.localScale = new UnityEngine.Vector3() {x = scale.x, y = val_1, z = scale.y};
    }
    public void Claim()
    {
        this._state = 3;
    }
    private void Decline()
    {
        this._state = 4;
    }
    public void OnClickClaim()
    {
        if(this._state != 2)
        {
                return;
        }
        
        if(this._onClaim == null)
        {
                return;
        }
        
        this._onClaim.Invoke();
    }
    public void OnClickDecline()
    {
        if(this._state != 2)
        {
                return;
        }
        
        if(this._onDecline != null)
        {
                this._onDecline.Invoke();
        }
        
        this._state = 4;
    }
    private void ClearItem()
    {
        if(this._item == 0)
        {
                return;
        }
        
        this._item = 0;
        UnityEngine.Object.Destroy(obj:  this._item);
    }
    public RewardOverRay()
    {
    
    }

}
