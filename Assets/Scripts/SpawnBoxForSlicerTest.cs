using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxForSlicerTest : MonoBehaviour
{
    public GameObject[] box;
    public Transform[] SpawnPoint;
    public GameObject[] enemies;
    public Transform[] enemieSpawnPoints;
    //public float spawnTime;
    void Start()
    {

    }

    public void OnclickSpawnEnemie()
    {
        GameObject spawnEnemie1 = Instantiate(enemies[0]);
        spawnEnemie1.transform.position = enemieSpawnPoints[0].position;
        GameObject spawnEnemie2 = Instantiate(enemies[1]);
        spawnEnemie2.transform.position = enemieSpawnPoints[1].position;
        GameObject spawnEnemie3 = Instantiate(enemies[2]);
        spawnEnemie3.transform.position = enemieSpawnPoints[2].position;
    }
    public void OnclickspawnBox()
    {

        GameObject spawnItem1= Instantiate(box[0]);
        spawnItem1.transform.position = SpawnPoint[0].position;
        GameObject spawnItem2 = Instantiate(box[1]);
        spawnItem2.transform.position = SpawnPoint[1].position;
    }
}
