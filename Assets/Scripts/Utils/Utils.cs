using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
/// <summary>
/// Utility Functions
/// </summary>
public static class Utils
{
    public static class StandardColors
    {
        //Cyan-ish color that should be used for displaying AOE's
        public static Color AOEColor = new Color(0f, 0.5f, 1f, 0.25f);
        public static Color NotifyColor = new Color(0f, 0.5f, 1f, 0.25f);
        public static Color DetectColor = new Color(1f, 0f, 0f, 0.5f);
    }
    public static void LineCastChildChecks() { }
    /// <summary>
    /// Rotate a vector 90 degrees to the left
    /// </summary>
    public static Vector2 Vec2LeftParallel(Vector2 v) => new Vector2(-v.y, v.x);
    /// <summary>
    /// Rotate a vector 90 degrees to the right
    /// </summary>
    public static Vector2 Vec2RightParallel(Vector2 v) => new Vector2(v.y, -v.x);
    /// <summary>
    /// Utility functions for Editor Scripts
    /// </summary>
    public static bool CoinFlip() => UnityEngine.Random.value > 0.5f;
    public static Vector2 Rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
}
public static class UtilsEditor
{
    /*
    /// <summary>
    /// For editing multiple scripts. Checks if all fields contain the same value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool CheckAll<T, S>(S[] scripts, System.Func<T, bool> predicate)
    {
        T valueChecked;
        for (int i = 0; i < scripts.Length; i++)
        {
                
        }
        
        if ()
        {
            return (false, valueChecked);
        }
        else
        {
            return (true, valueChecked);
        }
            
    }*/
    /// <summary>
    /// Im missing docs here. Send me a hate message if you for whatever reason need to use this
    /// </summary>
    /// <typeparam name="ArrayType"></typeparam>
    /// <typeparam name="MemberType"></typeparam>
    /// <param name="source"></param>
    /// <param name="getMember"></param>
    /// <returns></returns>
    public static bool CheckAlls<ArrayType, MemberType>(this IEnumerable<ArrayType> source, Func<ArrayType, MemberType> getMember)
    {
        //if (source.Count() == 0) return false;
        MemberType first = getMember(source.First());
        return source.All(x => getMember(x).Equals(first));
    }
    public static Vector2 ClosestPoint(this Collider2D[] arr, Vector2 point)
    {
        throw new NotImplementedException();

        return Vector2.zero;
    }
}
/// <summary>
/// A struct for containing a precalculated rotation
/// </summary>
public struct RotationMatrix2
{
    public float cos;
    public float sin;
    public void SetRotation(float angle)
    {

    }
    public Vector2 Rotate(Vector2 m) => throw new NotImplementedException();
    
}
