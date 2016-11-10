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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ObstacleTag"){
            print("tot");
            Destroy(this.gameObject);
        }
    }

}
