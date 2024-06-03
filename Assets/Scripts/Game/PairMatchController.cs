using System.Collections;
using UnityEngine;

public class PairMatchController : MonoBehaviour
{
    public float animationDuration = 1f;
    private Card firstCard;

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
        firstCard.cardButton.interactable = false;
        secondCard.cardButton.interactable = false;

        firstCard.PlayCorrectAnimation();
        secondCard.PlayCorrectAnimation();

        GlobalManager.Instance.audioManager.Play(GlobalConstants.CORRECT_SFX_NAME);

        yield return null;
    }

    private IEnumerator WrongCards(Card firstCard, Card secondCard)
    {
        firstCard.cardButton.interactable = false;
        secondCard.cardButton.interactable = false;

        firstCard.PlayWrongAnimation();
        secondCard.PlayWrongAnimation();

        yield return new WaitForSeconds(animationDuration);

        firstCard.cardButton.interactable = true;
        secondCard.cardButton.interactable = true;
    }

    private void ClearFirstData()
    {
        firstCard = null;
    }
}
