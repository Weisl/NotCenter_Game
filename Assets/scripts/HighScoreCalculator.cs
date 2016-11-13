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
		float score;
		score = Time.time * 1;
		return score;

	} 

	public static float getScore (){
		return calculateScore();
	}
		
	public static void printScore(){
		float score = getScore();
		print ("Score " + score);
	}
}
