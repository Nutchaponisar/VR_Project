using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] public float weaponDamage;

    [Header("[For Range]")]
    [SerializeField] private int gunMaxBullet;
    private int bulletRemain;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float fireSpeed = 20;
    private float gunReloadRemaining;
    private float gunTimeReload = 3f;
    [SerializeField] ParticleSystem gunEffect;
    [SerializeField] Transform gunEffectPosition;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI bulletText;


    [Header("[For Melee]")]
    [SerializeField]private GameObject effect;
    /* [Header("Floor Check")]
     [SerializeField] private Transform checkFloor;
     [SerializeField] private float floorRadius;
     [SerializeField] LayerMask floorMask;
     [SerializeField] private bool isFloor;*/

    [Header("Sound")]
    public AudioClip clip;
    private AudioSource source;



    public enum WeaponType { Melee, Range }
    public WeaponType weaponType;
    private int hitpoint;

    //[SerializeField] private GameObject hightlight;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        XRGrabInteractable grabable = GetComponent<XRGrabInteractable>();
        grabable.activated.AddListener(FireBullet);
        bulletRemain = gunMaxBullet;
        gunReloadRemaining = gunTimeReload;
    }
    private void Update()
    {
        /*if (isFloor == true)
        {
            hightlight.SetActive(true);
        }
        else
        {
            hightlight.SetActive(false);
        }

        isFloor = Physics.CheckSphere(checkFloor.position, floorRadius, (int)floorMask);*/

        if (bulletRemain <= 0)
        {
            bulletText.text = "Reloading..";
            gunReloadRemaining -= Time.deltaTime;
        }
        else if (bulletRemain > 0)
        {
            bulletText.text = $"{bulletRemain}";
        }



        if(gunReloadRemaining <= 0)
        {
            bulletRemain = gunMaxBullet;
            gunReloadRemaining = gunTimeReload;
        }
    }

    /*private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHP hp = collision.transform.GetComponent<EnemyHP>();
            hp.TakeDamage(weaponDamage);
        }
    }*/
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyHP hp = other.transform.GetComponent<EnemyHP>();
            hp.TakeDamage(weaponDamage);
        }
    }*/
    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Enemy")
       {
            EnemyHP hp = collision.transform.GetComponent<EnemyHP>();
            hp.TakeDamage(weaponDamage);
       }
    }
    /*private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHP hp = collision.transform.GetComponent<EnemyHP>();
            hp.TakeDamage(weaponDamage);
        }
    }*/
    public void FireBullet(ActivateEventArgs arg)
    {
        switch (weaponType)
        {
            case WeaponType.Melee:
                effect.SetActive(!effect.activeInHierarchy);
                if(effect.activeInHierarchy == true)
                {
                    source.PlayOneShot(clip);
                }
               
                break;
            case WeaponType.Range:
                if(bulletRemain > 0)
                {
                    Instantiate(gunEffect, gunEffectPosition.position, Quaternion.identity);
                    GameObject spawnedBullet = Instantiate(bullet);
                    spawnedBullet.AddComponent<BulletHit>().damage = weaponDamage;
                    spawnedBullet.transform.position = bulletSpawnPoint.position;
                    spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * fireSpeed;
                    bulletRemain -= 1;
                    source.PlayOneShot(clip);
                    Destroy(spawnedBullet, 3);
                }
                else
                {

                }
                break;
        }  
    }
}
