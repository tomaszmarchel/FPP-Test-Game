using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        FirstStageScene,
        SecondStageScene,
        ThirdStageScene
    }

    private static Scene targetScene;
    public static void Load(Scene scene)
    {
        Loader.targetScene = scene;

        SceneManager.LoadScene(targetScene.ToString());

    }
}
