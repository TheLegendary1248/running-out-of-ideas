using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// WRITE DESC PLS
/// </summary>
public class MasterManager : MonoBehaviour
{
    /// <summary>
    /// The scene the game loads in first
    /// </summary>
    public Scene initializerScene;
    public static string currentLevelName;
    private void Start()
    {
        //Miscellanous code for testing already loaded scenes
        if(SceneManager.sceneCount == 1)
        {   //Game starts as usual. Loads the only scene that should be in the build index
            SceneManager.LoadScene(0, LoadSceneMode.Additive);
        }
        else
        {   //Game starts as usual- usually...
            //NEEDS CODE FOR EXCEPTIONS AS TO NOT TERRIBLY SCREW UP
            currentLevelName = SceneManager.GetActiveScene().name;
        }
        
    }
    public static void LoadScene(string str)
    {
        //Trigger switch
        AsyncOperation sceneUnload = SceneManager.UnloadSceneAsync(currentLevelName);
        AsyncOperation sceneLoad   = SceneManager.LoadSceneAsync(str, LoadSceneMode.Additive);
        //Ensure only one level is loaded at a time
        sceneLoad.allowSceneActivation = false;
        sceneUnload.completed += (_) => sceneLoad.allowSceneActivation = true;
        currentLevelName = str;
    }
}
