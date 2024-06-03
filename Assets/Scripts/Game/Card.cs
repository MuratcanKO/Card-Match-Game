using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class Card : MonoBehaviour, ICardInteractable, IPointerClickHandler
{
    [Inject]
    private PairMatchController pairMatchController;

    public Animator cardAnimator;
    public int cardIndex;
    public Image cardImage;
    public Button cardButton;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Utils.IsNull(eventData.pointerPress.GetComponent<Card>()) && Utils.IsNull(pairMatchController))
        {
            pairMatchController.OnCardClick(eventData.pointerPress.GetComponent<Card>());
        }
    }

    public void PlayCorrectAnimation()
    {
        cardAnimator.Play(GlobalConstants.CARD_ANIMATOR_CORRECT_NAME);
    }

    public void PlayRemovoAnimation()
    {
        cardAnimator.Play(GlobalConstants.CARD_ANIMATOR_REMOVE_NAME);
    }

    public void PlaySelectAnimation()
    {
        cardAnimator.Play(GlobalConstants.CARD_ANIMATOR_SELECT_NAME);
    }

    public void PlaySpawnAnimation()
    {
        cardAnimator.Play(GlobalConstants.CARD_ANIMATOR_SPAWN_NAME);
    }

    public void PlayUnselectAnimation()
    {
        cardAnimator.Play(GlobalConstants.CARD_ANIMATOR_UNSELECT_NAME);
    }

    public void PlayWrongAnimation()
    {
        cardAnimator.Play(GlobalConstants.CARD_ANIMATOR_WRONG_NAME);
    }
}

public class CardFactory : PlaceholderFactory<Card>
{

}
