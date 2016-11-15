using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {


    public Button Seed_Button;
    public Button Score_Button;

    // Use this for initialization
    void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }

    public void goToMenu()
    {
      SceneManager.LoadScene(0);
    }
    
    
    public void startEndScreen()
    {
        printScore();
        printSeed();

        GameObject UI_Obj = GameObject.FindGameObjectWithTag("GAME_UI");
        Canvas c = UI_Obj.GetComponent<Canvas>();
        c.planeDistance = 10;

        
    }

    void printScore()
    {
        GameObject highscore = GameObject.FindGameObjectWithTag("GameHandlerTag");
        HighScoreCalculator hsc = highscore.GetComponent<HighScoreCalculator>();

        Button hsb = Score_Button.GetComponent<Button>();   
        hsb.GetComponentInChildren<Text>().text = "Score: " + hsc.getScore();

    }

    void printSeed()
    {
        int seed = 0;
        GameObject UI_Obj = GameObject.FindGameObjectWithTag("UI");
        UI_Logic log = UI_Obj.GetComponent<UI_Logic>();
        if (log != null)
        {
            print("inside");
            seed = log.getCurrentSeed();
        }
        
        Button sb = Seed_Button.GetComponent<Button>();
        sb.GetComponentInChildren<Text>().text = "Seed: " + seed;

       

    }
         
}
