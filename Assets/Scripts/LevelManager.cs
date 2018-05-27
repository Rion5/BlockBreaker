using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Intent: When the Start Button is pressed, Start the Game
    public void LoadLevel(string name)
    {
        Debug.Log("Level Load Requested: " + name);
        Brick.breakableCount = 0;
        Application.LoadLevel(name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game Button Pressed");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
