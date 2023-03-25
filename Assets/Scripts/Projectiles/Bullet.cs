using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public TrailRenderer trail;
    //It costs 400,000 to fire this weapon for 12 seconds
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 40f);
    }
    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
