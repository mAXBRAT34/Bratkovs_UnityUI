using UnityEngine;
using TMPro;
using System;

public class CharacterInfo : MonoBehaviour
{
    public TMP_InputField nameInput; 
    public TMP_InputField birthYearInput; 
    public TMP_Text infoText; 

    public void ShowCharacterInfo()
    {
        string name = nameInput.text;
        string birthYearText = birthYearInput.text;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(birthYearText))
        {
            Debug.Log("Aizpildiet visus laukus!");
            return;
        }

        if (int.TryParse(birthYearText, out int birthYear))
        {
            int currentYear = DateTime.Now.Year;

            if (birthYear < 1900 || birthYear > currentYear)
            {
                Debug.Log($"Nepareizs gads! Ievadiet gadu no 1900 līdz {currentYear}");
                return;
            }

            int age = currentYear - birthYear;
            infoText.text = $"Sveiki! Mani sauc {name}, un man ir {age} gadi!";
        }
        else
        {
            Debug.Log("Ievadiet pareizu gadu!");
        }
    }
}
