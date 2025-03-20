using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private Button exit;

    public List<UISlot> slotList = new List<UISlot>();
    private Item equippedItem;

    public int inventorySize = 20;

    private void Start()
    {
        InitInventoryUI();
        exit.onClick.AddListener(() => UIManager.Instance.ToggleInventoryUI());
    }

    public void InitInventoryUI()
    {
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
        RefreshAllSlots(); // 모든 슬롯 초기화

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i] != null) // 아이템 데이터가 존재하는 경우만 추가
            {
                slotList[i].SetItem(inventoryItems[i]);
            }
        }
    }

    public void AddItemToInventory(Item newItem)
    {
        foreach (var slot in slotList)
        {
            if (slot.IsEmpty()) // 빈 슬롯 찾기
            {
                slot.SetItem(newItem); // 아이템 추가
                RefreshAllSlots();
                return;
            }
        }
    }

    public void EquipItem(Item newItem)
    {
        equippedItem = newItem; // 새로운 아이템 장착
        RefreshAllSlots(); // UI 갱신
    }

    public Item GetEquippedItem()
    {
        return equippedItem;
    }

    public void RefreshAllSlots()
    {
        foreach (var slot in slotList)
        {
            slot.RefreshUI(); // 모든 슬롯 UI 업데이트
        }
    }
}
