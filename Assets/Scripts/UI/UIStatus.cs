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
        attackText.text = $"<size=30>Attack</size>\n<size=50>{player.Attack}</size>";
        defenseText.text = $"<size=30>Defense</size>\n<size=50>{player.Defense}</size>";
        healthText.text = $"<size=30>Health</size>\n<size=50>{player.Health}</size>";
        criticalText.text = $"<size=30>Critical</size>\n<size=50>{player.Critical}</size>";
    }
}
