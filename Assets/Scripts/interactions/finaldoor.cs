using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finaldoor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(sendToNextLevel());
        }
    }

    IEnumerator sendToNextLevel()
    {

        yield return new WaitForSeconds(1f);

        loadNextScene();
    }
    private void loadNextScene()
    {

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}

