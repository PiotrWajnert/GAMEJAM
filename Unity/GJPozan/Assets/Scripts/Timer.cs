using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public UnityAction onTimerEnds;
    private Slider slider;
    [SerializeField]
    private float time;

    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = time;
        slider.value = time;
    }

    private void Update()
    {
        slider.value -= Time.deltaTime;
        if (slider.value <= 0) slider.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        onTimerEnds?.Invoke();
    }
}
