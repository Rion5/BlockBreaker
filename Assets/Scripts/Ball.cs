using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Paddle paddle;

    private Rigidbody2D rigidbody2D;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
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
}
