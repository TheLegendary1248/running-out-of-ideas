using UnityEngine;
using System;
using System.Collections;
using System.Collections.ObjectModel;
public class Player : MonoBehaviour, ICharacter, IWielder
{
    public ObservableCollection<LauncherInstance> holding {
        get { return weapons; }
        set { weapons = value; }
    }
    public int currentHeld { get; set; }
    public ObservableCollection<LauncherInstance> weapons = new ObservableCollection<LauncherInstance>(new LauncherInstance[] { null, null});
    public Vector2 shrinkRate;
    public static GameObject playerObject;
    public static Player singleton;
    [HideInInspector]
    public Rigidbody2D rb;
    public Collider2D col;
    ///<summary>Speed at which the player will be killed</summary>
    public float killSpeed;
    public AudioSource slideSFX_Src;
    public float maxSpeed;
    public AnimationCurve slideCurve;
    public AudioSource impactSFX_Src;
    public float slideSFXVolMulti = 0;
    public static Action PlayerInventoryChanged;
    public static Action PlayerFired;
    public PhysicsMaterial2D self;
    #region Unity Messages
    void Start()
    {
        singleton = this;
        rb = GetComponent<Rigidbody2D>();
        weapons.CollectionChanged += (_, _) => PlayerInventoryChanged?.Invoke();
        weapons[0] = new LauncherInstance("Minigun");
        
    }
    IEnumerator FixInAMoment()
    {
        yield return new WaitForSeconds(0.2f);
        self.bounciness = 0.33f;
    }
    // Update is called once per frame
    void Update()
    {
        void Fire()
        {
            //Setup shot
            StartCoroutine(FixInAMoment());
            self.bounciness = 1.0f;
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            WeaponUseInfo o = new WeaponUseInfo();
            o.user = this;
            o.direction = (pos - (Vector2)transform.position).normalized;
            //Shots intentionally are on collider bounds+
            Bounds colliderBounds = col.bounds;
            colliderBounds.size += new Vector3(1f, 1f);
            //This can be optimized. Don't
            float dist = 2f;
            colliderBounds.IntersectRay(new Ray(transform.position, o.direction), out dist);
            o.origin = (Vector2)transform.position - (o.direction * dist);
            if(currentHeld < weapons.Count)weapons[currentHeld]?.Use(o);
            //Affect scale with shot
            Vector2 userScale = transform.localScale;
            transform.localScale = userScale + new Vector2(weapons[0].instance.selfDamage, weapons[0].instance.selfDamage);
            //Call event
            PlayerFired?.Invoke();
        }
        if (Input.GetMouseButtonDown(0))
        {
            currentHeld = 0;
            Fire();
        }
        if (Input.GetMouseButtonDown(1))
        {
            currentHeld = 1;
            Fire();
        }
    }
    public void FixedUpdate()
    {
        //Kill on passing zero
        transform.localScale = (Vector2)transform.localScale - (shrinkRate * Time.fixedDeltaTime);
        //Sliding sound effect
        float speed = rb.velocity.magnitude / maxSpeed;
        slideSFX_Src.volume = slideSFXVolMulti * Mathf.Min(slideCurve.Evaluate(speed), maxSpeed);
        slideSFX_Src.pitch = Mathf.Lerp(0.5f, 1f, slideCurve.Evaluate(speed));
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Cheap and relatively ok way to check the true force of the impact
        Vector2 impactForce = collision.relativeVelocity * Vector2.Dot(collision.relativeVelocity.normalized, collision.GetContact(0).normal);
        impactSFX_Src.volume = Mathf.Min(impactForce.sqrMagnitude / (maxSpeed * maxSpeed), maxSpeed * maxSpeed);
        impactSFX_Src.Play();
        foreach(LauncherInstance inst in holding)
        {
            if (inst != null) inst.ammo = inst.instance.ammo;
        }
        if(impactForce.sqrMagnitude > killSpeed * killSpeed) //Make sure to test all collisions
        {
            Kill();
            return;
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        slideSFXVolMulti = 1;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        slideSFXVolMulti = 0;
    }
    public void Kill()
    {
        Debug.LogWarning("we should be dead");
    }
    #endregion
    ///<summary>Disable player's presence in the world when the level end has been reached</summary>
    public void YieldToEnd()
    {
        rb.simulated = false;
        this.enabled = false;
    }
}
