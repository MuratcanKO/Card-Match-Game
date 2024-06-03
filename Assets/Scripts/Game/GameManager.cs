using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject]
    private TimerController timerController;

    [Inject]
    private GameUIManager gameUIManager;

    [Inject]
    private LevelManager levelManager;

    [Inject]
    private PlayerPrefsManager playerPrefsManager;

    [Inject]
    private ScoreManager scoreManager;

    private GameData gameData = new GameData();

    private List<CardData> currentLevelCardList = new List<CardData>();

    public TextMeshProUGUI matchCountText;
    public TextMeshProUGUI TurnCountText;
    public TextMeshProUGUI currentScoreText;

    void Start()
    {
        Input.multiTouchEnabled = false;
        SetupValues();
        CreateLevel(0);
    }

    void Update()
    {
        if (timerController.currentTime <= 0f && !gameData.isGameOver)
        {
            GameOver();
        }
    }

    private void SetupValues()
    {
        SettingsParser.TransferData(GlobalManager.Instance.settingsReader.GameSettings, gameData);
        playerPrefsManager.GetAllData(gameData);
        gameData.currentLevelPairsCount = levelManager.CurrentLevelPairsCountCalculater(gameData.firstLevelPairsCount,
            gameData.pairsIncreaseCountPerLevel,
            gameData.maximumPairsCount, gameData.currentLevel);
        currentScoreText.text = gameData.currentScore.ToString();
        scoreManager.SetInitialValues(gameData.currentScore, gameData.currentComboCount, gameData.maximumComboCount);
    }

    private void GameOver()
    {
        gameData.isGameOver = true;
        GlobalManager.Instance.audioManager.Play(GlobalConstants.GAME_OVER_SFX_NAME);
        gameUIManager.GameOver();
        HighScoreCheck();
        ResetCurrentLevelAndScore();
    }

    private void CreateNextLevel()
    {
        gameData.currentLevel++;
        HighScoreCheck();
        CreateLevel(gameData.waitForRemoveAnimations);
        SaveCurrentLevelAndScore();
    }

    private void CreateLevel(float delaySecond)
    {
        StartCoroutine(LevelInstantiate(delaySecond));
    }

    private IEnumerator LevelInstantiate(float delayForAnimation)
    {
        gameData.currentLevelPairsCount = levelManager.CurrentLevelPairsCountCalculater(gameData.firstLevelPairsCount,
            gameData.pairsIncreaseCountPerLevel,
            gameData.maximumPairsCount, gameData.currentLevel);
        timerController.ResetTimer();
        timerController.SetTimerValue(gameData.firstLevelTimerCount, gameData.timerDescreaseCountPerLevel,
            gameData.minimumTimerCount, gameData.currentLevel);
        CardListManager.ResetCardList(currentLevelCardList);
        CardListManager.CreateCardList(gameData, currentLevelCardList);
        CardListManager.ShuffleCardList(currentLevelCardList);
        gameData.targetMatchCount = gameData.currentLevelPairsCount;
        scoreManager.ResetCombo();

        yield return new WaitForSeconds(delayForAnimation);

        levelManager.ClearScene();
        ResetMatchAndTurnCountText();

        yield return new WaitForSeconds(delayForAnimation);

        levelManager.InstantiateCards(currentLevelCardList);
    }

    public void CorrectCardMatch()
    {
        scoreManager.AddScore(gameData.scoreCountPerMatch);
        IncreaseTurnCountText();
        IncreaseMatchCountText();
        if (gameData.currentMatchCount == gameData.targetMatchCount)
        {
            CreateNextLevel();
        }
    }

    public void WrongCardMatch()
    {
        gameData.currentComboCount = 1;
        gameData.currentTurnCount++;
        TurnCountText.text = gameData.currentTurnCount.ToString();
        scoreManager.ResetCombo();
    }

    private void HighScoreCheck()
    {
        if (scoreManager.GetScore() > gameData.highScore)
        {
            playerPrefsManager.SetHighScore(scoreManager.GetScore());
        }
    }

    private void ResetCurrentLevelAndScore()
    {
        gameData.currentLevel = 1;
        gameData.currentScore = 0;
        playerPrefsManager.SetCurrentScore(gameData.currentScore);
        playerPrefsManager.SetCurrentLevel(gameData.currentLevel);
        scoreManager.ResetCombo();
        scoreManager.ResetCurrentScore(gameData.currentScore);
    }
    private void SaveCurrentLevelAndScore()
    {
        playerPrefsManager.SetCurrentScore(scoreManager.GetScore());
        playerPrefsManager.SetCurrentLevel(gameData.currentLevel);
    }

    private void IncreaseTurnCountText()
    {
        gameData.currentTurnCount++;
        TurnCountText.text = gameData.currentTurnCount.ToString();
    }

    private void IncreaseMatchCountText()
    {
        gameData.currentMatchCount++;
        matchCountText.text = gameData.currentMatchCount.ToString();
    }

    private void ResetMatchAndTurnCountText()
    {
        gameData.currentMatchCount = 0;
        gameData.currentTurnCount = 0;
        matchCountText.text = gameData.currentMatchCount.ToString();
        TurnCountText.text = gameData.currentTurnCount.ToString();
    }
}
