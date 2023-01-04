using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private float spawnTime = 3f;
    public GameObject[] enemies;
    public Transform[] enemieSpawnPoints;

    private GameObject[] allMob;
    private int numberMob;

    private void Start()
    {
        StartCoroutine(spawn());
    }

    void Update()
    {
        allMob = GameObject.FindGameObjectsWithTag("Enemy");
        numberMob = allMob.Length;
    }

    public void SpawnMob()
    {
        GameObject spawnMob = Instantiate(enemies[Random.Range(0, enemies.Length)]);
        spawnMob.transform.position = enemieSpawnPoints[Random.Range(0, enemieSpawnPoints.Length)].position;
    }
    IEnumerator spawn()
    {
        SpawnMob();
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(spawn());
    }
}
