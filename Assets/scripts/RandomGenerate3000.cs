using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RandomGenerate3000 : MonoBehaviour {

  	public int seed = 0;
    
    UI_Logic log;

    public List<GameObject> obstaclelist;
    public GameObject powerUp;
	public GameObject boostObject;
    
	public float sizeMin = 1;
	public float sizeMax = 1.5f;

	public int objectsLivespan = 8;

    public float obstacleRate = 3.0f;
    public float powerUpRate = 10.0f;
    public float boostRate = 2.0f;
    
    private float obPrevTime = 0;
    private float powerPrevTime = 0;
    private float boostPrevTime = 0;
    
    private Vector3 cameraPos;
    
    
    // Use this for initialization
    void Start () {
   	    
        getSeedFromOldScene();
		Random.seed = this.seed;
    
	}
    
    void getSeedFromOldScene()
    {
        //LOAD THIS WHEN SCENE IS LOADED
        GameObject UI_Obj = GameObject.FindGameObjectWithTag("UI");
        log = UI_Obj.GetComponent<UI_Logic>();
        if (log != null)
        {
            print("inside");
            seed = log.getCurrentSeed();
        }
        print("New Seed: " + seed);

    }

    // Update is called once per frame
    void Update() {

    
        //print("Camera Position " + Camera.main.gameObject.transform.position);
        
		float cTime = Time.time;
		//print ("Time: " + cTime);
        
		float obCurrentTime = cTime  % obstacleRate;
		float powerCurrentTime = cTime  % powerUpRate;
		float boostCurrentTime = cTime  % boostRate;
        
        // Obstacle spawn
        if ( this.obPrevTime > obCurrentTime) { 
            this.cameraPos = Camera.main.gameObject.transform.position;
            GameObject obstacle = obstaclelist[Random.Range(0, obstaclelist.Count)];
			spawnObj(obstacle,-15.0f, 15.0f, 30.0f, 35.0f, this.objectsLivespan, sizeMin,sizeMax); 
            
        }
        // Power spawn 
        if (this.powerPrevTime > powerCurrentTime){
            this.cameraPos = Camera.main.gameObject.transform.position;
			spawnObj(this.powerUp ,-15.0f, 15.0f, 30.0f, 35.0f, this.objectsLivespan, sizeMin,sizeMax);        
        }
        
        // Boost spawn 
        if (this.boostPrevTime > boostCurrentTime){
			this.cameraPos = Camera.main.gameObject.transform.position;
			spawnObj (this.boostObject, -15.0f, 15.0f, 30.0f, 35.0f, this.objectsLivespan, sizeMin,sizeMax);
        }
        
        
        this.obPrevTime = obCurrentTime;
        this.powerPrevTime = powerCurrentTime;
		this.boostPrevTime = boostCurrentTime;
	
	}
    
	private void spawnObj (GameObject obj, float randomXMin, float randomXMax, float cameraDistMin, float cameraDistMax, int livespan, float sizeMin, float sizeMax){
             
        float zPos = Random.Range(randomXMin, randomXMax);
        float xPos = cameraPos.x + Random.Range(cameraDistMin, cameraDistMax);
        
        GameObject assignedObj = Instantiate(obj, new Vector3 (xPos, 0,zPos), Quaternion.identity) as GameObject; 
		Destroy(assignedObj, livespan);        
    }

	public void setSeed(int seed){
		this.seed = seed;
	}
	public int getSeed(){
		return this.seed;
	}    
}
