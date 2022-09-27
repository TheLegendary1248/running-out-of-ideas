using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Basic class for all weapons that simply fire a projectile
public class Launcher : MonoBehaviour, IWeapon
{
    public bool isFinite { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int quantity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    [SerializeField]
    public float fireRate { get; set; }
    public GameObject projectile;
    Coroutine waitForNextFire;
    /// <summary>
    /// Fire the launcher. 
    /// </summary>
    /// <param name="a"></param>
    public void Use(object a)
    {
        //GameObject projectile = GameObject.Instantiate(projectile, new Vector2(0, 0), Quaternion.identity);
        
    }

}
