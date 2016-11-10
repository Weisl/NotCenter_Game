using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {
    public float rotationSpeed = 5f;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
	}
}
