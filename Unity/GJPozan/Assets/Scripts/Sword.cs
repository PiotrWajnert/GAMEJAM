using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Actor
{
    private int baseDmg = 5;
    private int flameDmg = 2;
    private int otherDmd = 0;

    public void Repair(List<Item> items)
    {
        foreach(Item i in items)
        {
            switch (i.itemType)
            {
                case Item.ItemType.METAL:
                    health++;
                    break;

                case Item.ItemType.FLAME:
                    flameDmg++;
                    break;
            }
                
                    
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
