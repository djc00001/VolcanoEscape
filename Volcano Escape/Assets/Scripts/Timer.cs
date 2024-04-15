using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            // Play volcano sound effect every minute
            if (Mathf.Approximately(remainingTime % 60, 0))
            {
                audioManager.PlaySFX(audioManager.volcano);
            }
        }
        else if (remainingTime <= 0)
        {
            SceneManager.LoadScene(3); // Taken to lose screen
            remainingTime = 0;

        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}