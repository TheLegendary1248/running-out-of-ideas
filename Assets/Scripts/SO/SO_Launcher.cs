using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Gun", menuName = "SO/Launcher", order = 1)]
public class SO_Launcher : ScriptableObject
{
    [Tooltip("Path references to prefabs in Resources")]
    public GameObject projectile;
    [Tooltip("The amount of ammunition available for this launcher. Mostly only applies to Player")]
    public int ammo;
    [Tooltip("How much knockback the launcher produces")]
    public float knockback;
    [Tooltip("The amount the projectile takes from the player")]
    public float selfDamage;
    public virtual void Use(dynamic param)
    {
        WeaponUseInfo p = param;
        p.user.GetComponent<Rigidbody2D>()?.AddForce(-knockback * p.direction, ForceMode2D.Impulse);
        GameObject gb = Instantiate(projectile, p.origin, Quaternion.LookRotation(Vector3.forward, p.direction));
        gb.GetComponent<Rigidbody2D>().AddForce(p.direction * knockback * 2f, ForceMode2D.Impulse);
        
    }
    public static SO_Launcher GetLauncher(string name)
    {
        return (SO_Launcher)Resources.Load(Settings.commonPathNames["Launchers"] + $"/{name}");
    }
}
//this is obviously terrible, don't be a retard and fix this at some point before it's too late
public class LauncherInstance
{
    public int ammo;
    public SO_Launcher instance;
    public LauncherInstance(string name)
    {
        instance = (SO_Launcher)Resources.Load(Settings.commonPathNames["Launchers"] + $"/{name}");
        ammo = instance.ammo;
    }
    public void Use(dynamic param)
    {
        if(ammo > 0)
        {
            ammo -= 1;
            instance.Use(param);
        }
    }
}
