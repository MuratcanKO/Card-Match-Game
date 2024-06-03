using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0;
    private int comboMultiplier = 1;
    private int maxComboMultiplier = 5;

    public TextMeshProUGUI scoreText;

    public void AddScore(int scoreCountPerMatch)
    {
        currentScore += scoreCountPerMatch * comboMultiplier;
        UpdateText();
        UpdateCombo();
    }

    public void SetInitialValues(int updatedScore, int comboMultiplierCount, int maxComboValue)
    {
        currentScore = updatedScore;
        comboMultiplier = comboMultiplierCount;
        maxComboMultiplier = maxComboValue;
        UpdateText();
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

    public void ResetCurrentScore(int updatedScore) 
    {
        currentScore = updatedScore;
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
