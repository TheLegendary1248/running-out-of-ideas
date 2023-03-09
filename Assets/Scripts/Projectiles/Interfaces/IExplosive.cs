using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// For all entities that can 'explode'
/// </summary>
public interface IExplosive
{
    /// <summary>
    /// Radius of the affected area
    /// </summary>
    public float i_radius { get; }
    /// <summary>
    /// Any fragmentation the explosive may have
    /// </summary>
    public GameObject[] frag => new GameObject[]{};
    /// <summary>
    /// Overall effect time
    /// </summary>
    public float i_time { get; }
    /// <summary>
    /// Time until trigger
    /// </summary>
    public float i_fuse { get; }
}
