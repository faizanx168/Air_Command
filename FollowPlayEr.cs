using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayEr : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemySpeed();
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }
    private IEnumerator enemySpeed()
    {
        yield return new WaitForSeconds(20);
        speed++;
    }
}
