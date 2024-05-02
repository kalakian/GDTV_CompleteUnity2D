using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    CountdownTimer timer;

    void Start()
    {
        timer = FindObjectOfType<CountdownTimer>();
    }

    void Update()
    {
        if(timer.IsTimerRunning())
        {
            float timeToRun = timer.GetTimeToRun();
            float timerValue = timer.GetTimerValue();
            GetComponent<Image>().fillAmount = timerValue / timeToRun;
        }
    }
}
