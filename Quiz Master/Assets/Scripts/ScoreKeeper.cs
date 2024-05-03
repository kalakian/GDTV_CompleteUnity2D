using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int numberOfQuestions = 0;

    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public int GetNumberOfQuestions()
    {
        return numberOfQuestions;
    }

    public void SetNumberOfQuestions(int numQuestions)
    {
        numberOfQuestions = numQuestions;
    }

    public int CalculateScore()
    {
        int score = 0;

        if(numberOfQuestions > 0)
        {
            score = Mathf.RoundToInt(correctAnswers / (float)numberOfQuestions * 100);
        }

        return score;
    }
}
