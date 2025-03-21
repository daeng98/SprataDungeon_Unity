using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public UIInventory uiInventory;
    [SerializeField] public List<Item> allItems;

    public Character character { get; set; }

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        SetData();
        uiInventory.InitInventoryUI();
        uiInventory.SetInventoryItems(allItems);
    }

    private void SetData()
    {
        character = new Character("Slime", 2, 1000, 20, 15, 100, 5);
        UIManager.Instance.UpdateAllUI(character);
    }
}
