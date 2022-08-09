using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerControllerX : MonoBehaviour
{
    public float speed = 50.0f;
    public float rotationSpeed = 50.0f;
    public float zSpeed = 3.0f;
    private float verticalInput;
    private Manager script;
    private AudioSource playerAudio;
    public ParticleSystem explosion;
    public ParticleSystem dust;
    public AudioClip crash;
    public AudioClip jumpSound;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Scores score;

    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("Spawn").GetComponent<Manager>();
        playerAudio = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical inputs
        verticalInput = Input.GetAxis("Vertical");

     
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.right, Time.deltaTime * rotationSpeed * verticalInput);
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += new Vector3(0, 0, zSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += new Vector3(0, 0, -zSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("checkpoint"))
        {
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            script.SpawnRandomCircle();
            score.AddPoints(1);
           
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerAudio.PlayOneShot(crash);
            StartCoroutine(destroyplayer());
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }
       private IEnumerator destroyplayer()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    
}
