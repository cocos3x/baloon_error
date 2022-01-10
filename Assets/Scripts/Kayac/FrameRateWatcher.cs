using UnityEngine;

namespace Kayac
{
    public class FrameRateWatcher
    {
        // Fields
        private System.Action<float> onLow;
        private System.Action<float> onHigh;
        private float lowThreshold;
        private float highThreshold;
        private float logDeltaTimeSum;
        private float deltaTimeFrames;
        private int checkFrameTimer;
        
        // Methods
        public FrameRateWatcher(float lowThresholdFrameTime, System.Action<float> onLow, float highThresholdFrameTime, System.Action<float> onHigh)
        {
            this.onLow = onLow;
            this.onHigh = onHigh;
            this.lowThreshold = lowThresholdFrameTime;
            this.highThreshold = highThresholdFrameTime;
        }
        public void Update()
        {
            float val_3 = UnityEngine.Time.deltaTime;
            int val_4 = this.checkFrameTimer;
            val_3 = this.logDeltaTimeSum + val_3;
            val_4 = val_4 - 1;
            this.logDeltaTimeSum = val_3;
            this.deltaTimeFrames = this.deltaTimeFrames + 1f;
            this.checkFrameTimer = val_4;
            if(val_4 > 0)
            {
                    return;
            }
            
            this.CheckImmediately();
        }
        public void Check(int delayFrames)
        {
            if(delayFrames >= 1)
            {
                    this.checkFrameTimer = delayFrames;
                return;
            }
            
            this.CheckImmediately();
        }
        private void CheckImmediately()
        {
            float val_1 = this.logDeltaTimeSum / this.deltaTimeFrames;
            val_1 = 1f / val_1;
            if(val_1 >= 0)
            {
                goto label_3;
            }
            
            label_7:
            this.onLow.Invoke(obj:  val_1);
            goto label_6;
            label_3:
            if(val_1 <= this.highThreshold)
            {
                goto label_6;
            }
            
            if(this.onHigh != null)
            {
                goto label_7;
            }
            
            throw new NullReferenceException();
            label_6:
            this.logDeltaTimeSum = 0f;
            this.deltaTimeFrames = 0f;
            this.checkFrameTimer = 2147483647;
        }
    
    }

}
