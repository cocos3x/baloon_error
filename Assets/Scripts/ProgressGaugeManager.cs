using UnityEngine;
public class ProgressGaugeManager : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject[] _gaugeObjects;
    private UnityEngine.UI.Text[] _gaugeTexts;
    
    // Methods
    public void Init(int currentLevelIndex)
    {
        var val_5 = 0;
        val_5 = currentLevelIndex - val_5;
        var val_1 = () ? 5 : (val_5);
        if(this._gaugeObjects.Length >= 1)
        {
                var val_6 = 0;
            do
        {
            1152921505924991760.SetActive(value:  false);
            val_6 = val_6 + 1;
        }
        while(val_6 < this._gaugeObjects.Length);
        
        }
        
        if(val_1 >= 1)
        {
                var val_8 = 0;
            do
        {
            this._gaugeObjects[val_8].SetActive(value:  true);
            val_8 = val_8 + 1;
        }
        while(val_8 < val_1);
        
        }
        
        var val_10 = 0;
        val_1 = (currentLevelIndex + 1) - val_1;
        do
        {
            if(val_10 >= this._gaugeTexts.Length)
        {
                return;
        }
        
            UnityEngine.UI.Text val_9 = this._gaugeTexts[val_10];
            string val_4 = val_1 + val_10.ToString();
            val_10 = val_10 + 1;
        }
        while(this._gaugeTexts != null);
        
        throw new NullReferenceException();
    }
    public ProgressGaugeManager()
    {
    
    }

}
