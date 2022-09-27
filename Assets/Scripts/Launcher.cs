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
    public float fireRate { get; set; }
    public string name { get; private set; }
    public string[] prefabRefs { get; }

    public GameObject projectile;
    Coroutine waitForNextFire;
    /// <summary>
    /// Fire the launcher. 
    /// </summary>
    /// <param name="a"></param>
    public void Use(dynamic param)
    {
        
        GameObject gb = Object.Instantiate(projectile, param.user.transform.position, Quaternion.identity);
        
    }
    public Launcher(string name)
    {
        SO_Launcher so = (SO_Launcher)Resources.Load($"SO/Launchers/{name}");
        quantity = so.ammo;
        this.name = name;
        projectile = (GameObject)Resources.Load($"Prefabs/Projectiles/{so.prefabReferences[0]}");
    }
}
