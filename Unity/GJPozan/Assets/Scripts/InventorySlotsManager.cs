using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class InventorySlotsManager : MonoBehaviour
{
    public static InventorySlotsManager Instance;
    public Sprite[] sprites;
    public Image[] images;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInventorySlot(Queue<Item> items)
    {
        int decounter = 8;      
        int counter = 0;
        foreach(Item i in items)
        {
            decounter--;
            images[counter].enabled = true;
            images[counter].sprite = sprites[i.GetItemType()];
            Slot slot = images[counter].GetComponent<Slot>();
            slot.itemOnSlot = i;
           
            counter++;
        }
        for(int i = 0; i < decounter; i++)
        {
            decounter--;
            images[counter].enabled = false;
            Slot slot = images[counter].GetComponent<Slot>();
            slot.itemOnSlot = null;
            counter++;
        }
        
    }
}
