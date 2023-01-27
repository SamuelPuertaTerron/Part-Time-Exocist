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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
