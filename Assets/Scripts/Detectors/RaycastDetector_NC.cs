using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
/// <summary>
/// In game detector piece that functions like a camera
/// </summary>
public class RaycastDetector_NC : MonoBehaviour, IDetector
{
    public UnityEvent events;
    bool isActive;
    //Arc range of detector
    public float arcRange { 
        get => _arcRange;
        set { _arcRange = value; dotRange = Mathf.Cos(value * Mathf.Deg2Rad * 0.5f); } }
    [SerializeField]
    [HideInInspector]
    float _arcRange;
    //Precalculated float to be compared against the dot product of 
    float dotRange = 0f;
    
    //Radius range of detector
    public float radiusRange;
    //If obstructions should be considered
    public bool doSightCheck;
    
#if UNITY_EDITOR
    Collider2D[] detectedCols;
#endif
    private void Awake()
    {
        arcRange = arcRange; //Cheap hack. Are you going to blame me??
    }
    private void FixedUpdate()
    {
        //Get objects in AOE 
        //TODO: FILTER OUT TERRAIN
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radiusRange);
        if (colliders.Length == 0) { return; } //Stop early if there's nothing
        //Filter out objects not in arc range
        Collider2D[] detectedColliders = new Collider2D[colliders.Length];
#if UNITY_EDITOR
            detectedCols = detectedColliders;
#endif
        int detectedArraySize = 0; //TODO: Create Util for this 
        bool skipArcCheck = arcRange >= 360f;
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider2D otherCollider = colliders[i];

            if (skipArcCheck) goto sightCheck; //Bite me, GOTO haters
            Vector2 toObjNormal = (otherCollider.transform.position - transform.position).normalized;
            Vector2 forwardNormal = transform.up;
            //Compare to check if in arc
            if (Vector2.Dot(toObjNormal, forwardNormal) < dotRange) continue;

            sightCheck:

            goto colliderAdd;
            if (!doSightCheck) goto colliderAdd;
            RaycastHit2D[] obstructions = Physics2D.LinecastAll(transform.position, otherCollider.transform.position);

        colliderAdd:
            detectedColliders[detectedArraySize++] = otherCollider;
        }
        if(detectedArraySize != 0) 
        {
            GameObject obj = detectedColliders[0].gameObject;
            Reciever[] targets = GetComponents<Reciever>();
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].GetSignal(obj);
            }
        }
    }
    private void OnDrawGizmos()
    { 
        if(detectedCols != null) 
        {
            Gizmos.color = Utils.StandardColors.DetectColor;
            foreach(Collider2D collider in detectedCols)
            {
                if(collider) Gizmos.DrawLine(transform.position, collider.transform.position);
            }
        }
        Handles.color = Utils.StandardColors.AOEColor * new Color(1,1,1,0.25f);
        Handles.DrawSolidArc(transform.position, transform.forward, transform.up, arcRange / 2f, radiusRange);
        Handles.DrawSolidArc(transform.position, transform.forward, transform.up, -arcRange / 2f, radiusRange);
        Handles.color = Utils.StandardColors.AOEColor;
        Handles.DrawWireDisc(transform.position, transform.forward, radiusRange);
    }
}
