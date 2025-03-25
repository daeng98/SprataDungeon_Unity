using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Slider expSlider;

    private void Start()
    {
        statusButton.onClick.AddListener(() => UIManager.Instance.ToggleStatusUI());
        inventoryButton.onClick.AddListener(() => UIManager.Instance.ToggleInventoryUI());
    }

    public void UpdateUI(Character character)
    {
        titleText.text = character.Title;
        infoText.text = character.Info;
        playerNameText.text = character.Name;
        levelText.text = $"<size=30>LV</size> <size=50>{character.Level}</size>";
        goldText.text = character.Gold.ToString();
        expSlider.maxValue = character.ExpToNextLevel;

        StopAllCoroutines();
        StartCoroutine(SmoothExpBar(character.Experience));
    }

    private IEnumerator SmoothExpBar(float targetExp)
    {
        float duration = 0.3f;
        float startExp = expSlider.value;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            expSlider.value = Mathf.Lerp(startExp, targetExp, time / duration);
            yield return null;
        }

        expSlider.value = targetExp;
    }
}
