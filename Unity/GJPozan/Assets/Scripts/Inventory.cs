using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> items = new List<Item>();
    int itemsOnBoard = 8;

    // Start is called before the first frame update
    public void AddItem(Item itemToAdd)
    {
        items.Add(itemToAdd);
        UpdateInventoryUI();
    }

    public void RemoveItem(Item itemToRemove)
    {
        items.Remove(itemToRemove);
        UpdateInventoryUI();
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public void UpdateInventoryUI()
    {
        int counter = 0;
        foreach(Item i in items)
        {
            counter++;
            if (counter <5)
            i.image.rectTransform.position = new Vector2(-50+ 250 * counter, 375);          
            else
                i.image.rectTransform.position = new Vector2(-50 + 250 * (counter-4), 100);
        }
        
    }
}
