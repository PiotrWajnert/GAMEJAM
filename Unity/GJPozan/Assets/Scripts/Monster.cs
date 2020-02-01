using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Actor
{ 
    public enum MonsterType { WOODEN, IRON, STONE}

    [SerializeField]
    public MonsterType monsterType;    

}
