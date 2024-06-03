public static class SettingsParser
{
    public static void TransferData(GameSettings globalSettings, GameData gameData)
    {
        gameData.firstLevelPairsCount = globalSettings.FirstLevelPairsCount;
        gameData.pairsIncreaseCountPerLevel = globalSettings.PairsIncreaseCountPerLevel;
        gameData.maximumPairsCount = globalSettings.MaximumPairsCount;
        gameData.firstLevelTimerCount = globalSettings.FirstLevelTimerCount;
        gameData.timerDescreaseCountPerLevel = globalSettings.TimerDescreaseCountPerLevel;
        gameData.minimumTimerCount = globalSettings.MinimumTimerCount;
        gameData.scoreCountPerMatch = globalSettings.ScoreCountPerMatch;
        gameData.maximumComboCount = globalSettings.MaximumComboCount;
        gameData.pairsImages = globalSettings.PairsImages;
    }
}
