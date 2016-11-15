using UnityEngine;
using System.Collections;

public class HighScoreCalculator : MonoBehaviour {
	private static float initialScore = 0;
	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private static float calculateScore(){
        return Time.timeSinceLevelLoad * 1;
	} 

	public float getScore (){
		return calculateScore();
	}
		
	public void printScore(){

        print ("Score " + this.getScore());
	}
}
