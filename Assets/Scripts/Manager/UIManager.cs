using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private UIMainMenu mainMenu;
    [SerializeField] private UIStatus status;
    [SerializeField] public UIInventory inven;
    [SerializeField] private GameObject buttons;

    private bool isStatusOpen = false;
    private bool isInventoryOpen = false;

    public void UpdateAllUI(Character player)
    {
        mainMenu.UpdateUI(player);
        status.UpdateUI(player);
    }

    public void ToggleStatusUI()
    {
        isStatusOpen = !isStatusOpen;
        status.gameObject.SetActive(isStatusOpen);
        inven.gameObject.SetActive(false);
        isInventoryOpen = false;
        buttons.SetActive(!isStatusOpen);
    }

    public void ToggleInventoryUI()
    {
        isInventoryOpen = !isInventoryOpen;
        inven.gameObject.SetActive(isInventoryOpen);
        status.gameObject.SetActive(false);
        isStatusOpen = false;
        buttons.SetActive(!isInventoryOpen);
    }
}
