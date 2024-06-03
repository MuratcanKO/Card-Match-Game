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

    [Inject]
    private TimerController timerController;

    [Inject]
    private CardFactory cardFactory;

    [Inject]
    private CellSizeFlexable cellSizeFlexable;

    private List<Button> buttons = new List<Button>();

    private float animationDuration = 1f;

    public void InstantiateCards(List<CardData> cardList)
    {
        foreach (CardData card in cardList)
        {
            Card cardObject = cardFactory.Create();
            cardObject.transform.SetParent(gridLayoutGroup.transform);

            cardObject.cardIndex = card.cardIndex;
            cardObject.cardImage.sprite = card.cardSprite;
        }
        cellSizeFlexable.SetCellSize();
        buttons.Clear();
        CollectAllButtons();
        StartCoroutine(PlayAnimationAndEnableButtons());
    }

    public int CurrentLevelPairsCountCalculater(int firstLevelPairsCount, int pairsIncreaseCountPerLevel, int maximumPairsCount, int currentLevel)
    {
        return Mathf.Min((currentLevel * pairsIncreaseCountPerLevel) + firstLevelPairsCount - 1, maximumPairsCount);
    }

    public void CollectAllButtons()
    {
        foreach (Transform child in gridLayoutGroup.transform)
        {
            Button button = child.GetComponent<Button>();
            if (button != null && child.gameObject.activeSelf)
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
        }

        yield return new WaitForSeconds(animationDuration);

        foreach (Button button in buttons)
        {
            button.interactable = true;
            timerController.StartTimer();
        }        
    }

    public void ClearScene()
    {
        foreach (Transform child in gridLayoutGroup.transform)
        {
            Card selectedCard = child.GetComponent<Card>();
            if (child != null && child.gameObject.activeSelf)
            {
                selectedCard.PlayRemovoAnimation();
            }
        }
    }
}
