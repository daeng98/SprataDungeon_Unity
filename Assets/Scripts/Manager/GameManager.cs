using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public UIInventory uiInventory;
    [SerializeField] public List<Item> allItems;

    public Character character { get; set; }

    public float addTime = 5f;
    public bool isCreate = false;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        uiInventory.InitInventoryUI();
        uiInventory.SetInventoryItems(allItems);
    }

    public void SetData(Character createCharcter)
    {
        character = createCharcter;

        StopAllCoroutines();
        StartCoroutine(AddExp());
    }

    private IEnumerator AddExp()
    {
        while (character != null)
        {
            yield return new WaitForSeconds(addTime);
            character.AddExperience(2);
            character.plusGold(100);
            UIManager.Instance.mainMenu.UpdateUI(character);
        }
    }
}
