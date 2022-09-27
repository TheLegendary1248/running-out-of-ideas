 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Dynamic;
public class Player : MonoBehaviour, ICharacter
{
    public static GameObject playerObject;
    public static Player s;
    [HideInInspector]
    public Rigidbody2D rb;
    public IWeapon[] weps = new IWeapon[1];
    // Start is called before the first frame update
    void Start()
    {
        weps[0] = new Launcher("Minigun");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dynamic o = new ExpandoObject();
            o.user = this;
            o.direction = ((Vector2)transform.position - pos).normalized;
            weps[0].Use(o);
        }
    }
}
