using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public enum GameStage
    {
        FirstStage,
        SecondStage,
        ThirdStage
    }
    public GameStage gameStage = GameStage.FirstStage;

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
        StartCoroutine(LoadYourAsyncScene());   
    }

    IEnumerator LoadYourAsyncScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Loader.Scene.SecondStageScene.ToString(), LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName(Loader.Scene.SecondStageScene.ToString()));
        gameStage = GameStage.SecondStage;
        SceneManager.UnloadSceneAsync(Loader.Scene.FirstStageScene.ToString());
    }
}
