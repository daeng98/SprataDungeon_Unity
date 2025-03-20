using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;  // ������ �̹���
    [SerializeField] private GameObject equippedMark;

    private Item itemData; // �ش� ������ ������ ����
    private UIInventory inventory;

    public void SetInventory(UIInventory inven)
    {
        inventory = inven;
    }

    // ������ ����
    public void SetItem(Item newItem)
    {
        itemData = newItem;
        itemIcon.sprite = newItem.icon;

        RefreshUI();
    }

    // UI ������Ʈ
    public void RefreshUI()
    {
        if (itemData != null)
        {
            itemIcon.sprite = itemData.icon;
            itemIcon.enabled = true;  // �����Ͱ� ���� ���� ������ Ȱ��ȭ
        }
        else
        {
            itemIcon.enabled = false; // �����Ͱ� ������ ������ ����
        }
    }

    // ���� Ŭ�� �� ����/���� ��� �߰�
    public void OnSlotClick()
    {
        if (inventory != null && itemData != null)
        {
            inventory.EquipItem(itemData); // �κ��丮���� ���� ó��
        }
    }

    public bool IsEmpty()
    {
        return itemData == null; // �������� ������ �� ����
    }
}
