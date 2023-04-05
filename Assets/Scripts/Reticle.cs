using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Class for the custom reticle, and programmatically animated for the sake of being EYE CANDY
public class Reticle: MonoBehaviour
{
    public float minSize;
    public float maxSize;
    [Range(0, 1)]
    public float lerp;
    public Camera c_camera;
    // Start is called before the first frame update
    void Start()
    {
        c_camera = Camera.main;
    }
    void Update()
    {
        if (!c_camera)
        {
            c_camera = Camera.main;
        }
        else
        {
            transform.position = (Vector2)c_camera.ScreenToWorldPoint(Input.mousePosition);
        }
        //TODO: Connect to actual weapon firing
        if (Input.GetMouseButtonDown(0))
        {
            SetSize(maxSize);
        }
    }
    void SetSize(float size) => transform.localScale = new Vector2(size, size) * Camera.main.orthographicSize * 0.01f;
    
    //TODO: DONT HARDCODE
    //AND MAKE SCALE WITH SCREEN
    private void FixedUpdate()
    {
        SetSize(Mathf.Lerp(minSize, transform.localScale.x / Camera.main.orthographicSize / 0.01f, lerp));
    }
}
