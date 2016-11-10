using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
    public GameObject explosionPrefab;
    private float currentHealt = 0;
    public float maxHealth = 0;

	// Use this for initialization
	void Start () {
        currentHealt = maxHealth;

    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnDestroy() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
       
    }

    public void Hit (float damage){
        currentHealt = currentHealt - damage;
        if (currentHealt <= 0) {
            Destroy(gameObject);
        }
    }
}
