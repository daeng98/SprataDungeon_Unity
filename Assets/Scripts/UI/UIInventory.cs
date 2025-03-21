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
        Debug.Log($"InitInventoryUI 호출됨! inventorySize: {inventorySize}");
        for (int i = 0; i < inventorySize; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotParent);
            UISlot slot = newSlot.GetComponent<UISlot>();

            slot.SetInventory(this); // 슬롯에 UIInventory 전달

            slotList.Add(slot);
        }
    }

    public void SetInventoryItems(List<Item> inventoryItems)
    {
        Debug.Log("SetInventoryItems 호출됨!");
        Debug.Log($"inventoryItems.Count: {inventoryItems.Count}");
        Debug.Log($"slotList.Count: {slotList.Count}");

        RefreshAllSlots();

        for (int i = 0; i < inventoryItems.Count && i < slotList.Count; i++)
        {
            Debug.Log($"for문 진입");
            if (inventoryItems[i] == null)
            {
                Debug.Log($"inventoryItems[{i}]가 null입니다.");
            }
            else
            {
                slotList[i].SetItem(inventoryItems[i]);
                Debug.Log($"슬롯 {i}에 {inventoryItems[i].name} 추가됨");
            }
        }
    }

    public bool CanEquip(Item newItem)
    {
        if (newItem == null) return false;

        // 같은 타입의 아이템이 이미 장착되어 있는지 확인
        return !equippedItems.ContainsKey(newItem.itemType);
    }

    public void EquipItem(Item newItem)
    {
        if (newItem == null) return;

        // 같은 타입의 아이템이 장착되어 있다면 먼저 해제
        if (equippedItems.ContainsKey(newItem.itemType))
        {
            UnequipItem(equippedItems[newItem.itemType]);
        }

        equippedItems[newItem.itemType] = newItem; // 아이템 장착
        Debug.Log($"{newItem.name} 장착 완료");

        RefreshAllSlots(); // 모든 슬롯 UI 갱신
    }

    public void UnequipItem(Item item)
    {
        if (item == null || !equippedItems.ContainsKey(item.itemType)) return;

        equippedItems.Remove(item.itemType); // 장착 해제
        Debug.Log($"{item.name} 장착 해제");

        RefreshAllSlots(); // 모든 슬롯 UI 갱신
    }

    public Item GetEquippedItem(ItemType type)
    {
        return equippedItems.ContainsKey(type) ? equippedItems[type] : null;
    }

    public void RefreshAllSlots()
    {
        foreach (var slot in slotList)
        {
            slot.RefreshUI(); // 모든 슬롯 UI 업데이트
        }
    }
}
