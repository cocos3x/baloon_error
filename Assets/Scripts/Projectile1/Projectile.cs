using UnityEngine;
public class Projectile : MonoBehaviour
{
    // Fields
    private float disappearAfterTime;
    private float disappearTimer;
    private bool isActive;
    private UnityEngine.Vector3 direction;
    private UnityEngine.Vector3 startPosition;
    private float movementSpeed;
    private UnityEngine.Vector3 targetPosition;
    private float distanceToTarget;
    private float movementValue;
    
    // Methods
    private void Start()
    {
    
    }
    private void Update()
    {
        if(this.isActive == false)
        {
                return;
        }
        
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = this.disappearTimer + val_1;
        this.disappearTimer = val_1;
        if(val_1 > this.disappearAfterTime)
        {
                this.disappearTimer = 0f;
            this.isActive = false;
        }
        
        float val_2 = UnityEngine.Time.deltaTime;
        float val_3 = 1f / this.distanceToTarget;
        val_3 = val_3 * this.movementSpeed;
        val_2 = val_3 * val_2;
        val_2 = this.movementValue + val_2;
        this.movementValue = val_2;
        if(val_2 > 1f)
        {
                this.disappearTimer = 0f;
            this.movementValue = 1f;
            this.isActive = false;
        }
        
        this.Move();
    }
    private void Move()
    {
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = this.startPosition, y = V9.16B, z = V10.16B}, b:  new UnityEngine.Vector3() {x = this.targetPosition, y = V13.16B, z = V11.16B}, t:  this.movementValue);
        this.transform.position = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
    }
    private void MoveWithoutTargetHit()
    {
        UnityEngine.Transform val_1 = this.transform;
        UnityEngine.Vector3 val_2 = val_1.position;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, d:  this.movementSpeed);
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, b:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
        val_1.position = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
    }
    public void Fire(UnityEngine.Vector3 target, UnityEngine.Vector3 spawnPosition, UnityEngine.Vector3 Direction, float speed)
    {
        float val_5 = spawnPosition.z;
        if(this.isActive == true)
        {
                return;
        }
        
        this.isActive = true;
        this.disappearTimer = 0f;
        this.transform.position = new UnityEngine.Vector3() {x = spawnPosition.x, y = spawnPosition.y, z = val_5};
        this.movementSpeed = Direction.z;
        this.direction = spawnPosition;
        mem[1152921507346710472] = spawnPosition.y;
        mem[1152921507346710476] = val_5;
        this.targetPosition = target;
        mem[1152921507346710500] = target.y;
        mem[1152921507346710504] = target.z;
        UnityEngine.Vector3 val_3 = this.transform.position;
        val_5 = val_3.x;
        this.startPosition = spawnPosition;
        mem[1152921507346710484] = spawnPosition.y;
        this.distanceToTarget = UnityEngine.Vector3.Distance(a:  new UnityEngine.Vector3() {x = target.x, y = target.y, z = target.z}, b:  new UnityEngine.Vector3() {x = val_5, y = val_3.y, z = val_3.z});
        this.movementValue = 0f;
        mem[1152921507346710488] = val_5;
    }
    private void Explode()
    {
        this.disappearTimer = 0f;
        this.isActive = false;
    }
    public bool GetIsActive()
    {
        return (bool)this.isActive;
    }
    public Projectile()
    {
        this.disappearAfterTime = 3f;
        this.movementSpeed = 1f;
    }

}
