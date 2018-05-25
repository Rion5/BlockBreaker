using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private Rigidbody2D rigidbody2D;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();

        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Set Ball to rest above mouse
        if (!hasStarted)
        {
            //Lock the ball relative to the paddle.
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for mouse press to lauch the ball.
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse Clicked - Launch Ball");
                hasStarted = true;
                this.rigidbody2D.velocity = new Vector2(2f, 10f);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 randomTweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted) { 
            GetComponent<AudioSource>().Play();
            rigidbody2D.velocity += randomTweak;
            print(randomTweak);
        }
    }
}
