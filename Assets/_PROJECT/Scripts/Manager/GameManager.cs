using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public Transform player;

    [Space(10)]
    [Header("Game"), Space(20)]
    public bool _isPausing;
    public Transform[] spawnPosition;
    public MenuManager menuManager;
    private int _currenthighScore;
    public int CurrentHighScore
    {
        get { return _currenthighScore; }

        set 
        {
            _currenthighScore = value;

            int _highestScore = PlayerPrefs.GetInt("HighScore", 0);
            if (_currenthighScore > _highestScore) 
            {
                PlayerPrefs.SetInt("HighScore", _currenthighScore);
            }
        }
    }


    [Space(10)]
    [Header("UI"), Space(20)]
    public Text scoreUI;
    public Image[] healthUI;

}   
