using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitcher : MonoBehaviour
{
    public Dropdown characterDropdown;
    public Text descriptionText;
    public ScrollRect scrollView;

    private string[] descriptions = {
        "Varonis 1: Drosmīgs bruņinieks ar leģendāru zobenu.",
        "Varonis 2: Burvis, kas pārvalda stihiju spēku un burvestības."
    };

    void Start()
    {
        if (characterDropdown != null)
        {
            characterDropdown.onValueChanged.AddListener(UpdateDescription);
            UpdateDescription(characterDropdown.value);
        }
        else
        {
            Debug.LogError("Dropdown nav piesaistīts! Pārliecinies, ka tas ir pievienots `Inspector`.");
        }
    }

    void UpdateDescription(int index)
    {
        if (index < descriptions.Length)
        {
            descriptionText.text = descriptions[index];
            scrollView.normalizedPosition = new Vector2(0, 1);
        }
        else
        {
            Debug.LogWarning("Izvēlēts neesošs varonis!");
        }
    }
}
