using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndPanelUI : MonoBehaviour
{
    public static EndPanelUI Instance;

    public Text text;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeText(int dead)
    {
        text.text = "TOWNS WITHOUT BREAD: " + dead;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
