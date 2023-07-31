using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static GameManager Instance;
    public int Score { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        //Debug.Log("SCore " + Score);
        scoreText.SetText("Score: " + Score);
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

}
