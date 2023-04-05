using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>Universal camera follow script</summary>
public class CamFollow : MonoBehaviour
{
    public static CamFollow main;
    public Camera cam;
    ///<summary>The amount the car's velocity is multiplied by, then added onto the camera's position</summary>
    public float lookAheadMulti = 1.5f;
    public float baseCameraSize = 50f;
    public float viewMulti = 0.25f;
    public float viewSizeCap = 120;
    public static float Shake = 0f;
    //UNUSED - SET WITH SETTINGS
    public static float ShakeMulti = 1;
    private void Update()
    {
        if (Player.singleton != null)
        {
            //TODO :SMOOTH INTERLOP
            //Camera Location
            transform.position = Player.singleton.transform.position + new Vector3(0, 0, 0) + (Vector3)(Shake * 10f * Random.insideUnitCircle);
            //Dynamic camera zoom depending on car speed
            //cam.orthographicSize = Mathf.Min(viewSizeCap, baseCameraSize + (viewMulti * Player.s.rb.velocity.magnitude));
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shake += 0.1f;
        }
        Shake -= Time.deltaTime;
        Shake = Mathf.Max(0, Shake);
    }
    //Go figure
    /// <summary>
    /// Shakes the Camera
    /// </summary>
    /// <param name="m"></param>
    public static void CamShake(float m) => Shake = Mathf.Max(m, Shake);
}
