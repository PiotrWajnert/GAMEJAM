using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    List<Item> items = new List<Item>();
    Queue<Item> itemsQueue = new Queue<Item>();
    int itemsOnBoard = 8;

    // Start is called before the first frame update
    public void AddItem(Item itemToAdd)
    {
        if (itemsQueue.Count == 8)
        {
            Item itemToDestroy = itemsQueue.Dequeue();
            Destroy(itemToDestroy.gameObject);
        }
        
        itemsQueue.Enqueue(itemToAdd);             
        UpdateInventoryUI();
    }

    public void RemoveItem(Item itemToRemove)
    {
        items = itemsQueue.ToList();
        items.Remove(itemToRemove);
        itemsQueue.Clear();
        foreach(Item i in items)
        {
            itemsQueue.Enqueue(i);
        }
        UpdateInventoryUI();
    }

    public Queue<Item> GetItems()
    {
        return itemsQueue;
    }

    public void UpdateInventoryUI()
    {
        InventorySlotsManager.Instance.UpdateInventorySlot(itemsQueue);
        /*int counter = 0;
        foreach(Item i in itemsQueue)
        {
            counter++;
            if (counter <5)
            i.image.rectTransform.position = new Vector2(-50+ 250 * counter, 375);          
            else
                i.image.rectTransform.position = new Vector2(-50 + 250 * (counter-4), 100);
        }*/
        
    }
}
