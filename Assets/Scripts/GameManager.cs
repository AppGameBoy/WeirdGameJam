using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI tries;

    public static GameManager Instance;
    public int numOfTries;
    private bool gameOver;
    public string sceneToLoad;

    public int Score { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        //Debug.Log("SCore " + Score);
        scoreText.SetText("Score: " + Score);
        tries.SetText("Tries: " + numOfTries);
        Debug.Log(numOfTries.ToString());
        //IsGameOver(numOfTries);
        if (IsGameOver())
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void Start()
    {
        
        Score = 0;
        //scoreText.text = "Score: " + Score;
    }

    public void IncreaseScore( int amount)
    {
        Score += amount;
    }
    public void DecreaseTries( )
    {
        numOfTries--;
    }
    public bool IsGameOver()
    {
        if ( numOfTries <= 0)
        {
            Debug.Log("Game Over");
            
            return true;
            
        } else
        {
            return false;
        }
            
    }

}
