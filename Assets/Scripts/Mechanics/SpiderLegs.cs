using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLegs : MonoBehaviour
{
    public Vector2 spot;
    public float speed;
    public LayerMask mask;
    public float delay;
    public float surfaceDist;
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
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Random.insideUnitCircle.normalized, float.MaxValue, mask);
        if (ray) spot = ray.point + (ray.normal * surfaceDist);
    }

}
