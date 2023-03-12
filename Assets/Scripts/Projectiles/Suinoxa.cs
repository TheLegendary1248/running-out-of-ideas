using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
/// <summary>
/// The thrown dagger that bounces off the impact point when it's user uses the weapon
/// </summary>
public class Suinoxa : MonoBehaviour
{
    public int bounces;
    public int accruedBounces;
    public bool hitSurface = false;
    public static Action<GameObject> OnEntityFired;
    public Rigidbody2D collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D impact = collision.GetContact(0);
        hitSurface = true;
        
    }
    void Bounce()
    {
        
    }
}
