using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winlosescript : MonoBehaviour
{
    public void loadlevel1()
    {
        SceneManager.LoadScene("lv1");
    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void loadlevelSelection()
    {
        SceneManager.LoadScene("Level_Selection");
    }
}
