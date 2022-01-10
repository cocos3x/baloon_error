using UnityEngine;
public class DebugMenu : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text _testGroupText;
    private UnityEngine.UI.Text _resolutionText;
    private UnityEngine.UI.Text _versionsText;
    private UnityEngine.UI.Toggle _fpsToggle;
    private UnityEngine.UI.Button _mediationDebuggerButton;
    private UnityEngine.UI.Button _closeButton;
    private UnityEngine.UI.Button _halfResolutionButton;
    private UnityEngine.UI.Button _restoreResolutionButton;
    private UnityEngine.UI.Button _allGunButton;
    private UnityEngine.GameObject _visibleRoot;
    private UnityEngine.UI.InputField _debugCommnadField;
    private CoreServices _core;
    private Manager _manager;
    private FPSCounter _fpsCounter;
    private int _originalWidth;
    private int _originalHeight;
    
    // Methods
    public void Init(CoreServices core, Manager manager, FPSCounter fpsCounter)
    {
        this._core = core;
        this._manager = manager;
        this._fpsCounter = fpsCounter;
        this._mediationDebuggerButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void DebugMenu::OnMediationDebuggerButtonClick()));
        this._halfResolutionButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void DebugMenu::OnHalfResolutionButtonClick()));
        this._restoreResolutionButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void DebugMenu::OnRestoreResolutionButtonClick()));
        this._allGunButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void DebugMenu::OnGetAllGunsButtonClick()));
        this._closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void DebugMenu::OnCloseButtonClick()));
        this._fpsToggle.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void DebugMenu::OnFpsToggleValueChanged(bool on)));
        this._debugCommnadField.m_OnEndEdit.AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  System.Void DebugMenu::OnEndEnterCommand(string input)));
        this._visibleRoot.SetActive(value:  false);
        this._originalWidth = UnityEngine.Screen.width;
        this._originalHeight = UnityEngine.Screen.height;
    }
    public void Show()
    {
        var val_15;
        object val_16;
        this._visibleRoot.SetActive(value:  true);
        System.Text.StringBuilder val_1 = new System.Text.StringBuilder();
        val_15 = 0;
        if((this._core.<saveData>k__BackingField.testGroupCount) >= 1)
        {
                object val_15 = 0;
            do
        {
            System.Text.StringBuilder val_4 = val_1.AppendFormat(format:  "group{0} : {1}\n", arg0:  val_15, arg1:  this._core.<saveData>k__BackingField.GetTestGroup(index:  0));
            val_15 = 0;
            val_15 = val_15 + 1;
        }
        while(val_15 < (this._core.<saveData>k__BackingField.testGroupCount));
        
        }
        
        System.Text.StringBuilder val_6 = val_1.Clear();
        System.Text.StringBuilder val_8 = val_1.AppendFormat(format:  "App  : {0}\n", arg0:  UnityEngine.Application.version);
        UnityEngine.TextAsset val_9 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "Kayac/BuildVersion");
        if(val_9 != 0)
        {
                val_16 = val_9.text;
        }
        else
        {
                val_16 = "Unknown";
        }
        
        System.Text.StringBuilder val_12 = val_1.AppendFormat(format:  "Build: {0}\n", arg0:  val_16);
        System.Text.StringBuilder val_14 = val_1.AppendFormat(format:  "Unity: {0}", arg0:  UnityEngine.Application.unityVersion);
    }
    private void Update()
    {
        UnityEngine.UI.Text val_5;
        if(UnityEngine.Time.frameCount != 63)
        {
                return;
        }
        
        val_5 = this._resolutionText;
        string val_4 = System.String.Format(format:  "{0} x {1}, rendererLevel : {2}", arg0:  UnityEngine.Screen.width, arg1:  UnityEngine.Screen.height, arg2:  this._core.<saveData>k__BackingField._rendererLevel);
    }
    private void OnCloseButtonClick()
    {
        if(this._visibleRoot != null)
        {
                this._visibleRoot.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OnMediationDebuggerButtonClick()
    {
        this._core.<adManager>k__BackingField.ShowMediationDebugger();
    }
    private void OnFpsToggleValueChanged(bool on)
    {
        if(this._fpsCounter != null)
        {
                this._fpsCounter.SetFpsViewEnabled(enable:  on);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OnHalfResolutionButtonClick()
    {
        int val_1 = UnityEngine.Screen.width;
        int val_2 = UnityEngine.Screen.height;
        int val_3 = (val_1 < 0) ? (val_1 + 1) : (val_1);
        val_3 = val_3 >> 1;
        UnityEngine.Screen.SetResolution(width:  val_3, height:  ((val_2 < 0) ? (val_2 + 1) : (val_2)) >> 1, fullscreen:  true);
    }
    private void OnRestoreResolutionButtonClick()
    {
        UnityEngine.Screen.SetResolution(width:  this._originalWidth, height:  this._originalHeight, fullscreen:  true);
    }
    private void OnGetAllGunsButtonClick()
    {
        this._core.<saveData>k__BackingField.GetAllGuns();
    }
    private void OnEndEnterCommand(string input)
    {
        char[] val_1 = new char[1];
        val_1[0] = '_';
        System.String[] val_2 = input.Split(separator:  val_1);
        if((System.String.op_Equality(a:  val_2[0], b:  "level")) == false)
        {
                return;
        }
        
        var val_7 = 0;
        do
        {
            val_7 = val_7 + 1;
            if(val_7 >= (System.Int32.Parse(s:  val_2[1])))
        {
                return;
        }
        
            this._core.<saveData>k__BackingField.IncrementLastLevelIndex();
        }
        while(val_2.Length > 1);
        
        throw new IndexOutOfRangeException();
    }
    public DebugMenu()
    {
    
    }

}
