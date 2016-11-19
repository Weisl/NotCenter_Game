using UnityEngine;
using System.Collections;

public class HighScoreCalculator : MonoBehaviour {
	private float initialScore;
	// Use this for initialization
	void Start () {	
		this.initialScore = 1;
	}

	// Update is called once per frame
	void Update () {
	
		this.initialScore +=  1 * Time.deltaTime;
	}
		

	public float getScore (){
		return this.initialScore;
	}

}
