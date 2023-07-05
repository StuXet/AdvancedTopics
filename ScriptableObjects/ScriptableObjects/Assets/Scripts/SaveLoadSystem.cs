using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveLoadSystem : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameManager gameManager;

    public void SaveSystem()
    {
        for (int i = 1; i <= gameManager.currentCards.Count; i++)
        {
            PlayerPrefs.SetString("Card" + i.ToString(), gameManager.currentCards[i - 1].card.ID);
        }
    }

    public void LoadSystem()
    {
        //inputField.text = PlayerPrefs.GetString("Name");
        List<string> idList = new List<string>();
        for (int i = 1; i <= gameManager.currentCards.Count; i++)
        {
            idList.Add(PlayerPrefs.GetString("Card" + i));
        }
        gameManager.LoadCards(idList);
    }
}
