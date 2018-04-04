using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        ///Set Paddle to follow the Mouse X Position
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);  
        float mouseXPosInBlocks = (Input.mousePosition.x / Screen.width * 16);  //game screen is 16 world units
        paddlePos.x = Mathf.Clamp(mouseXPosInBlocks,0.0f, 15f);                 //Mathf.Clamp Restricts the Paddle within the game screen 
        this.transform.position = paddlePos;
    }
}
