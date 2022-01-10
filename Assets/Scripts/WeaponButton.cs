using UnityEngine;
public class WeaponButton : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject _select;
    private UnityEngine.GameObject _notShow;
    private UnityEngine.GameObject _lock;
    private UnityEngine.GameObject _notSelect;
    private UnityEngine.GameObject _itemIcon;
    private UnityEngine.UI.Image _skinIconImage;
    private UnityEngine.UI.Button _button;
    private int _buttonId;
    private SaveData _saveData;
    private WeaponSelectManager _manager;
    
    // Methods
    public void Init(int id, SaveData saveData, WeaponSelectManager manager, UnityEngine.Sprite icon)
    {
        this._buttonId = id;
        this._saveData = saveData;
        this._manager = manager;
        this._skinIconImage.sprite = icon;
        this._button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WeaponButton::OnclickSkinButton()));
        this.UpdateState();
    }
    private void OnclickSkinButton()
    {
        if((this._saveData._skinStates[(this._buttonId) << 2]) == 2)
        {
                this._saveData.SetSkinState(id:  this._buttonId, state:  1);
        }
        
        Sound.Play(self:  3);
        this._manager.AllButtonUpdateState();
    }
    public void UpdateState()
    {
        this.DisableAll();
        this._itemIcon.SetActive(value:  true);
        if((this._saveData._skinStates[(this._buttonId) << 2]) > 3)
        {
                return;
        }
        
        var val_4 = 11543284 + (this._saveData._skinStates[(this._buttonId) << 2][0]) << 2;
        val_4 = val_4 + 11543284;
        goto (11543284 + (this._saveData._skinStates[(this._buttonId) << 2][0]) << 2 + 11543284);
    }
    private void DisableAll()
    {
        this._select.SetActive(value:  false);
        this._lock.SetActive(value:  false);
        this._notShow.SetActive(value:  false);
        this._notSelect.SetActive(value:  false);
    }
    public WeaponButton()
    {
    
    }

}
