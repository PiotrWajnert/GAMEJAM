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
}
