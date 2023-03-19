using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// Controls an Item Slot
/// </summary>
public class UI_ItemSlot : MonoBehaviour
{
    public TextMeshPro text;
    public Image img;
    List<Coroutine> routines;
    public void SetItem()
    {

    }
    public void RemoveItem()
    {

    }
    public void UsedItem()
    {

    }
    //Animates usage of an item on the UI
    IEnumerator AnimateShot()
    {
        float timestamp = Time.fixedTime;
        yield return null;
    }
    //Animates get of an item on the UI
    IEnumerator AnimateGet()
    {
        
        yield return null;
    }
    //Manually runs 'FixedUpdate' for the previous
    IEnumerator RunAnims()
    {
        yield return null;
    }
    
    
}
