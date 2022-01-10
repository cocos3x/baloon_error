using UnityEngine;

namespace Kayac.HyperCasual
{
    public static class Util
    {
        // Methods
        public static void SetAlpha(UnityEngine.UI.Graphic self, float a)
        {
            goto typeof(UnityEngine.UI.Graphic).__il2cppRuntimeField_2A0;
        }
        public static void SetAlpha(UnityEngine.SpriteRenderer self, float a)
        {
            UnityEngine.Color val_1 = self.color;
            self.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = a};
        }
        public static void ChangeLayerWithChildren(UnityEngine.GameObject self, int layer)
        {
            int val_7;
            var val_8;
            var val_11;
            val_7 = layer;
            if(self == null)
            {
                    throw new NullReferenceException();
            }
            
            self.layer = val_7;
            UnityEngine.Transform val_1 = self.transform;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_8 = val_1.GetEnumerator();
            label_17:
            var val_8 = 0;
            val_8 = val_8 + 1;
            if(val_8.MoveNext() == false)
            {
                goto label_8;
            }
            
            var val_9 = 0;
            val_9 = val_9 + 1;
            object val_6 = val_8.Current;
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.GameObject val_7 = val_6.gameObject;
            goto label_17;
            label_8:
            val_7 = 0;
            if(X0 == false)
            {
                goto label_18;
            }
            
            var val_12 = X0;
            val_8 = X0;
            if((X0 + 294) == 0)
            {
                goto label_22;
            }
            
            var val_10 = X0 + 176;
            var val_11 = 0;
            val_10 = val_10 + 8;
            label_21:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_20;
            }
            
            val_11 = val_11 + 1;
            val_10 = val_10 + 16;
            if(val_11 < (X0 + 294))
            {
                goto label_21;
            }
            
            goto label_22;
            label_20:
            val_12 = val_12 + (((X0 + 176 + 8)) << 4);
            val_11 = val_12 + 304;
            label_22:
            val_8.Dispose();
            label_18:
            if(val_7 != 0)
            {
                    throw val_7;
            }
        
        }
        public static void Kill(ref DG.Tweening.Tweener tweener)
        {
            if(tweener != null)
            {
                    if((DG.Tweening.TweenExtensions.IsPlaying(t:  tweener)) != false)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  tweener, complete:  false);
            }
            
            }
            
            tweener = 0;
        }
        public static void Kill(ref DG.Tweening.Sequence seq)
        {
            if(seq != null)
            {
                    if((DG.Tweening.TweenExtensions.IsPlaying(t:  seq)) != false)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  seq, complete:  false);
            }
            
            }
            
            seq = 0;
        }
        public static DG.Tweening.Sequence KillAndNew(ref DG.Tweening.Sequence seq)
        {
            if(seq != null)
            {
                    if((DG.Tweening.TweenExtensions.IsPlaying(t:  seq)) != false)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  seq, complete:  false);
            }
            
            }
            
            DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
            seq = val_2;
            return val_2;
        }
        public static DG.Tweening.Tweener DOEmmison(UnityEngine.Material self, UnityEngine.Color color, float duration)
        {
            Util.<>c__DisplayClass6_0 val_1 = new Util.<>c__DisplayClass6_0();
            .self = self;
            UnityEngine.Color val_2 = Kayac.HyperCasual.Util.GetEmmisionColor(self:  self);
            .c = val_2;
            mem[1152921507476940020] = val_2.g;
            mem[1152921507476940024] = val_2.b;
            mem[1152921507476940028] = val_2.a;
            return DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Core.TweenerCore<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<UnityEngine.Color>(object:  val_1, method:  UnityEngine.Color Util.<>c__DisplayClass6_0::<DOEmmison>b__0()), setter:  new DG.Tweening.Core.DOSetter<UnityEngine.Color>(object:  val_1, method:  System.Void Util.<>c__DisplayClass6_0::<DOEmmison>b__1(UnityEngine.Color v)), endValue:  new UnityEngine.Color() {r = color.r, g = color.g, b = color.b, a = color.a}, duration:  duration), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void Util.<>c__DisplayClass6_0::<DOEmmison>b__2()));
        }
        public static UnityEngine.Color GetEmmisionColor(UnityEngine.Material self)
        {
            return self.GetColor(name:  "_EmissionColor");
        }
        public static void SetEmmisionColor(UnityEngine.Material self, UnityEngine.Color color)
        {
            self.SetColor(name:  "_EmissionColor", value:  new UnityEngine.Color() {r = color.r, g = color.g, b = color.b, a = color.a});
        }
    
    }

}
