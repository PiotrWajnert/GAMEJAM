using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    public bool onTheWay = false;
    public Animator animator;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public float elapsedTime = 0;
    public float moveTime = 1;
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
        if (onTheWay)
        {
            elapsedTime += Time.deltaTime / moveTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
            if (elapsedTime > 1)
            {

                onTheWay = false;
                animator.SetBool("walk", false);
                elapsedTime = 0;
            }
        }
           

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



}
