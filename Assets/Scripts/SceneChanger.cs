using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Dropdown characterDropdown;

    void Start()
    {
        if (characterDropdown == null)
        {

            return;
        }

        characterDropdown.onValueChanged.AddListener(ChangeScene);
    }

    public void ChangeScene(int index)
    {
        if (index == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (index == 1)
        {
            SceneManager.LoadScene("SampleScene 1");
        }
        else
        {
            Debug.LogWarning("Nezinams!");
        }
    }
}
