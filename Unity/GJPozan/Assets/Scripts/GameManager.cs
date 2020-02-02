using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject[] windmills;
    public GameObject[] scraps;
    public PlayerController player;
    public Knight don;
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
        WaveManager.Instance.PrepareQueue();
        StartGame();
    }

    IEnumerator PrepareBattlefield()
    {
 
        player.canCollect = false;
        player.elapsedTime = 0;
        player.onTheWay = false;
        player.animator.SetBool("walk", false);
        sword.UpdateKnightUI();
        yield return new WaitForSeconds(2);
        int next = WaveManager.Instance.GetMonster();
        GameObject nextMonster = Instantiate(windmills[next], windmillStartPoint.position, Quaternion.identity);
        monster = nextMonster.GetComponent<Monster>();
        monster.UpdateKnightUI();
        UIManager.Instance.ActiveMonsterHP(monster);
        NextWindmill.Instance.UpdateNextWindmill();
        if (monster == null) Debug.Log("WTF!!!!!!!!!!!!!!!!!!!!!!!!!!");
        //monster.Reset();
        
    }
    IEnumerator Battle()
    {
        don.anim.SetBool("attack", true);
        yield return new WaitForSeconds(1);
        
        while (sword.GetHealth() > 0 && monster.GetHealth() > 0)
        {
            sword.SpecialAttack(monster);
            monster.Attack(sword);

            //scrap
            
            int quantity = Random.Range(1, 3);
            for(int i = 0; i < quantity; i++)
            {
                int randomScrap = Random.Range(0, scraps.Length);
                float randomX = Random.Range(-2.25f, 2.25f);
                float randomY = Random.Range(1.85f, -2f);
                Vector3 scrapPosition = new Vector3(randomX, randomY, -1);
                Instantiate(scraps[randomScrap], scrapPosition, Quaternion.identity);
            }
            
            yield return new WaitForSeconds(1);
         }
        don.anim.SetBool("attack", false);
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
        player.canCollect = true;
        UIManager.Instance.ActivateTimer();
        while (Timer.Instance.isActiveAndEnabled)
        {
            yield return null;
        }
        Debug.Log("POCZASIE!");

        player.canCollect = false;
        
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
