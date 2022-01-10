using UnityEngine;

namespace Kayac
{
    public class SoundManager : MonoBehaviour
    {
        // Fields
        private static Kayac.SoundManager <Instance>k__BackingField;
        private int seChannelCount;
        private float masterVolume;
        private float bgmVolume;
        private float seVolume;
        private bool muted;
        private string assetRootPath;
        private float silenceDb;
        private int clipCacheSize;
        private bool autoUpdate;
        private Kayac.SoundManager.Channel[] seChannels;
        private Kayac.SoundManager.Channel[] bgmChannels;
        private int nextBgmChannelIndex;
        private Kayac.SoundManager.ClipManager clipManager;
        private const float OverlapDurationUntilEnd = -∞;
        private bool bgmReserved;
        
        // Properties
        public static Kayac.SoundManager Instance { get; set; }
        public bool Muted { get; set; }
        public float MasterVolume { get; set; }
        public float SeVolume { get; set; }
        public float BgmVolume { get; set; }
        public bool BgmPlaying { get; }
        public bool BgmLooping { get; }
        public string BgmName { get; }
        
        // Methods
        public static Kayac.SoundManager get_Instance()
        {
            return (Kayac.SoundManager)Kayac.SoundManager.OverlapDurationUntilEnd;
        }
        private static void set_Instance(Kayac.SoundManager value)
        {
            Kayac.SoundManager.OverlapDurationUntilEnd = value;
        }
        public bool get_Muted()
        {
            return (bool)this.muted;
        }
        public void set_Muted(bool value)
        {
            this.muted = value;
        }
        public float get_MasterVolume()
        {
            return (float)this.masterVolume;
        }
        public void set_MasterVolume(float value)
        {
            this.masterVolume = value;
        }
        public float get_SeVolume()
        {
            return (float)S0;
        }
        public void set_SeVolume(float value)
        {
        
        }
        public float get_BgmVolume()
        {
            return (float)S0;
        }
        public void set_BgmVolume(float value)
        {
        
        }
        public bool get_BgmPlaying()
        {
            var val_2;
            Channel val_2 = this.bgmChannels[0];
            if((this.bgmChannels[0].<Playing>k__BackingField) != false)
            {
                    val_2 = 1;
                return (bool)((this.bgmChannels[1].<Playing>k__BackingField) == true) ? 1 : 0;
            }
            
            Channel val_3 = this.bgmChannels[1];
            return (bool)((this.bgmChannels[1].<Playing>k__BackingField) == true) ? 1 : 0;
        }
        public bool get_BgmLooping()
        {
            int val_1 = this.nextBgmChannelIndex;
            val_1 = 1 - val_1;
            Channel val_2 = this.bgmChannels[val_1];
            if((this.bgmChannels[(1 - this.nextBgmChannelIndex)][0].<Playing>k__BackingField) == false)
            {
                    return false;
            }
            
            return this.bgmChannels[(1 - this.nextBgmChannelIndex)][0].source.loop;
        }
        public string get_BgmName()
        {
            string val_1;
            int val_1 = this.nextBgmChannelIndex;
            val_1 = 1 - val_1;
            Channel val_2 = this.bgmChannels[val_1];
            if((this.bgmChannels[(1 - this.nextBgmChannelIndex)][0].<Clip>k__BackingField) != null)
            {
                    val_1 = this.bgmChannels[(1 - this.nextBgmChannelIndex)][0].<Clip>k__BackingField.<Name>k__BackingField;
                return (string)val_1;
            }
            
            val_1 = 0;
            return (string)val_1;
        }
        public bool IsClipLoading(string name)
        {
            if(this.clipManager != null)
            {
                    return this.clipManager.IsLoading(name:  name);
            }
            
            throw new NullReferenceException();
        }
        public bool IsAnyClipLoading(System.Collections.Generic.IEnumerable<string> names)
        {
            var val_8;
            var val_9;
            var val_13;
            var val_14;
            var val_16;
            val_8 = names;
            val_9 = this;
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_10 = 0;
            val_10 = val_10 + 1;
            val_8 = val_8.GetEnumerator();
            label_17:
            var val_11 = 0;
            val_11 = val_11 + 1;
            if(val_8.MoveNext() == false)
            {
                goto label_11;
            }
            
            var val_12 = 0;
            val_12 = val_12 + 1;
            if(this.clipManager == null)
            {
                    throw new NullReferenceException();
            }
            
            if((this.clipManager.IsLoading(name:  val_8.Current)) == false)
            {
                goto label_17;
            }
            
            val_13 = 0;
            val_9 = 0;
            val_14 = 1;
            if(val_8 != null)
            {
                goto label_33;
            }
            
            goto label_34;
            label_11:
            val_13 = 0;
            val_9 = 0;
            val_14 = 0;
            if(val_8 == null)
            {
                goto label_34;
            }
            
            label_33:
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_8.Dispose();
            label_34:
            if(val_9 != 0)
            {
                    throw val_9;
            }
            
            if(val_13 != 1)
            {
                    val_16 = val_14 & ((49 == 51) ? 1 : 0);
                return (bool)val_16;
            }
            
            val_16 = 0;
            return (bool)val_16;
        }
        private void Awake()
        {
            Channel[] val_1 = new Channel[2];
            this.bgmChannels = val_1;
            val_1[0] = this.CreateChannel(channelName:  "BgmChannel0");
            this.bgmChannels[1] = this.CreateChannel(channelName:  "BgmChannel1");
            Channel[] val_4 = new Channel[0];
            this.seChannels = val_4;
            if(this.seChannelCount < 1)
            {
                goto label_14;
            }
            
            label_15:
            val_4[0] = this.CreateChannel(channelName:  "SeChannel" + 0.ToString());
            if(1 >= this.seChannelCount)
            {
                goto label_14;
            }
            
            Channel val_10 = this.CreateChannel(channelName:  "SeChannel" + 1.ToString());
            if(this.seChannels != null)
            {
                goto label_15;
            }
            
            throw new NullReferenceException();
            label_14:
            this.clipManager = new SoundManager.ClipManager(rootPath:  this.assetRootPath, cacheSize:  this.clipCacheSize);
            Kayac.SoundManager.OverlapDurationUntilEnd = this;
        }
        private Kayac.SoundManager.Channel CreateChannel(string channelName)
        {
            UnityEngine.GameObject val_1 = new UnityEngine.GameObject(name:  channelName);
            val_1.transform.SetParent(parent:  this.transform, worldPositionStays:  false);
            .source = val_1.AddComponent<UnityEngine.AudioSource>();
            return (Channel)new SoundManager.Channel();
        }
        private void OnDestroy()
        {
            this.Dispose();
            Kayac.SoundManager.OverlapDurationUntilEnd = 0f;
            Kayac.SoundManager.OverlapDurationUntilEnd.__il2cppRuntimeField_3 = 0;
        }
        public void Dispose()
        {
            if(this.bgmChannels != null)
            {
                    this.bgmChannels[0].Dispose();
                this.bgmChannels[1].Dispose();
                this.bgmChannels = 0;
            }
            
            if(this.seChannels == null)
            {
                goto label_6;
            }
            
            var val_4 = 0;
            label_10:
            if(val_4 >= this.seChannels.Length)
            {
                goto label_7;
            }
            
            this.seChannels[val_4].Dispose();
            val_4 = val_4 + 1;
            if(this.seChannels != null)
            {
                goto label_10;
            }
            
            throw new NullReferenceException();
            label_7:
            this.seChannels = 0;
            label_6:
            if(this.clipManager == null)
            {
                    return;
            }
            
            this.clipManager.Dispose();
            this.clipManager = 0;
        }
        public void PlayBgm(string name, float volume = 0, bool loop = True, float fadeOutDuration = 0.5, float fadeInDuration = 0, float overlapDuration = 0, bool ignoreSame = True)
        {
            if(this.muted == true)
            {
                    return;
            }
            
            float val_3 = this.masterVolume;
            val_3 = val_3 + this.bgmVolume;
            val_3 = val_3 + volume;
            if(val_3 <= this.silenceDb)
            {
                    return;
            }
            
            this.PlayBgmInternal(clipName:  name, volume:  volume, loop:  loop, fadeOutDuration:  fadeOutDuration, fadeInDuration:  fadeInDuration, overlapDuration:  overlapDuration, ignoreSame:  ignoreSame);
        }
        public void ReserveBgm(string name, float volume = 0, bool loop = True, float fadeInDuration = 0, bool ignoreSame = True)
        {
            if(this.muted == true)
            {
                    return;
            }
            
            float val_3 = this.masterVolume;
            val_3 = val_3 + this.bgmVolume;
            val_3 = val_3 + volume;
            if(val_3 <= this.silenceDb)
            {
                    return;
            }
            
            int val_4 = this.nextBgmChannelIndex;
            val_4 = 1 - val_4;
            this.PlayBgm(name:  name, volume:  volume, loop:  loop, fadeOutDuration:  0f, fadeInDuration:  fadeInDuration, overlapDuration:  -Infinityf, ignoreSame:  ignoreSame);
        }
        private void PlayBgmInternal(string clipName, float volume, bool loop, float fadeOutDuration, float fadeInDuration, float overlapDuration, bool ignoreSame)
        {
            float val_7;
            float val_8;
            int val_9;
            val_7 = overlapDuration;
            val_8 = fadeOutDuration;
            if(ignoreSame != false)
            {
                    if((System.String.op_Equality(a:  clipName, b:  this.BgmName)) == true)
            {
                    return;
            }
            
            }
            
            if(val_7 <= (-Infinityf))
            {
                goto label_2;
            }
            
            this.bgmReserved = false;
            int val_7 = this.nextBgmChannelIndex;
            val_7 = 1 - val_7;
            Channel val_8 = this.bgmChannels[val_7];
            if((this.bgmChannels[(1 - this.nextBgmChannelIndex)][0].playRequested) != true)
            {
                    if((this.bgmChannels[(1 - this.nextBgmChannelIndex)][0].<Playing>k__BackingField) == false)
            {
                goto label_7;
            }
            
            }
            
            float val_9 = this.silenceDb;
            val_9 = val_9 - (this.bgmChannels[(1 - this.nextBgmChannelIndex)][0].<BaseVolume>k__BackingField);
            val_9 = val_9 / val_8;
            this.bgmChannels[(1 - this.nextBgmChannelIndex)][0].fadeSpeed = val_9;
            goto label_15;
            label_2:
            val_7 = 0f;
            this.bgmReserved = true;
            label_16:
            val_8 = 0f;
            label_15:
            if((System.String.IsNullOrEmpty(value:  clipName)) != false)
            {
                    val_9 = this.nextBgmChannelIndex;
            }
            else
            {
                    val_9 = this;
                float val_11 = this.bgmVolume;
                val_11 = val_11 + this.masterVolume;
                this.bgmChannels[this.nextBgmChannelIndex].RequestPlay(clip:  this.clipManager.Load(name:  clipName), baseVolume:  volume, volumeModifier:  val_11, loop:  loop, pitch:  1f, delay:  val_8 - val_7, fadeDuration:  fadeInDuration, startWithPaused:  this.bgmReserved, silenceDb:  this.silenceDb);
            }
            
            int val_12 = val_7;
            val_12 = 1 - val_12;
            this.nextBgmChannelIndex = val_12;
            return;
            label_7:
            if(val_7 <= 0f)
            {
                goto label_15;
            }
            
            goto label_16;
        }
        public void PlaySe(string name, float volume = 0, bool loop = False, bool stopSame = True, float pitch = 1, float delay = 0)
        {
            System.DateTime val_10;
            var val_11;
            string val_12;
            if(this.muted == true)
            {
                    return;
            }
            
            float val_10 = this.masterVolume;
            val_10 = val_10 + this.seVolume;
            val_10 = val_10 + volume;
            if(val_10 <= this.silenceDb)
            {
                    return;
            }
            
            val_11 = 0;
            val_10 = System.DateTime.MaxValue;
            label_19:
            if(val_11 >= this.seChannels.Length)
            {
                goto label_6;
            }
            
            if(this.seChannels[0x0][0].playRequested != true)
            {
                    if((this.seChannels[0x0][0].<Playing>k__BackingField) == false)
            {
                goto label_10;
            }
            
            }
            
            if(stopSame == false)
            {
                goto label_11;
            }
            
            if((this.seChannels[0x0][0].<Clip>k__BackingField) == null)
            {
                goto label_12;
            }
            
            val_12 = this.seChannels[0x0][0].<Clip>k__BackingField.<Name>k__BackingField;
            if(name != null)
            {
                goto label_13;
            }
            
            label_12:
            val_12 = 0;
            label_13:
            if((name.Equals(value:  val_12)) == true)
            {
                goto label_16;
            }
            
            label_11:
            bool val_2 = System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = this.seChannels[0x0][0].<EstimatedEndTime>k__BackingField}, t2:  new System.DateTime() {dateData = val_10});
            var val_3 = (val_2 != true) ? (val_11) : -2147483647;
            var val_4 = (val_2 != true) ? this.seChannels[0x0][0].<EstimatedEndTime>k__BackingField : (val_10);
            label_21:
            val_11 = val_11 + 1;
            if(this.seChannels != null)
            {
                goto label_19;
            }
            
