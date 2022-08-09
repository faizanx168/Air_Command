using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    public GameObject child;
    private Vector3 offset;
    private Vector3 newtrans;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
        child = plane.transform.Find("playerfollow").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        follow();
        
    }
    private void follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(plane.gameObject.transform.position);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
