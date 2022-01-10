using UnityEngine;

namespace Kayac
{
    public class FirebaseWrapper
    {
        // Fields
        private bool <AnalyticsInitializing>k__BackingField;
        private bool <RemoteConfigInitializing>k__BackingField;
        private bool <AnalyticsReady>k__BackingField;
        private bool <RemoteConfigReady>k__BackingField;
        private System.Action <OnRemoteConfigFetched>k__BackingField;
        private string remoteConfigCachePath;
        private System.Collections.Generic.Queue<Kayac.FirebaseWrapper.Event> eventQueue;
        private Kayac.FirebaseWrapper.UserProperty userProperty;
        private System.Collections.Generic.Dictionary<string, Kayac.FirebaseWrapper.ConfigDataItem> config;
        private bool fetchForced;
        private Kayac.FileWriter fileWriter;
        private Firebase.RemoteConfig.FirebaseRemoteConfig remoteConfigInstance;
        
        // Properties
        public bool AnalyticsInitializing { get; set; }
        public bool RemoteConfigInitializing { get; set; }
        public bool AnalyticsReady { get; set; }
        public bool RemoteConfigReady { get; set; }
        private System.Action OnRemoteConfigFetched { get; set; }
        
        // Methods
        public bool get_AnalyticsInitializing()
        {
            return (bool)this.<AnalyticsInitializing>k__BackingField;
        }
        private void set_AnalyticsInitializing(bool value)
        {
            this.<AnalyticsInitializing>k__BackingField = value;
        }
        public bool get_RemoteConfigInitializing()
        {
            return (bool)this.<RemoteConfigInitializing>k__BackingField;
        }
        private void set_RemoteConfigInitializing(bool value)
        {
            this.<RemoteConfigInitializing>k__BackingField = value;
        }
        public bool get_AnalyticsReady()
        {
            return (bool)this.<AnalyticsReady>k__BackingField;
        }
        private void set_AnalyticsReady(bool value)
        {
            this.<AnalyticsReady>k__BackingField = value;
        }
        public bool get_RemoteConfigReady()
        {
            return (bool)this.<RemoteConfigReady>k__BackingField;
        }
        private void set_RemoteConfigReady(bool value)
        {
            this.<RemoteConfigReady>k__BackingField = value;
        }
        private System.Action get_OnRemoteConfigFetched()
        {
            return (System.Action)this.<OnRemoteConfigFetched>k__BackingField;
        }
        public void set_OnRemoteConfigFetched(System.Action value)
        {
            this.<OnRemoteConfigFetched>k__BackingField = value;
        }
        public FirebaseWrapper(Kayac.FileWriter fileWriter, string remoteConfigCachePath)
        {
            val_1 = new System.Object();
            this.fileWriter = fileWriter;
            this.config = new System.Collections.Generic.Dictionary<System.String, ConfigDataItem>();
            this.remoteConfigCachePath = val_1;
            if((System.String.IsNullOrEmpty(value:  string val_1 = remoteConfigCachePath)) != false)
            {
                    this.remoteConfigCachePath = Kayac.FirebaseWrapper.MakeDefaultCachePath();
            }
            
            this.<AnalyticsInitializing>k__BackingField = true;
            this.<RemoteConfigInitializing>k__BackingField = true;
            UnityEngine.Debug.Log(message:  "FirebaseManager() time="("FirebaseManager() time=") + UnityEngine.Time.realtimeSinceStartup);
            this.eventQueue = new System.Collections.Generic.Queue<Event>();
            if(this.LoadCachedRemoteConfig() == false)
            {
                    return;
            }
            
            this.<RemoteConfigReady>k__BackingField = true;
            this.<RemoteConfigInitializing>k__BackingField = false;
        }
        public void Initialize(bool fetchForced)
        {
            this.fetchForced = fetchForced;
            UnityEngine.SystemLanguage val_2 = UnityEngine.Application.systemLanguage;
            if(val_2 != 40)
            {
                    if(val_2 != 6)
            {
                goto label_2;
            }
            
            }
            
            UnityEngine.Debug.Log(message:  "FirebaseManager() IsInChina() == true. skip all.");
            this.<AnalyticsInitializing>k__BackingField = false;
            this.<RemoteConfigInitializing>k__BackingField = false;
            this.<RemoteConfigReady>k__BackingField = true;
            goto label_5;
            label_2:
            System.Threading.Tasks.Task val_5 = Firebase.Extensions.TaskExtension.ContinueWithOnMainThread<Firebase.DependencyStatus>(task:  Firebase.FirebaseApp.CheckAndFixDependenciesAsync(), continuation:  new System.Action<System.Threading.Tasks.Task<Firebase.DependencyStatus>>(object:  this, method:  System.Void Kayac.FirebaseWrapper::<Initialize>b__23_0(System.Threading.Tasks.Task<Firebase.DependencyStatus> task)));
            label_5:
            Param[] val_6 = new Param[1];
            float val_9 = 1000f;
            val_9 = UnityEngine.Time.realtimeSinceStartup * val_9;
            val_6[3] = UnityEngine.Mathf.RoundToInt(f:  val_9);
            val_6[3] = 0;
            val_6[0] = 9.88131291682493E-324;
            val_6[1] = "arg";
            val_6[2] = 0;
            this.AddEvent(eventType:  0, parameters:  val_6);
        }
        public bool GetConfig(string key, out bool value)
        {
            bool val_6;
            value = false;
            if((this.config.TryGetValue(key:  key, value: out  0)) != false)
            {
                    string val_3 = 3613776.ToLower();
                if((System.String.op_Equality(a:  val_3, b:  "true")) != false)
            {
                    val_6 = true;
                value = val_6;
                return (bool)val_6;
            }
            
                if((System.String.op_Equality(a:  val_3, b:  "false")) != false)
            {
                    val_6 = 1;
                value = false;
                return (bool)val_6;
            }
            
            }
            
            val_6 = 0;
            return (bool)val_6;
        }
        public bool GetConfigBool(string key, bool defaultValue = False)
        {
            bool val_5;
            bool val_1 = false;
            if((this.GetConfig(key:  key, value: out  val_1)) != false)
            {
                    val_5 = val_1;
                return (bool)(val_5 == true) ? 1 : 0;
            }
            
            val_5 = defaultValue;
            return (bool)(val_5 == true) ? 1 : 0;
        }
        public bool GetConfig(string key, out int value)
        {
            var val_5;
            value = 0;
            if((this.config.TryGetValue(key:  key, value: out  0)) != false)
            {
                    if((System.Int64.TryParse(s:  3613776, result: out  0)) != false)
            {
                    value = 0;
            }
            
                val_5 = 1;
                return (bool)val_5;
            }
            
            val_5 = 0;
            return (bool)val_5;
        }
        public int GetConfigInt(string key, int defaultValue = 0)
        {
            int val_3 = defaultValue;
            int val_1 = 0;
            if((this.GetConfig(key:  key, value: out  val_1)) == false)
            {
                    return val_3;
            }
            
            val_3 = val_1;
            return val_3;
        }
        public bool GetConfig(string key, out float value)
        {
            var val_5;
            value = 0f;
            if((this.config.TryGetValue(key:  key, value: out  0)) != false)
            {
                    bool val_4 = System.Single.TryParse(s:  3613776, result: out  -1.979428E-13f);
                val_5 = 1;
                return (bool)val_5;
            }
            
            val_5 = 0;
            return (bool)val_5;
        }
        public float GetConfigFloat(string key, float defaultValue = 0)
        {
            float val_3 = defaultValue;
            if((this.GetConfig(key:  key, value: out  float val_1 = -1.990295E-13f)) == false)
            {
                    return val_3;
            }
            
            val_3 = 0f;
            return val_3;
        }
        public bool GetConfig(string key, out string value)
        {
            var val_3;
            value = 0;
            if((this.config.TryGetValue(key:  key, value: out  0)) != false)
            {
                    val_3 = 1;
                value = 3613776;
                return (bool)val_3;
            }
            
            val_3 = 0;
            return (bool)val_3;
        }
        public string GetConfigString(string key, string defaultValue)
        {
            string val_3 = defaultValue;
            string val_1 = 0;
            if((this.GetConfig(key:  key, value: out  val_1)) == false)
            {
                    return val_3;
            }
            
            val_3 = val_1;
            return val_3;
        }
        public void AddEvent(Kayac.FirebaseWrapper.EventType eventType, Kayac.FirebaseWrapper.Param[] parameters)
        {
            if((this.<AnalyticsInitializing>k__BackingField) != true)
            {
                    if((this.<AnalyticsReady>k__BackingField) == false)
            {
                    return;
            }
            
            }
            
            this.eventQueue.Enqueue(item:  new Event() {type = eventType, parameters = parameters});
            this.TrySendFirebase();
        }
        public void AddEvent(string customEventName, Kayac.FirebaseWrapper.Param[] parameters)
        {
            if((this.<AnalyticsInitializing>k__BackingField) != true)
            {
                    if((this.<AnalyticsReady>k__BackingField) == false)
            {
                    return;
            }
            
            }
            
            this.eventQueue.Enqueue(item:  new Event() {type = 1.48219693752374E-323, customName = customEventName, parameters = parameters});
            this.TrySendFirebase();
        }
        public void AddErrorEvent(string message)
        {
            Param[] val_1 = new Param[1];
            val_1[0] = 0;
            val_1[2] = 0;
            this.AddEvent(customEventName:  "ky_error", parameters:  val_1);
        }
        public void SetUserProperty(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>> properties)
        {
            .pairs = properties;
            .<Sent>k__BackingField = false;
            this.userProperty = new FirebaseWrapper.UserProperty();
            this.TrySendFirebase();
        }
        public static void DeleteCacheDefaultPath()
        {
            Kayac.FirebaseWrapper.DeleteCache(path:  Kayac.FirebaseWrapper.MakeDefaultCachePath());
        }
        public void DeleteCache()
        {
            Kayac.FirebaseWrapper.DeleteCache(path:  this.remoteConfigCachePath);
        }
        private void FetchRemoteConfig()
        {
            UnityEngine.Debug.Log(message:  "FirebaseRemoteConfig Fetch Start: time="("FirebaseRemoteConfig Fetch Start: time=") + UnityEngine.Time.realtimeSinceStartup);
            Firebase.RemoteConfig.FirebaseRemoteConfig val_3 = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance;
            this.remoteConfigInstance = val_3;
            if(this.fetchForced != false)
            {
                    System.Threading.Tasks.Task val_6 = Firebase.Extensions.TaskExtension.ContinueWithOnMainThread(task:  val_3.FetchAsync(cacheExpiration:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero}), continuation:  new System.Action<System.Threading.Tasks.Task>(object:  this, method:  System.Void Kayac.FirebaseWrapper::<FetchRemoteConfig>b__49_0(System.Threading.Tasks.Task fetchTask)));
                return;
            }
            
