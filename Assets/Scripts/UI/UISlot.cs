using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static Item;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;  // ������ �̹���
    [SerializeField] private Button itemButton;
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

        if (itemIcon != null)
        {
            itemIcon.sprite = newItem.icon; // ������ ����
            itemIcon.enabled = true; // ������ Ȱ��ȭ
        }
        else
        {
            Debug.LogWarning("�������� ������� ����"); // �������� ���� ��� ��� �α�
        }

        if (itemButton != null)
        {
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(OnSlotClick); // ��ư Ŭ�� �̺�Ʈ �߰�
        }
        else
        {
            Debug.LogWarning("��ư�� ������� ����");
        }

        RefreshUI();
    }

    // UI ������Ʈ
    public void RefreshUI()
    {
        if (itemData != null)
        {
            itemIcon.sprite = itemData.icon;
            itemIcon.enabled = true;  // �����Ͱ� ���� ���� ������ Ȱ��ȭ
            equippedMark.SetActive(inventory.GetEquippedItem(itemData.itemType) == itemData);
        }
        else
        {
            itemIcon.enabled = false; // �����Ͱ� ������ ������ ����
            equippedMark.SetActive(false);
        }
    }

    // ���� Ŭ�� �� ����/���� ��� �߰�
    public void OnSlotClick()
    {
        Item equippedItem = inventory.GetEquippedItem(itemData.itemType);

        if (equippedItem == itemData)
        {
            inventory.UnequipItem(itemData); // ����
        }
        else
        {
            inventory.EquipItem(itemData); // ����
        }

        RefreshUI(); // ���� UI ����
    }

    public bool IsEmpty()
    {
        return itemData == null; // �������� ������ �� ����
    }
}
