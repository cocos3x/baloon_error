using UnityEngine;
[Serializable]
public class projectileActor.projectile
{
    // Fields
    public string name;
    public UnityEngine.Rigidbody bombPrefab;
    public UnityEngine.GameObject muzzleflare;
    public float min;
    public float max;
    public bool rapidFire;
    public float rapidFireCooldown;
    public bool shotgunBehavior;
    public int shotgunPellets;
    public UnityEngine.GameObject shellPrefab;
    public bool hasShells;
    
    // Methods
    public projectileActor.projectile()
    {
    
    }

}
