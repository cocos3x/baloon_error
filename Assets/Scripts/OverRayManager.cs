using UnityEngine;
public class OverRayManager : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject _surpriseRewardOverRayGameObject;
    private RewardOverRay _rewardOverRay;
    private CoreServices _core;
    private int _id;
    private bool _shownReward;
    private OverRayManager.SurpriseState _surpriseState;
    
    // Properties
    public bool shownReward { get; set; }
    public OverRayManager.SurpriseState surpriseState { get; }
    
    // Methods
    public bool get_shownReward()
    {
        return (bool)this._shownReward;
    }
    public void set_shownReward(bool value)
    {
        this._shownReward = value;
    }
    public OverRayManager.SurpriseState get_surpriseState()
    {
        return (SurpriseState)this._surpriseState;
    }
    public void PlaySurprisedReward(CoreServices core)
    {
        RewardOverRay val_12;
        ClaimDelegete val_13;
        this._core = core;
        if(this._surpriseRewardOverRayGameObject == 0)
        {
                UnityEngine.Object val_2 = UnityEngine.Resources.Load(path:  "Prefabs/RewardOverray");
            if(val_2 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
            this._surpriseRewardOverRayGameObject = val_2;
            val_13 = this;
            this._rewardOverRay = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_2).GetComponent<RewardOverRay>();
        }
        else
        {
                val_13 = this;
            val_12 = this._rewardOverRay;
        }
        
        this._surpriseState = 1;
        val_12.Format();
        if((this._core.<saveData>k__BackingField._isTrial) != false)
        {
                this._rewardOverRay.SetReward(prefab:  new Skin().GetModelGameObject(id:  this._core.<saveData>k__BackingField.GetSelectedSkinId()));
            val_13 = new RewardOverRay.ClaimDelegete();
            mem[1152921507401079504] = this;
            mem[1152921507401079512] = System.Void OverRayManager::OnClaim();
            mem[1152921507401079488] = System.Void OverRayManager::OnClaim();
            mem[1152921507401087696] = this;
            mem[1152921507401087704] = System.Void OverRayManager::OnComplete();
            mem[1152921507401087680] = System.Void OverRayManager::OnComplete();
            UnityEngine.Coroutine val_9 = this._rewardOverRay.Play(onClaim:  new RewardOverRay.ClaimDelegete(), onDecline:  new RewardOverRay.DeclineDelegate(object:  this, method:  System.Void OverRayManager::OnDecline()), onComplete:  new RewardOverRay.CompleteDelegate());
            this._core.<saveData>k__BackingField._isTrial = false;
            return;
        }
        
        if(this.CanSetReward() != false)
        {
                this._core.<saveData>k__BackingField._isTrial = false;
            mem[1152921507401116368] = this;
            mem[1152921507401116376] = System.Void OverRayManager::OnComplete();
            mem[1152921507401116352] = System.Void OverRayManager::OnComplete();
            UnityEngine.Coroutine val_11 = this._rewardOverRay.Play(onClaim:  0, onDecline:  0, onComplete:  new RewardOverRay.CompleteDelegate());
            return;
        }
        
        this._surpriseState = 2;
        return;
        label_5:
    }
    private bool CanSetReward()
    {
        System.Int32[] val_1 = this._core.<saveData>k__BackingField.GetSkinIds(state:  0);
        if(val_1.Length == 0)
        {
                if(val_2.Length == 0)
        {
                return true;
        }
        
        }
        
        this.<CanSetReward>g__SetId|13_0(: ref  new <>c__DisplayClass13_0() {<>4__this = this, ids = this._core.<saveData>k__BackingField.GetSkinIds(state:  3)});
        return true;
    }
    private void OnCompleteShowAd()
    {
        this._shownReward = true;
        this._core.<saveData>k__BackingField.SetSkinState(id:  this._core.<saveData>k__BackingField.GetSelectedSkinId(), state:  1);
        this._core.<saveData>k__BackingField.Save();
        this._rewardOverRay._state = 3;
        UnityEngine.Coroutine val_3 = this._rewardOverRay.StartCoroutine(routine:  this.ChangeState());
    }
    private System.Collections.IEnumerator ChangeState()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new OverRayManager.<ChangeState>d__15();
    }
    private void OnClaim()
    {
        this._core.<adManager>k__BackingField.ShowRewarded(onEnd:  new System.Action(object:  this, method:  System.Void OverRayManager::OnCompleteShowAd()), placement:  "SurpriseReward");
    }
    private void OnDecline()
    {
        this._core.<saveData>k__BackingField.SetSkinState(id:  this._core.<saveData>k__BackingField.GetSelectedSkinId(), state:  3);
        this._core.<saveData>k__BackingField.SetSkinState(id:  this._core.<saveData>k__BackingField._lastSelectedSkinId, state:  1);
        this._surpriseState = 2;
    }
    private void OnComplete()
    {
        this._surpriseState = 2;
    }
    public OverRayManager()
    {
    
    }
    private void <CanSetReward>g__SetId|13_0(ref OverRayManager.<>c__DisplayClass13_0 )
    {
        this._id = .ids[0];
        this._rewardOverRay.SetReward(prefab:  new Skin().GetModelGameObject(id:  this._id));
        this._core.<saveData>k__BackingField._lastSelectedSkinId = this._core.<saveData>k__BackingField.GetSelectedSkinId();
        this._core.<saveData>k__BackingField.SetSkinState(id:  this._id, state:  1);
    }

}
