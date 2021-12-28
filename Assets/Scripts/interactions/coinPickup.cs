using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickup : MonoBehaviour
{
    [SerializeField] int coinvalue = 1;
    [SerializeField] AudioClip coinSFX;

    private void Start()
    {
        if(DoorScript.instance != null)
        {
            DoorScript.instance.coinCount++;
        }
        countCoins();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<Gamesession>().addToScore(coinvalue);
            if (DoorScript.instance != null)
            {
                DoorScript.instance.DecrementCoins();
            }
            AudioSource.PlayClipAtPoint(coinSFX, transform.position);
            Destroy(gameObject);
        }
    }

    private void countCoins()
    {
        if(tag=="coin")
        {
            FindObjectOfType<Gamesession>().countCoins();
        }
    }
}
