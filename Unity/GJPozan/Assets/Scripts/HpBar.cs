using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    
    [SerializeField]
    private Actor actor;

    Slider slider;

    private void OnEnable()
    {
        actor.onValueHPChange += ChangeSliderValue;
    }

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = actor.GetHealth();
    }

    private void ChangeSliderValue(int value)
    {
        slider.value = value;
    }
}
