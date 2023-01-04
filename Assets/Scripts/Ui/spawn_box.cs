using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_box : MonoBehaviour
{
    public GameObject box;
    public Transform SpawnPoint;
    public float spawnTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime)
        {
            spawnTime += 5;
            spawnBox();
        }
    }

    public void spawnBox()
    {
       
        GameObject spawnedBullet = Instantiate(box);
        spawnedBullet.transform.position = SpawnPoint.position;
    }
}
