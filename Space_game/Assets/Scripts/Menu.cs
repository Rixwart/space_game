using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject asfaf;
    // Start is called before the first frame update
    public void ChangeSceen(string SceenName)
    {
        asfaf.SetActive(true);
        Invoke("NextLevel",2.0f);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
