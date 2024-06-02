using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsUIScreen;

    [SerializeField]
    private GameObject gameOverUIScreen;

    [SerializeField]
    private SceneLoader menuSceneLoader;

    [SerializeField]
    private Image musicImage;

    [SerializeField]
    private Sprite soundOnSprite;

    [SerializeField]
    private Sprite soundOffSprite;


    public void SettingsButtonClicked()
    {
        settingsUIScreen.SetActive(true);
    }

    public void ReturnHomeButtonClicked()
    {
        menuSceneLoader.AsyncSceneLoader(GlobalConstants.MENU_SCENE_NAME);
    }

    public void ContinueButtonClicked()
    {
        settingsUIScreen.SetActive(false);
    }

    public void RestartButtonClicked()
    {
        menuSceneLoader.AsyncSceneLoader(GlobalConstants.GAME_SCENE_NAME);
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

    public void GameOver()
    {
        gameOverUIScreen.SetActive(true);
    }
}
