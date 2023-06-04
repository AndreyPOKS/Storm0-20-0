using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("1lvl");// в кавычках название сцены на которую осуществляется переход
    }
    
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
