using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private RoomsController roomsController;

    public static float secondStageStartTime = 0;
    public enum GameStage
    {
        FirstStage,
        SecondStage,
        ThirdStage
    }
    public GameStage gameStage = GameStage.FirstStage;

    void Awake()
    {
        Instance = this;

        // TO TEST ON SECOND STAGE
        FindRoomControllerRef();
    }

    private void Start()
    {
        GameInput.Instance.OnGameOverExit += GameInput_OnGameOverExit;
    }

    private void GameInput_OnGameOverExit(object sender, System.EventArgs e)
    {
        Application.Quit();
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

        FindRoomControllerRef();
        secondStageStartTime = Time.timeSinceLevelLoad;
    
    }

    private void FindRoomControllerRef()
    {
        roomsController = GameObject.FindObjectOfType<RoomsController>().GetComponent<RoomsController>();
    }

    public void GameOver()
    {
        CalculateMissedWalls();

        gameStage = GameStage.ThirdStage;
        ShowStatistics();
        Time.timeScale = 0.0f;
    }

    private void CalculateMissedWalls()
    {
        GameStatistics.missedWallsInRoomError = roomsController.GetMissedWalls();
    }

    private void ShowStatistics()
    {
        UIManager.Instance.ShowStatistics();
    }
}
