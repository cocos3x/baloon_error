using UnityEngine;

namespace HyperCasual
{
    public class Manager : MonoBehaviour
    {
        // Fields
        protected UnityEngine.Transform _levelRoot;
        protected HyperCasual.Level[] _levels;
        private HyperCasual.Level _bossLevel;
        private System.Collections.Generic.List<int> _levelIndexList;
        protected UnityEngine.Vector3 _levelSlideInPositon;
        private UnityEngine.Vector3 _levelSlideOutPosition;
        protected HyperCasual.Level _currentLevel;
        private HyperCasual.Manager.State <state>k__BackingField;
        
        // Properties
        private HyperCasual.Manager.State state { get; set; }
        
        // Methods
        private HyperCasual.Manager.State get_state()
        {
            return (State)this.<state>k__BackingField;
        }
        private void set_state(HyperCasual.Manager.State value)
        {
            this.<state>k__BackingField = value;
        }
        protected virtual void Prepare()
        {
            UnityEngine.Transform val_8;
            this.<state>k__BackingField = 0;
            val_8 = 1152921504698220544;
            if((this._currentLevel != 0) && (this._levels.Length != 0))
            {
                    UnityEngine.Object.DestroyImmediate(obj:  this._currentLevel.gameObject);
                this._currentLevel = 0;
            }
            
            if(this._levels.Length != 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_8 = this._levelRoot;
                HyperCasual.Level val_6 = UnityEngine.Object.Instantiate<HyperCasual.Level>(original:  this._levels[(typeof(SaveData).__il2cppRuntimeField_2C + (typeof(SaveData).__il2cppRuntimeField_2C - ((typeof(SaveData).__il2cppRuntimeField_2C / UnityEngine.Object.__il2cppRuntimeField_cctor_finished) * UnityEngi + 32], parent:  val_8);
            }
            
            this._currentLevel = this.GetComponentInChildren<HyperCasual.Level>();
        }
        private System.Collections.Generic.List<int> SetUpLevelIndexList(int bossLevelIndex)
        {
            var val_8;
            var val_9;
            val_8 = bossLevelIndex;
            System.Collections.Generic.List<System.Int32> val_1 = new System.Collections.Generic.List<System.Int32>();
            if(val_8 != 0)
            {
                    int val_2 = this._levels.Length * val_8;
                if(val_2 < 1)
            {
                    return val_1;
            }
            
                val_9 = 0;
                var val_9 = 0;
                do
            {
                int val_4 = val_9 / val_8;
                val_4 = val_9 - (val_4 * val_8);
                if(val_4 == (val_8 - 1))
            {
                    val_1.Add(item:  this._levels.Length - 1);
            }
            else
            {
                    int val_8 = this._levels.Length;
                val_8 = val_8 - 1;
                val_1.Add(item:  val_9 - ((val_9 / val_8) * val_8));
                val_9 = val_9 + 1;
            }
            
                val_9 = val_9 + 1;
                if(val_9 >= val_2)
            {
                    return val_1;
            }
            
            }
            while(this._levels != null);
            
            }
            
            val_8 = 0;
            do
            {
                int val_10 = this._levels.Length;
                val_10 = val_10 - 1;
                if(val_8 >= val_10)
            {
                    return val_1;
            }
            
                val_1.Add(item:  0);
                val_8 = val_8 + 1;
            }
            while(this._levels != null);
            
            throw new NullReferenceException();
        }
        protected void SetLevelBundle()
        {
            this._levels = UnityEngine.Resources.LoadAll<Level>(path:  "LevelBundles/Level_Bundle_0");
            this._levelIndexList = this.SetUpLevelIndexList(bossLevelIndex:  5);
        }
        protected virtual void GameStart()
        {
            if((this.<state>k__BackingField) != 0)
            {
                    UnityEngine.Debug.LogError(message:  "stateが不正です");
                return;
            }
            
            UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
            DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> val_4 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  this._levelRoot, endValue:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z}, duration:  0.25f, snapping:  false), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void HyperCasual.Manager::<GameStart>b__15_0()));
        }
        protected virtual void OnGameStarted()
        {
        
        }
        public void GameOver()
        {
            if((this.<state>k__BackingField) == 1)
            {
                    this.<state>k__BackingField = 2;
                string val_2 = this._currentLevel.gameObject.name;
                UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this);
                return;
            }
            
