using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float groundWidht;
    float obstacleWidth;
    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWidht = box.size.x - 3.2f;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
    }
    void Update()
    {
        if (GameManager.gameOver == false && GameManager.gameStarted == true)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        if (transform.position.x <= -groundWidht)
        {
            transform.position = new Vector2(transform.position.x + 2 * groundWidht, transform.position.y);
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x < GameManager.bottomLeft.x - obstacleWidth)
            {
                Destroy(gameObject);
            }
        }
    }
}

