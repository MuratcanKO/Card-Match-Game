using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject]
    private TimerController timerController;


    // Start is called before the first frame update
    void Start()
    {
        timerController.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerController.currentTime <= 0f)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
    }
}
