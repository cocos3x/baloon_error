using UnityEngine;
public static class TweenUtils
{
    // Methods
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
        TweenUtils.<>c__DisplayClass3_0 val_1 = new TweenUtils.<>c__DisplayClass3_0();
        .self = self;
        UnityEngine.Color val_2 = TweenUtils.GetEmmisionColor(self:  self);
        .c = val_2;
        mem[1152921507363479428] = val_2.g;
        mem[1152921507363479432] = val_2.b;
        mem[1152921507363479436] = val_2.a;
        return DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Core.TweenerCore<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<UnityEngine.Color>(object:  val_1, method:  UnityEngine.Color TweenUtils.<>c__DisplayClass3_0::<DOEmmison>b__0()), setter:  new DG.Tweening.Core.DOSetter<UnityEngine.Color>(object:  val_1, method:  System.Void TweenUtils.<>c__DisplayClass3_0::<DOEmmison>b__1(UnityEngine.Color v)), endValue:  new UnityEngine.Color() {r = color.r, g = color.g, b = color.b, a = color.a}, duration:  duration), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void TweenUtils.<>c__DisplayClass3_0::<DOEmmison>b__2()));
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
