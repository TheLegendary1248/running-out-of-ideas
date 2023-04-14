using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// In game detector piece that functions like a camera
/// </summary>
public class RaycastDetector_NC : MonoBehaviour
{
    bool isActive;
    float arcRange;
    float radiusRange;
    private void FixedUpdate()
    {
        //Get objects in AOE. Filter out terrain
        //Filter out objects not in arc range
        //Check objects line of sight, if used
        //Send out notifs
    }
    private void OnDrawGizmos()
    {
        //Draw helpy things here
    }

}
