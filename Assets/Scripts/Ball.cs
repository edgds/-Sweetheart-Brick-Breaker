using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioClip _audioClip;
    public AudioClip _audioClip2;
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;
    public Transform powerup;
    public AudioClip _SpawnSound;
   

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        if (inPlay == false)
        {
            transform.position = paddle.position; //ball follows paddle object (child object of paddle that hovers over paddle)
        }

        if (Input.GetButtonDown("Jump") && !inPlay) //release the ball if space bar is pressed
        {
            inPlay = true; 
            rb.AddForce(Vector2.up * speed); //send ball upwards
        }
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {   //if ball hits bottom wall tagged as "Bottom":
        if (other.CompareTag("Bottom"))
        {
            AudioSource.PlayClipAtPoint(_audioClip, transform.position);

            Debug.Log("Ball hit the bottom of the screen");
            rb.velocity = Vector2.zero; //Vector2(0,0)
            inPlay = false;

            gm.UpdateLives(-1); //lose a life
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Brick") || other.transform.CompareTag("BrickGold"))
        {
            //if its the gold brick, instantiatea extra life powerup:
            if (other.transform.CompareTag("BrickGold")) 
            {
                Instantiate(powerup, other.transform.position, other.transform.rotation); //spawn it at gold brick position
                AudioSource.PlayClipAtPoint(_SpawnSound, transform.position);
            }

            AudioSource.PlayClipAtPoint(_audioClip2, transform.position);
            //create an explosion (break effect) at brick position and rotation
            //(store in Transform variable to make less messy)
            Transform newExplosion= Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.0f);

            //add points when brick is destroyed:
            gm.UpdateScore(other.gameObject.GetComponent<BrickPoints>().points);
            gm.UpdateNumberofBricks();
            Destroy(other.gameObject);

            

        }
    }
        
}