            System.Threading.Tasks.Task val_9 = Firebase.Extensions.TaskExtension.ContinueWithOnMainThread<System.Boolean>(task:  val_3.FetchAndActivateAsync(), continuation:  new System.Action<System.Threading.Tasks.Task<System.Boolean>>(object:  this, method:  System.Void Kayac.FirebaseWrapper::<FetchRemoteConfig>b__49_1(System.Threading.Tasks.Task<bool> activateTask)));
        }
        private void OnRemoteConfigFetchComplete(bool activated)
        {
            System.Action<System.Threading.Tasks.Task<T>> val_10;
            int val_11;
            this.<AnalyticsReady>k__BackingField = true;
            this.TrySendFirebase();
            val_10 = this.remoteConfigInstance.Info;
            object[] val_2 = new object[4];
            val_2[0] = "FirebaseRemoteConfig Fetched: time=";
            val_11 = val_2.Length;
            val_2[1] = UnityEngine.Time.realtimeSinceStartup;
            val_11 = val_2.Length;
            val_2[2] = " status=";
            val_2[3] = val_10.LastFetchStatus;
            UnityEngine.Debug.Log(message:  +val_2);
            if(val_10.LastFetchStatus != 0)
            {
                    if((this.<OnRemoteConfigFetched>k__BackingField) != null)
            {
                    this.<OnRemoteConfigFetched>k__BackingField.Invoke();
            }
            
                this.<RemoteConfigInitializing>k__BackingField = false;
                return;
            }
            
            if(activated != false)
            {
                    this.OnRemoteConfigActivateComplete();
                return;
            }
            
            System.Action<System.Threading.Tasks.Task<System.Boolean>> val_8 = null;
            val_10 = val_8;
            val_8 = new System.Action<System.Threading.Tasks.Task<System.Boolean>>(object:  this, method:  System.Void Kayac.FirebaseWrapper::<OnRemoteConfigFetchComplete>b__50_0(System.Threading.Tasks.Task<bool> activateTask));
            System.Threading.Tasks.Task val_9 = Firebase.Extensions.TaskExtension.ContinueWithOnMainThread<System.Boolean>(task:  this.remoteConfigInstance.ActivateAsync(), continuation:  val_8);
        }
        private void OnRemoteConfigActivateComplete()
        {
            UnityEngine.Debug.Log(message:  "FirebaseRemoteConfig Activated: time="("FirebaseRemoteConfig Activated: time=") + UnityEngine.Time.realtimeSinceStartup);
            this.OnRemoteConfigFixed(data:  this.LoadFetchedRemoteConfig());
        }
        private void OnRemoteConfigFixed(Kayac.FirebaseWrapper.ConfigData data)
        {
            if(data != null)
            {
                    this.ApplyConfig(data:  data);
                this.<RemoteConfigReady>k__BackingField = true;
            }
            
            if((this.<OnRemoteConfigFetched>k__BackingField) != null)
            {
                    this.<OnRemoteConfigFetched>k__BackingField.Invoke();
            }
            
            this.<RemoteConfigInitializing>k__BackingField = false;
        }
        private void ApplyConfig(Kayac.FirebaseWrapper.ConfigData data)
        {
            System.Collections.Generic.Dictionary<System.String, ConfigDataItem> val_2;
            this.config.Clear();
            List.Enumerator<T> val_1 = data.items.GetEnumerator();
            label_7:
            if(((-1434559512) & 1) == 0)
            {
                goto label_4;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_2 = this.config;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_2.set_Item(key:  11993091, value:  0);
            goto label_7;
            label_4:
            UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
            Kayac.FirebaseWrapper.DumpRemoteConfig(items:  data.items);
            this.SaveCache();
        }
        private Kayac.FirebaseWrapper.ConfigData LoadFetchedRemoteConfig()
        {
            string val_10;
            ConfigDataItem val_13;
            var val_15;
            var val_16;
            if(this.remoteConfigInstance == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Collections.Generic.IDictionary<System.String, Firebase.RemoteConfig.ConfigValue> val_1 = this.remoteConfigInstance.AllValues;
            FirebaseWrapper.ConfigData val_2 = new FirebaseWrapper.ConfigData();
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_13 = 0;
            val_13 = val_13 + 1;
            System.Collections.Generic.IEnumerator<T> val_4 = val_1.GetEnumerator();
            label_19:
            var val_14 = 0;
            val_14 = val_14 + 1;
            if(val_4.MoveNext() == false)
            {
                goto label_12;
            }
            
            var val_15 = 0;
            val_15 = val_15 + 1;
            T val_8 = val_4.Current;
            FirebaseWrapper.ConfigDataItem val_11 = null;
            val_13 = val_11;
            val_11 = new FirebaseWrapper.ConfigDataItem();
            .key = val_10;
            .stringValue = ;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((FirebaseWrapper.ConfigData)[1152921507467461072].items == null)
            {
                    throw new NullReferenceException();
            }
            
            (FirebaseWrapper.ConfigData)[1152921507467461072].items.Add(item:  val_11);
            goto label_19;
            label_12:
            val_13 = 0;
            if(val_4 != null)
            {
                    var val_16 = 0;
                val_16 = val_16 + 1;
                val_4.Dispose();
            }
            
            if(val_13 != 0)
            {
                    throw val_13;
            }
            
            return (ConfigData)val_2;
            label_44:
            val_15 = 0;
            val_16 = val_13;
            if( != 1)
            {
                goto label_39;
            }
            
            if((null & 1) != 0)
            {
                    UnityEngine.Debug.LogException(exception:  1152921504792096768);
                return (ConfigData)val_2;
            }
            
            mem[8] = null;
            goto label_44;
            label_39:
        }
        private void StartAnalytics()
        {
            this.<AnalyticsReady>k__BackingField = true;
            this.TrySendFirebase();
        }
        private bool LoadCachedRemoteConfig()
        {
            var val_2;
            ConfigData val_1 = Kayac.FirebaseWrapper.LoadCachedRemoteConfig(remoteConfigCachePath:  this.remoteConfigCachePath);
            if(val_1 == null)
            {
                    return (bool)val_2;
            }
            
            this.ApplyCachedRemoteConfigData(data:  val_1);
            Kayac.FirebaseWrapper.DumpRemoteConfig(items:  val_1.items);
            val_2 = 1;
            return (bool)val_2;
        }
        private void ApplyCachedRemoteConfigData(Kayac.FirebaseWrapper.ConfigData data)
        {
            System.Collections.Generic.Dictionary<System.String, ConfigDataItem> val_2;
            this.config.Clear();
            List.Enumerator<T> val_1 = data.items.GetEnumerator();
            label_7:
            if(((-1434002840) & 1) == 0)
            {
                goto label_4;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_2 = this.config;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_2.Add(key:  11993091, value:  0);
            goto label_7;
            label_4:
            UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
        }
        private static void DumpRemoteConfig(System.Collections.Generic.IList<Kayac.FirebaseWrapper.ConfigDataItem> items)
        {
            var val_7;
            string val_8;
            val_7 = items;
            System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_8 = "[Fireabse.RemoteConfig]";
            System.Text.StringBuilder val_2 = val_1.AppendLine(value:  val_8);
            if(val_7 == null)
            {
                goto label_2;
            }
            
            var val_10 = 0;
            val_10 = val_10 + 1;
            val_7 = val_7.GetEnumerator();
            label_17:
            var val_11 = 0;
            val_11 = val_11 + 1;
            val_8 = public System.Boolean System.Collections.IEnumerator::MoveNext();
            if(val_7.MoveNext() == false)
            {
                goto label_12;
            }
            
            var val_12 = 0;
            val_12 = val_12 + 1;
            Kayac.FirebaseWrapper.DumpRemoteConfig(sb:  val_1, item:  val_7.Current);
            goto label_17;
            label_12:
            if(val_7 != null)
            {
                    var val_13 = 0;
                val_13 = val_13 + 1;
                val_8 = public System.Void System.IDisposable::Dispose();
                val_7.Dispose();
            }
            
            if(0 != 0)
            {
                    throw X21;
            }
            
            label_2:
            UnityEngine.Debug.Log(message:  val_1);
        }
        private static void DumpRemoteConfig(System.Text.StringBuilder sb, Kayac.FirebaseWrapper.ConfigDataItem item)
        {
            string val_8;
            System.Text.StringBuilder val_1 = sb.Append(value:  "\t");
            System.Text.StringBuilder val_2 = sb.Append(value:  item.key);
            System.Text.StringBuilder val_3 = sb.Append(value:  " = ");
            if(item.stringValue.m_stringLength >= 33)
            {
                    System.Text.StringBuilder val_5 = sb.Append(value:  item.stringValue.Substring(startIndex:  0, length:  32));
                val_8 = "...\n";
            }
            else
            {
                    System.Text.StringBuilder val_6 = sb.Append(value:  item.stringValue);
                val_8 = "\n";
            }
            
            System.Text.StringBuilder val_7 = sb.Append(value:  val_8);
        }
        private static Kayac.FirebaseWrapper.ConfigData LoadCachedRemoteConfig(string remoteConfigCachePath)
        {
            return (ConfigData)UnityEngine.JsonUtility.FromJson<ConfigData>(json:  System.IO.File.ReadAllText(path:  remoteConfigCachePath));
        }
        private void SaveCache()
        {
            var val_7;
            System.Action<System.Exception> val_9;
            .items = new System.Collections.Generic.List<ConfigDataItem>();
            Dictionary.ValueCollection.Enumerator<TKey, TValue> val_4 = this.config.Values.GetEnumerator();
            label_6:
            if(((-1433349560) & 1) == 0)
            {
                goto label_4;
            }
            
            if((FirebaseWrapper.ConfigData)[1152921507468508800].items == null)
            {
                    throw new NullReferenceException();
            }
            
            (FirebaseWrapper.ConfigData)[1152921507468508800].items.Add(item:  0);
            goto label_6;
            label_4:
            UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
            val_7 = null;
            val_7 = null;
            val_9 = FirebaseWrapper.<>c.<>9__61_0;
            if(val_9 == null)
            {
                    System.Action<System.Exception> val_6 = null;
                val_9 = val_6;
                val_6 = new System.Action<System.Exception>(object:  FirebaseWrapper.<>c.__il2cppRuntimeField_static_fields, method:  System.Void FirebaseWrapper.<>c::<SaveCache>b__61_0(System.Exception e));
                FirebaseWrapper.<>c.<>9__61_0 = val_9;
            }
            
            this.fileWriter.SaveAsync(path:  this.remoteConfigCachePath, text:  UnityEngine.JsonUtility.ToJson(obj:  new FirebaseWrapper.ConfigData(), prettyPrint:  true), onComplete:  val_6);
        }
        private void TrySendFirebase()
        {
            if((this.<AnalyticsReady>k__BackingField) == false)
            {
                    return;
            }
            
            if(this.userProperty == null)
            {
                    return;
            }
            
            if((this.userProperty.<Sent>k__BackingField) != true)
            {
                    this.userProperty.Send();
            }
            
            if(this.eventQueue != null)
            {
                    do
            {
                if((this.userProperty.<Sent>k__BackingField) <= false)
            {
                    return;
            }
            
                Event val_1 = this.eventQueue.Dequeue();
            }
            while(this.eventQueue != null);
            
                throw new NullReferenceException();
            }
            
            UnityEngine.Debug.LogError(message:  "eventQueue == null. 100%バグ。");
        }
        private static string MakeDefaultCachePath()
        {
            return Kayac.SaveDataPathUtil.MakeFullPath(relativePath:  "kayac_firebase_manager_cache.json");
        }
        private static void DeleteCache(string path)
        {
            System.IO.File.Delete(path:  path);
        }
        private static bool IsInChina()
        {
            var val_2;
            UnityEngine.SystemLanguage val_1 = UnityEngine.Application.systemLanguage;
            if(val_1 != 40)
            {
                    if(val_1 != 6)
            {
                goto label_1;
            }
            
            }
            
            val_2 = 1;
            return (bool)val_2;
            label_1:
            val_2 = 0;
            return (bool)val_2;
        }
        private void <Initialize>b__23_0(System.Threading.Tasks.Task<Firebase.DependencyStatus> task)
        {
            var val_7;
            int val_8;
            object[] val_1 = new object[4];
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_7 = "FirebaseApp.CheckAndFixDependenciesAsync End: time=";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_1.Length == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[0] = "FirebaseApp.CheckAndFixDependenciesAsync End: time=";
            float val_2 = UnityEngine.Time.realtimeSinceStartup;
            if(val_2 != 0)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
            val_8 = val_1.Length;
            if(val_8 <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[1] = val_2;
            val_7 = " Status=";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_8 = val_1.Length;
            if(val_8 <= 2)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_1[2] = " Status=";
            val_1[3] = task.Result;
            UnityEngine.Debug.Log(message:  +val_1);
            this.<AnalyticsInitializing>k__BackingField = false;
            Firebase.DependencyStatus val_5 = task.Result;
            if(val_5 != 0)
            {
                    UnityEngine.Debug.LogError(message:  "Firebase Dependencies error: "("Firebase Dependencies error: ") + val_5);
                return;
            }
            
            this.FetchRemoteConfig();
        }
        private void <FetchRemoteConfig>b__49_0(System.Threading.Tasks.Task fetchTask)
        {
            this.OnRemoteConfigFetchComplete(activated:  false);
        }
        private void <FetchRemoteConfig>b__49_1(System.Threading.Tasks.Task<bool> activateTask)
        {
            this.OnRemoteConfigFetchComplete(activated:  true);
        }
        private void <OnRemoteConfigFetchComplete>b__50_0(System.Threading.Tasks.Task<bool> activateTask)
        {
            this.OnRemoteConfigActivateComplete();
        }
    
    }

}
