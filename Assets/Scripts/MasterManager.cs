using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterManager : MonoBehaviour
{
    /// <summary>
    /// The scene the game loads in first
    /// </summary>
    public Scene initializerScene;
    private void Start()
    {
        //Miscellanous code for testing already loaded scenes
        if(SceneManager.sceneCount == 1)
        {   //Game starts as usual. Loads the only scene that should be in the build index
            SceneManager.LoadScene(0, LoadSceneMode.Additive);
        }
        else
        {   //Game starts as usual- usually...

        }
        
    }
    void LoadScene(string str)
    {
        
    }
}
