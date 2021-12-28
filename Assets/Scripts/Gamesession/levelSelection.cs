using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelection : MonoBehaviour
{
    // [SerializeField]  bool unlocked;//by default is false





    public void pressSelection(string levelName)//press the button to go to the level
    {

        SceneManager.LoadScene(levelName);

    }

}
