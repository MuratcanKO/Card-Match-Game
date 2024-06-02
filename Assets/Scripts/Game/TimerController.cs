using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float totalTime = 30f;
    public float currentTime = 30f;
    private int currentSecond = 30;
    private bool isTimerRunning = false;

    public TextMeshProUGUI timerText;

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                UpdateTimerText();
                isTimerRunning = false;
            }
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        currentSecond = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = currentSecond.ToString();
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void PauseTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = totalTime;
        isTimerRunning = false;
        UpdateTimerText();
    }
}
