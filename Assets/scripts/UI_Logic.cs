using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class UI_Logic : MonoBehaviour {

    static int currentSeed = 0;
    public InputField userSeed;
    public Button randomButton;
    public Button displayButton;
    public GameObject UI_Manager;

    public Text leaderboardText;

    void Start()
    {
        //UI
        Button rndBtn = randomButton.GetComponent<Button>();
        rndBtn.onClick.AddListener(createRandomNumber);

        InputField usrSeed = userSeed.GetComponent<InputField>();
        usrSeed.onValueChanged.AddListener(delegate { getUserSeed(); });

        //Transfer Stuff
        DontDestroyOnLoad(UI_Manager);

       
        //Display Seed
        if (currentSeed == 0)
        {
            createRandomNumber();
        }
      

        //Create UserPrefs if necessary
        if(PlayerPrefs.HasKey("Highscore") == false)
        {
            createLeaderBoard();
         
        }
        updateDisplay();
        


    }


    public void createLeaderBoard()
    {

        for(int i = 1; i < 4; i++)
        {
            PlayerPrefs.SetString("Player" + i, "Bob");
            PlayerPrefs.SetFloat("Player" + i + "Score", 0.0f);
            PlayerPrefs.SetInt("Player" + i + "Seed", 0);
        }
        print("Leaderboard created");
        PlayerPrefs.SetInt("Highscore", 1);
        updateDisplay();
    }
        
    //Load Level
    public void changetoScene(int sceneNumber)
    {
      

        SceneManager.LoadScene(sceneNumber);
    }

    public void closeGame()
    {
        Application.Quit();
    }

    //Generate Random Number from Random Button
    public void createRandomNumber()
    {
        currentSeed = (int)((7548 * System.DateTime.UtcNow.Millisecond) / 1000);
       
        updateDisplay();
    }
    
    //Get User Input
    public void getUserSeed()
    {
       InputField usrSeed = userSeed.GetComponent<InputField>();
       
       currentSeed = IntParseFast(usrSeed.text.ToString());

       updateDisplay();  
    }


    public void updateDisplay()
    {
        Button dispBtn = displayButton.GetComponent<Button>();
        print(currentSeed);
        dispBtn.GetComponentInChildren<Text>().text = "Seed: " + currentSeed.ToString();
        printHighscore();
    }

    public void printHighscore()
    {

        Text txt  = leaderboardText.GetComponent<Text>();

        
        txt.text = "Player \t\t Score \t Seed \n\n";

        for(int i = 1; i < 4; i++)
        {
            txt.text += PlayerPrefs.GetString("Player" + i) + "\t\t"+ PlayerPrefs.GetFloat("Player" + i + "Score") + "\t\t" + PlayerPrefs.GetInt("Player" + i + "Seed");
            txt.text += "\n";

        }
    }
    
    public int IntParseFast(string value)
    {
        int result = 0;
        for (int i = 0; i < value.Length; i++)
        {
            char letter = value[i];
            result = 10 * result + (letter - 48);
        }
       
        return result;
    }

    public int getCurrentSeed()
    {
        return currentSeed;
    }
}

