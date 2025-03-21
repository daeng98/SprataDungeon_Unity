using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public event Action OnStatsChanged;

    public string Name { get;  set; }
    public int Level { get;  set; }
    public int Gold { get;  set; }

    private int attack;
    private int defense;
    private int health;
    private int critical;

    public int Attack
    {
        get => attack;
        set
        {
            attack = Mathf.Max(0, value);
            OnStatsChanged?.Invoke();
            Debug.Log($"[Ω∫≈» ∫Ø∞Ê] Attack: {attack}");
        }
    }

    public int Defense
    {
        get => defense;
        set
        {
            defense = Mathf.Max(0, value);
            OnStatsChanged?.Invoke();
            Debug.Log($"[Ω∫≈» ∫Ø∞Ê] Defense: {defense}");
        }
    }

    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Max(1, value);
            OnStatsChanged?.Invoke();
            Debug.Log($"[Ω∫≈» ∫Ø∞Ê] Health: {health}");
        }
    }

    public int Critical
    {
        get => critical;
        set
        {
            critical = Mathf.Clamp(value, 0, 100);
            OnStatsChanged?.Invoke();
            Debug.Log($"[Ω∫≈» ∫Ø∞Ê] Critical: {critical}");
        }
    }

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
