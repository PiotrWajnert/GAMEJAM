using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        transform.Translate(movement);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Item item = collider.GetComponent<Item>();
        GameManager.Instance.inventory.AddItem(item);
        item.Hide();
    }
}
