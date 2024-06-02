using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private int firstLevelPairsCount;
    public int FirstLevelPairsCount { get { return firstLevelPairsCount; } }

    [SerializeField] private int pairsIncreaseCountPerLevel;
    public int PairsIncreaseCountPerLevel { get { return pairsIncreaseCountPerLevel; } }

    [SerializeField] private int maximumPairsCount;
    public int MaximumPairsCount { get { return maximumPairsCount; } }

    [SerializeField] private int firstLevelTimerCount;
    public int FirstLevelTimerCount { get { return firstLevelTimerCount; } }

    [SerializeField] private int timerDescreaseCountPerLevel;
    public int TimerDescreaseCountPerLevel { get { return timerDescreaseCountPerLevel; } }

    [SerializeField] private int minimumTimerCount;
    public int MinimumTimerCount { get { return minimumTimerCount; } }

    [SerializeField] private int scoreCountPerMatch;
    public int ScoreCountPerMatch { get { return scoreCountPerMatch; } }

    [SerializeField] private int maximumComboCount;
    public int MaximumComboCount { get { return maximumComboCount; } }

    [SerializeField] private Sprite[] pairsImages;
    public Sprite[] PairsImages { get { return pairsImages; } }
}
