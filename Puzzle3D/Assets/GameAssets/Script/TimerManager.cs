using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    // constructor
    public static TimerManager instance;
    public float totalTime = 240f;
    [SerializeField] TextMeshProUGUI timerDisplay;
    [SerializeField] Image sliderBackground;
    [SerializeField] Slider slider;
    public bool isPaused;
    public bool isGameOver;
    private float maxTime;
    private float minutes;
    private float seconds;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
        maxTime = totalTime;

        SetTimerDisplay();
        SetSliderValue();
    }
    private void Update()
    {
        if (isPaused) return;
        CountDownTime();
    }
    private void CountDownTime()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            SetTimerDisplay();
            SetSliderValue();
        }
        if (totalTime <= 0)
        {
            isGameOver = true;
            totalTime = 0;
        }
    }
    private void SetTimerDisplay()
    {
        int minutes = (int)(totalTime / 60);
        int seconds = (int)(totalTime % 60);

        timerDisplay.text = "0" + minutes + " : " + seconds;
        if (seconds < 10)
            timerDisplay.text = "0" + minutes + " : 0" + seconds;
    }
    private void SetSliderValue()
    {
        float value = 1 - totalTime / maxTime;
        slider.value = value;
        //sliderBackground.color = Color.Lerp(Color.blue, Color.red, value);
    }
    public void PauseTime(bool _value)
    {
        isPaused = _value;
    }
    public int GetTime()
    {
        return (int)totalTime;
    }
    public int GetStartTime()
    {
        return (int)maxTime;
    }
    public void ResetTime()
    {
        totalTime = maxTime;
    }
    public float GetSliderValue()
    {
        return slider.value;
    }
}
