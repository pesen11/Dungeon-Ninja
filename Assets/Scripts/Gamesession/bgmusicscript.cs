using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bgmusicscript : MonoBehaviour
{

  

    private void Awake()
    {
        
        setUpMusicSingleton();
       
    }
   
    private void setUpMusicSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
       
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
