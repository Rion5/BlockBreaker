using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private static MusicPlayer instance = null;
    private void Awake()
    {
        print("MusicPlayer: Awake()");
        if (instance != null)
        {
            Destroy(gameObject);
            print("Duplicate Music Player Destroyed");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        print("MusicPlayer: Start()");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
