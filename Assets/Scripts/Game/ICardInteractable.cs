using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardInteractable
{
    void PlaySelectAnimation();
    void PlayUnselectAnimation();
    void PlayCorrectAnimation();
    void PlayWrongAnimation();
    void PlaySpawnAnimation();
    void PlayRemovoAnimation();
}
