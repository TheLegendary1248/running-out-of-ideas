using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>Universal camera follow script</summary>
public class CamFollow : MonoBehaviour
{
    public static CamFollow main;
    [SerializeField] Camera c_camera;
    public float baseCameraSize = 50f;
    public float viewMulti = 0.25f;
    public float viewSizeCap = 120;
    [Range(0, 1)]
    public float sizeLerp = 0f;
    public static float shake = 0f;
    //UNUSED - SET WITH SETTINGS
    public static float ShakeMulti = 1;
    private void Update()
    {
        if (Player.singleton != null)
        {
            //Calculate Camera position and ortho size
            transform.position = Player.singleton.transform.position + new Vector3(0, 0, 0) + (Vector3)(shake * 10f * Random.insideUnitCircle);
            
            c_camera.orthographicSize = 
                //Smooth lerp to new size
                Mathf.Lerp(c_camera.orthographicSize,
                    //Calculate size based on speed with cap
                    Mathf.Min(viewSizeCap, baseCameraSize + (viewMulti * Player.singleton.rb.velocity.magnitude))
                , 0.05f);
        }
        //Reduce shake
        shake -= Time.deltaTime;
        shake = Mathf.Max(0, shake);
    }
    /// <summary>
    /// Shakes the camera
    /// </summary>
    /// <param name="seconds"></param>
    public static void CameraShake(float seconds) => shake = Mathf.Max(seconds, shake);
}
