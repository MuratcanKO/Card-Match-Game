using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour, ICardInteractable
{
    public Animator cardAnimator;
    public int cardIndex;
    public Image cardImage;

    public void PlayCorrectAnimation()
    {
        throw new System.NotImplementedException();
    }

    public void PlayRemovoAnimation()
    {
        throw new System.NotImplementedException();
    }

    public void PlaySelectAnimation()
    {
        throw new System.NotImplementedException();
    }

    public void PlaySpawnAnimation()
    {
        throw new System.NotImplementedException();
    }

    public void PlayUnselectAnimation()
    {
        throw new System.NotImplementedException();
    }

    public void PlayWrongAnimation()
    {
        throw new System.NotImplementedException();
    }
}
