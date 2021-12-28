using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] int spawnValuesx;
    [SerializeField] int negSpawnvaluesx;
    [SerializeField] int spawnValuesy;
     float spawnWait;
    [SerializeField] float spawnMostWait;
    [SerializeField] float spawnLeastWait;
    [SerializeField] int StartWait;
    [SerializeField] bool stop;

    int randEnemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }


    IEnumerator spawner()
    {
        yield return new WaitForSeconds(StartWait);
        while(!stop)
        {
            randEnemy = Random.Range(0, 2);
            Vector2 spawnPosition = new Vector2(Random.Range(negSpawnvaluesx, spawnValuesx), spawnValuesy);
            Instantiate(enemies[randEnemy], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);
        }

    }
}
