using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour {

    public LevelCreator levelCreator;

	void Awake () {
        levelCreator.GetComponent<LevelCreator>();
        levelCreator.CreateMap();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
