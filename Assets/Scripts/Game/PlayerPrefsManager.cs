using UnityEngine;
using UnityEngine.Playables;

public class PlayerPrefsManager : MonoBehaviour
{
    public int GetCurrentScore()
    {
        return PlayerPrefs.GetInt(GlobalConstants.PLAYERPREFS_CURRENT_SCORE_KEY_VALUE, 0);
    }

    public void SetCurrentScore(int score)
    {
        PlayerPrefs.SetInt(GlobalConstants.PLAYERPREFS_CURRENT_SCORE_KEY_VALUE, score);
    }

    public int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt(GlobalConstants.PLAYERPREFS_CURRENT_LEVEL_KEY_VALUE, 1);
    }

    public void SetCurrentLevel(int level)
    {
        PlayerPrefs.SetInt(GlobalConstants.PLAYERPREFS_CURRENT_LEVEL_KEY_VALUE, level);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(GlobalConstants.PLAYERPREFS_HIGH_SCORE_KEY_VALUE, 0);
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(GlobalConstants.PLAYERPREFS_HIGH_SCORE_KEY_VALUE, score);
    }

    public void GetAllData(GameData gameData)
    {
        gameData.currentScore = PlayerPrefs.GetInt(GlobalConstants.PLAYERPREFS_CURRENT_SCORE_KEY_VALUE, 0);
        gameData.currentLevel = PlayerPrefs.GetInt(GlobalConstants.PLAYERPREFS_CURRENT_LEVEL_KEY_VALUE, 1);
        gameData.highScore = PlayerPrefs.GetInt(GlobalConstants.PLAYERPREFS_HIGH_SCORE_KEY_VALUE, 0);
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
