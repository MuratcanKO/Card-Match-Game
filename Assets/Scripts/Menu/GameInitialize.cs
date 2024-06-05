using TMPro;
using UnityEngine;

public class GameInitialize : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScoreText;

    private int highScoreValue;

    void Start()
    {
        highScoreValue = PlayerPrefs.GetInt(GlobalConstants.PLAYERPREFS_HIGH_SCORE_KEY_VALUE, 0);
        highScoreText.text = "High Score : " + highScoreValue.ToString();
        PlayThemeSong();
    }

    private void PlayThemeSong()
    {
        if (Utils.IsNull(GlobalManager.Instance.audioManager)) 
        {
            GlobalManager.Instance.audioManager.Play(GlobalConstants.THEME_SONG_NAME);
        }
    }
}
