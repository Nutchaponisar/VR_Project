using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;

    SpawnSystem spawn;

    public Transform head;
    public float distance;
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject scoreCanvas;

    private GameObject[] enemies;
    private GameObject[] EnemyBullet;

    void Awake()
    {
        instance = this;
    }
    public void AddScore(int getScore)
    {
        score += getScore;
    }
    public void Update()
    {
        EnemyBullet = GameObject.FindGameObjectsWithTag("EnemyBullet");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        scoreCanvas.transform.LookAt(new Vector3(head.position.x, scoreCanvas.transform.position.y, head.position.z));
        scoreCanvas.transform.forward *= -1;
    }

    public void ShowScore()
    {
        DestroyAllEnemy();
        scoreText.text = $"Score Point \n= {score}";
        scoreCanvas.SetActive(true);
        scoreCanvas.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * distance;
        Time.timeScale = 0;
    }

    void DestroyAllEnemy()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);
        }

        for (int i = 0; i < EnemyBullet.Length; i++)
        {
            Destroy(EnemyBullet[i].gameObject);
        }


    }
}
