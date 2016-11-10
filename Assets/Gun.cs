using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
    public Bullet bulletPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
	}
}
