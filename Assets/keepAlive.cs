using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class keepAlive : MonoBehaviour {


    public GameObject alive;

    void Awake()
    {
              
        DontDestroyOnLoad(alive);
    }

   
}
