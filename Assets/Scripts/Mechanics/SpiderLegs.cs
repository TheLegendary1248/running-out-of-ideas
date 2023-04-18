using System.Collections;
using UnityEngine;

public class SpiderLegs : MonoBehaviour
{
    public Vector2 spot;
    public Vector2 normal = Vector2.down;
    public float speed;
    public LayerMask mask;
    public float delay;
    public float surfaceDist;
    public float angle;
    
    Coroutine co;
    private void Start()
    {
        co = StartCoroutine(Timer());
        
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, spot, speed * Time.fixedDeltaTime);

    }
    IEnumerator Timer()
    {
        CheckForSpot();
        yield return new WaitForSeconds(delay);
        co = StartCoroutine(Timer());
    }
    void CheckForSpot()
    {
        Debug.Log("Hello?");
        float angle = 45f * (Utils.CoinFlip() ? 1f : -1f);
        Vector2 rotated = Utils.Rotate(normal, angle * Mathf.Deg2Rad);        
        Debug.DrawRay(transform.position, rotated * 10f, Color.red, 5f);
        RaycastHit2D ray = Physics2D.Raycast(transform.position, rotated, float.MaxValue, mask);
        if (ray)
        {
            spot = ray.point + (ray.normal * surfaceDist);
            normal = -ray.normal;
        }

        
    }

    private void OnDrawGizmos()
    {
        
    }
}
