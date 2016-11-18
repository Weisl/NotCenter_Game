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
        if(currentSeed == 0)
        {
            createRandomNumber();
        }
        updateDisplay();
    }
        
    //Load Level
    public void changetoScene(int sceneNumber)
    {
        print("Seed in old scene: " + currentSeed);
            
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
    }

    public void printHighscore()
    {

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

