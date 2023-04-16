using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Utility Functions
/// </summary>
public static class Utils
{
    public static class StandardColors
    {
        //Cyan-ish color that should be used for displaying AOE's
        public static Color AOEColor = new Color(0f, 0.5f, 1f, 0.5f);
        public static Color NotifyColor = new Color(0f, 0.5f, 1f, 0.5f);
        public static Color DetectColor = new Color(1f, 0f, 0f, 0.75f);
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
}
