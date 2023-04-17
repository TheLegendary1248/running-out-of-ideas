using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDetector
{
    
}
public interface Restriction
{
    void Delegate();
}
[System.Serializable]
public struct MotionRestriction: Restriction
{
    [SerializeField]
    public float value;
    void Restriction.Delegate() { }

}
public class SizeRestriction
{

}