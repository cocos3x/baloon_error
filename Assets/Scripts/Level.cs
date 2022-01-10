using UnityEngine;
public class Level : Level
{
    // Fields
    private EnemyManager _enemyManager;
    private bool _isBoss;
    private HyperCasual.Manager _manager;
    private CameraManager _cameraManager;
    private bool _isGameStart;
    
    // Methods
    public void Init(Manager manager, CameraManager cameraManager, UnityEngine.Color[] enemyColors, UnityEngine.Texture[] faceTextures, UnityEngine.Texture[] damagedFaceTextures, UnityEngine.Texture dieFaceTextures)
    {
        this._manager = manager;
        this._cameraManager = cameraManager;
        this._enemyManager.Init(enemyColors:  enemyColors, isBoss:  this._isBoss, level:  this, faceTextures:  faceTextures, damagedFaceTextures:  damagedFaceTextures, dieFaceTexture:  dieFaceTextures);
        this._isGameStart = false;
    }
    public void GameStart()
    {
        this._isGameStart = true;
        this._cameraManager.Init(onFailed:  new System.Action(object:  this, method:  System.Void Level::Failed()), enemyManager:  this._enemyManager, isBoss:  this._isBoss);
        this._cameraManager.StartProcess();
    }
    private void Failed()
    {
        if(this._manager != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public void OnKilledAllEnemies()
    {
        this._cameraManager.OnGameOver();
        this._manager.GameOver();
    }
    public void OnKilledPlayer()
    {
        if(this._cameraManager != null)
        {
                this._cameraManager.OnFailed();
            return;
        }
        
        throw new NullReferenceException();
    }
    public override void OnMainButtonDown(UnityEngine.EventSystems.PointerEventData pointer)
    {
        if(this._isGameStart == false)
        {
                return;
        }
        
        if(this._cameraManager != null)
        {
                this._cameraManager.OnTap(pointerEventData:  pointer);
            return;
        }
        
        throw new NullReferenceException();
    }
    public override void OnMainButtonDrag(UnityEngine.EventSystems.PointerEventData pointer)
    {
    
    }
    public override void OnMainButtonUp(UnityEngine.EventSystems.PointerEventData pointer)
    {
        if(this._isGameStart == false)
        {
                return;
        }
        
        if(this._cameraManager != null)
        {
                this._cameraManager.OnRelease();
            return;
        }
        
        throw new NullReferenceException();
    }
    public Level()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
