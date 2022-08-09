using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float range = 200;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandom", 2, 20);
        
    }
    public void SpawnRandom()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
        Instantiate(enemyPrefab, spawnPos, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
