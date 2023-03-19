using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>Universal camera follow script</summary>
public class CamFollow : MonoBehaviour
{
    public Camera cam;
    ///<summary>The amount the car's velocity is multiplied by, then added onto the camera's position</summary>
    public float lookAheadMulti = 1.5f;
    public float baseCameraSize = 50f;
    public float viewMulti = 0.25f;
    public float viewSizeCap = 120;
    private void Update()
    {
        if (Player.instance != null)
        {
            //TODO :SMOOTH INTERLOP
            //Camera Location
            transform.position = Player.instance.transform.position + new Vector3(0, 0, 0);
            //Dynamic camera zoom depending on car speed
            //cam.orthographicSize = Mathf.Min(viewSizeCap, baseCameraSize + (viewMulti * Player.s.rb.velocity.magnitude));
        }
    }
}
