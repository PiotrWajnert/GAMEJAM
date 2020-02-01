using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField]
    private Canvas rPanel;
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private MonsterHpBar monsterBar;
    // Start is called before the first frame update

    private void OnEnable()
    {
        timer.onTimerEnds += ActiveRepairPanel;
    }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }

    public void ActivateTimer()
    {
        timer.gameObject.SetActive(true);
    }
    public void ActiveRepairPanel()
    {
        rPanel.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        timer.onTimerEnds -= ActiveRepairPanel;
    }

    public bool IsRepairPanelActive()
    {
        if (rPanel.isActiveAndEnabled)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ActiveMonsterHP(Actor actor)
    {
        monsterBar.gameObject.SetActive(true);
        monsterBar.SetActor(actor);
    }
    public void DeactivateMonsterHP()
    {
        monsterBar.gameObject.SetActive(false);
    }
}
