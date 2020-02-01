using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    [SerializeField]
    private float width = 9f;
    [SerializeField]
    private float height = 16f;

    void Awake()
    {
        Camera.main.aspect = width / height;
    }
}
