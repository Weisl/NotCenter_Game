using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
    public float cameraSpeed = 5f;
    public float velocityFactor = 1.1f;

	private float currentSpeed;
	private bool stopped;
    // Use this for initialization
    
	void Start () {
		this.currentSpeed = this.cameraSpeed;
    }


	// Update is called once per frame
	void Update () {
		print("Camera Speed" + this.currentSpeed);
		if (this.stopped == false) {
			this.currentSpeed = this.currentSpeed * velocityFactor;
			transform.Translate (this.currentSpeed * Time.deltaTime, 0, 0);
	
		}
	}

	public void stopCamera (){
		this.stopped = true;
	}

}
