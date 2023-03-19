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
    public TextMeshProUGUI tmp;
    public Image img;
    public Launcher itemRef;
    List<Coroutine> routines;
    public void SetItem()
    {
        StartCoroutine(AnimateGet());
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
        const float time = 0.5f;
        float timeStamp = Time.fixedTime;
        float timeDif = Time.fixedTime - time;
        string itemName = "Weapon Name";
        while(timeDif < timeStamp)
        {
            float range = (Time.fixedTime - timeStamp) / time;
            //Lerp Image
            Vector2 anchorMax = img.rectTransform.anchorMax;
            anchorMax.x = range;
            img.rectTransform.anchorMax = anchorMax;
            //Lerp text
            tmp.text = itemName.Substring(0, Mathf.Min(itemName.Length - 1,(int)(range * itemName.Length)));
            //Iterate
            yield return new WaitForFixedUpdate();
            timeDif = Time.fixedTime - time;
        }
        //End State
        tmp.text = itemName;
        img.rectTransform.anchorMax = Vector2.one;
        yield return null;
    }
    //Manually runs 'FixedUpdate' for the previous
    IEnumerator RunAnims()
    {
        yield return null;
    }
    
    
}
