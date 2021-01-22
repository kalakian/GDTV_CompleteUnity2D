using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;

    int guess;
    
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        NextGuess();
    }

    public void OnPressHigher()
    {
        min = Math.Min(guess + 1, max);
        NextGuess();
    }

    public void OnPressLower()
    {
        max = Math.Max(guess - 1, min);
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
    }
}
