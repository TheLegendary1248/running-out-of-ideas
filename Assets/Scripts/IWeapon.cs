using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Dynamic;
///Base interface for weapons
public interface IWeapon
{
    ///<summary>The name for the weapon</summary>
    public string name { get; }
    ///<summary>If the weapon can be exhausted of use when quantity is used up</summary>
    public bool isFinite { get; set; }
    ///<summary>Defines the durability, amount, magazine size, or whatever equivalent of the weapon</summary>
    public int quantity { get; set; }
    ///<summary>Defines the initial value or cap to for quantity</summary>
    public int maxQuantity { get; set; }
    ///<summary>Defines how much damage the weapon does</summary>
    public float damage { get; set; }

    /// <summary>
    /// The Use function for the weapon
    /// </summary>
    /// <param name="options">The options to passed to the weapon. Can be anything, ideally of type WeaponUseInfo</param>
    public abstract void Use(dynamic options);
}
///<summary>Standard argument type sent with the Use function for IWeapons.
///One can choose not to use it, but it's STRONGLY recommended for less future headaches
/// </summary>
public struct WeaponUseInfo
{
    ///<summary>The entity that spawned the object</summary>
    public MonoBehaviour user;
    ///<summary>The intended spawn location of the object</summary>
    public Vector2 spawn;
    ///<summary>The intended direction in which the weapon should be used</summary>
    public Vector2 direction;
    ///<summary>Miscellanous information that should be passed. Namely an ExpandoObject</summary>
    public dynamic options;
}