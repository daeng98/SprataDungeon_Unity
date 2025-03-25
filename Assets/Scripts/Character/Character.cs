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
            Debug.Log($"[���� ����] Attack: {attack}");
        }
    }

    public int Defense
    {
        get => defense;
        set
        {
            defense = Mathf.Max(0, value);
            OnStatsChanged?.Invoke();
            Debug.Log($"[���� ����] Defense: {defense}");
        }
    }

    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Max(1, value);
            OnStatsChanged?.Invoke();
            Debug.Log($"[���� ����] Health: {health}");
        }
    }

    public int Critical
    {
        get => critical;
        set
        {
            critical = Mathf.Clamp(value, 0, 100);
            OnStatsChanged?.Invoke();
            Debug.Log($"[���� ����] Critical: {critical}");
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
        if (level >= 10) return "����";
        if (level >= 7) return "����";
        if (level >= 5) return "����";
        if (level >= 3) return "���";
        if (level >= 1) return "�ʺ�";
        return "����";
    }

    private string GetInfo(int level)
    {
        if (level >= 10) return "�������� ���谡 �Դϴ�.";
        if (level >= 7) return "�������� ���谡 �Դϴ�.";
        if (level >= 5) return "������� ���õ� ���谡 �Դϴ�.";
        if (level >= 3) return "�ʺ� ������ �� ����� ���谡 �Դϴ�.";
        if (level >= 1) return "���� �������� �� �ʺ� ���谡 �Դϴ�.";
        return "���� �� ������ ���� �Դϴ�.";
    }

    public void AddExperience(int amount)
    {
        Experience += amount;
        Debug.Log($"����ġ ȹ��: {amount} (���� ����ġ: {Experience} / {ExpToNextLevel})");

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
        Debug.Log($"������ ���� ����: {Level} (Īȣ: {Title})");
    }
}
