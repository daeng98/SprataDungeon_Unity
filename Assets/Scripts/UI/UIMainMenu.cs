using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    private void Start()
    {
        statusButton.onClick.AddListener(() => UIManager.Instance.ToggleStatusUI());
        inventoryButton.onClick.AddListener(() => UIManager.Instance.ToggleInventoryUI());
    }

    public void UpdateUI(Character character)
    {
        playerNameText.text = character.Name;
        levelText.text = $"<size=30>LV</size> <size=50>{character.Level}</size>";
        goldText.text = character.Gold.ToString();
    }
}
