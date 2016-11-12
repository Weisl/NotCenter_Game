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
        // collisions with obstacles
        if (collision.gameObject.tag == "ObstacleTag"){
            //print("tot");
            Destroy(this.gameObject);
        }
        
        // collision with PowerUps
        if (collision.gameObject.tag == "BoostTag") {
            print("Boost");
            PlayerMovement playerMov = this.gameObject.GetComponent<PlayerMovement>();
            playerMov.Boost();
            
            Destroy(collision.gameObject,0);
        }

		if (collision.gameObject.tag == "PowerUpTag") {
			print("PowerUp");
			PlayerMovement playerMov = this.gameObject.GetComponent<PlayerMovement>();
			playerMov.PowerPlus();

			Destroy(collision.gameObject,0);
		}
        
        
    }

}
