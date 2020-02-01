using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public string name;
    [SerializeField]
    protected int health;
    private int startHealth;
    [SerializeField]
    protected int dmg;
    private int startDmg;

    void Start()
    {
        startHealth = health;
        startDmg = dmg;
    }
    public void Attack(Actor opponent)
    {
        opponent.Damage(dmg);
    }
    
    public void Damage(int dealDamage)
    {
        health -= dealDamage;
        Debug.Log(name + " health: " + health);
    }

    public int GetHealth()
    {
        return health;
    }

    public void EndMessage()
    {
        Debug.Log(name + " health: " + health);
    }
    public void Reset()
    {
        health = startHealth;
        dmg = startDmg;
    }
}
