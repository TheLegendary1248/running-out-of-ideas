using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Simply updates the attached Gameobject rotation to match the object's delta direction
/// </summary>
public class FX_MatchVelocityDirection : MonoBehaviour
{
    Vector2 lastPosition;
    void FixedUpdate()
    {
        transform.up = (transform.position - (Vector3)lastPosition).normalized;
        lastPosition = transform.position;
    }
}
