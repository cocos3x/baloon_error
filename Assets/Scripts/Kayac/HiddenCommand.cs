using UnityEngine;

namespace Kayac
{
    public class HiddenCommand : BaseRaycaster
    {
        // Fields
        private UnityEngine.Camera myCamera;
        private string password;
        private string word;
        private bool down;
        private System.Action <onMatch>k__BackingField;
        
        // Properties
        private System.Action onMatch { get; set; }
        public override UnityEngine.Camera eventCamera { get; }
        
        // Methods
        private System.Action get_onMatch()
        {
            return (System.Action)this.<onMatch>k__BackingField;
        }
        public void set_onMatch(System.Action value)
        {
            this.<onMatch>k__BackingField = value;
        }
        public override UnityEngine.Camera get_eventCamera()
        {
            return (UnityEngine.Camera)this.myCamera;
        }
        protected override void Awake()
        {
            this.word = 0.CreateString(c:  ' ', count:  this.password.m_stringLength);
        }
        public override void Raycast(UnityEngine.EventSystems.PointerEventData eventData, System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> resultAppendList)
        {
            if(this.down == false)
            {
                goto label_1;
            }
            
            label_12:
            this.down = eventData.<eligibleForClick>k__BackingField;
            return;
            label_1:
            if((eventData.<eligibleForClick>k__BackingField) == false)
            {
                goto label_12;
            }
            
            float val_2 = (eventData.<position>k__BackingField) * 3f;
            val_2 = val_2 / (float)UnityEngine.Screen.width;
            int val_3 = UnityEngine.Mathf.FloorToInt(f:  val_2);
            float val_5 = S8 * 3f;
            val_5 = val_5 / (float)UnityEngine.Screen.height;
            int val_6 = UnityEngine.Mathf.FloorToInt(f:  val_5);
            if((val_3 > 2) || (val_6 > 2))
            {
                goto label_12;
            }
            
            int val_8 = val_6 + (val_6 << 1);
            val_8 = val_3 + val_8;
            string val_11 = this.word.Substring(startIndex:  1)(this.word.Substring(startIndex:  1)) + 0.CreateString(c:  val_8 + 49, count:  1)(0.CreateString(c:  val_8 + 49, count:  1));
            this.word = val_11;
            if(((System.String.op_Equality(a:  val_11, b:  this.password)) == false) || ((this.<onMatch>k__BackingField) == null))
            {
                goto label_12;
            }
            
            this.<onMatch>k__BackingField.Invoke();
            goto label_12;
        }
        public HiddenCommand()
        {
        
        }
    
    }

}
