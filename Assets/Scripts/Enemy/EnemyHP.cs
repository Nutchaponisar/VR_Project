using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [Header("Effect")]
    [SerializeField] ParticleSystem deathEffect;
    [SerializeField] Transform deathEffectPosition;

    [SerializeField] float healthPoint = 2f;
    [SerializeField] float enemyDamage = 1f;
    [SerializeField] int addScore = 1;


    public void TakeDamage(float damage)
    {
        healthPoint -= damage;

        if (healthPoint <= 0)
        {
            Instantiate(deathEffect, deathEffectPosition.position, Quaternion.identity);
            Destroy(this.gameObject);
            Score.instance.AddScore(addScore);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHP hp = collision.transform.GetComponent<PlayerHP>();
            hp.TakeDamage(enemyDamage);
        }
    }
}
