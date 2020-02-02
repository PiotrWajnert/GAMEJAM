using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    public Item itemOnSlot;

    public void OnPointerDown(PointerEventData eventData)
    {       
        if(itemOnSlot.inInventory && UIManager.Instance.IsRepairPanelActive())
        {
            RepairPanel.Instance.AddItem(itemOnSlot);
            itemOnSlot.inInventory = false;
            GameManager.Instance.inventory.RemoveItem(itemOnSlot);
        }
            
        

    }
}
