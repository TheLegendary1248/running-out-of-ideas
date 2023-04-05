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
    public AudioSource sizeWarnSFX_Src;
    public float slideSFXVolMulti = 0;
    public static Action PlayerInventoryChanged;
    public static Action PlayerFired;
    public PhysicsMaterial2D self;

    public Vector2 origin;
    public Vector2 scale;
    #region Unity Messages
    void Start()
    {
        singleton = this;
        rb = GetComponent<Rigidbody2D>();
        weapons.CollectionChanged += (_, _) => PlayerInventoryChanged?.Invoke();
        weapons[0] = new LauncherInstance("Minigun");
        //Rough
        origin = transform.position;
        scale = transform.localScale;    
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
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 cursorDir = cursorPos - (Vector2)transform.position;
            //Affect scale with shot - probably extract this out as a util function for the future
            Vector2 transformDir = transform.up;
            float dif = Mathf.Asin(Vector2.Dot(transformDir, cursorDir.normalized));
            dif /= Mathf.PI / 2f;
            dif = Mathf.Abs(dif);
            Vector2 userScale = transform.localScale;
            transform.localScale = userScale + new Vector2(weapons[0].instance.selfDamage * (1 - dif), weapons[0].instance.selfDamage * dif);

            WeaponUseInfo o = new WeaponUseInfo();
            o.user = this;
            o.direction = cursorDir.normalized;
            //Shots intentionally are on collider bounds+
            Bounds colliderBounds = col.bounds;
            //TODO This does do not account for sudden scale change, fix this later!!!!!!!!
            colliderBounds.size += new Vector3(2f, 2f);
            //This can be optimized. Don't
            float dist;
            colliderBounds.IntersectRay(new Ray(transform.position, o.direction), out dist);
            o.origin = (Vector2)transform.position - (o.direction * dist);
            if(currentHeld < weapons.Count)weapons[currentHeld]?.Use(o);
            
            
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
        //TODO: Kill on crossing zero
        Vector2 loss = shrinkRate * Time.fixedDeltaTime;
        transform.localScale = (Vector2)transform.localScale - loss;
        Vector2 selfScale = transform.localScale;
        float min;
        if (selfScale.x < 0 | selfScale.y < 0)
        {
            Kill();
            return;
        }
        else if (1f > (min = Mathf.Min(selfScale.x,selfScale.y)))
        {
            sizeWarnSFX_Src.volume = (1 - min) * 0.02f;
        }
        else sizeWarnSFX_Src.volume = 0;
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
        CamFollow.CameraShake(0.1f * (impactForce.magnitude / killSpeed));
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        slideSFXVolMulti = 1;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        slideSFXVolMulti = 0;
    }
    
    #endregion
    public void Kill()
    {
        transform.position = origin;
        transform.localScale = scale;
    }
    ///<summary>Disable player's presence in the world when the level end has been reached</summary>
    public void YieldToEnd()
    {
        rb.simulated = false;
        this.enabled = false;
    }
}
