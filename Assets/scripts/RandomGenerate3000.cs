using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomGenerate3000 : MonoBehaviour {
    
    public List<GameObject> obstaclelist;
    public GameObject powerUp;
	public GameObject boostObject;
    public int objectsLivespan = 8;

	public int seed = 0;

    public float obstacleRate = 3.0f;
    public float powerUpRate = 10.0f;
    public float boostRate = 2.0f;
    
    private float obPrevTime = 0;
    private float powerPrevTime = 0;
    private float boostPrevTime = 0;
    
    private Vector3 cameraPos;
    
    // Use this for initialization
    void Start () {
		Random.seed = this.seed;
	}


    // Update is called once per frame
    void Update() {
        
        //print("Camera Position " + Camera.main.gameObject.transform.position);
        float cTime = Time.time;
        
        float obCurrentTime = cTime % obstacleRate;
        float powerCurrentTime = cTime % powerUpRate;
        float boostCurrentTime = cTime % boostRate;
        
        // Obstacle spawn
        if ( this.obPrevTime > obCurrentTime) { 
            this.cameraPos = Camera.main.gameObject.transform.position;
            GameObject obstacle = obstaclelist[Random.Range(0, obstaclelist.Count)];
            spawnObj(obstacle,-15.0f, 15.0f, 30.0f, 35.0f, this.objectsLivespan); 
            
        }
        // Power spawn 
        if (this.powerPrevTime > powerCurrentTime){
            this.cameraPos = Camera.main.gameObject.transform.position;
            spawnObj(this.powerUp ,-15.0f, 15.0f, 30.0f, 35.0f, this.objectsLivespan);        
        }
        
        // Boost spawn 
        if (this.boostPrevTime > boostCurrentTime){
			this.cameraPos = Camera.main.gameObject.transform.position;
			spawnObj (this.boostObject, -15.0f, 15.0f, 30.0f, 35.0f, this.objectsLivespan);
        }
        
        
        this.obPrevTime = obCurrentTime;
        this.powerPrevTime = powerCurrentTime;
		this.boostPrevTime = boostCurrentTime;
	
	}
    
    private void spawnObj (GameObject obj, float randomXMin, float randomXMax, float cameraDistMin, float cameraDistMax, int livespan){
             
        float zPos = Random.Range(randomXMin, randomXMax);
        float xPos = cameraPos.x + Random.Range(cameraDistMin, cameraDistMax);
        
        GameObject assignedObj = Instantiate(obj, new Vector3 (xPos, 0,zPos), Quaternion.identity) as GameObject;
        Destroy(assignedObj, livespan);        
    }

	public void getSeed(int seed){
		this.seed = seed;
	}
	public int setSeed(){
		return this.seed;
	}    
}
