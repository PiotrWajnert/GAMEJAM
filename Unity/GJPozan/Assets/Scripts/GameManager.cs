using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject[] windmills;
    public Sword sword;
    private Monster monster;
    [SerializeField]
    private Transform windmillStartPoint;
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

    IEnumerator PrepareBattlefield()
    {
        sword.UpdateKnightUI();
        yield return new WaitForSeconds(2);
        int randomMonster = Random.Range(0, windmills.Length);
        GameObject instance = Instantiate(windmills[randomMonster], windmillStartPoint.position, Quaternion.identity);
        monster = instance.GetComponent<Monster>();
        monster.UpdateKnightUI();
        UIManager.Instance.ActiveMonsterHP(monster);
        if (monster == null) Debug.Log("WTF!!!!!!!!!!!!!!!!!!!!!!!!!!");
        //monster.Reset();
        
    }
    IEnumerator Battle()
    {
        yield return new WaitForSeconds(2);

        while (sword.GetHealth() > 0 && monster.GetHealth() > 0)
        {
           // Debug.Log("Sword Attack");

           // sword.Attack(monster);
            //Debug.Log("Sword Specjal Attack");
            sword.SpecialAttack(monster);

            monster.Attack(sword);
            yield return new WaitForSeconds(1);
         }
         Debug.Log("Koniec walki");
         sword.EndMessage();
        if (monster.GetHealth() <= 0)
        {
            UIManager.Instance.DeactivateMonsterHP();
            Destroy(monster.gameObject);
        }

        
        if (sword.GetHealth() <= 0)
        {
            //gameover
        }
    }

    IEnumerator Picking()
    {
        UIManager.Instance.ActivateTimer();
        while (Timer.Instance.isActiveAndEnabled)
        {
            yield return null;
        }
        Debug.Log("POCZASIE!");
        
    }

    IEnumerator Repairing()
    {
        while (RepairPanel.Instance.isActiveAndEnabled)
        {
            yield return null;
        }
        Debug.Log("PONaprawie!");
    }
    IEnumerator Gameloop()
    {
        yield return StartCoroutine(PrepareBattlefield());
        yield return StartCoroutine(Battle());
        yield return StartCoroutine(Picking());
        yield return StartCoroutine(Repairing());
        Debug.Log("koniec gameloopu");
        StartGame();
    }

    void StartGame()
    {
        StartCoroutine(Gameloop());
    }


    /*
     * Equipment 
     * 
     * Item metal.Effect();
     */
}
