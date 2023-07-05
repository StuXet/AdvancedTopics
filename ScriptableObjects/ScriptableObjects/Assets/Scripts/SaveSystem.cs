using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSystem : MonoBehaviour
{
    public TMPro_InputField inputField;

    public void SaveSystem()
    {
        PlayerPrefs.SetString("Name", inputField.text);
    }

    public void LoadSystem()
    {
        inputField.text = PlayerPrefs.GetString("Name");
    }
}
