using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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


    private List<CardData> currentLevelCardList = new List<CardData>();

    private int firstLevelPairsCount = 2;
    private int pairsIncreaseCountPerLevel = 1;
    private int maximumPairsCount = 8;
    private int firstLevelTimerCount = 30;
    private int timerDescreaseCountPerLevel = 0;
    private int minimumTimerCount = 30;
    private int scoreCountPerMatch = 50;
    private int maximumComboCount = 5;
    private int currentComboCount = 1;
    private int currentLevel = 1;
    private int currentScore = 0;
    private int currentMatchCount = 0;
    private int targetMatchCount = 0;
    private int currentTurnCount = 0;
    private float waitForRemoveAnimations = 1f;

    private bool isGameOver = false;

    private Sprite[] pairsImages;

    private int currentLevelPairsCount;

    public GameObject confettiRainbowPrefab;

    void Start()
    {
        Input.multiTouchEnabled = false;
        GetSettingsValues();
        CreateLevel(0);
    }

    void Update()
    {
        if (timerController.currentTime <= 0f && !isGameOver)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        GlobalManager.Instance.audioManager.Play(GlobalConstants.GAME_OVER_SFX_NAME);
        gameUIManager.GameOver();
    }

    private void NextLevel()
    {
        currentLevel++;
        CreateLevel(waitForRemoveAnimations);
    }

    private void GetSettingsValues()
    {
        firstLevelPairsCount = GlobalManager.Instance.settingsReader.GameSettings.FirstLevelPairsCount;
        pairsIncreaseCountPerLevel = GlobalManager.Instance.settingsReader.GameSettings.PairsIncreaseCountPerLevel;
        maximumPairsCount = GlobalManager.Instance.settingsReader.GameSettings.MaximumPairsCount;
        firstLevelTimerCount = GlobalManager.Instance.settingsReader.GameSettings.FirstLevelTimerCount;
        timerDescreaseCountPerLevel = GlobalManager.Instance.settingsReader.GameSettings.TimerDescreaseCountPerLevel;
        minimumTimerCount = GlobalManager.Instance.settingsReader.GameSettings.MinimumTimerCount;
        scoreCountPerMatch = GlobalManager.Instance.settingsReader.GameSettings.ScoreCountPerMatch;
        maximumComboCount = GlobalManager.Instance.settingsReader.GameSettings.MaximumComboCount;
        pairsImages = GlobalManager.Instance.settingsReader.GameSettings.PairsImages;
        currentLevel = playerPrefsManager.GetCurrentLevel();
        currentScore = playerPrefsManager.GetCurrentScore();
        currentLevelPairsCount = levelManager.CurrentLevelPairsCountCalculater(firstLevelPairsCount, pairsIncreaseCountPerLevel,
            maximumPairsCount, currentLevel);
    }

    private void CreateCardList()
    {
        for (int i = 0; i < currentLevelPairsCount; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                CardData newCardData;
                newCardData.cardIndex = i;
                newCardData.cardSprite = pairsImages[i];
                currentLevelCardList.Add(newCardData);
            }
        }
    }

    private void ShuffleCardList()
    {
        for (int i = 0; i < currentLevelCardList.Count; i++)
        {
            CardData temp = currentLevelCardList[i];
            int randomIndex = Random.Range(i, currentLevelCardList.Count);
            currentLevelCardList[i] = currentLevelCardList[randomIndex];
            currentLevelCardList[randomIndex] = temp;
        }
    }

    private void ResetCardList(List<CardData> cardList)
    {
        cardList.Clear();
    }

    public void CorrectCardMatch()
    {
        scoreManager.AddScore(scoreCountPerMatch, currentComboCount);
        currentComboCount = Mathf.Min(currentComboCount + 1, maximumComboCount);
        currentMatchCount++;
        currentTurnCount++;
        if (currentMatchCount == targetMatchCount)
        {
            NextLevel();
        }
    }

    public void WrongCardMatch()
    {
        currentComboCount = 1;
        currentTurnCount++;
    }

    private void CreateLevel(float delaySecond)
    {
        levelManager.ClearScene();
        currentLevelPairsCount = levelManager.CurrentLevelPairsCountCalculater(firstLevelPairsCount, pairsIncreaseCountPerLevel,
            maximumPairsCount, currentLevel);
        timerController.ResetTimer();
        timerController.SetTimerValue(firstLevelTimerCount, timerDescreaseCountPerLevel, minimumTimerCount, currentLevel);
        ResetCardList(currentLevelCardList);
        CreateCardList();
        ShuffleCardList();
        targetMatchCount = currentLevelPairsCount;
        currentMatchCount = 0;
        currentTurnCount = 0;
        currentComboCount = 1;
        StartCoroutine(LevelInstantiate(delaySecond));
        
    }

    private IEnumerator LevelInstantiate(float delayForAnimation)
    {
        yield return new WaitForSeconds(delayForAnimation);

        levelManager.InstantiateCards(currentLevelCardList);
    }
}
