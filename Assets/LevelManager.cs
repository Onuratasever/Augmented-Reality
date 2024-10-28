using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextScene()
    {
        // get current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // you should check index bounds before loading scene
        // if currentSceneIndex is last scene, go to first scene
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
            return;
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    public void previousScene()
    {
        // get current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // load previous scene
        // you should check index bounds before loading scene
        // if currentSceneIndex is 0, go to last scene
        if (currentSceneIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
            return;
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
        // SceneManager.LoadScene(currentSceneIndex - 1);
    }
}
