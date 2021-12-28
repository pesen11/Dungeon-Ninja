using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lifeCounterScript : MonoBehaviour
{
    [SerializeField] int playerLives = 5;
    [SerializeField] Text livesText;
    [SerializeField] AudioClip apparentLosssfx;
    [SerializeField] AudioClip maninlosssfx;
    AudioSource myaudiosource;


    private void Awake()
    {
        int numberOfLifeCounters = FindObjectsOfType(GetType()).Length;
        if (numberOfLifeCounters > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = playerLives.ToString();
        myaudiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void processPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            StartCoroutine(ResetGameSession());

        }
    }

    private void TakeLife()
    {
        playerLives -= 1;
        StartCoroutine(reloadLevel());
        myaudiosource.PlayOneShot(apparentLosssfx);
        livesText.text = playerLives.ToString();
    }

    IEnumerator reloadLevel()
    {

        yield return new WaitForSeconds(2f);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    IEnumerator ResetGameSession()
    {
        myaudiosource.PlayOneShot(maninlosssfx);
        Destroy(gameObject,3f);
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("You_lose");


    }
}
