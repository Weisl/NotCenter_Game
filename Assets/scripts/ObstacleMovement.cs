using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {
    
    public float rotationMin = 5f;
    public float rotationMax = 50f;
    
    private float rotationSpeed = 0f;
    // Use this for initialization
    
    
    void setRotationMinMax(float rotationMin, float rotationMax){     
        // rotationValues
        this.rotationMin = rotationMin;
        this.rotationMax = rotationMax;
    }
    
    
    void Start() {
        // calculates the rotationspeed of the obstacle
        rotationSpeed = Random.Range(rotationMin,rotationMax);
    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
	}
}
