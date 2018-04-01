using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    //Intent: When the Start Button is pressed, Start the Game
    public void LoadLevel(string name)
    {
        Debug.Log("Level Load Requested: " + name);
        Application.LoadLevel(name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game Button Pressed");
    }
}
