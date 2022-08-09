using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject[] CirclePrefabs;
    private float rangeX = 200.0f;
    private float rangeY = 200.0f;
    
   
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomCircle();
        
    }

    // Update is called once per frameg
    void Update()
    {
        
    }
    public void SpawnRandomCircle()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY) , Random.Range(-rangeX, rangeX));
        int i = Random.Range(0, CirclePrefabs.Length);
        Instantiate(CirclePrefabs[i], spawnPos, transform.rotation);
    }
}
