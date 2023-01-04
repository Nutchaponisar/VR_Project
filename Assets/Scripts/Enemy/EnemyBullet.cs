using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage;
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(this.gameObject, 1);
        if (collision.gameObject.tag == "Player")
        {
            PlayerHP hp = collision.transform.GetComponent<PlayerHP>();
            hp.TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}
