using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public enum EnemyType { Melee, Range }
    public EnemyType enemyType;

    private GameObject player;
    [SerializeField] Transform target;
    [SerializeField] float EnemyRange = 20f;
    private float distanceBetweenTarget;
    private NavMeshAgent navMeshAgent;

    [SerializeField] private Transform[] bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;

    private float fireRateCount = 0f;
    [SerializeField] private float fireRate = 2f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        

        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        distanceBetweenTarget = Vector3.Distance(target.position, transform.position);

        switch (enemyType)
        {
            case EnemyType.Melee:
                navMeshAgent.SetDestination(target.position);
                break;
            case EnemyType.Range:
                if (distanceBetweenTarget < EnemyRange)
                {
                    navMeshAgent.SetDestination(target.position);
                }

                if (distanceBetweenTarget <= navMeshAgent.stoppingDistance)
                {
                    if (fireRateCount <= 0f)
                    {
                        Transform spawnPoint = bulletSpawnPoint[Random.Range(0, bulletSpawnPoint.Length)];
                        GameObject spawnedBullet = Instantiate(bulletPrefab);
                        spawnedBullet.transform.position = spawnPoint.position;
                        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
                        Destroy(spawnedBullet, 4);
                        
                        fireRateCount = 1f / fireRate;
                    }
                    fireRateCount -= Time.deltaTime;
                }
                break;
        }
    }
}
