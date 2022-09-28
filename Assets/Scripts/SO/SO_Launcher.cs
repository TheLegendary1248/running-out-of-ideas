using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Gun", menuName = "SO/Launcher", order = 1)]
public class SO_Launcher : ScriptableObject
{
    [Tooltip("Path references to prefabs in Resources. Namely the projectile prefabs")]
    public string[] prefabReferences;
    [Tooltip("The damage the projectile should do with this launcher")]
    public float damage;
    [Tooltip("The amount of ammunition available for this launcher")]
    public int ammo;
    [Tooltip("How much knockback the launcher produces")]
    public float knockback;
    [Tooltip("The delay in between shots for automatic weapons")]
    public float fireRate;
    [Tooltip("The force the launcher applies to the projectile")]
    public float force;
}
