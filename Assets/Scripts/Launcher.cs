using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Dynamic;
//Basic class for all weapons that simply fire a projectile
public class Launcher : IWeapon
{
    
    public bool isFinite { get; set; }
    public int quantity { get; set; }
    [SerializeField]
    ///<summary>The fire rate for the weapon</summary>
    public float fireRate { get; set; }
    ///<summary>The knockback of weapon, obviously used for traversal</summary>
    public float knockBack { get; set; }
    public string name { get; private set; }
    ///<summary>Prefab references for instantiating projectiles</summary>
    public string[] prefabRefs { get; }
    public int maxQuantity { get; set; }
    public float damage { get; set; }
    public float force { get; set; }
    public float selfDamage { get; set; }
    ///<summary>The projectile to be used</summary>
    public GameObject projectile;
    Coroutine waitForNextFire;
    /// <summary>
    /// Fire the launcher 
    /// </summary>
    /// <param name="param">Can be anything. Very ideally use WeaponUseInfo</param>
    public virtual void Use(dynamic param)
    {
        WeaponUseInfo p = param;
        p.user.GetComponent<Rigidbody2D>().AddForce(-knockBack * p.direction, ForceMode2D.Impulse);
        GameObject gb = Object.Instantiate(projectile, p.spawn, Quaternion.LookRotation(Vector3.forward ,p.direction));
        gb.GetComponent<Rigidbody2D>().AddForce(p.direction * force, ForceMode2D.Impulse);
        //Affect scale with shot
        Vector2 userScale = p.user.transform.localScale;
        p.user.transform.localScale = userScale + new Vector2(selfDamage, selfDamage);
    }
    
}
