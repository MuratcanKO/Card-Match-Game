using System.Collections;
using System.Collections.Generic;
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

    private List<CardData> currentLevelCardList = new List<CardData>();

    private int firstLevelPairsCount = 2;
    private int pairsIncreaseCountPerLevel = 1;
    private int maximumPairsCount = 8;
    private int firstLevelTimerCount = 30;
    private int timerDescreaseCountPerLevel = 0;
    private int minimumTimerCount = 30;
    private int scoreCountPerMatch = 50;
    private int maximumComboCount = 5;
    private int currentLevel = 1;
    private int currentScore = 0;

    private Sprite[] pairsImages;

    private int currentLevelPairsCount;

    void Start()
    {
        GetSettingsValues();
        CreateCardList();
        ShuffleCardList();
        levelManager.InstantiateCards(currentLevelCardList);
        timerController.StartTimer();
    }

    void Update()
    {
        if (timerController.currentTime <= 0f)
        {
            GameOver();
            gameUIManager.GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
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

    private void ResetCardList(List<Card> cardList)
    {
        cardList.Clear();
    }
}
