using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float elapsedTime;
    private String timerTextFormat;

    void Start()
    {
        timerText = transform.Find("Value").GetComponent<TextMeshProUGUI>();
        elapsedTime = 0f;
        timerTextFormat = "{0:00}:{1:00}:{2:00}";
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        SetTimerText();
    }

    void SetTimerText() {
        int hours = GetHoursPart();
        int minutes = GetMinutesPart();
        int seconds = GetSecondsPart();
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
}
