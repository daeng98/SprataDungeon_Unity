using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Gold { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int Critical { get; private set; }

    public Character(string name, int level, int gold, int attack, int defense, int health, int critical)
    {
        Name = name;
        Level = level;
        Gold = gold;
        Attack = attack;
        Defense = defense;
        Health = health;
        Critical = critical;
    }

    public void plusGold(int amount)
    {
        Gold += amount;
    }

    public void LevelUp()
    {
        Level++;
    }
}
