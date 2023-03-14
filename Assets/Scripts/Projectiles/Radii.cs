using System.Collections;
using UnityEngine;
/// <summary>
/// The bubble projectile that forces all objects in radius to a fixed growing distance from it's impact point
/// </summary>
public class Radii : MonoBehaviour, IExplosive
{
    public float i_time => time; public float i_radius => radius; public float i_fuse => radius;
    public float time, radius, fuse;
    public Rigidbody2D rb;
    public GameObject fx;
    public SpriteRenderer fxSprite;
    public AudioSource aud;
    // Start is called before the first frame update

    void OnCollisionEnter2D()
    {
        //Trigger
        rb.simulated = false;
        aud.Play();
        StartCoroutine(Function());
    }
    IEnumerator Function()
    {
        yield return null;
        float timeStamp = Time.fixedTime;
        float timeDif = Time.fixedTime - i_time;
        fx.transform.parent = null;
        fx.transform.localScale = Vector2.zero;
        fx.SetActive(true);
        while (timeDif < timeStamp) //In case i decide to implement time shenanigans
        {   //Keep loop
            float range = (Time.fixedTime - timeStamp) / time;
            ForceObjectsToRadius(radius * range, transform.position);
            fx.transform.localScale = Vector2.one * radius * range * 2f;
            fx.transform.position = transform.position;
            fxSprite.material.SetFloat("_Fill", 1 - range);
            yield return new WaitForFixedUpdate();
            timeDif = Time.fixedTime - time;
        }
        Destroy(fx);
        Destroy(gameObject);
    }
    /// <summary>
    /// Forces all object in radius to the circle formed by the radius
    /// </summary>
    static void ForceObjectsToRadius(float radius, Vector2 pos)
    {
        
        //Get all objects
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, radius);
        for (int i = 0; i < colliders.Length; i++)
        {   
            Vector2 objPos = colliders[i].transform.position;
            //Break out if the object center is not range compared to collider
            if ((objPos - pos).sqrMagnitude > radius * radius) continue;
            Vector2 pointOnCircle = (objPos - pos).normalized * radius;
            colliders[i].transform.position = pos + pointOnCircle;
        }
    }
}
