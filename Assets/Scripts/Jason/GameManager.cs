using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    void Awake()
    {
        DontDestroyOnLoad(this);
        if(gameManager==null){
            gameManager = this;
        }
        else{
            Destroy(gameManager);
        }
    }
}
