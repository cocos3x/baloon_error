using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    // Fields
    private System.Collections.Generic.List<Enemy> _enemies;
    private Level _level;
    private bool _isBoss;
    private float _attackTimer;
    private int _killCount;
    
    // Methods
    public void Init(UnityEngine.Color[] enemyColors, bool isBoss, Level level, UnityEngine.Texture[] faceTextures, UnityEngine.Texture[] damagedFaceTextures, UnityEngine.Texture dieFaceTexture)
    {
        this._isBoss = isBoss;
        System.Collections.Generic.List<TSource> val_3 = System.Linq.Enumerable.ToList<Enemy>(source:  this.GetComponentsInChildren<Enemy>());
        this._enemies = val_3;
        this._level = level;
        List.Enumerator<T> val_4 = val_3.GetEnumerator();
        label_4:
        if(((-1544826600) & 1) == 0)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        0.Init(colors:  enemyColors, isBoss:  isBoss, onKilledBoss:  new System.Action(object:  this, method:  System.Void EnemyManager::OnKilledEnemy()), level:  this._level, faceTextures:  faceTextures, damagedFaceTextures:  damagedFaceTextures, dieFaceTexture:  dieFaceTexture);
        goto label_4;
        label_2:
        UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
    }
    public Enemy GetNearestEnemy()
    {
        System.Collections.Generic.List<Enemy> val_5;
        var val_6;
        var val_7;
        var val_8;
        val_5 = this._enemies;
        val_6 = 99;
        var val_6 = 4;
        label_15:
        var val_1 = val_6 - 4;
        if(val_1 >= 11317248)
        {
            goto label_2;
        }
        
        if(11317248 <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = 8;
        if(4194311 != 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            UnityEngine.Vector3 val_3 = UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32 + 48.position;
            UnityEngine.Vector3 val_4 = UnityEngine.Vector3.zero;
            if((UnityEngine.Vector3.Distance(a:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, b:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z})) < 0)
        {
                val_6 = val_1;
        }
        
        }
        
        val_5 = this._enemies;
        val_6 = val_6 + 1;
        if(val_5 != null)
        {
            goto label_15;
        }
        
        throw new NullReferenceException();
        label_2:
        if(val_6 == 99)
        {
                val_8 = 0;
            return (Enemy)val_8;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        val_8 = mem[(UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished + ((4 - 4)) << 3) + 32];
        val_8 = (UnityEngine.Vector3.__il2cppRuntimeField_cctor_finished + ((4 - 4)) << 3) + 32;
        return (Enemy)val_8;
    }
    private void Update()
    {
        if(this._isBoss == false)
        {
                return;
        }
        
        float val_1 = UnityEngine.Time.deltaTime;
        val_1 = val_1 + val_1;
        val_1 = this._attackTimer - val_1;
        this._attackTimer = val_1;
        if(val_1 >= 0)
        {
                return;
        }
        
        this._attackTimer = UnityEngine.Random.Range(min:  2f, max:  4f);
        if(this._isBoss != true)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this._isBoss + 32.LaunchRocket(onKilledPlayer:  new System.Action(object:  this, method:  System.Void EnemyManager::<Update>b__7_0()));
    }
    private void OnKilledEnemy()
    {
        int val_1 = this._killCount;
        val_1 = val_1 + 1;
        this._killCount = val_1;
        if(val_1 < this._enemies)
        {
                return;
        }
        
        this.KilledAllEnemies();
    }
    private void KilledAllEnemies()
    {
        this._isBoss = false;
        if(this._level != null)
        {
                this._level.OnKilledAllEnemies();
            return;
        }
        
        throw new NullReferenceException();
    }
    public EnemyManager()
    {
        this._enemies = new System.Collections.Generic.List<Enemy>();
        this._attackTimer = 3f;
    }
    private void <Update>b__7_0()
    {
        if(this._level != null)
        {
                this._level.OnKilledPlayer();
            return;
        }
        
        throw new NullReferenceException();
    }

}
