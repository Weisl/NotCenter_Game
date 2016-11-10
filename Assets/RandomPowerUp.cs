using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomPowerUp : MonoBehaviour {
    public GameObject powerUp;
    private int count = 0;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (count < 10) { 
        GameObject power = powerUp;
        //Vector3 pos = new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(-4.0f, 4.0f), 0);
        float xPos = Random.Range(-20.0f,20.0f);
        Instantiate(power, new Vector3 (xPos, 0,10 * count), Quaternion.identity);
        count ++;
        }
        
	
	}
}
