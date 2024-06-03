using System.Collections;
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

    private Card tempCard;

    private float waitForDestroy = 10f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Utils.IsNull(eventData.pointerPress.GetComponent<Card>()) && Utils.IsNull(pairMatchController)
            && Utils.IsNull(eventData.pointerPress.GetComponent<Card>().cardButton))
        {
            tempCard = eventData.pointerPress.GetComponent<Card>();
            OnCardClicked(tempCard.cardButton);
        }
    }

    public void PlayCorrectAnimation()
    {
        cardAnimator.Play(GlobalConstants.CARD_ANIMATOR_CORRECT_NAME);
    }

    public void PlayRemovoAnimation()
    {
        cardAnimator.Play(GlobalConstants.CARD_ANIMATOR_REMOVE_NAME);
        StartCoroutine(DestroyCurrentGameObject());
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

    private void OnCardClicked(Button selectedButton)
    {
        if (selectedButton.interactable == true)
        {
            GlobalManager.Instance.audioManager.Play(GlobalConstants.FLIP_CARD_SFX_NAME);
            pairMatchController.OnCardClick(tempCard);
        }
    }
    IEnumerator DestroyCurrentGameObject()
    {
        yield return new WaitForSeconds(cardAnimator.GetCurrentAnimatorStateInfo(0).length);
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitForDestroy);
        Destroy(this.gameObject);
    }
}

public class CardFactory : PlaceholderFactory<Card>
{

}
