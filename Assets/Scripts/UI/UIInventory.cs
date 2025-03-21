using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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

    private void Awake()
    {
        InitInventoryUI();
    }

    private void Start()
    {
        exit.onClick.AddListener(() => UIManager.Instance.ToggleInventoryUI());
    }

    public void InitInventoryUI()
    {
        Debug.Log($"InitInventoryUI ȣ���! inventorySize: {inventorySize}");
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
        Debug.Log("SetInventoryItems ȣ���!");
        Debug.Log($"inventoryItems.Count: {inventoryItems.Count}");
        Debug.Log($"slotList.Count: {slotList.Count}");

        RefreshAllSlots();

        for (int i = 0; i < inventoryItems.Count && i < slotList.Count; i++)
        {
            Debug.Log($"for�� ����");
            if (inventoryItems[i] == null)
            {
                Debug.Log($"inventoryItems[{i}]�� null�Դϴ�.");
            }
            else
            {
                slotList[i].SetItem(inventoryItems[i]);
                Debug.Log($"���� {i}�� {inventoryItems[i].name} �߰���");
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
        {
            UnequipItem(equippedItems[newItem.itemType]);
        }

        equippedItems[newItem.itemType] = newItem; // ������ ����
        Debug.Log($"{newItem.name} ���� �Ϸ�");

        RefreshAllSlots(); // ��� ���� UI ����
    }

    public void UnequipItem(Item item)
    {
        if (item == null || !equippedItems.ContainsKey(item.itemType)) return;

        equippedItems.Remove(item.itemType); // ���� ����
        Debug.Log($"{item.name} ���� ����");

        RefreshAllSlots(); // ��� ���� UI ����
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
