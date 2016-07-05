﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public GameObject player;
    public float speed = 4;

    public Vector3 playerPos;

	// Use this for initialization
	void Start () {
	

            
	}
	
	// Update is called once per frame
	void Update () {

        playerPos = player.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
            
	}
}