            label_10:
            var val_5 = ((-2147483647) >= 0) ? -2147483647 : (val_11);
            goto label_21;
            label_6:
            val_11 = -2147483647;
            goto label_22;
            label_16:
            this.seChannels[val_11].StopImmediately();
            label_22:
            var val_6 = (val_11 < 1) ? (val_11) : -2147483647;
            if((val_6 >> 31) != 0)
            {
                    return;
            }
            
            float val_13 = this.masterVolume;
            val_13 = this.seVolume + val_13;
            this.seChannels[val_6].RequestPlay(clip:  this.clipManager.Load(name:  name), baseVolume:  volume, volumeModifier:  val_13, loop:  loop, pitch:  pitch, delay:  delay, fadeDuration:  0f, startWithPaused:  false, silenceDb:  this.silenceDb);
        }
        public void StopBgm(float fadeDuration = 0.5)
        {
            this.PlayBgmInternal(clipName:  0, volume:  0f, loop:  false, fadeOutDuration:  fadeDuration, fadeInDuration:  0f, overlapDuration:  0f, ignoreSame:  false);
        }
        public void StopSe(string name, float fadeDuration = 0)
        {
            string val_2;
            if(this.seChannels.Length < 1)
            {
                    return;
            }
            
            var val_4 = 0;
            do
            {
                Channel val_2 = this.seChannels[val_4];
                if((this.seChannels[0x0][0].<Clip>k__BackingField) != null)
            {
                    val_2 = this.seChannels[0x0][0].<Clip>k__BackingField.<Name>k__BackingField;
            }
            else
            {
                    val_2 = 0;
            }
            
                if((System.String.op_Equality(a:  val_2, b:  name)) != false)
            {
                    float val_3 = this.silenceDb;
                val_3 = val_3 - (this.seChannels[0x0][0].<BaseVolume>k__BackingField);
                val_3 = val_3 / fadeDuration;
                this.seChannels[0x0][0].fadeSpeed = val_3;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < this.seChannels.Length);
        
        }
        public void StopAllLoopSe()
        {
            if(this.seChannels.Length < 1)
            {
                    return;
            }
            
            var val_3 = 0;
            do
            {
                if(this.seChannels[0x0][0].source.loop != false)
            {
                    this.seChannels[val_3].StopImmediately();
            }
            
                val_3 = val_3 + 1;
            }
            while(val_3 < this.seChannels.Length);
        
        }
        public void StopAllSe()
        {
            if(this.seChannels.Length < 1)
            {
                    return;
            }
            
            var val_2 = 0;
            do
            {
                this.seChannels[val_2].StopImmediately();
                val_2 = val_2 + 1;
            }
            while(val_2 < this.seChannels.Length);
        
        }
        public void StopAll(bool immediately = False)
        {
            if(immediately != false)
            {
                
            }
            
            this.PlayBgmInternal(clipName:  0, volume:  0f, loop:  false, fadeOutDuration:  0.5f, fadeInDuration:  0f, overlapDuration:  0f, ignoreSame:  false);
            this.StopAllSe();
        }
        private void Update()
        {
            if(this.autoUpdate == false)
            {
                    return;
            }
            
            this.ManualUpdate(deltaTime:  UnityEngine.Time.deltaTime);
        }
        public void ManualUpdate(float deltaTime)
        {
            this.clipManager.ManualUpdate(deltaTime:  deltaTime);
            if(this.seChannels.Length >= 1)
            {
                    var val_4 = 0;
                do
            {
                this.seChannels[val_4].ManualUpdate(deltaTime:  deltaTime, volumeModifier:  this.masterVolume + this.seVolume, silenceDb:  this.silenceDb);
                val_4 = val_4 + 1;
            }
            while(val_4 < this.seChannels.Length);
            
            }
            
            if(this.bgmChannels.Length >= 1)
            {
                    var val_6 = 0;
                do
            {
                this.bgmChannels[val_6].ManualUpdate(deltaTime:  deltaTime, volumeModifier:  this.masterVolume + this.bgmVolume, silenceDb:  this.silenceDb);
                val_6 = val_6 + 1;
            }
            while(val_6 < this.bgmChannels.Length);
            
            }
            
            if(this.bgmReserved == false)
            {
                    return;
            }
            
            int val_8 = this.nextBgmChannelIndex;
            Channel val_7 = this.bgmChannels[val_8];
            if(this.bgmChannels[this.nextBgmChannelIndex][0].playRequested == true)
            {
                    return;
            }
            
            if((this.bgmChannels[this.nextBgmChannelIndex][0].<Playing>k__BackingField) == true)
            {
                    return;
            }
            
            val_8 = 1 - val_8;
            Channel val_9 = this.bgmChannels[val_8];
            this.bgmChannels[(1 - this.nextBgmChannelIndex)][0].paused = false;
            this.bgmReserved = false;
        }
        public void UnloadUnused()
        {
            if(this.clipManager != null)
            {
                    this.clipManager.UnloadUnused();
                return;
            }
            
            throw new NullReferenceException();
        }
        private static float ToDecibel(float value)
        {
            if(value <= 0f)
            {
                    return -3.402823E+38f;
            }
            
            float val_1 = value;
            val_1 = val_1 * 20f;
            return -3.402823E+38f;
        }
        private static float FromDecibel(float decibel)
        {
            float val_1 = decibel / 20f;
        }
        public SoundManager()
        {
            this.seChannelCount = 4;
            this.silenceDb = -80f;
            this.clipCacheSize = 32;
            this.autoUpdate = true;
        }
    
    }

}
