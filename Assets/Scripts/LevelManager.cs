using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary>Overall script to handle levels in general</summary>
public class LevelManager : MonoBehaviour
{

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard,
    }
    public static Difficulty currentDifficulty => Difficulty.Easy;
    ///<summary>Called by the End Goal or whenever a condition is satisfied for the level to end</summary>
    public static void ExitLevel()
    {

    }
}
