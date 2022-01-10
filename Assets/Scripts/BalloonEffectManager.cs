using UnityEngine;
public class BalloonEffectManager
{
    // Fields
    private BalloonFX _balloonFX;
    private System.Collections.Generic.List<BalloonFX> _balloonFxes;
    private static BalloonEffectManager <instance>k__BackingField;
    
    // Properties
    public static BalloonEffectManager instance { get; set; }
    
    // Methods
    public static BalloonEffectManager get_instance()
    {
        return (BalloonEffectManager)BalloonEffectManager.<instance>k__BackingField;
    }
    private static void set_instance(BalloonEffectManager value)
    {
        BalloonEffectManager.<instance>k__BackingField = value;
    }
    private BalloonEffectManager()
    {
        this._balloonFxes = new System.Collections.Generic.List<BalloonFX>();
        this._balloonFX = UnityEngine.Resources.Load<BalloonFX>(path:  "Prefabs/BalloonPop");
    }
    private static void BeforeSceneLoad()
    {
        BalloonEffectManager.TryCreateInstance();
    }
    private static void TryCreateInstance()
    {
        BalloonEffectManager val_2;
        if((BalloonEffectManager.<instance>k__BackingField) != null)
        {
                return;
        }
        
        BalloonEffectManager val_1 = null;
        val_2 = val_1;
        val_1 = new BalloonEffectManager();
        BalloonEffectManager.<instance>k__BackingField = val_2;
    }
    public void Play(UnityEngine.Vector3 position, UnityEngine.Color color, bool withConfetti)
    {
        BalloonFX val_1 = this.GetFX();
        withConfetti = withConfetti;
        val_1._confettiGameObject.SetActive(value:  withConfetti);
        val_1.SetColor(color:  new UnityEngine.Color() {r = color.r, g = color.g, b = color.b, a = color.a});
        val_1.gameObject.SetActive(value:  true);
        val_1.transform.position = new UnityEngine.Vector3() {x = position.x, y = position.y, z = position.z};
    }
    private BalloonFX GetFX()
    {
        BalloonFX val_4;
        List.Enumerator<T> val_1 = this._balloonFxes.GetEnumerator();
        label_4:
        if(((-1550617176) & 1) == 0)
        {
            goto label_2;
        }
        
        val_4 = 0;
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_4.CanUse == false)
        {
            goto label_4;
        }
        
        UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
        return val_4;
        label_2:
        UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
        val_4 = UnityEngine.Object.Instantiate<BalloonFX>(original:  this._balloonFX, parent:  0);
        this._balloonFxes.Add(item:  val_4);
        return val_4;
    }

}
