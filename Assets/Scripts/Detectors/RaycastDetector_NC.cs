using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// In game detector piece that functions like a camera
/// </summary>
public class RaycastDetector_NC : MonoBehaviour
{
    bool isActive;
    //Arc range of detector
    [SerializeField]
    float _arcRange;
    public float arcRange { 
        get => _arcRange;
        set { _arcRange = value; /*PRECALC DOTRANGE*/ } }
    //Radius range of detector
    public float radiusRange;
    //If obstructions should be considered
    public bool doSightCheck;
    //Precalculated float to be compared against the dot product of 
    float dotRange;
#if UNITY_EDITOR
    Collider2D[] detectedCols;
#endif
    private void FixedUpdate()
    {
        //Get objects in AOE 
        //TODO: FILTER OUT TERRAIN
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radiusRange);
        //Filter out objects not in arc range
        Collider2D[] detectedColliders = new Collider2D[colliders.Length];
        int detectedArraySize = 0; //TODO: Create Util for this 
        bool skipArcCheck = arcRange >= 360f;
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider2D otherCollider = colliders[i];
            
            if (skipArcCheck) goto sightCheck; //Bite me, GOTO haters
            Vector2 toObjNormal = (otherCollider.transform.position - transform.position).normalized;
            Vector2 forwardNormal = transform.up;
            //Compare
            if (Vector2.Dot(toObjNormal, forwardNormal) > dotRange) continue;

            sightCheck:
            goto colliderAdd;
            if (!doSightCheck) goto colliderAdd;
            RaycastHit2D[] obstructions = Physics2D.LinecastAll(transform.position, otherCollider.transform.position);

            colliderAdd:
            detectedColliders[detectedArraySize++] = otherCollider;
            detectedCols = detectedColliders;
        }
        //Check objects line of sight, if used
        //Send out notifs
    }
    private void OnDrawGizmos()
    {
        //Draw helpy things here
        if(detectedCols != null)
        {
            Gizmos.color = Color.yellow;
            foreach(Collider2D collider in detectedCols)
            {
                if(collider) Gizmos.DrawLine(transform.position, collider.transform.position);
            }
        }
        Gizmos.color = new Color(0f, 0.5f, 1f, 0.2f);
        Gizmos.DrawWireSphere(transform.position, radiusRange);
    }

}
