using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;

    [Header("Button Images")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] float timeToCompleteQuestion = 30;
    [SerializeField] float timeToShowCorrectAnswer = 10;
    CountdownTimer timer;
    bool isAnsweringQuestion;

    void Start()
    {
        timer = FindObjectOfType<CountdownTimer>();
        GetNextQuestion();
    }

    void Update()
    {
        if(!timer.IsTimerRunning())
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
        int correctAnswerIndex = question.GetCorrectAnswerIndex();

        if (index == correctAnswerIndex)
        {
            questionText.text = "Correct!";
            ShowCorrectAnswer();
        }
        else
        {
            questionText.text = "Incorrect! The correct answer was\n'"
                                + question.GetAnswer(correctAnswerIndex)
                                + "'";
            ShowCorrectAnswer();
        }

        SetButtonState(false);
    }

    void GetNextQuestion()
    {
        DisplayQuestion();
        SetDefaultButtonSprites();
        SetButtonState(true);
        
        isAnsweringQuestion = true;
        timer.StartTimer(timeToCompleteQuestion);
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
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

    void ShowCorrectAnswer()
    {
        int correctAnswerIndex = question.GetCorrectAnswerIndex();
        Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;

        isAnsweringQuestion = false;
        timer.StartTimer(timeToShowCorrectAnswer);
    }
}
