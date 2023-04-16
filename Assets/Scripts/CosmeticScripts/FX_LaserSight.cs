using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_LaserSight : MonoBehaviour
{
    GameObject sight;
    LineRenderer lineRender;
    public Material material;
    public float width;
    public float range;
    public Gradient color;
    // Start is called before the first frame update
    void Awake()
    {
        sight = new GameObject("LaserSight", typeof(LineRenderer));
        lineRender = sight.GetComponent<LineRenderer>();
        lineRender.positionCount = 2;
        lineRender.widthMultiplier = width;
        lineRender.material = material;
        lineRender.colorGradient = color;

    }
    private void FixedUpdate()
    {
        Vector3 up = transform.up;
        RaycastHit2D ray = Physics2D.Raycast(transform.position, up, range);
        lineRender.SetPositions(new Vector3[] {
            transform.position,
            ray ? ray.point : transform.position + (up * range)
        });
    }
    private void OnDestroy()
    {
        Destroy(sight);
    }
}
