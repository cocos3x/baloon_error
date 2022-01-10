using UnityEngine;

namespace Kayac.UI
{
    public class ButtonPressAnimation : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerExitHandler, IPointerUpHandler
    {
        // Fields
        private UnityEngine.RectTransform _root;
        private float _pressY;
        private DG.Tweening.Tweener _tweener;
        private UnityEngine.Vector3 _baseAnchorPosition;
        
        // Methods
        private void Awake()
        {
            UnityEngine.Vector2 val_1 = this._root.anchoredPosition;
            UnityEngine.Vector3 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y});
            this._baseAnchorPosition = val_2;
            mem[1152921507474868628] = val_2.y;
            mem[1152921507474868632] = val_2.z;
        }
        private void OnEnable()
        {
            UnityEngine.Vector2 val_1 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = this._baseAnchorPosition, y = V8.16B, z = V9.16B});
            this._root.anchoredPosition = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
        }
        public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this.KillTween();
            this._tweener = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>>(t:  DG.Tweening.DOTweenModuleUI.DOAnchorPosY(target:  this._root, endValue:  this._pressY, duration:  0.05f, snapping:  false), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void Kayac.UI.ButtonPressAnimation::<OnPointerDown>b__6_0()));
        }
        public void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this.Release();
        }
        public void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this.Release();
        }
        private void Release()
        {
            this.KillTween();
            this._tweener = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>>(t:  DG.Tweening.DOTweenModuleUI.DOAnchorPosY(target:  this._root, endValue:  0f, duration:  0.25f, snapping:  false), ease:  30), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void Kayac.UI.ButtonPressAnimation::<Release>b__9_0()));
        }
        private void KillTween()
        {
            if(this._tweener != null)
            {
                    if((DG.Tweening.TweenExtensions.IsPlaying(t:  this._tweener)) != false)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this._tweener, complete:  false);
            }
            
            }
            
            this._tweener = 0;
        }
        public ButtonPressAnimation()
        {
            this._pressY = -15f;
            UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
            this._baseAnchorPosition = val_1;
            mem[1152921507475782676] = val_1.y;
            mem[1152921507475782680] = val_1.z;
        }
        private void <OnPointerDown>b__6_0()
        {
            this._tweener = 0;
        }
        private void <Release>b__9_0()
        {
            this._tweener = 0;
        }
    
    }

}
