using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Class for the custom reticle, and programmatically animated for the sake of being EYE CANDY
public class Reticle: MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (!cam)
        {
            cam = Camera.main;
        }
        else
        {
            transform.position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonDown(0))
        {
            transform.localScale = new Vector2(0.6f, 0.6f);
        }
    }
    //TODO: DONT HARDCODE
    //AND MAKE SCALE WITH SCREEN
    private void FixedUpdate()
    {
        transform.localScale = Vector2.Lerp(new Vector2(0.3f, 0.3f), transform.localScale, 0.75f);
    }
}
