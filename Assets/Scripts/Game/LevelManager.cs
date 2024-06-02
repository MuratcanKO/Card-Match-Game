using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;

    [SerializeField]
    private GameObject gridLayoutGroup;

    private int pairsCountForCurrentLevel;

    public void InstantiateCards(List<CardData> cardList)
    {
        foreach (CardData card in cardList)
        {
            GameObject cardObject = Instantiate(cardPrefab, gridLayoutGroup.transform.position, Quaternion.identity);
            cardObject.transform.SetParent(gridLayoutGroup.transform);

            cardObject.GetComponent<Card>().cardIndex = card.cardIndex;
            cardObject.GetComponent<Card>().cardImage.sprite = card.cardSprite;
        }
    }

    public int CurrentLevelPairsCountCalculater(int firstLevelPairsCount, int pairsIncreaseCountPerLevel, int maximumPairsCount, int currentLevel)
    {
       return pairsCountForCurrentLevel = Mathf.Min((currentLevel* pairsIncreaseCountPerLevel) + firstLevelPairsCount - 1, maximumPairsCount);
    }
}
