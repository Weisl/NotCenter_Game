﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float defaultSpeed = 5f;
   // public float rotationSpeed = 5f;
    public float sideSpeed = 5f;
    public float slowingFactor = 1.001f;
    public float currentSpeed = 0f;
    public float boostFactor = 2f;

	private Vector3 cameraPos;
	public int InitialPowerUps = 2;

	private int powerUps = 0;

	// Use this for initialization
	void Start () {
        currentSpeed = defaultSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		this.cameraPos = Camera.main.gameObject.transform.position;

        this.currentSpeed = (this.currentSpeed / this.slowingFactor);
            
		//if ()

		if (currentSpeed > 0){
            print("Speed " + currentSpeed);
            transform.Translate(this.currentSpeed * Time.deltaTime,0,0);
        }

        //float xPost = this.gameObject.position.x % 25;
        //this.gameObject.transform.position = new Vector3 (xPost, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, (sideSpeed * Time.deltaTime));
        }
        
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, -((sideSpeed * Time.deltaTime)));
        }

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (powerUps >= 1) {
				Boost ();
			}
		} 
	}



	public void PowerPlus (){
		this.powerUps += 1;
	}
		
    public void Boost(){
        currentSpeed = currentSpeed + boostFactor;
    }
}

