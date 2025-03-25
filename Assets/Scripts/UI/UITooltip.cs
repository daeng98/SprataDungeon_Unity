using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UITooltip : MonoBehaviour
{
    public TextMeshProUGUI tooltipText; // ÅøÆÁ ÅØ½ºÆ®

    public void ShowTooltip(Item item)
    {
        string colorCode = GetStatColorHex(item.itemType);

        tooltipText.text = 
            $"<size=40><color=#{colorCode}>{item.itemName}</color></size>\n" +
            $"<size=30>{item.description}</size>\n" +
            $"<size=30><color=#{colorCode}>{item.itemType} +{item.statValue}</color></size>";
        tooltipText.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltipText.gameObject.SetActive(false);
    }

    private string GetStatColorHex(Item.ItemType type)
    {
        switch (type)
        {
            case Item.ItemType.Attack: return "FF4D4D";   // »¡°­
            case Item.ItemType.Defense: return "4D4DFF";  // ÆÄ¶û
            case Item.ItemType.Health: return "33CC33";  // ÃÊ·Ï
            case Item.ItemType.Critical: return "FF9933"; // ÁÖÈ²
            default: return "FFFFFF";                     // ±âº» Èò»ö
        }
    }
}