using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int max = 1000;
    int min = 1;
    int guess = 500;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome to number wizard, a simple guessing game");
        Debug.Log("Pick a number between " + min + " and " + max);
        Debug.Log("I'll try to guess it, so don't tell me what it is");
        Debug.Log("Tell me if your number is higher or lower than " + guess);
        Debug.Log("Push Up if your number is higher, Push Down if it's lower, Push Enter if I got it correct");

        max++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            guess = (max + min) / 2;
            Debug.Log("I guessed too low ... how about " + guess + "?");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            guess = (max + min) / 2;
            Debug.Log("I guessed too high ... how about " + guess + "?");
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I guessed correctly! I knew I'd get there eventually :)");
        }
    }
}
