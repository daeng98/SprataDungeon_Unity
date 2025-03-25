using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public UIInventory uiInventory;
    [SerializeField] public List<Item> allItems;

    public Character character { get; set; }

    public float addTime = 5f;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        SetData();
        StartCoroutine(AddExp());
        uiInventory.InitInventoryUI();
        uiInventory.SetInventoryItems(allItems);
    }

    private void SetData()
    {
        character = new Character("ΩΩ∂Û¿”", 0, 1000, 10, 10, 100, 5);
        UIManager.Instance.UpdateAllUI(character);
    }

    private IEnumerator AddExp()
    {
        while (true)
        {
            yield return new WaitForSeconds(addTime);
            character.AddExperience(2);
            UIManager.Instance.mainMenu.UpdateUI(character);
        }
    }
}
