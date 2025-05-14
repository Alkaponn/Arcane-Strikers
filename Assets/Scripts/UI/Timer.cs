using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action OnSecondPassed;

    private TextMeshProUGUI timerText;
    private string timerTextFormat;
    private float elapsedTime;
    private int hours;
    private int minutes;
    private int seconds;

    void Start()
    {
        timerText = transform.Find("ValuePart").Find("ValueText").GetComponent<TextMeshProUGUI>();
        elapsedTime = 0f;
        timerTextFormat = "{0:00}:{1:00}:{2:00}";
    }

    void Update()
    {
        if (Time.timeScale == 0f) {
            return;
        }
        
        elapsedTime += Time.deltaTime;
        NotifyOnSecondPassed();
        SetTimerText();
    }

    void NotifyOnSecondPassed() {
        if (seconds != GetSecondsPart()) {
            OnSecondPassed?.Invoke();
        }
    }

    void SetTimerText() {
        hours = GetHoursPart();
        minutes = GetMinutesPart();
        seconds = GetSecondsPart();
        timerText.text = string.Format(timerTextFormat, hours, minutes, seconds);
    }

    int GetHoursPart() {
        return ((int) Math.Floor(elapsedTime)) / 3600;
    }

    int GetMinutesPart() {
        return (((int) Math.Floor(elapsedTime)) % 3600) / 60;
    }

    int GetSecondsPart() {
        return ((int) Math.Floor(elapsedTime)) % 60;
    }    

    public string GetTime() {
        return timerText.text;
    }
}
