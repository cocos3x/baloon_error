using UnityEngine;
private class SoundManager.Channel : IDisposable
{
    // Fields
    private bool <Playing>k__BackingField;
    private Kayac.SoundManager.Clip <Clip>k__BackingField;
    private System.Exception <Exception>k__BackingField;
    private float <BaseVolume>k__BackingField;
    private float <Volume>k__BackingField;
    private System.DateTime <EstimatedEndTime>k__BackingField;
    private UnityEngine.AudioSource source;
    private bool playRequested;
    private bool actuallyStarted;
    private float delay;
    private float fadeSpeed;
    private float fadedVolume;
    private bool paused;
    
    // Properties
    public bool Playing { get; set; }
    public bool Busy { get; }
    public string ClipName { get; }
    public Kayac.SoundManager.Clip Clip { get; set; }
    public System.Exception Exception { get; set; }
    private float BaseVolume { get; set; }
    public float Volume { get; set; }
    public System.DateTime EstimatedEndTime { get; set; }
    public bool Looping { get; }
    
    // Methods
    public bool get_Playing()
    {
        return (bool)this.<Playing>k__BackingField;
    }
    private void set_Playing(bool value)
    {
        this.<Playing>k__BackingField = value;
    }
    public bool get_Busy()
    {
        if(this.playRequested == false)
        {
                return (bool)((this.<Playing>k__BackingField) == true) ? 1 : 0;
        }
        
        return true;
    }
    public string get_ClipName()
    {
        if((this.<Clip>k__BackingField) == null)
        {
                return 0;
        }
        
        return (string)this.<Clip>k__BackingField.<Name>k__BackingField;
    }
    public Kayac.SoundManager.Clip get_Clip()
    {
        return (Clip)this.<Clip>k__BackingField;
    }
    private void set_Clip(Kayac.SoundManager.Clip value)
    {
        this.<Clip>k__BackingField = value;
    }
    public System.Exception get_Exception()
    {
        return (System.Exception)this.<Exception>k__BackingField;
    }
    private void set_Exception(System.Exception value)
    {
        this.<Exception>k__BackingField = value;
    }
    private float get_BaseVolume()
    {
        return (float)this.<BaseVolume>k__BackingField;
    }
    public void set_BaseVolume(float value)
    {
        this.<BaseVolume>k__BackingField = value;
    }
    public float get_Volume()
    {
        return (float)this.<Volume>k__BackingField;
    }
    private void set_Volume(float value)
    {
        this.<Volume>k__BackingField = value;
    }
    public System.DateTime get_EstimatedEndTime()
    {
        return (System.DateTime)this.<EstimatedEndTime>k__BackingField;
    }
    private void set_EstimatedEndTime(System.DateTime value)
    {
        this.<EstimatedEndTime>k__BackingField = value;
    }
    public bool get_Looping()
    {
        if(this.source != null)
        {
                return this.source.loop;
        }
        
        throw new NullReferenceException();
    }
    public SoundManager.Channel(UnityEngine.AudioSource source)
    {
        this.source = source;
    }
    public void Dispose()
    {
        if((this.<Clip>k__BackingField) != null)
        {
                int val_3 = this.<Clip>k__BackingField.referenceCount;
            val_3 = val_3 - 1;
            this.<Clip>k__BackingField.referenceCount = val_3;
            this.<Clip>k__BackingField = 0;
        }
        
        if(this.source == 0)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.source.gameObject);
        this.source = 0;
    }
    public void RequestPlay(Kayac.SoundManager.Clip clip, float baseVolume, float volumeModifier, bool loop, float pitch, float delay, float fadeDuration, bool startWithPaused, float silenceDb)
    {
        float val_10;
        bool val_11;
        float val_12;
        float val_13;
        var val_14;
        System.DateTime val_15;
        val_10 = silenceDb;
        val_11 = loop;
        val_12 = baseVolume;
        if((clip.<Exception>k__BackingField) != null)
        {
                return;
        }
        
        this.StopImmediately();
        this.<BaseVolume>k__BackingField = val_12;
        this.<Volume>k__BackingField = val_12;
        this.source.loop = val_11;
        this.source.pitch = pitch;
        this.<Clip>k__BackingField = clip;
        int val_10 = clip.referenceCount;
        val_13 = 0f;
        val_10 = val_10 + 1;
        clip.referenceCount = val_10;
        this.playRequested = true;
        if(fadeDuration != 0f)
        {
                val_13 = (val_12 - val_10) / fadeDuration;
            val_12 = val_10;
        }
        
        this.fadeSpeed = val_13;
        this.fadedVolume = val_12;
        this.source.volume = Kayac.SoundManager.FromDecibel(decibel:  val_12 + volumeModifier);
        this.delay = delay;
        this.paused = startWithPaused;
        this.ManualUpdate(deltaTime:  0f, volumeModifier:  volumeModifier, silenceDb:  val_10);
        val_14 = null;
        if(val_11 != false)
        {
                val_14 = null;
            val_15 = System.DateTime.MaxValue;
        }
        else
        {
                System.DateTime val_6 = System.DateTime.Now;
            val_11 = val_6.dateData;
            val_10 = clip.Length;
            System.TimeSpan val_8 = System.TimeSpan.FromSeconds(value:  (double)val_10);
            System.DateTime val_9 = System.DateTime.op_Addition(d:  new System.DateTime() {dateData = val_11}, t:  new System.TimeSpan() {_ticks = val_8._ticks});
        }
        
        this.<EstimatedEndTime>k__BackingField = val_9;
    }
    public void EndPause()
    {
        this.paused = false;
    }
    public void ManualUpdate(float deltaTime, float volumeModifier, float silenceDb)
    {
        float val_5;
        float val_7 = volumeModifier;
        float val_6 = deltaTime;
        if(this.paused != false)
        {
                return;
        }
        
        if(this.playRequested != false)
        {
                this.TryPlay(deltaTime:  val_6);
        }
        
        if((this.<Playing>k__BackingField) == false)
        {
                return;
        }
        
        float val_5 = this.fadeSpeed;
        if(val_5 != 0f)
        {
                val_5 = val_5 * val_6;
            val_6 = val_5 + this.fadedVolume;
            this.fadedVolume = val_6;
            float val_1 = UnityEngine.Mathf.Clamp(value:  val_6, min:  silenceDb, max:  0f);
            this.fadedVolume = val_1;
            if((val_1 <= silenceDb) && (this.fadeSpeed < 0))
        {
                this.StopImmediately();
        }
        
        }
        
        if(this.source.isPlaying != false)
        {
                val_5 = this.fadedVolume;
            val_7 = val_5 + val_7;
            if((this.<Volume>k__BackingField) != val_7)
        {
                val_5 = val_7;
            this.<Volume>k__BackingField = val_7;
            this.source.volume = Kayac.SoundManager.FromDecibel(decibel:  val_5);
        }
        
            if(this.actuallyStarted == true)
        {
                return;
        }
        
            if(this.source.time == 0f)
        {
                return;
        }
        
            this.actuallyStarted = true;
            return;
        }
        
        if(this.actuallyStarted == false)
        {
                return;
        }
        
        this.StopImmediately();
    }
    public void StopImmediately()
    {
        this.source.Stop();
        if((this.<Clip>k__BackingField) != null)
        {
                int val_1 = this.<Clip>k__BackingField.referenceCount;
            val_1 = val_1 - 1;
            this.<Clip>k__BackingField.referenceCount = val_1;
            this.<Clip>k__BackingField = 0;
        }
        
        this.playRequested = false;
        this.actuallyStarted = false;
        this.<Playing>k__BackingField = false;
    }
    public void Stop(float fadeDuration, float silenceDb)
    {
        silenceDb = silenceDb - (this.<BaseVolume>k__BackingField);
        fadeDuration = silenceDb / fadeDuration;
        this.fadeSpeed = fadeDuration;
    }
    private void TryPlay(float deltaTime)
    {
        this.delay = this.delay - deltaTime;
        if(this.delay > 0f)
        {
                return;
        }
        
        if((this.<Clip>k__BackingField.Loading) == true)
        {
                return;
        }
        
        this.playRequested = false;
        if((this.<Clip>k__BackingField.<AudioClip>k__BackingField) == 0)
        {
                return;
        }
        
        this.source.clip = this.<Clip>k__BackingField.<AudioClip>k__BackingField;
        this.source.Play();
        this.<Playing>k__BackingField = true;
    }

}
