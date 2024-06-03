using DG.Tweening.Core.Easing;
using System.Collections;
using UnityEngine;
using Zenject;

public class PairMatchController : MonoBehaviour
{
    private float animationDuration = 0.3f;
    private Card firstCard;

    [Inject]
    private GameManager gameManager;

    private void Start()
    {
        ClearFirstData();
    }

    public void OnCardClick(Card card)
    {
        card.PlaySelectAnimation();
        if (firstCard == null)
        {
            firstCard = card;
            firstCard.cardButton.interactable = false;
        }
        else if (firstCard.cardIndex == card.cardIndex)
        {
            StartCoroutine(MatchCards(firstCard, card));
            
        }
        else
        {
            StartCoroutine(WrongCards(firstCard, card));
            ClearFirstData();
        }
    }

    private IEnumerator MatchCards(Card firstCard, Card secondCard)
    {
        ClearFirstData();
        gameManager.CorrectCardMatch();

        firstCard.cardButton.interactable = false;
        secondCard.cardButton.interactable = false;

        yield return new WaitForSeconds(animationDuration);

        firstCard.PlayCorrectAnimation();
        secondCard.PlayCorrectAnimation();

        GlobalManager.Instance.audioManager.Play(GlobalConstants.CORRECT_SFX_NAME);

        yield return null;
    }

    private IEnumerator WrongCards(Card firstCard, Card secondCard)
    {
        gameManager.WrongCardMatch();

        firstCard.cardButton.interactable = false;
        secondCard.cardButton.interactable = false;

        yield return new WaitForSeconds(animationDuration);

        firstCard.PlayWrongAnimation();
        secondCard.PlayWrongAnimation();

        GlobalManager.Instance.audioManager.Play(GlobalConstants.WRONG_SFX_NAME);

        yield return new WaitForSeconds(animationDuration);

        firstCard.cardButton.interactable = true;
        secondCard.cardButton.interactable = true;
    }

    private void ClearFirstData()
    {
        firstCard = null;
    }
}
