using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Item;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI criticalText;
    [SerializeField] private Button exit;

    private Character character;
    private UIInventory inventory;

    private void Start()
    {
        character = GameManager.Instance.character;
        inventory = GameManager.Instance.uiInventory;
        character.OnStatsChanged += () => UpdateUI(character, inventory);
        UpdateUI(character, inventory);

        exit.onClick.AddListener(() => UIManager.Instance.ToggleStatusUI());
    }

    public void UpdateUI(Character player, UIInventory inventory)
    {
        int bonusAttack = inventory.GetBonusStat(ItemType.Attack);
        int bonusDefense = inventory.GetBonusStat(ItemType.Defense);
        int bonusHealth = inventory.GetBonusStat(ItemType.Health);
        int bonusCritical = inventory.GetBonusStat(ItemType.Critical);

        attackText.text = $"<size=30>공격력</size>\n<size=50>{player.Attack}</size>" +
            (bonusAttack != 0 ? $" ({(bonusAttack > 0 ? "+" : "")}{bonusAttack})" : "");

        defenseText.text = $"<size=30>방어력</size>\n<size=50>{player.Defense}</size>" +
            (bonusDefense != 0 ? $" ({(bonusDefense > 0 ? "+" : "")}{bonusDefense})" : "");

        healthText.text = $"<size=30>체력</size>\n<size=50>{player.Health}</size>" +
            (bonusHealth != 0 ? $" ({(bonusHealth > 0 ? "+" : "")}{bonusHealth})" : "");

        criticalText.text = $"<size=30>크리티컬</size>\n<size=50>{player.Critical}</size>" +
            (bonusCritical != 0 ? $" ({(bonusCritical > 0 ? "+" : "")}{bonusCritical})" : "");
    }
}
