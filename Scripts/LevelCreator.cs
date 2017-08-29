using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

    public GameObject block;

	// Use this for initialization
	void Start () {
		
	}

    private void CreateBlock(float x, float y)
    {
        GameObject toInstantiate = block;
        GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
    }

    public void CreateMap()
    {
        for (int x = 0; x < 20; x++)
        {
            CreateBlock(x, 0);
        }

        for (int y = 0; y > -20; y--)
        {
            CreateBlock(22, y);
        }

        for (int x = 22; x < 42; x++)
        {
            CreateBlock(x, 0);
        }
        CreateBlock(10, 1);
        CreateBlock(10, 2);
        CreateBlock(10, 3);
        CreateBlock(11, 2);
        CreateBlock(43, 0);
        CreateBlock(44, 0);
        CreateBlock(45, 0);
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
