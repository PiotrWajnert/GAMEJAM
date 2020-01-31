using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField]
    private Actor actor1 = new Actor();
    [SerializeField]
    private Actor actor2 = new Actor();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");

        //startbattle
        //atack knight 
        //atack monster
        // check is alive
        //reapet
    }

    // Update is called once per frame
    void Update()
    {
        if (actor1.GetHealth() > 0  || actor2.GetHealth() > 0)
        {
            actor1.Attack(actor1);
            actor2.Attack(actor2);
        }
        else
        {
            Debug.Log("gameobver");
        }
    }
}
