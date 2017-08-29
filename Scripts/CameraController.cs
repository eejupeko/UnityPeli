using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private float offsetX;
    private float offsetY;


    // Use this for initialization
    void Start () {
        offsetX = transform.position.x - player.transform.position.x;
        offsetY = transform.position.y - player.transform.position.y;

    }
	
	// Update is called once per frame
	void LateUpdate () {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        transform.position = new Vector3(x, y + offsetY, transform.position.z);
    }
}
