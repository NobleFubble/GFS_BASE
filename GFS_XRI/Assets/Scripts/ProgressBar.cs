using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public Slider slider;

    public void SetProgress(float progress)
    {
        if  (slider.value + progress >= 100)
        {
            gameManager.GameOver();
        }
        slider.value += progress;
    }
}