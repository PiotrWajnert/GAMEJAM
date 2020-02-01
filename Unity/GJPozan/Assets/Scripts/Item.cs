using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string name;
    public enum ItemType { METAL, FLAME}
    [SerializeField]
    public ItemType itemType;
    [SerializeField]
    private BoxCollider2D boxCollider2d;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hide()
    {
        spriteRenderer.enabled = false;
        boxCollider2d.enabled = false;
    }

    public void Show()
    {
        spriteRenderer.enabled = true;
        boxCollider2d.enabled = true;
    }
}
