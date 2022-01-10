using UnityEngine;
public class Skin
{
    // Fields
    private UnityEngine.GameObject[] _models;
    private int[] _ids;
    private Skin.State _state;
    
    // Methods
    public Skin()
    {
        this._models = UnityEngine.Resources.LoadAll<UnityEngine.GameObject>(path:  "Guns");
        System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>();
        if(this._models.Length >= 1)
        {
                var val_10 = 0;
            do
        {
            char[] val_4 = new char[1];
            val_4[0] = '_';
            val_2.Add(item:  System.Int32.Parse(s:  this._models[val_10].name.Split(separator:  val_4)[0]));
            val_10 = val_10 + 1;
        }
        while(val_10 < this._models.Length);
        
        }
        
        this._ids = val_2.ToArray();
    }
    public UnityEngine.GameObject GetModelGameObject(int id)
    {
        return (UnityEngine.GameObject)this._models[id];
    }
    public int[] GetIds()
    {
        return (System.Int32[])this._ids;
    }

}
