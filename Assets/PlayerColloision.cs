using UnityEngine;
using System.Collections;

public class PlayerColloision : MonoBehaviour {
    public GameObject explosionPrefab;
    // Use this for initialization

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnDestroy(){
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ObstacleTag"){
            print("tot");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "PowerUpTag") {
            CameraMovement.PowerUp();
            print("PowerUp");
        }
    }

}
