using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class UI_Logic : MonoBehaviour {

    int currentSeed;
    bool hasChanged = false;
    public InputField userSeed;
    public Button randomButton;
    public Button displayButton;


    void Start()
    {

        Button rndBtn = randomButton.GetComponent<Button>();
        rndBtn.onClick.AddListener(createRandomNumber);

       

        InputField usrSeed = userSeed.GetComponent<InputField>();
        usrSeed.onValueChanged.AddListener(delegate { getUserSeed(); });

    }

    public void changetoScene (int sceneNumber)
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
        print(currentSeed);
        updateDisplay();
    }
    
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
        dispBtn.GetComponentInChildren<Text>().text =  "Seed: " + currentSeed.ToString();
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
        print(result);
        return result;
    }
}

