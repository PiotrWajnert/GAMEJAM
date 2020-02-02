using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairSlotManager : MonoBehaviour
{
    public static RepairSlotManager Instance;
    public Sprite[] sprites;
    public Image[] images;
    private void Awake()
    {
        Instance = this;
    }

    public void ClearSlots()
    {
        for (int i = 0; i < 4; i++)
        {
            images[i].enabled = false;
        }
    }
    public void UpdateRepairSlots(Queue<Item> items)
    {
        int decounter = 4;
        int counter = 0;
        foreach (Item i in items)
        {
            decounter--;
            images[counter].enabled = true;
            images[counter].sprite = sprites[i.GetItemType()];
            //Slot slot = images[counter].GetComponent<Slot>();
            //slot.itemOnSlot = i;

            counter++;
        }
        for (int i = 0; i < decounter; i++)
        {
            decounter--;
            images[counter].enabled = false;
            //Slot slot = images[counter].GetComponent<Slot>();
            //slot.itemOnSlot = null;
            counter++;
        }

        
    }
}
