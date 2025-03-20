using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI criticalText;
    [SerializeField] private Button exit;

    private void Start()
    {
        exit.onClick.AddListener(() => UIManager.Instance.ToggleStatusUI());
    }

    public void UpdateUI(Character player)
    {
        attackText.text = player.Attack.ToString();
        defenseText.text = player.Defense.ToString();
        healthText.text = player.Health.ToString();
        criticalText.text = player.Critical.ToString();
    }
}
