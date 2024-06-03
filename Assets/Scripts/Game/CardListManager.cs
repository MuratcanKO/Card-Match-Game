using System.Collections.Generic;
using UnityEngine;

public static class CardListManager
{
    public static void CreateCardList(GameData gameData, List<CardData> currentLevelCardList)
    {
        for (int i = 0; i < gameData.currentLevelPairsCount; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                CardData newCardData;
                newCardData.cardIndex = i;
                newCardData.cardSprite = gameData.pairsImages[i];
                currentLevelCardList.Add(newCardData);
            }
        }
    }

    public static void ShuffleCardList(List<CardData> currentLevelCardList)
    {
        for (int i = 0; i < currentLevelCardList.Count; i++)
        {
            CardData temp = currentLevelCardList[i];
            int randomIndex = Random.Range(i, currentLevelCardList.Count);
            currentLevelCardList[i] = currentLevelCardList[randomIndex];
            currentLevelCardList[randomIndex] = temp;
        }
    }

    public static void ResetCardList(List<CardData> cardList)
    {
        cardList.Clear();
    }
}
