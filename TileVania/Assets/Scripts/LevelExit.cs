using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float delayBeforeNextLevel = 1;

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(delayBeforeNextLevel);

        int numLevels = SceneManager.sceneCountInBuildSettings;
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = levelIndex + 1;
        if(nextLevel == numLevels)
        {
            nextLevel = 0;
        }

        FindObjectOfType<ScenePersist>().ResetScenePersistence();
        SceneManager.LoadScene(nextLevel);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }
}
