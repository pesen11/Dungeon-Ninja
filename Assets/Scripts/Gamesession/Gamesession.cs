using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamesession : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] int score = 0;
    [SerializeField] Text totalCoinsText;
   
     int totalcoins=0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        
        
    }

    public void addToScore(int pointsToAdd)
    {
        score =score + pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void countCoins()
    {
        totalcoins++;
        totalCoinsText.text = totalcoins.ToString();
    }
    
    

    
}


