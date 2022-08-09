using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boundry : MonoBehaviour
{
    public ParticleSystem explosion; 
    public AudioClip crash;
    private AudioSource playerAudio;
    public AudioClip alarm;
    public float radius = 300;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public TextMeshProUGUI boundryLeft;
    public float radiusB = 230;
    public float rangeLeft;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > radiusB || transform.position.x < -radiusB || transform.position.y > radiusB || transform.position.y < -radiusB || transform.position.z > radiusB || transform.position.z < -radiusB)
        {
            boundryLeft.gameObject.SetActive(true);
            playerAudio.PlayOneShot(alarm);
            StartCoroutine(destroyplay());
        }
        else
        { boundryLeft.gameObject.SetActive(false);  }    
           

        if (transform.position.x > radius || transform.position.x < -radius || transform.position.y > radius || transform.position.y < -radius || transform.position.z > radius || transform.position.z < -radius)
        {
           
            playerAudio.PlayOneShot(crash);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }

       

        }
    private IEnumerator destroyplay()
    {
        yield return new WaitForSeconds(1);
        playerAudio.PlayOneShot(alarm);
    }

}
