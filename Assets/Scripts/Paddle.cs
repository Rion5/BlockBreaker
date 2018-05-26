using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = true;

    private Ball ball;
    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }


    // Update is called once per frame
    void Update () {
        if (!autoPlay)
        {
            MouseWithMouse();
        }
        else
        {
            AutoPlay();
        }
        
    }

    void MouseWithMouse()
    {
        ///Set Paddle to follow the Mouse X Position
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mouseXPosInBlocks = (Input.mousePosition.x / Screen.width * 16);  //game screen is 16 world units
        paddlePos.x = Mathf.Clamp(mouseXPosInBlocks, 0.0f, 15f);                 //Mathf.Clamp Restricts the Paddle within the game screen 
        this.transform.position = paddlePos;
    }

    /// <summary>
    /// Moves Paddle Position Underneath Ball
    /// </summary>
    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x-1, 0.0f, 15f);                 //Mathf.Clamp Restricts the Paddle within the game screen 
        this.transform.position = paddlePos;
    }
}
