 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour, ICharacter
{
    public static GameObject playerObject;
    public static Player s;
    public Rigidbody2D rb;
    public IWeapon[] weps = new IWeapon[] { };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //weps[0].Use(0);
        }
    }
}
