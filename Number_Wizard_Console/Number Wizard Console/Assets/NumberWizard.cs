using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int max;
    int min;
    int guess;
    
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        max = 1000;
        min = 1;

        Debug.Log("Welcome to number wizard, a simple guessing game");
        Debug.Log("Pick a number between " + min + " and " + max);
        Debug.Log("I'll try to guess it, so don't tell me what it is");
        NextGuess();
        Debug.Log("Push Up if your number is higher, Push Down if it's lower, Push Enter if I got it correct");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess + 1;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess - 1;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I guessed correctly! I knew I'd get there eventually :)");
            StartGame();
        }   
    }

    void NextGuess()
    {
        guess = (max + min) / 2;
        Debug.Log("Is your number higher or lower than " + guess + "?");
    }
}
