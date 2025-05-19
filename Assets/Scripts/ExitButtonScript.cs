using UnityEngine;
using UnityEngine.UI;

public class ExitButtonScript : MonoBehaviour
{
    public Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        Debug.Log("Iziet...");
        Application.Quit();
    }
}
