using UnityEngine;

namespace Kayac
{
    public class GdprDialog : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image blackScreen;
        private bool _accepted;
        
        // Methods
        private void Awake()
        {
            if(this.blackScreen != null)
            {
                    this.blackScreen.enabled = false;
                return;
            }
            
            throw new NullReferenceException();
        }
        public void ShowBlackScreen()
        {
            if(this.blackScreen != null)
            {
                    this.blackScreen.enabled = true;
                return;
            }
            
            throw new NullReferenceException();
        }
        public System.Collections.IEnumerator CoShow()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new GdprDialog.<CoShow>d__4();
        }
        public void OnClickGdprPrivacyPolicy()
        {
            UnityEngine.Debug.Log(message:  "OnClickGdprPrivacyPolicy");
            UnityEngine.Application.OpenURL(url:  "http://hypercasual.kayac.com/privacy-policy");
        }
        public void OnClickGdprAccept()
        {
            UnityEngine.Debug.Log(message:  "OnClickGdprAccept");
            this._accepted = true;
        }
        public GdprDialog()
        {
        
        }
    
    }

}
