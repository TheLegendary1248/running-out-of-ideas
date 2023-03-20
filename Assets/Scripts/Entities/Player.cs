using UnityEngine;
using System;
using System.Collections.ObjectModel;
public class Player : MonoBehaviour, ICharacter, IWielder
{
    public ObservableCollection<SO_Launcher> holding { 
        get { return weapons; } 
        set { weapons = value; } 
    }
    public int currentHeld { get; set; }
    public ObservableCollection<SO_Launcher> weapons = new ObservableCollection<SO_Launcher>();
    public Vector2 rate;
    public static GameObject playerObject;
    public static Player instance;
    [HideInInspector]
    public Rigidbody2D rb;
    
    public AudioSource slideSFX;
    public float maxSpeed;
    public AnimationCurve slide_curve;
    public AudioSource impactSFX;
    public float slide_multi = 0;
    public static Action PlayerInventoryChanged;
    public static Action PlayerFired;

    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        weapons.CollectionChanged += (_, _) => PlayerInventoryChanged?.Invoke();
        weapons.Add(SO_Launcher.GetLauncher("Minigun"));
        
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            WeaponUseInfo o = new WeaponUseInfo();
            o.user = this;
            o.direction = (pos - (Vector2)transform.position).normalized;
            o.spawn = (Vector2)transform.position + (o.direction * 2f);
            weapons[0].Use(o);
            //Affect scale with shot
            Vector2 userScale = transform.localScale;
            transform.localScale = userScale + new Vector2(weapons[0].selfDamage, weapons[0].selfDamage);
            PlayerFired?.Invoke();
        }
    }
    ///<summary>Disable player's presence in the world when the level end has been reached</summary>
    public void YieldToEnd()
    {
        rb.simulated = false;
        this.enabled = false;
    }
    public void FixedUpdate()
    {
        //Kill on passing zero
        transform.localScale = (Vector2)transform.localScale - (rate * Time.fixedDeltaTime);
        //Sliding sound effect
        float speed = rb.velocity.magnitude / maxSpeed;
        slideSFX.volume = slide_multi * Mathf.Min(slide_curve.Evaluate(speed), maxSpeed);
        slideSFX.pitch = Mathf.Lerp(0.5f, 1f, slide_curve.Evaluate(speed));

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        impactSFX.volume = Mathf.Min(collision.relativeVelocity.sqrMagnitude / (maxSpeed * maxSpeed), maxSpeed * maxSpeed);
        impactSFX.Play();

    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        slide_multi = 1;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        slide_multi = 0;
    }
}
