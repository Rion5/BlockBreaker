using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private LevelManager levelManager;

    //How many times the brick can be hit (I.E its health)
    public int maxHits;

    private int timesHit;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
        }
        //SimulateWin(); For Testing Purposes. Hitting a Brick sends you to the next level
    }

    //TODO Remove this method once we can actually win!
    void SimulateWin()
    {
        levelManager.LoadNextLevel();   
    }
}
