using TMPro;
using UnityEngine;

public class GameInitialize : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScoreText;

    private int highScoreValue;

    private bool themeSongStarted = false;

    void Start()
    {
        highScoreValue = PlayerPrefs.GetInt(GlobalConstants.PLAYERPREFS_HIGH_SCORE_KEY_VALUE, 0);
        highScoreText.text = "High Score : " + highScoreValue.ToString();
        PlayThemeSong();
    }

    void Update()
    {
        if (!themeSongStarted)
        {
            PlayThemeSong();
        }
    }

    private void PlayThemeSong()
    {
        if (Utils.IsNull(GlobalManager.Instance.audioManager)) 
        {
            if (GlobalManager.Instance.audioManager.IsPlaying(GlobalConstants.THEME_SONG_NAME))
            {
                themeSongStarted = true;
            }
            else
            {
                GlobalManager.Instance.audioManager.Play(GlobalConstants.THEME_SONG_NAME);
            }
        }
    }
}
