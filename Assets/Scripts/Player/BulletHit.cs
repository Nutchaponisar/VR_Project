using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHP hp = collision.transform.GetComponent<EnemyHP>();
            hp.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

}
