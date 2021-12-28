using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] obstacles;
    [SerializeField] Transform[] spawnPositions;

    float spawnWait;
    [SerializeField] float spawnMostWait;
    [SerializeField] float spawnLeastWait;

    [SerializeField] float startWait;

    int randEnemy;
    //int randPos;
    //int obstacleSpawned;
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

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            
            randEnemy = Random.Range(0, 2);
            Instantiate(obstacles[randEnemy], spawnPositions[i].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);

        }
    


    }
}
