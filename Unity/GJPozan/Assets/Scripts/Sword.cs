using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Actor
{
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    private int baseDmg = 5;
    private int flameDmg = 0;
    private int bluntDmg = 0;
    private int cutDmg = 0;

    private void Start()
    {
        LancaStatsUI.Instance.UpdateLancaUI(baseDmg, flameDmg, bluntDmg, cutDmg);
    }
    public void Repair(Queue<Item> items)
    {
        List<Item> itemToDestroy = new List<Item>();
        foreach(Item i in items)
        {

            switch (i.itemType)
            {
                case global::Item.ItemType.METAL:
                    Debug.Log("Add durability");
                    health += 5;
                    break;

                case global::Item.ItemType.FLAME:
                    Debug.Log("Add flame");
                    flameDmg++;
                    break;
                case global::Item.ItemType.BLUNT:
                    Debug.Log("Add flame");
                    bluntDmg++;
                    break;
                case global::Item.ItemType.CUT:
                    Debug.Log("Add flame");
                    cutDmg++;
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

        LancaStatsUI.Instance.UpdateLancaUI(baseDmg, flameDmg, bluntDmg, cutDmg);
    }

    public void SpecialAttack(Monster opponent)
    {
        Attack(opponent);
        switch (opponent.monsterType)
        {
            case (Monster.MonsterType.WOODEN):
                opponent.Damage(flameDmg);
                break;
            case (Monster.MonsterType.IRON):
                opponent.Damage(cutDmg);
                break;
            case (Monster.MonsterType.STONE):
                opponent.Damage(bluntDmg);
                break;
        }
            
    }

    private void Update()
    {
        if(health > 20)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if(health  > 10 && health<= 20)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else
        {
            spriteRenderer.sprite = sprites[2];
        }
    }
}

