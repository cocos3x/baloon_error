using UnityEngine;
[Serializable]
public class Gun
{
    // Fields
    public string name;
    public Sound.Se fireSe;
    public bool rapidFire;
    public int burst;
    public float fireInterval;
    public GunManager.ShootType shootType;
    public int bulletNum;
    public int diffusivity;
    public bool explosion;
    
    // Methods
    public Gun()
    {
    
    }

}
