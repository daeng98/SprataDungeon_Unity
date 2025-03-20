using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;  // 아이템 이미지
    [SerializeField] private GameObject equippedMark;

    private Item itemData; // 해당 슬롯의 아이템 정보
    private UIInventory inventory;

    public void SetInventory(UIInventory inven)
    {
        inventory = inven;
    }

    // 아이템 설정
    public void SetItem(Item newItem)
    {
        itemData = newItem;
        itemIcon.sprite = newItem.icon;

        RefreshUI();
    }

    // UI 업데이트
    public void RefreshUI()
    {
        if (itemData != null)
        {
            itemIcon.sprite = itemData.icon;
            itemIcon.enabled = true;  // 데이터가 있을 때만 아이콘 활성화
        }
        else
        {
            itemIcon.enabled = false; // 데이터가 없으면 아이콘 숨김
        }
    }

    // 슬롯 클릭 시 장착/해제 기능 추가
    public void OnSlotClick()
    {
        if (inventory != null && itemData != null)
        {
            inventory.EquipItem(itemData); // 인벤토리에서 장착 처리
        }
    }

    public bool IsEmpty()
    {
        return itemData == null; // 아이템이 없으면 빈 슬롯
    }
}
