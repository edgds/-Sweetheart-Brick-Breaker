using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public GameManager gm;
    public AudioClip _life;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        //get negaive number if left, positive number if right:
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed); //Vector2.right= Vector2(1, 0)

        //prevent paddle going beyond borders:
        if (transform.position.x <  leftScreenEdge)
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }

        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }
    }
    void OnTriggerEnter2D(Collider2D other) //if the paddle hits the extra life
    {
        AudioSource.PlayClipAtPoint(_life, transform.position, 0.3f);
        gm.UpdateLives(1);
        Destroy(other.gameObject);
    }
}
