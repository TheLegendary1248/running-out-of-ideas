using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Base interface for weapons
public interface IWeapon
{
    public bool isFinite { get; set; }
    public int quantity { get; set; }

    //FIGURE OUT EXPANDO OBJECT
    public abstract void Use(object a);
}
