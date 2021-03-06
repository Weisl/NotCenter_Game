﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

   
    public float defaultSpeed = 5f;
   // public float rotationSpeed = 5f;
    public float sideSpeed = 5f;
    public float slowingFactor = 1.001f;
    public float currentSpeed = 0f;
    public float boostFactor = 2f;
	public int maxCameraDst = 15;
	public int maxZDist = 10; 

	private Vector3 cameraPos;
	public int InitialPowerUps = 2;

	private int powerUps = 0;


	void Destroy (){
		
	}

	// Use this for initialization
	void Start () {
        currentSpeed = defaultSpeed;
	}
	
	// Update is called once per frame
	void Update () {

        //World Movement
        this.cameraPos = Camera.main.gameObject.transform.position;
        
		if (Time.timeSinceLevelLoad > 1) {
			// make object slower
//			this.currentSpeed = (this.currentSpeed / this.slowingFactor);
			currentSpeed -= currentSpeed>defaultSpeed? 0.015f : 0.0015f;// (this.slowingFactor);
		}            
		float cameraPosX = this.cameraPos.x;
		//float cameraPosZ = this.cameraPos.z;


		if (this.gameObject.transform.position.x > cameraPosX + this.maxCameraDst) {
			this.gameObject.transform.position = new Vector3 (cameraPosX + this.maxCameraDst,this.gameObject.transform.position.y , this.gameObject.transform.position.z );
		}

		// teleporter on border
		if (this.gameObject.transform.position.z > maxZDist || this.gameObject.transform.position.z < -maxZDist) {
			this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, -this.gameObject.transform.position.z);
		}

	
		if (currentSpeed > 0){
            //print("Speed " + currentSpeed);
            transform.Translate(this.currentSpeed * Time.deltaTime,0,0);
        }

        //float xPost = this.gameObject.position.x % 25;
        //this.gameObject.transform.position = new Vector3 (xPost, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        


        //Controls 
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


    public int getPowerUps()
    {
        return powerUps;
    }



	public void PowerPlus (){
		this.powerUps += 1;

	}
		
    public void Boost(){
		currentSpeed = Mathf.Min( 2*defaultSpeed,  currentSpeed + boostFactor);
    }
}

