using UnityEngine;
public class FailedManager : MonoBehaviour
{
    // Fields
    private UnityEngine.CanvasGroup _failedCanvasGroup;
    private UnityEngine.Animator _failedAnimator;
    private UnityEngine.UI.Button _declineButton;
    private System.Action _decline;
    
    // Methods
    private void Awake()
    {
        this._declineButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FailedManager::OnClickDecline()));
    }
    public void Prepare()
    {
        this._failedCanvasGroup.blocksRaycasts = false;
        this._failedCanvasGroup.alpha = 0f;
        this._failedAnimator.gameObject.SetActive(value:  false);
        this._declineButton.gameObject.SetActive(value:  false);
    }
    public void Play(System.Action decline)
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.CoPlay());
        this._decline = decline;
    }
    private System.Collections.IEnumerator CoPlay()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new FailedManager.<CoPlay>d__7();
    }
    private void OnClickDecline()
    {
        if(this._decline == null)
        {
                return;
        }
        
        this._decline.Invoke();
    }
    public FailedManager()
    {
    
    }

}
