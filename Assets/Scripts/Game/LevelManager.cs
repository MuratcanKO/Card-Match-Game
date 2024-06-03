using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;

    [SerializeField]
    private GameObject gridLayoutGroup;

    public float animationDuration = 1f;

    [Inject]
    private TimerController timerController;

    [Inject]
    private CardFactory cardFactory;

    private int pairsCountForCurrentLevel;

    private List<Button> buttons = new List<Button>();

    public void InstantiateCards(List<CardData> cardList)
    {
        foreach (CardData card in cardList)
        {
            Card cardObject = cardFactory.Create();
            //cardObject = Instantiate(cardPrefab, gridLayoutGroup.transform.position, Quaternion.identity);
            cardObject.transform.SetParent(gridLayoutGroup.transform);

            cardObject.cardIndex = card.cardIndex;
            cardObject.cardImage.sprite = card.cardSprite;
        }
        CollectAllButtons();
        StartCoroutine(PlayAnimationAndEnableButtons());
    }

    public int CurrentLevelPairsCountCalculater(int firstLevelPairsCount, int pairsIncreaseCountPerLevel, int maximumPairsCount, int currentLevel)
    {
        return pairsCountForCurrentLevel = Mathf.Min((currentLevel * pairsIncreaseCountPerLevel) + firstLevelPairsCount - 1, maximumPairsCount);
    }

    public void CollectAllButtons()
    {
        foreach (Transform child in gridLayoutGroup.transform)
        {
            Button button = child.GetComponent<Button>();
            if (button != null)
            {
                buttons.Add(button);
            }
        }
    }

    private IEnumerator PlayAnimationAndEnableButtons()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;

            yield return new WaitForSeconds(animationDuration);

            button.interactable = true;
            timerController.StartTimer();
        }
    }
}
