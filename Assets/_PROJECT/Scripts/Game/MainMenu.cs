using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text bestScore;
    private void Awake()
    {
        bestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("HighScore",0);
    }

    public void LoadScene(int _sceneIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneIndex);
    }
}
