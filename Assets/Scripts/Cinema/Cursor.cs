using UnityEngine;

namespace Cinema
{
    public class Cursor : MonoBehaviour
    {
        // Fields
        private UnityEngine.GameObject _cursorGameObject;
        private UnityEngine.GameObject _centerGameObject;
        private UnityEngine.UI.Image _cursorImage;
        private Cinema.SettingData _settingData;
        private UnityEngine.RectTransform _rectTransform;
        private bool _initialized;
        private float _alpha;
        private bool _changing;
        
        // Methods
        public void Init()
        {
            Cinema.SettingData val_1 = UnityEngine.Resources.Load<Cinema.SettingData>(path:  "CursorSetting");
            this._settingData = val_1;
            if(val_1 == 0)
            {
                    return;
            }
            
            UnityEngine.Canvas val_4 = this.gameObject.AddComponent<UnityEngine.Canvas>();
            val_4.renderMode = 0;
            val_4.sortingOrder = 232;
            UnityEngine.UI.CanvasScaler val_6 = this.gameObject.AddComponent<UnityEngine.UI.CanvasScaler>();
            UnityEngine.GameObject val_7 = new UnityEngine.GameObject(name:  "Cusor");
            this._cursorGameObject = val_7;
            val_7.transform.parent = this.transform;
            UnityEngine.GameObject val_10 = new UnityEngine.GameObject(name:  "CenterImage");
            this._centerGameObject = val_10;
            val_10.transform.parent = this.transform;
            UnityEngine.UI.Image val_13 = val_10.AddComponent<UnityEngine.UI.Image>();
            val_13.sprite = UnityEngine.Resources.Load<UnityEngine.Sprite>(path:  "CenterCircle");
            UnityEngine.Color val_15 = UnityEngine.Color.red;
            val_13.color = new UnityEngine.Color() {r = val_15.r, g = val_15.g, b = val_15.b, a = val_15.a};
            UnityEngine.Vector3 val_17 = UnityEngine.Vector3.one;
            UnityEngine.Vector3 val_18 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z}, d:  0.1f);
            val_10.GetComponent<UnityEngine.RectTransform>().localScale = new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z};
            UnityEngine.Vector3 val_20 = UnityEngine.Vector3.zero;
            val_10.GetComponent<UnityEngine.RectTransform>().localPosition = new UnityEngine.Vector3() {x = val_20.x, y = val_20.y, z = val_20.z};
            if(this._settingData.normalHand == 0)
            {
                    UnityEngine.Debug.LogError(message:  "カーソル画像が設定されていないよ！");
            }
            else
            {
                    UnityEngine.UI.Image val_22 = this._cursorGameObject.AddComponent<UnityEngine.UI.Image>();
                this._cursorImage = val_22;
                val_22.sprite = this._settingData.normalHand;
                this._rectTransform = this._cursorGameObject.GetComponent<UnityEngine.RectTransform>();
            }
            
            this._initialized = true;
        }
        private void Update()
        {
            float val_46;
            float val_47;
            float val_51;
            Cinema.SettingData val_52;
            if(this._initialized == false)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_1 = UnityEngine.Input.mousePosition;
            val_46 = val_1.x;
            val_47 = 0f;
            UnityEngine.Quaternion val_3 = UnityEngine.Quaternion.Euler(euler:  new UnityEngine.Vector3() {x = 0f, y = 0f, z = val_47});
            this._cursorGameObject.transform.localRotation = new UnityEngine.Quaternion() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w};
            this._rectTransform.pivot = new UnityEngine.Vector2() {x = this._settingData.center, y = val_3.y};
            if(this._settingData.flip != false)
            {
                    val_51 = 0f;
                val_47 = 0f;
            }
            else
            {
                    UnityEngine.Vector3 val_5 = UnityEngine.Vector3.one;
                UnityEngine.Vector3 val_6 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, d:  this._settingData.scale);
            }
            
            this._cursorGameObject.transform.localScale = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
            if(val_46 >= 0)
            {
                goto label_19;
            }
            
            label_44:
            if(this._settingData.backToCenter == false)
            {
                goto label_21;
            }
            
            int val_7 = UnityEngine.Screen.width;
            int val_8 = UnityEngine.Screen.height;
            var val_9 = (val_7 < 0) ? (val_7 + 1) : (val_7);
            val_9 = val_9 >> 1;
            UnityEngine.Vector2 val_12 = new UnityEngine.Vector2(x:  (float)val_9, y:  (float)((val_8 < 0) ? (val_8 + 1) : (val_8)) >> 1);
            UnityEngine.Vector3 val_15 = this._cursorGameObject.transform.position;
            val_46 = val_15.x;
            UnityEngine.Vector3 val_16 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_12.x, y = val_12.y});
            label_51:
            UnityEngine.Vector3 val_17 = UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = val_46, y = val_15.y, z = val_15.z}, b:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z}, t:  this._settingData.smooth);
            this._cursorGameObject.transform.position = new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z};
            label_21:
            if((UnityEngine.Input.GetMouseButtonDown(button:  0)) != false)
            {
                    if(this._settingData.tapedHand != 0)
            {
                    UnityEngine.Coroutine val_21 = this.StartCoroutine(routine:  this.ChangeCursorImage(ontaped:  true));
            }
            
            }
            
            if((UnityEngine.Input.GetMouseButtonUp(button:  0)) != false)
            {
                    UnityEngine.Coroutine val_24 = this.StartCoroutine(routine:  this.ChangeCursorImage(ontaped:  false));
            }
            
            val_52 = this._settingData;
            if(this._settingData.DisplayType > 4)
            {
                goto label_38;
            }
            
            var val_45 = 11320520;
            val_45 = (11320520 + (this._settingData.DisplayType) << 2) + val_45;
            goto (11320520 + (this._settingData.DisplayType) << 2 + 11320520);
            label_19:
            if(((val_1.y < 0) || (val_46 > (float)UnityEngine.Screen.width)) || (val_1.y > (float)UnityEngine.Screen.height))
            {
                goto label_44;
            }
            
            UnityEngine.Transform val_28 = this._cursorGameObject.transform;
            UnityEngine.Vector3 val_30 = this._cursorGameObject.transform.position;
            goto label_51;
            label_38:
            if((this._settingData.DisplayType != 2) && (this._settingData.DisplayType != 4))
            {
                    Cinema.ImageExt.SetAlpha(image:  this._cursorImage, alpha:  1f);
                val_52 = this._settingData;
            }
            
            this._centerGameObject.SetActive(value:  this._settingData.centerAdjustment);
        }
        private System.Collections.IEnumerator FadeIn()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new Cursor.<FadeIn>d__9();
        }
        private System.Collections.IEnumerator FadeOut()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new Cursor.<FadeOut>d__10();
        }
        private System.Collections.IEnumerator ChangeCursorImage(bool ontaped)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .ontaped = ontaped;
            return (System.Collections.IEnumerator)new Cursor.<ChangeCursorImage>d__12();
        }
        public Cursor()
        {
        
        }
    
    }

}
