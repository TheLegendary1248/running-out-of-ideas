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
    public string Launcher;
    public LauncherInstance inst;
    public Coroutine c;
    public float time;
    public float reloadTime;

    // Start is called before the first frame update
    void Start()
    {
        
        inst = new LauncherInstance(Launcher);
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
            Vector2 dir = Player.singleton.transform.position - transform.position;
            inst.Use(new WeaponUseInfo(this, dir.normalized));
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
