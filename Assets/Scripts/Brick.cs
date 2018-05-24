using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private LevelManager levelManager;
    private int timesHit;
    private bool isBreakable;

    public Sprite[] hitSprites;
    public static int breakableCount = 0;

    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        //Keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount = breakableCount++;
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        //Increment the hit counter. If the counter is > it's maxHits (or its hp), then destroy the gameObject
        //Otherwise load the damaged sprite
        timesHit++;
        int maxHits = hitSprites.Length + 1; //How many times the brick can be hit (I.E its health)
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    //TODO Remove this method once we can actually win!
    void SimulateWin()
    {
        levelManager.LoadNextLevel();   
    }
}
