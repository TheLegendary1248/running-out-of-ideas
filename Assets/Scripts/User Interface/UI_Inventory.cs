using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>Main interface to control the player's Inventory UI</summary>
public class UI_Inventory : MonoBehaviour
{
    public UI_ItemSlot primary;
    public UI_ItemSlot secondary;
    public void Awake()
    {
        Player.PlayerFired += Used;
        Player.PlayerInventoryChanged += UpdateInventory;
    }
    public void Used() => primary.UsedItem();
    public void UpdateInventory()
    {
        var inv = Player.instance.holding;
        if(inv.Count > 0)
        {
            primary.SetItem(Player.instance.holding[0]);
        }
        if(inv.Count > 1)
        {
            secondary.SetItem(Player.instance.holding[1]);
        }
        
    }
}
