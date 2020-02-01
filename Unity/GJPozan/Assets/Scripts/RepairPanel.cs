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
        int counter = 0;
        foreach (Item i in repairItems)
        {
            counter++;
            i.image.rectTransform.position = new Vector2(225 * counter, 1000);
        }
    }
}
