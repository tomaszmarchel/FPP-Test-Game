using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStageManager : MonoBehaviour
{
    public static FirstStageManager Instance { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToSecondStage()
    {
        Loader.Load(Loader.Scene.SecondStageScene);
    }
}
