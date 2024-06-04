using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;

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
