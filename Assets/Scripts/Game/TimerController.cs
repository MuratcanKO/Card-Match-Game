using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [HideInInspector]
    public float currentTime = 30f;

    [SerializeField]
    private TextMeshProUGUI timerText;

    private float totalTime = 30f;
    private int currentSecond = 30;

    private bool isTimerRunning = false;

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
                isTimerRunning = false;
            }
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        currentSecond = Mathf.FloorToInt(currentTime);
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

    public void SetTimerValue(int firstLevelTimerCount, int timerDescreaseCountPerLevel, int minimumTimerCount, int currentLevel)
    {
        int tempTimer = firstLevelTimerCount + timerDescreaseCountPerLevel - (currentLevel * timerDescreaseCountPerLevel);
        totalTime = Mathf.Max(tempTimer, minimumTimerCount);
        ResetTimer();
    }
}
