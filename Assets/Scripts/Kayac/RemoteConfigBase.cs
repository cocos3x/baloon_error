using UnityEngine;

namespace Kayac
{
    public class RemoteConfigBase
    {
        // Fields
        protected Kayac.FirebaseWrapper firebase;
        
        // Methods
        public RemoteConfigBase(Kayac.FirebaseWrapper firebase)
        {
            this.firebase = firebase;
        }
        protected void SetUserProperties(System.Collections.Generic.IList<string> values)
        {
            var val_7;
            var val_8;
            System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<System.String, System.String>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<System.String, System.String>>();
            val_7 = 0;
            goto label_2;
            label_12:
            val_8 = 0;
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_8 = 0;
            UnityEngine.Rendering.BitArray128 val_6 = new UnityEngine.Rendering.BitArray128(initValue1:  "test_group_" + 0.ToString(), initValue2:  values.Item[0]);
            val_1.Add(item:  new System.Collections.Generic.KeyValuePair<System.String, System.String>() {Value = val_6.data1});
            val_7 = 1;
            label_2:
            var val_10 = 0;
            val_10 = val_10 + 1;
            if(val_7 < values.Count)
            {
                goto label_12;
            }
            
            this.firebase.SetUserProperty(properties:  val_1);
        }
        protected static float GetFloatFromOption(string option, float min, float max, float defaultValue)
        {
            if((System.String.IsNullOrEmpty(value:  option)) == true)
            {
                    return (float)defaultValue;
            }
            
            if((System.Single.TryParse(s:  option, result: out  float val_2 = -1.415625E-13f)) == false)
            {
                    return (float)defaultValue;
            }
            
            defaultValue = UnityEngine.Mathf.Clamp(value:  0f, min:  min, max:  max);
            return (float)defaultValue;
        }
        protected static int GetIntFromOption(string option, int min, int max, int defaultValue)
        {
            if((System.String.IsNullOrEmpty(value:  option)) == true)
            {
                    return (int)defaultValue;
            }
            
            if((System.Int32.TryParse(s:  option, result: out  0)) == false)
            {
                    return (int)defaultValue;
            }
            
            defaultValue = UnityEngine.Mathf.Clamp(value:  0, min:  min, max:  max);
            return (int)defaultValue;
        }
        protected static bool GetBoolFromOption(string option, bool defaultValue)
        {
            var val_5;
            var val_6;
            val_5 = defaultValue;
            if((System.String.IsNullOrEmpty(value:  option)) == true)
            {
                goto label_1;
            }
            
            if((System.String.op_Equality(a:  option, b:  "on")) == false)
            {
                goto label_2;
            }
            
            val_5 = 1;
            label_1:
            val_6 = val_5 & 1;
            return (bool)val_6;
            label_2:
            val_6 = val_5 & (~(System.String.op_Equality(a:  option, b:  "off")));
            return (bool)val_6;
        }
    
    }

}
