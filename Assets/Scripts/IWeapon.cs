using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///Base interface for weapons
public interface IWeapon
{
    public string name { get; }
    public bool isFinite { get; set; }
    public int quantity { get; set; }

    //FIGURE OUT EXPANDO OBJECT
    public abstract void Use(dynamic a);
}
///<summary>Standard argument type sent with the Use function for IWeapons.
///One can choose not to use it, but it's STRONGLY recommended for less future headaches
/// </summary>
public struct WeaponUseInfo
{

}