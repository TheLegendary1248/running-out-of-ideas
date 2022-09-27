using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Gun", menuName = "SO/Launcher", order = 1)]
public class SO_Launcher : ScriptableObject
{
    public string[] prefabReferences;
    public float Damage;
    public int ammo;
}
