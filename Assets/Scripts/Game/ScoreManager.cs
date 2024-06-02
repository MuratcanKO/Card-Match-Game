using TMPro;
using UnityEngine;
using Zenject;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0;
    private int comboMultiplier = 1;
    private int maxComboMultiplier = 5;

    public TextMeshProUGUI scoreText;

    [Inject]
    private PlayerPrefsManager playerPrefsManager;

    private void Start()
    {
        currentScore = playerPrefsManager.GetCurrentScore();
        UpdateText();
    }

    public void AddScore(int scoreCountPerMatch, int comboMultiplierCount)
    {
        currentScore += scoreCountPerMatch * comboMultiplierCount;
        UpdateText();
        UpdateCombo();
    }

    private void UpdateCombo()
    {
        comboMultiplier = Mathf.Min(comboMultiplier + 1, maxComboMultiplier);
    }

    private void UpdateText() 
    {
        scoreText.text = currentScore.ToString();
    }
        

    public void ResetCombo()
    {
        comboMultiplier = 1;
    }

    public int GetScore()
    {
        return currentScore;
    }

    public int GetComboMultiplier()
    {
        return comboMultiplier;
    }
}
