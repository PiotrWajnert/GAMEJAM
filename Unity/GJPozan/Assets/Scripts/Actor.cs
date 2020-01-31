using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    private int health = 10;
    private int dmg = 2;


    public void Attack(Actor opponent)
    {
        opponent.Damage(dmg);
    }
    
    public void Damage(int dmg)
    {
        health -= dmg;
        Debug.Log("health: " + health);
    }

    public int GetHealth()
    {
        return health;
    }
}
