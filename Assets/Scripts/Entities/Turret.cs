using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Basic Turret Enemy. Just Fires at the Player
/// </summary>
public class Turret : MonoBehaviour, IReciever
{
    public float range;
    public SO_Launcher newLauncherRef;
    public LauncherInstance inst;
    public Coroutine c;
    public float time;
    public float reloadTime;

    // Start is called before the first frame update
    void Start()
    {
        inst = new LauncherInstance(newLauncherRef);
        StartCoroutine(FireRate());
        StartCoroutine(Reload());
    }
    IEnumerator FireRate()
    {
        UseWeapon();
        yield return new WaitForSeconds(time);
        StartCoroutine(FireRate());
    }
    IEnumerator Reload()
    {
        while(true)
        {
            yield return new WaitForSeconds(reloadTime);
            inst.ammo = inst.instance.ammo;
        }
    }
    void UseWeapon()
    {
        if(Player.singleton)
        {
            Vector2 dir = transform.up;
            inst.Use(new WeaponUseInfo(this, dir.normalized));
        }
        
    }
}
