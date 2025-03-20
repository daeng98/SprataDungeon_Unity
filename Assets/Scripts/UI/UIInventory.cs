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

            slot.SetInventory(this); // ���Կ� UIInventory ����

            slotList.Add(slot);
        }
    }

    public void SetInventoryItems(List<Item> inventoryItems)
    {
        RefreshAllSlots(); // ��� ���� �ʱ�ȭ

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i] != null) // ������ �����Ͱ� �����ϴ� ��츸 �߰�
            {
                slotList[i].SetItem(inventoryItems[i]);
            }
        }
    }

    public void AddItemToInventory(Item newItem)
    {
        foreach (var slot in slotList)
        {
            if (slot.IsEmpty()) // �� ���� ã��
            {
                slot.SetItem(newItem); // ������ �߰�
                RefreshAllSlots();
                return;
            }
        }
    }

    public void EquipItem(Item newItem)
    {
        equippedItem = newItem; // ���ο� ������ ����
        RefreshAllSlots(); // UI ����
    }

    public Item GetEquippedItem()
    {
        return equippedItem;
    }

    public void RefreshAllSlots()
    {
        foreach (var slot in slotList)
        {
            slot.RefreshUI(); // ��� ���� UI ������Ʈ
        }
    }
}
