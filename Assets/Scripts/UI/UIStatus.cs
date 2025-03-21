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

    private Character character;

    private void Start()
    {
        character = GameManager.Instance.character;
        character.OnStatsChanged += () => UpdateUI(character);
        UpdateUI(character);

        exit.onClick.AddListener(() => UIManager.Instance.ToggleStatusUI());
    }

    public void UpdateUI(Character player)
    {
        attackText.text = $"<size=30>���ݷ�</size>\n<size=50>{player.Attack}</size>";
        defenseText.text = $"<size=30>����</size>\n<size=50>{player.Defense}</size>";
        healthText.text = $"<size=30>ü��</size>\n<size=50>{player.Health}</size>";
        criticalText.text = $"<size=30>ũ��Ƽ��</size>\n<size=50>{player.Critical}</size>";
    }
}
