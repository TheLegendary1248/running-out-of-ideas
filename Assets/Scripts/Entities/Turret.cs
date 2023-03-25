using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Basic Turret Enemy. Just Fires at the Player
/// </summary>
public class Turret : MonoBehaviour
{
    public bool requireSight;
    public float range;
    public LauncherInstance Launcher;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void UseWeapon()
    {
        
        Launcher.Use(new WeaponUseInfo(this, Vector2.zero));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
