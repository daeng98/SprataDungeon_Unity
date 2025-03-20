using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button exit;

    private void Start()
    {
        exit.onClick.AddListener(() => UIManager.Instance.ToggleInventoryUI());
    }
}
