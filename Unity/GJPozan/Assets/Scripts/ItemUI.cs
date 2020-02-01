using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Item item = this.transform.parent.transform.parent.GetComponent<Item>();
        if (item.inInventory)
        {
            RepairPanel.Instance.AddItem(item);
            item.inInventory = false;
            GameManager.Instance.inventory.RemoveItem(item);
        }
        
    }
}
