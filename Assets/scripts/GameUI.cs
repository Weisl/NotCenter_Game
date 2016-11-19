using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameUI : MonoBehaviour {


    public Button Seed_Button;
    public Button Score_Button;
    public Button Menu_Button;
    private double score = 0;

    public Button Save_Button;
    public InputField Name_Field;

    private string usr_name = "";
    int seed = 0;
    int places = 3;

    // Use this for initialization
    void Start () {
        //Deactivate Buttons while in BG
        Button hsb = Score_Button.GetComponent<Button>();
        hsb.interactable = false;

        Button sb = Seed_Button.GetComponent<Button>();
        sb.interactable = false;

        Button mb = Seed_Button.GetComponent<Button>();
        mb.interactable = false;

        Button svb = Save_Button.GetComponent<Button>();
        svb.interactable = false;
        svb.onClick.AddListener(saveToHighScore);

        InputField naf = Name_Field.GetComponent<InputField>();
        naf.interactable = false;


        //Listen for User Input on Name Buttons
        naf.onValueChanged.AddListener(delegate { getUserName(); });


    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }


    public void getUserName()
    {
        InputField nf = Name_Field.GetComponent<InputField>();
        usr_name = nf.text.ToString();
    }


    public void saveToHighScore()
    {
        //Check if user has inserted Name
        if(usr_name == "")
        {
            InputField nf = Name_Field.GetComponent<InputField>();
            nf.GetComponentInChildren<Text>().text = "Insert Name Please!: ";
        }
        else
        {
            saveToFile();
        }

    }

    private void saveToFile()
    {
        

        float tmp_score = (float) score; 
        for (int i = 1; i < 4; i++)
        {
                if(tmp_score > PlayerPrefs.GetFloat("Player" + i + "Score"))
                {
                    //Save to Prefs

                    if (i < places)
                    {   
                        //Move current entries correctly
                        if( i == 1)
                        {
                            int k = places - i;
                            while (k > 0)
                            {
                                PlayerPrefs.SetString("Player" + (i + k), PlayerPrefs.GetString("Player" + (k)));
                                PlayerPrefs.SetFloat("Player" + (i + k) + "Score", PlayerPrefs.GetFloat("Player" + (k) + "Score"));
                                PlayerPrefs.SetInt("Player" + (i + k) + "Seed", PlayerPrefs.GetInt("Player" + (k) + "Seed"));
                                k--;
                            }

                        }
                        else
                        {
                            int k = places - i;
                            while (k > 0)
                            {
                                PlayerPrefs.SetString("Player" + (i + k), PlayerPrefs.GetString("Player" + (i)));
                                PlayerPrefs.SetFloat("Player" + (i + k) + "Score", PlayerPrefs.GetFloat("Player" + (i) + "Score"));
                                PlayerPrefs.SetInt("Player" + (i + k) + "Seed", PlayerPrefs.GetInt("Player" + (i) + "Seed"));
                                k--;
                            }

                        }


                    }

                 PlayerPrefs.SetString("Player" + i, usr_name);
                 PlayerPrefs.SetFloat("Player" + i + "Score", tmp_score);
                 PlayerPrefs.SetInt("Player" + i + "Seed", seed);


                //Update Button
                Button svb = Save_Button.GetComponent<Button>();
                svb.GetComponentInChildren<Text>().text = "Highscore saved";
                //Exit Loop
                break;
            }
            
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

        //Activate MenuButtons
        Button mb = Seed_Button.GetComponent<Button>();
        mb.interactable = true;


        Button svb = Save_Button.GetComponent<Button>();
        svb.interactable = true;

        InputField naf = Name_Field.GetComponent<InputField>();
        naf.interactable = true;

        //Move Canvas to Front
        GameObject UI_Obj = GameObject.FindGameObjectWithTag("GAME_UI");
        Canvas c = UI_Obj.GetComponent<Canvas>();
        c.planeDistance = 10;

        
    }

    void printScore()
    {
		
        GameObject highscore = GameObject.FindGameObjectWithTag("GameHandlerTag");
        HighScoreCalculator hsc = highscore.GetComponent<HighScoreCalculator>();

        Button hsb = Score_Button.GetComponent<Button>();
        score = System.Math.Round(hsc.getScore(), 2);
       
		hsb.GetComponentInChildren<Text>().text = "Score: " + score;
        hsb.interactable = true;


    }

    void printSeed()
    {
       
        GameObject UI_Obj = GameObject.FindGameObjectWithTag("UI");
        UI_Logic log = UI_Obj.GetComponent<UI_Logic>();
        if (log != null)
        {
            seed = log.getCurrentSeed();
        }
        
        Button sb = Seed_Button.GetComponent<Button>();
        sb.GetComponentInChildren<Text>().text = "Seed: " + seed;
        sb.interactable = true;
    }
         
}