            UnityEngine.Debug.LogError(message:  "stateが不正です");
        }
        protected virtual System.Collections.IEnumerator CoGameOver(string levelName)
        {
            .<>1__state = 0;
            return (System.Collections.IEnumerator)new Manager.<CoGameOver>d__18();
        }
        public virtual void Failed()
        {
        
        }
        protected virtual void NextLevel()
        {
            DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> val_3 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  this._levelRoot, endValue:  new UnityEngine.Vector3() {x = this._levelSlideOutPosition}, duration:  0.25f, snapping:  false), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void HyperCasual.Manager::<NextLevel>b__20_0()));
        }
        public void OnMainButtonDown(UnityEngine.EventSystems.BaseEventData eventData)
        {
            UnityEngine.EventSystems.PointerEventData val_1 = HyperCasual.Extension.ToPointer(self:  eventData);
            goto typeof(HyperCasual.Manager).__il2cppRuntimeField_1D0;
        }
        public void OnMainButtonBeginDrag(UnityEngine.EventSystems.BaseEventData eventData)
        {
            UnityEngine.EventSystems.PointerEventData val_1 = HyperCasual.Extension.ToPointer(self:  eventData);
            goto typeof(HyperCasual.Manager).__il2cppRuntimeField_1E0;
        }
        public void OnMainButtonDrag(UnityEngine.EventSystems.BaseEventData eventData)
        {
            UnityEngine.EventSystems.PointerEventData val_1 = HyperCasual.Extension.ToPointer(self:  eventData);
            goto typeof(HyperCasual.Manager).__il2cppRuntimeField_1F0;
        }
        public void OnMainButtonEndDrag(UnityEngine.EventSystems.BaseEventData eventData)
        {
            UnityEngine.EventSystems.PointerEventData val_1 = HyperCasual.Extension.ToPointer(self:  eventData);
            goto typeof(HyperCasual.Manager).__il2cppRuntimeField_200;
        }
        public void OnMainButtonUp(UnityEngine.EventSystems.BaseEventData eventData)
        {
            UnityEngine.EventSystems.PointerEventData val_1 = HyperCasual.Extension.ToPointer(self:  eventData);
            goto typeof(HyperCasual.Manager).__il2cppRuntimeField_210;
        }
        public void OnMainButtonClick(UnityEngine.EventSystems.BaseEventData eventData)
        {
        
        }
        protected virtual void OnMainButtonDown(UnityEngine.EventSystems.PointerEventData pointer)
        {
            if(this._currentLevel != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        protected virtual void OnMainButtonBeginDrag(UnityEngine.EventSystems.PointerEventData pointer)
        {
            if(this._currentLevel != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        protected virtual void OnMainButtonDrag(UnityEngine.EventSystems.PointerEventData pointer)
        {
            if(this._currentLevel != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        protected virtual void OnMainButtonEndDrag(UnityEngine.EventSystems.PointerEventData pointer)
        {
            if(this._currentLevel != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        protected virtual void OnMainButtonUp(UnityEngine.EventSystems.PointerEventData pointer)
        {
            if(this._currentLevel != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        protected virtual void OnMainButtonClick(UnityEngine.EventSystems.PointerEventData pointer)
        {
            if(this._currentLevel != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public Manager()
        {
            this._levelIndexList = new System.Collections.Generic.List<System.Int32>();
            UnityEngine.Vector3 val_2 = UnityEngine.Vector3.right;
            UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, d:  20f);
            this._levelSlideInPositon = val_3;
            mem[1152921507430560428] = val_3.y;
            mem[1152921507430560432] = val_3.z;
            UnityEngine.Vector3 val_4 = UnityEngine.Vector3.left;
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, d:  20f);
            this._levelSlideOutPosition = val_5;
            mem[1152921507430560440] = val_5.y;
            mem[1152921507430560444] = val_5.z;
        }
        private void <GameStart>b__15_0()
        {
            this.<state>k__BackingField = 1;
        }
        private void <NextLevel>b__20_0()
        {
            this._levelRoot.localPosition = new UnityEngine.Vector3() {x = this._levelSlideInPositon};
            IncrementLastLevelIndex();
            Save();
            goto typeof(HyperCasual.Manager).__il2cppRuntimeField_180;
        }
    
    }

}
