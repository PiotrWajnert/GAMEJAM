using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    public bool canCollect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canCollect)
        {
            Move();
        }
        
    }

    public void Move()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        transform.Translate(movement);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canCollect)
        {
            Item item = collision.collider.GetComponent<Item>();
            GameManager.Instance.inventory.AddItem(item);
            item.Hide();
            item.inInventory = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        Item item = collider.GetComponent<Item>();
        GameManager.Instance.inventory.AddItem(item);
        item.Hide();
        item.inInventory = true;
    }
}
