using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingImage;

    [SerializeField]
    private Image musicImage;

    [SerializeField]
    private Sprite soundOnSprite;

    [SerializeField]
    private Sprite soundOffSprite;

    [SerializeField]
    private GameObject buttonPlay;

    [SerializeField]
    private SceneLoader sceneLoader;

    public void PlayButtonClicked()
    {
        buttonPlay.SetActive(false);
        loadingImage.SetActive(true);
        sceneLoader.AsyncSceneLoader(GlobalConstants.GAME_SCENE_NAME);
    }

    public void MusicButtonClicked() 
    {
        if (GlobalManager.Instance.audioManager.IsPlaying(GlobalConstants.THEME_SONG_NAME))
        {
            GlobalManager.Instance.audioManager.Pause(GlobalConstants.THEME_SONG_NAME);
            musicImage.sprite = soundOffSprite;
        }
        else
        {
            GlobalManager.Instance.audioManager.Play(GlobalConstants.THEME_SONG_NAME);
            musicImage.sprite = soundOnSprite;
        }

    }
}
