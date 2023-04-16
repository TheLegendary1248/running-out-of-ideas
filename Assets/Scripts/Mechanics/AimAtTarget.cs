using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtTarget : MonoBehaviour
{
    Vector2 target;
    /// <summary>
    /// The rate at which the component faces the target, in degrees
    /// </summary>
    [Tooltip("The rate at which the component faces the target, in degrees")]
    public float turnRate;
    /// <summary>
    /// The margin of angle before the turret bothers rotating again
    /// </summary>
    public float margin;
    private void FixedUpdate()
    {
        Vector2 dif = target - (Vector2)transform.position;
        dif = Utils.Vec2RightParallel(dif); //Because unity is wierd with these things
        float angle = Mathf.MoveTowardsAngle(
            transform.eulerAngles.z,
            Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg,
            turnRate);
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }
}
