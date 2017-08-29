using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float speed;

	// Use this for initialization
	void Start () {
        speed = -2f;
	}

    private void Move()
    {
        transform.Translate(new Vector3(speed*Time.deltaTime, 0f, 0f));
    }

    // Update is called once per frame
    void Update () {
        Move();
	}
}
