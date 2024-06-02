using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance { get; private set; }

    [SerializeField]
    private GameObject parentObj;

    public AudioManager audioManager { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(parentObj);
            return;
        }

        Instance = this;

        audioManager = GetComponentInChildren<AudioManager>();
    }
}
