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
    public int Experience { get; private set; }
    public int ExpToNextLevel => Level * 10;

    public string Title => GetTitle(Level);
    public string Info => GetInfo(Level);

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
            Debug.Log($"[스탯 변경] Attack: {attack}");
        }
    }

    public int Defense
    {
        get => defense;
        set
        {
            defense = Mathf.Max(0, value);
            OnStatsChanged?.Invoke();
            Debug.Log($"[스탯 변경] Defense: {defense}");
        }
    }

    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Max(1, value);
            OnStatsChanged?.Invoke();
            Debug.Log($"[스탯 변경] Health: {health}");
        }
    }

    public int Critical
    {
        get => critical;
        set
        {
            critical = Mathf.Clamp(value, 0, 100);
            OnStatsChanged?.Invoke();
            Debug.Log($"[스탯 변경] Critical: {critical}");
        }
    }

    public Character(string name, int level, int gold, int attack, int defense, int health, int critical)
    {
        Name = name;
        Level = level;
        Gold = gold;
        Experience = 0;
        Attack = attack;
        Defense = defense;
        Health = health;
        Critical = critical;
    }

    private string GetTitle(int level)
    {
        if (level >= 10) return "전설";
        if (level >= 7) return "영웅";
        if (level >= 5) return "숙련";
        if (level >= 3) return "평범";
        if (level >= 1) return "초보";
        return "뉴비";
    }

    private string GetInfo(int level)
    {
        if (level >= 10) return "전설적인 모험가 입니다.";
        if (level >= 7) return "영웅적인 모험가 입니다.";
        if (level >= 5) return "어느정도 숙련된 모험가 입니다.";
        if (level >= 3) return "초보 딱지를 땐 평범한 모험가 입니다.";
        if (level >= 1) return "이제 걸음마를 땐 초보 모험가 입니다.";
        return "이제 막 시작한 뉴비 입니다.";
    }

    public void AddExperience(int amount)
    {
        Experience += amount;
        Debug.Log($"경험치 획득: {amount} (현재 경험치: {Experience} / {ExpToNextLevel})");

        if (Experience >= ExpToNextLevel)
        {
            LevelUp();
        }

        OnStatsChanged?.Invoke();
    }

    public void plusGold(int amount)
    {
        Gold += amount;
    }

    public void LevelUp()
    {
        Experience -= ExpToNextLevel;
        Level++;
        attack += 1;
        defense += 1;
        health += 10;
        critical += 1;
        Debug.Log($"레벨업 현재 레벨: {Level} (칭호: {Title})");
    }
}
