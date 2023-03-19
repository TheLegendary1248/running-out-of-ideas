using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>Main interface to control the player's Inventory UI</summary>
public class UI_Inventory : MonoBehaviour
{
    public UI_ItemSlot primary;
    public UI_ItemSlot secondary;
    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            primary.UsedItem();
        }
    }

}
