using UnityEngine;

namespace Cinema
{
    public class SettingData : ScriptableObject
    {
        // Fields
        public UnityEngine.Sprite normalHand;
        public UnityEngine.Sprite tapedHand;
        public int DisplayType;
        public float smooth;
        public float scale;
        public float angle;
        public bool flip;
        public bool centerAdjustment;
        public UnityEngine.Vector2 center;
        public float fadeInSpeed;
        public float fadeOutSpeed;
        public float delayInSpeed;
        public float delayOutSpeed;
        public bool backToCenter;
        
        // Methods
        public SettingData()
        {
            this.smooth = 1;
            UnityEngine.Vector2 val_1 = UnityEngine.Vector2.one;
            UnityEngine.Vector2 val_2 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y}, d:  0.5f);
            this.center = val_2;
            mem[1152921507425171664] = val_2.y;
            this.fadeInSpeed = 10;
        }
    
    }

}
