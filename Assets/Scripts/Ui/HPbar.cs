using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float speed = 2;
    private float target = 1;


    public void updateHealthBar(float maxHealth, float currentHealth)
    {
        target = currentHealth / maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, target, speed * Time.fixedDeltaTime);
    }
}
