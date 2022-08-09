using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Destroy : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public Scores scores;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per framess
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            scores.AddPoints(10);
            Instantiate(explosionParticle, other.transform.position, explosionParticle.transform.rotation);
        }
    }


}
