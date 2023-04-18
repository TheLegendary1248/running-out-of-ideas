using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtTarget : MonoBehaviour, IReciever
{
    Vector2 target;
    /// <summary>
    /// The rate at which the component faces the target, in degrees
    /// </summary>
    [Tooltip("The rate at which the component faces the target, in degrees")]
    public float turnRate;
    /// <summary>
    /// The margin of angle before the object bothers rotating again
    /// </summary>
    public float beginMargin;
    /// <summary>
    /// Is the turrent currently rotating?
    /// </summary>
    bool rotating = false;
    void IReciever.GetSignal(GameObject target)
    {
        this.target = target.transform.position;
    }
    void IReciever.GetSignal(Vector2 target)
    {
        this.target = target;
    }
    private void FixedUpdate()
    {
        //Precalc
        Vector2 dif = target - (Vector2)transform.position;
        float dot = Vector2.Dot(dif, transform.up);

        //If already rotating or vector difference is larger than margin
        if(rotating | (dif.magnitude - dot) > beginMargin)
        {
            rotating = true;
            dif = Utils.Vec2RightParallel(dif); //Because unity is wierd with these things
            float turnDelta = turnRate * Time.fixedDeltaTime;
            float angle = Mathf.MoveTowardsAngle(
                transform.eulerAngles.z,
                Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg,
                turnDelta);
            //Angle difference check. Might remove hardcode value
            float angleDif = Mathf.DeltaAngle(angle, transform.eulerAngles.z);
            if (Mathf.Abs(angleDif) < turnDelta / 2f) rotating = false;
            transform.eulerAngles = new Vector3(0f, 0f, angle);
        }
    }
}
