using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class for all entities that can wield a weapon. Unlikely I use this as intended, but who knows
/// </summary>
public interface IWielder
{
    public Launcher[] holding { get; set; }
    public int currentHeld { get; set; }
}
