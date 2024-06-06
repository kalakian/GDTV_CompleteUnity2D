using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        if(scoreKeeper && scoreText)
        {
            scoreText.text = "You Scored:\n" + scoreKeeper.GetScore().ToString("000000000");
        }
    }
}
