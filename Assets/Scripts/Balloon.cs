using UnityEngine;
public class Balloon : MonoBehaviour
{
    // Fields
    private UnityEngine.MeshRenderer[] _meshRenderers;
    private UnityEngine.Collider[] _ignoreColliders;
    private Balloon _crushSame;
    private UnityEngine.MeshFilter _meshFilter;
    private float _uvX;
    private bool _randomColor;
    private bool _useAlpha;
    private float _fixedAlpha;
    private bool _isRocket;
    private bool _withConfetti;
    private UnityEngine.ParticleSystem _balloonFX;
    private Enemy _enemy;
    private UnityEngine.Color _color;
    private float _startY;
    private bool _isHit;
    private System.Collections.Generic.List<Balloon> _childBalloons;
    private static readonly int _baseColor;
    private static readonly int _emissionColor;
    
    // Methods
    private void Awake()
    {
        float val_13;
        if(this._meshFilter == 0)
        {
                return;
        }
        
        UnityEngine.Vector3[] val_3 = this._meshFilter.mesh.vertices;
        UnityEngine.Vector2[] val_4 = new UnityEngine.Vector2[0];
        if(this._randomColor != false)
        {
                val_13 = 0f;
            this._uvX = UnityEngine.Random.Range(min:  val_13, max:  1f);
        }
        else
        {
                val_13 = this._uvX;
        }
        
        UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  val_13, y:  0f);
        if((val_4.Length << 32) >= 1)
        {
                var val_13 = 0;
            do
        {
            mem2[0] = val_6.x;
            val_13 = val_13 + 1;
        }
        while(val_13 < (long)val_4.Length);
        
        }
        
        this._meshFilter.mesh.uv = val_4;
        if(this._useAlpha == false)
        {
                return;
        }
        
