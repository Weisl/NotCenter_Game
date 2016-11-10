using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float bulletSpeed = 0.01f;
    public int livespan = 5;

    Rigidbody rBody;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, livespan);
        rBody = GetComponent<Rigidbody>();

        rBody.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);

	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "TargetTag") {
            Target target = collision.gameObject.GetComponent<Target>();
            target.Hit(13.178f);
            Destroy(this.gameObject);
        }

    }
}
