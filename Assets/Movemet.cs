using UnityEngine;
using System.Collections;

public class Movemet : MonoBehaviour {
    public float playerSpeed = 10f;
    public float rotationSpeed = 5f;
    public float sideSpeed = 5f;
    private float speed = 0f;
    //Rigidbody rBody;

    // Use this for initialization
    void Start () {
        //rBody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, playerSpeed * Time.deltaTime);


        // Player Speed with Input
        /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(0, 0, playerSpeed * Time.deltaTime);
            //rBody.AddForce(transform.forward * playerSpeed, ForceMode.Acceleration);
        }*/

        /*if (Input.GetKey(KeyCode.R)) {
            playerSpeed += 1f;
        }
        if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }*/

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(sideSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(-sideSpeed * Time.deltaTime, 0, 0);
        }
    }
}
