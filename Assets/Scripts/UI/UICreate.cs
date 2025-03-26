using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class UICreate : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private Button createButton;
    [SerializeField] private TextMeshProUGUI message;

    private void Start()
    {
        createButton.onClick.AddListener(CreateCharacter);
    }

    void CreateCharacter()
    {
        string playerName = nameInput.text;

        if (string.IsNullOrEmpty(playerName))
        {
            message.text = "�̸��� �Է��ϼ���!";
            return;
        }

        Character playerCharacter = new Character(playerName, 0, 0, 10, 10, 100, 5);
        
        GameManager.Instance.SetData(playerCharacter);
        GameManager.Instance.isCreate = true;

        message.text = $"{playerName} ĳ���� ���� �Ϸ�!";

        UIManager.Instance.ShowMainUI();
        UIManager.Instance.UpdateAllUI(playerCharacter);
    }
}
