using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;  // 아이템 이미지
    [SerializeField] private Button itemButton;
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
        Debug.Log($"SetItem 실행");
        itemData = newItem;

        if (itemIcon != null)
        {
            itemIcon.sprite = newItem.icon; // 아이콘 연결
            itemIcon.enabled = true; // 아이콘 활성화
            Debug.Log($"{newItem.name} 아이콘 적용 완료"); // 로그 추가
        }
        else
        {
            Debug.LogWarning("아이콘이 연결되지 않음!"); // 아이콘이 없을 경우 경고 로그
        }

        if (itemButton != null)
        {
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(OnSlotClick); // 버튼 클릭 이벤트 추가
            Debug.Log($"{newItem.name} 버튼 클릭 이벤트 등록 완료"); // 로그 추가
        }
        else
        {
            Debug.LogWarning("버튼이 연결되지 않음!"); // 버튼이 없을 경우 경고 로그
        }

        RefreshUI();
    }

    // UI 업데이트
    public void RefreshUI()
    {
        if (itemData != null)
        {
            itemIcon.sprite = itemData.icon;
            itemIcon.enabled = true;  // 데이터가 있을 때만 아이콘 활성화
            equippedMark.SetActive(inventory.GetEquippedItem(itemData.itemType) == itemData);
        }
        else
        {
            itemIcon.enabled = false; // 데이터가 없으면 아이콘 숨김
            equippedMark.SetActive(false);
        }
    }

    // 슬롯 클릭 시 장착/해제 기능 추가
    public void OnSlotClick()
    {
        Item equippedItem = inventory.GetEquippedItem(itemData.itemType);

        if (equippedItem == itemData)
        {
            inventory.UnequipItem(itemData); // 해제
        }
        else
        {
            inventory.EquipItem(itemData); // 장착
        }

        RefreshUI(); // 슬롯 UI 갱신
    }

    public bool IsEmpty()
    {
        return itemData == null; // 아이템이 없으면 빈 슬롯
    }
}
