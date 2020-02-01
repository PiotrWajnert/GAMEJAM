using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LancaStatsUI : MonoBehaviour
{
    public static LancaStatsUI Instance;
    [SerializeField]
    private Text stat1;
    [SerializeField]
    private Text stat2;
    [SerializeField]
    private Text stat3;
    [SerializeField]
    private Text stat4;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateLancaUI(int a, int b , int c, int d)
    {
        stat1.text = a.ToString();
        stat2.text = b.ToString();
        stat3.text = c.ToString();
        stat4.text = d.ToString();
    }
}
