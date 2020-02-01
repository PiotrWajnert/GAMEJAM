using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpBar : MonoBehaviour
{
    private Actor actor;

    Slider slider;
    private void OnEnable()
    {
        slider = GetComponent<Slider>();
    }
    private void Start()
    {
        
        //slider.maxValue = actor.GetHealth();
    }

    private void ChangeSliderValue(int value)
    {
        slider.value = value;
    }

    public void SetActor(Actor actorV)
    {
        actor = actorV;
        slider.maxValue = actor.GetHealth();
        slider.value = actor.GetHealth();
        actor.onValueHPChange += ChangeSliderValue;
    }
}
