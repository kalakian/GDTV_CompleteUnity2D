using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int points)
    {
        score += points;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
