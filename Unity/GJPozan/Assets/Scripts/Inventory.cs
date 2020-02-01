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

    public List<Item> GetItems()
    {
        return items;
    }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < itemsOnBoard; i++)
        {
            if(items[i] != null)
            {
                items[i].transform.position = new Vector2(-3.5f, -1.5f);
            }
        }
       
    }
}
