using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script for bullet impact effects
/// </summary>
public class ImpactUtil : MonoBehaviour
{
    public float lifetime = 1f;
    public float timestamp;
    public SpriteRenderer sprite;
    public AudioSource src;
    public float pitchVar = 0.2f;
    void Start()
    {
        timestamp = Time.fixedTime + lifetime;
        src.pitch += Random.Range(-pitchVar, pitchVar);
        transform.eulerAngles = Vector3.forward * 45f;
    }

    private void FixedUpdate()
    {
        if(timestamp < Time.fixedTime)
        {
            Destroy(gameObject);
            
        }
        else
        {
            float range = (timestamp - Time.fixedTime) / lifetime;
            sprite.material.SetFloat("_Destroy", Mathf.Lerp(10f, 0f, range * range));
        }
    }
}
[SerializeField]
public struct tempStruct
{
    
}