        UnityEngine.MeshRenderer val_9 = this._meshFilter.GetComponent<UnityEngine.MeshRenderer>();
        UnityEngine.Color val_11 = val_9.material.color;
        val_9.material.color = new UnityEngine.Color() {r = val_11.r, g = val_11.g, b = val_11.b, a = this._fixedAlpha};
    }
    public void BalloonSetUp(UnityEngine.Transform currentNode, Balloon parent, UnityEngine.Color randomColor, Enemy enemy)
    {
        Enemy val_9;
        var val_10;
        var val_13;
        val_9 = enemy;
        Balloon val_8 = 0;
        if(currentNode == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_1 = currentNode.gameObject;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_2 = val_1.transform;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10 = val_2.GetEnumerator();
        label_24:
        var val_10 = 0;
        val_10 = val_10 + 1;
        if(val_10.MoveNext() == false)
        {
            goto label_9;
        }
        
        var val_11 = 0;
        val_11 = val_11 + 1;
        object val_7 = val_10.Current;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_7.TryGetComponent<Balloon>(component: out  val_8)) == false)
        {
            goto label_24;
        }
        
        if(parent == null)
        {
                throw new NullReferenceException();
        }
        
        if(parent._childBalloons == null)
        {
                throw new NullReferenceException();
        }
        
        parent._childBalloons.Add(item:  val_8);
        if(val_8 == 0)
        {
                throw new NullReferenceException();
        }
        
        this.Init(enemy:  val_9, randomColor:  new UnityEngine.Color() {r = randomColor.r, g = randomColor.g, b = randomColor.b, a = randomColor.a});
        goto label_24;
        label_9:
        val_9 = 0;
        if(X0 == false)
        {
            goto label_25;
        }
        
        var val_14 = X0;
        val_10 = X0;
        if((X0 + 294) == 0)
        {
            goto label_29;
        }
        
        var val_12 = X0 + 176;
        var val_13 = 0;
        val_12 = val_12 + 8;
        label_28:
        if(((X0 + 176 + 8) + -8) == null)
        {
            goto label_27;
        }
        
        val_13 = val_13 + 1;
        val_12 = val_12 + 16;
        if(val_13 < (X0 + 294))
        {
            goto label_28;
        }
        
        goto label_29;
        label_27:
        val_14 = val_14 + (((X0 + 176 + 8)) << 4);
        val_13 = val_14 + 304;
        label_29:
        val_10.Dispose();
        label_25:
        if(val_9 != 0)
        {
                throw val_9;
        }
    
    }
    public void Init(Enemy enemy, UnityEngine.Color randomColor)
    {
        UnityEngine.Collider val_3 = 0;
        this._enemy = enemy;
        UnityEngine.Vector3 val_2 = this.transform.position;
        this._startY = val_2.y;
        this.SetColor(color:  new UnityEngine.Color() {r = randomColor.r, g = randomColor.g, b = randomColor.b, a = randomColor.a});
        if((this.TryGetComponent<UnityEngine.Collider>(component: out  val_3)) == false)
        {
                return;
        }
        
        this = this._ignoreColliders;
        int val_5 = this._ignoreColliders.Length;
        if(val_5 < 1)
        {
                return;
        }
        
        var val_6 = 0;
        val_5 = val_5 & 4294967295;
        do
        {
            UnityEngine.Physics.IgnoreCollision(collider1:  val_3, collider2:  null);
            val_6 = val_6 + 1;
        }
        while(val_6 < (this._ignoreColliders.Length << ));
    
    }
    private void Update()
    {
        UnityEngine.Vector3 val_2 = this.transform.position;
        if((this._startY - val_2.y) <= 6f)
        {
                return;
        }
        
        this.OnHit(isAddForce:  false);
    }
    private void SetColor(UnityEngine.Color color)
    {
        this._color = color;
        mem[1152921507371672860] = color.g;
        mem[1152921507371672864] = color.b;
        mem[1152921507371672868] = color.a;
        if(this._meshRenderers.Length < 1)
        {
                return;
        }
        
        var val_3 = 0;
        do
        {
            this = this._meshRenderers[val_3];
            this.material.SetColor(nameID:  Balloon._baseColor, value:  new UnityEngine.Color() {r = color.r, g = color.g, b = color.b, a = color.a});
            this.material.SetColor(nameID:  Balloon._emissionColor, value:  new UnityEngine.Color() {r = color.r, g = color.g, b = color.b, a = color.a});
            val_3 = val_3 + 1;
        }
        while(val_3 < this._meshRenderers.Length);
    
    }
    public void OnHit(bool isAddForce = False)
    {
        UnityEngine.Object val_5;
        float val_6;
        UnityEngine.Object val_33;
        UnityEngine.Object val_34;
        float val_35;
        float val_36;
        float val_37;
        if(this._isHit == true)
        {
                return;
        }
        
        this._isHit = true;
        bool val_1 = UnityEngine.Object.op_Inequality(x:  this._crushSame, y:  0);
        if(this._enemy != 0)
        {
                this._enemy.OnHit(balloon:  this, isAddForce:  isAddForce);
        }
        else
        {
                Sound.Play(self:  1);
        }
        
        List.Enumerator<T> val_4 = this._childBalloons.GetEnumerator();
        label_28:
        if(((-1529897296) & 1) == 0)
        {
            goto label_13;
        }
        
        val_33 = val_5;
        val_34 = 0;
        if(val_33 == val_34)
        {
            goto label_28;
        }
        
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_34 = 0;
        UnityEngine.GameObject val_8 = val_5.gameObject;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = 0;
        UnityEngine.Transform val_9 = val_8.transform;
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_9.parent == 0)
        {
            goto label_28;
        }
        
        val_34 = 0;
        UnityEngine.GameObject val_12 = val_5.gameObject;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = 0;
        UnityEngine.Transform val_13 = val_12.transform;
        val_33 = this._enemy;
        if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = 0;
        UnityEngine.Transform val_14 = val_33.transform;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = 0;
        UnityEngine.Transform val_15 = val_14.parent;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_34 = val_15.transform;
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_13.parent = val_34;
        goto label_28;
        label_13:
        UnityEngine.Experimental.Rendering.Universal.LibTessDotNet.Vec3..cctor();
        UnityEngine.Vector3 val_18 = this.transform.position;
        val_35 = val_18.x;
        val_36 = val_18.y;
        val_37 = val_18.z;
        if((this.TryGetComponent<UnityEngine.MeshRenderer>(component: out  0)) == true)
        {
            goto label_30;
        }
        
        UnityEngine.MeshRenderer val_22 = this.gameObject.GetComponentInChildren<UnityEngine.MeshRenderer>();
        if(val_22 == 0)
        {
            goto label_34;
        }
        
        label_30:
        val_22.enabled = false;
        UnityEngine.Bounds val_24 = val_22.bounds;
        val_35 = val_6;
        val_36 = val_18.y;
        val_37 = val_18.z;
        label_34:
        BalloonEffectManager.<instance>k__BackingField.Play(position:  new UnityEngine.Vector3() {x = val_35, y = val_36, z = val_37}, color:  new UnityEngine.Color() {r = this._color, g = V12.16B, b = V13.16B, a = 0.8f}, withConfetti:  (this._withConfetti == true) ? 1 : 0);
        if(this.gameObject.activeSelf != true)
        {
                if(this._isRocket == false)
        {
            goto label_41;
        }
        
        }
        
        UnityEngine.Coroutine val_29 = this.StartCoroutine(routine:  this.CoChildBurst());
        return;
        label_41:
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }
    private System.Collections.IEnumerator CoChildBurst()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new Balloon.<CoChildBurst>d__24();
    }
    public Balloon()
    {
        this._childBalloons = new System.Collections.Generic.List<Balloon>();
    }
    private static Balloon()
    {
        Balloon._baseColor = UnityEngine.Shader.PropertyToID(name:  "_BaseColor");
        Balloon._emissionColor = UnityEngine.Shader.PropertyToID(name:  "_EmissionColor");
    }
    private void <CoChildBurst>g__DestroyThis|24_0()
    {
        UnityEngine.Object.Destroy(obj:  this.gameObject);
    }

}
