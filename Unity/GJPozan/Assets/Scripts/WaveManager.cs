using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    public int windmillsNumber;
    Queue<int> wave = new Queue<int>();
    //prepare Wndmillqueue
    //return first windmill and create new one
    // show second windmill in background
    private void Awake()
    {
        Instance = this;
    }
    public void PrepareQueue()
    {
        int randomMonster1 = Random.Range(0, windmillsNumber);
        wave.Enqueue(randomMonster1);
        int randomMonster2 = Random.Range(0, windmillsNumber);
        wave.Enqueue(randomMonster2);
    }

    public int GetMonster()
    {
        int randomMonster2 = Random.Range(0, windmillsNumber);
        wave.Enqueue(randomMonster2);
        return wave.Dequeue();
    }

    public int GetNextMonster()
    {
        int[] waveArray = wave.ToArray();
        return waveArray[0];
    }
}
