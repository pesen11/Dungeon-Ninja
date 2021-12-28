using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public static DoorScript instance;
    Animator anim;
    BoxCollider2D boxcollider;

    public int coinCount;

    [SerializeField] float portalDelay = 0.5f;
    [SerializeField] float levelLoadDelay = 2f;




    private void Awake()
    {
        MakeInstance();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void DecrementCoins()
    {
        coinCount--;
        if (coinCount == 0)
        {
            StartCoroutine(OpenDoor());
        }
    }


    IEnumerator OpenDoor()
    {
        anim.Play("doorAnim");
        yield return new WaitForSeconds(.7f);
        boxcollider.isTrigger = true;
    }

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
