using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    public void NewScene(string _NextScene)
    {
        SceneManager.LoadScene(_NextScene); 
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
