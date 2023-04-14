using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPortal : MonoBehaviour
{
    public string LevelName;
    public void Awake()
    {
        //Update to utilize unity console effectively
        if (string.IsNullOrEmpty(LevelName)) throw new System.MissingFieldException($"Level Portal Name on {gameObject.name} is empty");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            MasterManager.LoadScene(LevelName);
        }
    }
}
