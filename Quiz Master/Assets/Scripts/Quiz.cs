using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;

    [Header("Button Images")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] float timeToCompleteQuestion = 30;
    [SerializeField] float timeToShowCorrectAnswer = 10;
    CountdownTimer timer;
    bool isAnsweringQuestion = false;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    bool isComplete = false;

    public bool IsGameComplete()
    {
        return isComplete;
    }

    void Awake()
    {
        timer = FindObjectOfType<CountdownTimer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
        scoreKeeper.SetNumberOfQuestions(questions.Count);
    }

    void Update()
    {
        if(!isComplete && !timer.IsTimerRunning())
        {
            isAnsweringQuestion = !isAnsweringQuestion;

            if(isAnsweringQuestion)
            {
                GetNextQuestion();
            }
            else
            {
                OnAnswerSelected(-1);
            }
        }
    }

    public void OnAnswerSelected(int index)
    {
        ShowCorrectAnswer(index);
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";

        SetButtonState(false);
        isAnsweringQuestion = false;
        timer.StartTimer(timeToShowCorrectAnswer);
    }

    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            GetRandomQuestion();
            DisplayQuestion();
            SetDefaultButtonSprites();
            SetButtonState(true);
            progressBar.value++;

            isAnsweringQuestion = true;
            timer.StartTimer(timeToCompleteQuestion);
        }
        else
        {
            isComplete = true;
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    void ShowCorrectAnswer(int index)
    {
        int correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
        Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;

        if (index == correctAnswerIndex)
        {
            questionText.text = "Correct!";
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            questionText.text = "Sorry, the correct answer was\n'"
                                + currentQuestion.GetAnswer(correctAnswerIndex)
                                + "'";
        }
    }
}
