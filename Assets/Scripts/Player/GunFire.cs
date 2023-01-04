using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class GunFire : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float fireSpeed = 20;

    [Header("Sound")]
    public AudioClip clip;
    private AudioSource source;

    private void Start()
    {
        XRGrabInteractable grabable = GetComponent<XRGrabInteractable>();
        grabable.activated.AddListener(FireBullet);
        source = GetComponent<AudioSource>();
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = bulletSpawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * fireSpeed;
        source.PlayOneShot(clip);
    }
}
