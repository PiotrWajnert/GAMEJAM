using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWindmill : MonoBehaviour
{
    public static NextWindmill Instance;
    public Sprite[] sprites;
    public SpriteRenderer currentWindmill;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //currentWindmill.GetComponent<SpriteRenderer>();
    }
    public void UpdateNextWindmill()
    {
        currentWindmill.sprite = sprites[WaveManager.Instance.GetNextMonster()];
    }
}
