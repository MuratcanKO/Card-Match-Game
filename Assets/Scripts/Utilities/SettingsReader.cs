using UnityEngine;

public class SettingsReader : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    public GameSettings GameSettings { get { return gameSettings; } }
}
