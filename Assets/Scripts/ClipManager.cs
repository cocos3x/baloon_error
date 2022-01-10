using UnityEngine;
private class SoundManager.ClipManager : IDisposable
{
    // Fields
    private System.Collections.Generic.Dictionary<string, Kayac.SoundManager.Clip> clips;
    private System.Collections.Generic.LinkedList<Kayac.SoundManager.Clip> rankedClips;
    private int cacheSize;
    private string rootPath;
    
    // Properties
    public int Count { get; }
    
    // Methods
    public int get_Count()
    {
        if(this.clips == null)
        {
                return (int)this.clips;
        }
        
        return this.clips.Count;
    }
    public SoundManager.ClipManager(string rootPath, int cacheSize)
    {
        this.rootPath = rootPath;
        if((System.String.IsNullOrEmpty(value:  rootPath = rootPath)) != true)
        {
                string val_2 = this.rootPath + "/"("/");
            this.rootPath = val_2;
        }
        
        val_2 = new System.Collections.Generic.Dictionary<System.String, Clip>();
        this.clips = val_2;
        this.rankedClips = new System.Collections.Generic.LinkedList<Clip>();
        this.cacheSize = cacheSize;
    }
    public void UnloadUnused()
    {
        if(==0)
        {
                return;
        }
        
        do
        {
            if((mem[16252968] + 16) <= 0)
        {
                if(mem[16252968].Loading != true)
        {
                this.Unload(clip:  mem[16252968]);
        }
        
        }
        
        }
        while(Next != null);
    
    }
    public void TryUnload(string name)
    {
        if((this.clips.ContainsKey(key:  name)) == false)
        {
                return;
        }
        
        Clip val_2 = this.clips.Item[name];
        int val_4 = val_2.referenceCount;
        val_4 = val_4 - 1;
        val_2.referenceCount = val_4;
        if(val_4 > 0)
        {
                return;
        }
        
        if(val_2.Loading != false)
        {
                return;
        }
        
        this.Unload(clip:  val_2);
    }
    public bool IsLoading(string name)
    {
        if((this.clips.ContainsKey(key:  name)) == false)
        {
                return false;
        }
        
        return this.clips.Item[name].Loading;
    }
    public float GetClipLength(string name)
    {
        if((this.clips.ContainsKey(key:  name)) == false)
        {
                return 0f;
        }
        
        return this.clips.Item[name].Length;
    }
    public void Dispose()
    {
        if((this.rankedClips != null) && (!=0))
        {
                do
        {
            mem[16252968].Dispose();
        }
        while(Next != null);
        
        }
        
        this.clips = 0;
        this.rankedClips = 0;
    }
    public void ManualUpdate(float deltaTime)
    {
        Clip val_5;
        if(!=0)
        {
                val_5 = 1152921507443355648;
            do
        {
            mem[16252968].ManualUpdate(deltaTime:  deltaTime);
        }
        while(Next != null);
        
        }
        
        System.Collections.Generic.LinkedListNode<T> val_2 = this.rankedClips.Last;
        do
        {
            if(val_2 == null)
        {
                return;
        }
        
            if(this.rankedClips <= this.cacheSize)
        {
                return;
        }
        
            System.Collections.Generic.LinkedListNode<T> val_3 = val_2.Previous;
            if("ሀᎀ" <= 0)
        {
                if(Loading != true)
        {
                this.Unload(clip:  val_5);
        }
        
        }
        
        }
        while(this.rankedClips != null);
        
        throw new NullReferenceException();
    }
    public Kayac.SoundManager.Clip Load(string name)
    {
        Clip val_7;
        if((this.clips.ContainsKey(key:  name)) != false)
        {
                val_7 = this.clips.Item[name];
            this.rankedClips.Remove(node:  val_2.<ListNode>k__BackingField);
            this.rankedClips.AddFirst(node:  val_2.<ListNode>k__BackingField);
            return val_7;
        }
        
        SoundManager.Clip val_5 = null;
        val_7 = val_5;
        val_5 = new SoundManager.Clip();
        .loadRequest = UnityEngine.Resources.LoadAsync(path:  this.rootPath + name);
        .<Name>k__BackingField = name;
        this.clips.Add(key:  name, value:  val_5);
        System.Collections.Generic.LinkedListNode<T> val_6 = this.rankedClips.AddFirst(value:  val_5);
        .<ListNode>k__BackingField = this.rankedClips;
        return val_7;
    }
    private void Unload(Kayac.SoundManager.Clip clip)
    {
        bool val_1 = this.clips.Remove(key:  clip.<Name>k__BackingField);
        this.rankedClips.Remove(node:  clip.<ListNode>k__BackingField);
        clip.Dispose();
    }

}
