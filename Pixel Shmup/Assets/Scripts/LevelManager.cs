using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2;

    const int mainMenuSceneIndex = 0;
    const int gameSceneIndex = 1;
    const int gameOverSceneIndex = 2;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad(gameOverSceneIndex, sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game ...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
}
