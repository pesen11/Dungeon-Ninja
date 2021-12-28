using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public void startFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        panel.GetComponent<Animator>().SetTrigger("popup");
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
