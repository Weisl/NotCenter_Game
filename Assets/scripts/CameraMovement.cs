using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public static float cameraSpeed = 5f;
    private static float currentSpeed;
    public float velocityFactor;
    // Use this for initialization
    void Start () {
        currentSpeed = cameraSpeed;
    }

	// Update is called once per frame
	void Update () {
        currentSpeed = currentSpeed * Time.deltaTime * velocityFactor;
        transform.Translate(cameraSpeed * Time.deltaTime, 0, 0);
	}


}
