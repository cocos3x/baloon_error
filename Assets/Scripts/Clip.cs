using UnityEngine;
private class SoundManager.Clip : IDisposable
{
    // Fields
    private int referenceCount;
    private UnityEngine.ResourceRequest loadRequest;
    private string <Name>k__BackingField;
    private System.Exception <Exception>k__BackingField;
    private System.Collections.Generic.LinkedListNode<Kayac.SoundManager.Clip> <ListNode>k__BackingField;
    private UnityEngine.AudioClip <AudioClip>k__BackingField;
    
    // Properties
    public string Name { get; set; }
    public System.Exception Exception { get; set; }
    public System.Collections.Generic.LinkedListNode<Kayac.SoundManager.Clip> ListNode { get; set; }
    public UnityEngine.AudioClip AudioClip { get; set; }
    public float Length { get; }
    public bool Loading { get; }
    public bool Referenced { get; }
    
    // Methods
    public string get_Name()
    {
        return (string)this.<Name>k__BackingField;
    }
    private void set_Name(string value)
    {
        this.<Name>k__BackingField = value;
    }
    public System.Exception get_Exception()
    {
        return (System.Exception)this.<Exception>k__BackingField;
    }
    private void set_Exception(System.Exception value)
    {
        this.<Exception>k__BackingField = value;
    }
    public System.Collections.Generic.LinkedListNode<Kayac.SoundManager.Clip> get_ListNode()
    {
        return (System.Collections.Generic.LinkedListNode<Clip>)this.<ListNode>k__BackingField;
    }
    public void set_ListNode(System.Collections.Generic.LinkedListNode<Kayac.SoundManager.Clip> value)
    {
        this.<ListNode>k__BackingField = value;
    }
    public UnityEngine.AudioClip get_AudioClip()
    {
        return (UnityEngine.AudioClip)this.<AudioClip>k__BackingField;
    }
    private void set_AudioClip(UnityEngine.AudioClip value)
    {
        this.<AudioClip>k__BackingField = value;
    }
    public float get_Length()
    {
        if((this.<AudioClip>k__BackingField) == 0)
        {
                return 0f;
        }
        
        return this.<AudioClip>k__BackingField.length;
    }
    public bool get_Loading()
    {
        var val_3;
        if((this.<AudioClip>k__BackingField) == 0)
        {
                var val_2 = ((this.<Exception>k__BackingField) == 0) ? 1 : 0;
            return (bool)val_3;
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    public bool get_Referenced()
    {
        return (bool)(this.referenceCount > 0) ? 1 : 0;
    }
    public SoundManager.Clip(UnityEngine.ResourceRequest loadRequest, string name)
    {
        val_1 = new System.Object();
        this.loadRequest = loadRequest;
        this.<Name>k__BackingField = val_1;
    }
    public void Dispose()
    {
        if((this.loadRequest != null) && (this.loadRequest.isDone != false))
        {
                if(this.loadRequest.asset != 0)
        {
                UnityEngine.Resources.UnloadAsset(assetToUnload:  this.loadRequest.asset);
        }
        
        }
        
        this.loadRequest = 0;
    }
    public void ManualUpdate(float deltaTime)
    {
        string val_10;
        string val_11;
        UnityEngine.AudioClip val_12;
        if(this.Loading == false)
        {
                return;
        }
        
        if(this.loadRequest == null)
        {
                return;
        }
        
        if(this.loadRequest.isDone == false)
        {
                return;
        }
        
        UnityEngine.Object val_3 = this.loadRequest.asset;
        if(val_3 == 0)
        {
                val_10 = this.<Name>k__BackingField;
            val_11 = "can\'t load asset name=";
        }
        else
        {
                if(val_3 != null)
        {
                var val_5 = (null == null) ? (val_3) : 0;
        }
        else
        {
                val_12 = 0;
        }
        
            this.<AudioClip>k__BackingField = val_12;
            if(val_12 != 0)
        {
                return;
        }
        
            val_10 = val_3.GetType();
            val_11 = "the asset is not AudioClip type=";
        }
        
        System.Exception val_9 = new System.Exception(message:  val_11 + val_10);
        this.<Exception>k__BackingField = val_9;
        UnityEngine.Debug.LogException(exception:  val_9);
    }
    public void Refer()
    {
        int val_1 = this.referenceCount;
        val_1 = val_1 + 1;
        this.referenceCount = val_1;
    }
    public void Release()
    {
        int val_1 = this.referenceCount;
        val_1 = val_1 - 1;
        this.referenceCount = val_1;
    }

}
