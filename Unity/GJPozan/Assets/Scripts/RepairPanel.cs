using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPanel : MonoBehaviour
{
    public static RepairPanel Instance;
    Queue<Item> repairItems = new Queue<Item>();

    void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item itemToAdd)
    {
        if(repairItems.Count == 4)
        {
            Item itemToRemove = repairItems.Dequeue();
            itemToRemove.inInventory = true;
            GameManager.Instance.inventory.AddItem(itemToRemove);
            repairItems.Enqueue(itemToAdd);
        }
        else
        {
            repairItems.Enqueue(itemToAdd);
        }
        UpdateRepairSlots();
    }


    public void JobDone()
    {
        GameManager.Instance.sword.Repair(repairItems);

    }

    public void UpdateRepairSlots()
    {
        RepairSlotManager.Instance.UpdateRepairSlots(repairItems);
    }
    private void OnDisable()
    {
        repairItems.Clear();
        RepairSlotManager.Instance.ClearSlots();
    }
}
