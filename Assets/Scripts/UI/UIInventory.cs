using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static Item;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private Button exit;

    public List<UISlot> slotList = new List<UISlot>();
    private Dictionary<ItemType, Item> equippedItems = new Dictionary<ItemType, Item>();

    public int inventorySize = 20;

    private void Start()
    {
        exit.onClick.AddListener(() => UIManager.Instance.ToggleInventoryUI());
    }

    private void OnEnable()
    {
        SetInventoryItems(GameManager.Instance.allItems);
    }

    public void InitInventoryUI()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotParent);
            UISlot slot = newSlot.GetComponent<UISlot>();

            slot.SetInventory(this); // ���Կ� UIInventory ����

            slotList.Add(slot);
        }
    }

    public void SetInventoryItems(List<Item> inventoryItems)
    {
        if (slotList == null || slotList.Count == 0)
        {
            InitInventoryUI();
        }

        RefreshAllSlots();

        for (int i = 0; i < inventoryItems.Count && i < slotList.Count; i++)
        {
            if (inventoryItems[i] == null)
            {
                Debug.Log($"inventoryItems[{i}]�� null�Դϴ�.");
            }
            else
            {
                slotList[i].SetItem(inventoryItems[i]);
            }
        }
    }

    public bool CanEquip(Item newItem)
    {
        if (newItem == null) return false;

        // ���� Ÿ���� �������� �̹� �����Ǿ� �ִ��� Ȯ��
        return !equippedItems.ContainsKey(newItem.itemType);
    }

    public void EquipItem(Item newItem)
    {
        if (newItem == null) return;

        // ���� Ÿ���� �������� �����Ǿ� �ִٸ� ���� ����
        if (equippedItems.ContainsKey(newItem.itemType))    
            UnequipItem(equippedItems[newItem.itemType]);

        if (CanEquip(newItem))
        {
            equippedItems[newItem.itemType] = newItem; // ������ ����
            ApplyItemStats(newItem, true);
        }

        RefreshAllSlots(); // ��� ���� UI ����
    }

    public void UnequipItem(Item item)
    {
        if (item == null || !equippedItems.ContainsKey(item.itemType)) return;
        {
            equippedItems.Remove(item.itemType); // ���� ����
            ApplyItemStats(item, false);
        }

        RefreshAllSlots(); // ��� ���� UI ����
    }

    private void ApplyItemStats(Item item, bool isEquipping)
    {
        var character = GameManager.Instance.character;
        int modifier = isEquipping ? 1 : -1;

        Dictionary<ItemType, Action> stat = new Dictionary<ItemType, Action>
        {
        { ItemType.Attack, () => character.Attack += item.statValue * modifier },
        { ItemType.Defense, () => character.Defense += item.statValue * modifier },
        { ItemType.Health, () => character.Health += item.statValue * modifier },
        { ItemType.Critical, () => character.Critical += item.statValue * modifier }
    };

        if (stat.TryGetValue(item.itemType, out Action applyStat))
        {
            applyStat();
        }
    }

    public Item GetEquippedItem(ItemType type)
    {
        return equippedItems.ContainsKey(type) ? equippedItems[type] : null;
    }

    public void RefreshAllSlots()
    {
        foreach (var slot in slotList)
        {
            slot.RefreshUI(); // ��� ���� UI ������Ʈ
        }
    }
}
