using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class keepAlive : MonoBehaviour {


    public GameObject alive;


    void Start()
    {
              
        DontDestroyOnLoad(alive);
    }


}
