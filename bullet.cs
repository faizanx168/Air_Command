using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed = 10000;
    public GameObject bullets;
    public Transform SpawnPoint;
    public float lifeTime = 3;
    public AudioSource playerAudio;
    public AudioClip gunSound;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
            playerAudio.PlayOneShot(gunSound, 1.0f);
        }
    }
    private IEnumerator destroyBullets(GameObject bullets, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullets);
    }
    void Fire()
    {
        GameObject bullet = Instantiate(bullets);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
        SpawnPoint.parent.GetComponent<Collider>());
        bullet.transform.position = SpawnPoint.position;
        Vector3 rotation = bullet.transform.rotation.eulerAngles;
        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        bullet.GetComponent<Rigidbody>().AddForce(SpawnPoint.forward * bulletSpeed, ForceMode.Impulse);
        StartCoroutine(destroyBullets(bullet, lifeTime));
    }
}

