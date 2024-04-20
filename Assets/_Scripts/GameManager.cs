using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI; // For text

public class GameManager : MonoBehaviour
{

    public GameObject car;
    bool isGameOver = false;
    bool isPaused = false;
    private float elapsedTime = 0;

    public TMP_Text currentTimeText;
    public TMP_Text finalTimeText;

    // When game is in pause or finished
    public GameObject resetLevelButton;
    public GameObject levelSelectorButton;
    public TMP_Text pauseText;


    public String resetLevel;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        // While game is running
        if (!isPaused)
        {
            elapsedTime = elapsedTime + Time.deltaTime;
            currentTimeText.SetText("Time: " + (int)elapsedTime);
        }

        // Pause game
        if (!isGameOver && !isPaused && Input.GetKeyDown(KeyCode.Return))
        {
            resetLevelButton.SetActive(true);
            levelSelectorButton.SetActive(true);
            pauseText.enabled = true; 
            Time.timeScale = 0;
            isPaused = true;
        } 
        // Unpause game
        else if (!isGameOver && isPaused && Input.GetKeyDown(KeyCode.Return))
        {
            resetLevelButton.SetActive(false);
            levelSelectorButton.SetActive(false);
            pauseText.enabled = false;
            isPaused = false;
            Time.timeScale = 1;
        }

        if (isGameOver)
        {
            resetLevelButton.SetActive(true);
            levelSelectorButton.SetActive(true);
            currentTimeText.enabled = false;
            finalTimeText.enabled = true;
            finalTimeText.SetText("Final time: " + (int)elapsedTime + " sec");
            Time.timeScale = 0;
        }
    }

    // Runs when the player enters the finish zone
	public void FinishedGame()
	{
		isGameOver = true;
	}

    public void LoadSelectLevelScene()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(resetLevel);
    }

}
