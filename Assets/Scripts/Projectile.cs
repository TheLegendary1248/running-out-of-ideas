using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Base class for all projectiles
public class Projectile : MonoBehaviour
{
    public float Speed;
    public float Damage;
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
