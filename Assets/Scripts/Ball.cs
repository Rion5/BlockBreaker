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
        //TODO: Test Gameplay and decide if I should use random range, or use the delta of the ball, from the middle of the paddle.
        Vector2 randomTweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted) { 
            if(collision.gameObject.name == "Paddle")
            {
                //Find the Delta
                //Ball's X position - (Paddle's X Pos + Paddle Width/2);
                var delta = this.transform.position - (paddle.transform.position + (paddle.transform.position / 2));
                rigidbody2D.velocity += (Vector2)delta;
                GetComponent<AudioSource>().Play();
            }
            else
            {
                rigidbody2D.velocity += randomTweak;
                print(randomTweak);
            }
        }
    }
}
