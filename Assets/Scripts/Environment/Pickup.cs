using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string weapon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IWielder wielder = collision.gameObject.GetComponent<IWielder>();
        if(wielder != null)
        {
            wielder.holding[wielder.currentHeld] = SO_Launcher.GetLauncher(weapon);
        }
    }
}
