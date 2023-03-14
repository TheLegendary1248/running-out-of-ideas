 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Dynamic;
public class Player : MonoBehaviour, ICharacter
{
    public Vector2 rate;
    public static GameObject playerObject;
    public static Player s;
    [HideInInspector]
    public Rigidbody2D rb;
    public IWeapon[] weps = new IWeapon[1];
    public AudioSource slideSFX;
    public float maxSpeed;
    public AnimationCurve slide_curve;
    public AudioSource impactSFX;
    public float slide_multi = 0;
    
    // Start is called before the first frame update
    void Start()
    {

        weps[0] = new Launcher("Minigun");
        s = this;
        rb = GetComponent<Rigidbody2D>();
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
            weps[0].Use(o);
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
