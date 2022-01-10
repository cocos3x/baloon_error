using UnityEngine;
public class destroyMe : MonoBehaviour
{
    // Fields
    private float timer;
    public float deathtimer;
    
    // Methods
    private void Start()
    {
    
    }
    private void Update()
    {
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = this.timer + val_1;
        this.timer = val_1;
        if(val_1 < this.deathtimer)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    public destroyMe()
    {
        this.deathtimer = 10f;
    }

}
