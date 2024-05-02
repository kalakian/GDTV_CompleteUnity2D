using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    float timeToRun;
    float timerValue;
    bool isTimerRunning = false;

    public void StartTimer(float time)
    {
        isTimerRunning = true;
        timerValue = timeToRun = time;
    }

    public bool IsTimerRunning()
    {
        return isTimerRunning;
    }

    public float GetTimeToRun()
    {
        return timeToRun;
    }

    public float GetTimerValue()
    {
        return timerValue;
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        if(isTimerRunning)
        {
            timerValue -= Time.deltaTime;
            if(timerValue <= 0)
            {
                timerValue = 0;
                isTimerRunning = false;
            }
        }
    }
}
