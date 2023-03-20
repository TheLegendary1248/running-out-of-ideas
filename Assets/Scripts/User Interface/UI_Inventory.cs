using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>Main interface to control the player's Inventory UI</summary>
public class UI_Inventory : MonoBehaviour
{
    public UI_ItemSlot[] slots;
    public void Awake()
    {
        Player.PlayerFired += Used;
        Player.PlayerInventoryChanged += UpdateInventory;
    }
    public void Used() => slots[Player.instance.currentHeld].UsedItem();
    public void UpdateInventory()
    {
        var inv = Player.instance.holding;
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inv.Count)
            {
                slots[i].SetItem(inv[i]);
            }
            else slots[i].SetItem(null);
        }
    }
}
