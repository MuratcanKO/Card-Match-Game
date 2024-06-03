using UnityEngine;

public class GameData
{
    public int firstLevelPairsCount = 2;
    public int pairsIncreaseCountPerLevel = 1;
    public int maximumPairsCount = 8;
    public int firstLevelTimerCount = 30;
    public int timerDescreaseCountPerLevel = 0;
    public int minimumTimerCount = 30;
    public int scoreCountPerMatch = 50;
    public int maximumComboCount = 5;
    public int currentComboCount = 1;
    public int currentLevel = 1;
    public int currentScore = 0;
    public int currentMatchCount = 0;
    public int targetMatchCount = 0;
    public int currentTurnCount = 0;
    public float waitForRemoveAnimations = 1f;
    public int highScore = 0;

    public bool isGameOver = false;

    public Sprite[] pairsImages;

    public int currentLevelPairsCount;
}
