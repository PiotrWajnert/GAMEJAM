using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Actor
{
    private int baseDmg = 5;
    private int flameDmg = 0;
    private int bluntDmd = 0;
    private int cutDmg = 0;

    public void Repair(Queue<Item> items)
    {
        List<Item> itemToDestroy = new List<Item>();
        foreach(Item i in items)
        {

            switch (i.itemType)
            {
                case Item.ItemType.METAL:
                    Debug.Log("Add durability");
                    health++;
                    break;

                case Item.ItemType.FLAME:
                    Debug.Log("Add flame");
                    flameDmg++;
                    break;
            }
            itemToDestroy.Add(i);

        }
        items.Clear();
       foreach (Item i in itemToDestroy)
        {
            Debug.Log("Niiszczymy");
            Destroy(i.gameObject); 
        }
        
    }

    public void SpecialAttack(Monster opponent)
    {
        Attack(opponent);
        switch (opponent.monsterType)
        {
            case (Monster.MonsterType.WOODEN):
                opponent.Damage(flameDmg);
                break;
        }
            
    }
}
