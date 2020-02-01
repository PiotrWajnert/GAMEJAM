using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Sword sword;
    public Monster monster;
    public Inventory inventory;

    void Awake()
    {
        Instance = this;
    }
    // walka
    //zbieranie
    // naprawa
    //reapet
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    IEnumerator Battle()
    {
        while (sword.GetHealth() > 0 && monster.GetHealth() > 0)
        {
           // Debug.Log("Sword Attack");

           // sword.Attack(monster);
            //Debug.Log("Sword Specjal Attack");
            sword.SpecialAttack(monster);

            //monster.Attack(sword);
            yield return new WaitForSeconds(1);
         }
         Debug.Log("Koniec walki");
         sword.EndMessage();
         monster.EndMessage();                              
    }

    IEnumerator Repairing()
    {
        //sword.Repair(inventory.GetItems());
        //isFighting = true;
        //isRapairing = false;
        yield return new WaitForSeconds(5);
        
    }

    IEnumerator Gameloop()
    {
        yield return StartCoroutine(Battle());
        yield return StartCoroutine(Repairing());
        Debug.Log("koniec gameloopu");
        StartGame();
    }

    void StartGame()
    {
        monster.Reset();
        StartCoroutine(Gameloop());
    }


    /*
     * Equipment 
     * 
     * Item metal.Effect();
     */
}
