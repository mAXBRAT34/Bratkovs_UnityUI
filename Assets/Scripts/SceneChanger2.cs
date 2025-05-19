using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class SceneChanger2 : MonoBehaviour
{

    void Start()
    {

    }

    public void ChangeScene(int index)
    {
        if (index == 1)
        {
            SceneManager.LoadScene("SampleScene"); 
        }
        else if (index == 0)
        {
            SceneManager.LoadScene("SampleScene 1"); 
        }
        else
        {
            Debug.LogWarning("Выбран неизвестный персонаж!");
        }
    }
}
