using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] float healthPoint = 10f;
    private float maxHealthPoint;
    private float timeForRegen = 5f;
    private float currenttimeForRegen;
    [SerializeField] private Score score;

    [SerializeField] private HPbar hPbar;

    private bool hit = true;


    private void Start()
    {
        maxHealthPoint = healthPoint;
        currenttimeForRegen = timeForRegen;
    }
    private void Update()
    {
        hPbar.updateHealthBar(maxHealthPoint, healthPoint);
        if (healthPoint < maxHealthPoint)
        {
            currenttimeForRegen -= Time.deltaTime;
            if (currenttimeForRegen <= 0 && healthPoint < maxHealthPoint)
            {
                healthPoint += Time.deltaTime * 2;
            }
        }
        else if (healthPoint >= maxHealthPoint)
        {
            currenttimeForRegen = timeForRegen;
            healthPoint = maxHealthPoint;
        }
    }
    public void TakeDamage(float damage)
    {
        if (hit)
        {
            StartCoroutine(HitBoxOff());
            {
                healthPoint -= damage;
                currenttimeForRegen = timeForRegen;
            }
        }
        if (healthPoint <= 0)
        {
            score.ShowScore();
        }
    }
    IEnumerator HitBoxOff()
    {
        hit = false;
        yield return new WaitForSeconds(0.5f);
        hit = true;
    }
}
