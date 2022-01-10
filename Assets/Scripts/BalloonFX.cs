using UnityEngine;
public class BalloonFX : MonoBehaviour
{
    // Fields
    private UnityEngine.ParticleSystem[] _particleSystems;
    private UnityEngine.GameObject _confettiGameObject;
    
    // Properties
    public bool CanUse { get; }
    
    // Methods
    public bool get_CanUse()
    {
        bool val_2 = this.gameObject.activeSelf;
        val_2 = (~val_2) & 1;
        return (bool)val_2;
    }
    public void SetConfetti(bool withConfetti)
    {
        if(this._confettiGameObject != null)
        {
                this._confettiGameObject.SetActive(value:  withConfetti);
            return;
        }
        
        throw new NullReferenceException();
    }
    public void SetColor(UnityEngine.Color color)
    {
        if(this._particleSystems.Length < 1)
        {
                return;
        }
        
        var val_8 = 0;
        do
        {
            MainModule val_1 = this._particleSystems[val_8].main;
            MinMaxGradient val_2 = ParticleSystem.MinMaxGradient.op_Implicit(color:  new UnityEngine.Color() {r = color.r, g = color.g, b = color.b, a = color.a});
            val_8 = val_8 + 1;
        }
        while(val_8 < this._particleSystems.Length);
    
    }
    public BalloonFX()
    {
    
    }

}
