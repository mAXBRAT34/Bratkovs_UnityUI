using UnityEngine;
using TMPro;
using System;

public class CharacterInfo : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField ageInput;
    public TMP_Text infoText;
    public GameObject inputPanel;

    public void ShowCharacterInfo()
    {
        string name = nameInput.text;
        string ageText = ageInput.text;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(ageText))
        {
            Debug.Log("Aizpildiet visus laukus!");
            return;
        }
        if (int.TryParse(ageText, out int birthYear))
        {
            if (birthYear < 1900 || birthYear > 2025)
            {
                Debug.Log("Nepareizs dzimšanas gads! Ievadiet gadu no 1900 lidz 2025");
                return;
            }
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;
            infoText.text = $"Lego {name} — {age} gadi!";

            if (inputPanel != null)
            {
                inputPanel.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Ievadiet pareizu gadu!");
        }
    }
}
