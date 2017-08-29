using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour {

    public LevelCreator levelCreator;
    public GameObject player;

	void Awake () {
        levelCreator.GetComponent<LevelCreator>();
        levelCreator.CreateMap(player);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
