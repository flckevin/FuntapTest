using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject restart;
    public Text highestScore;
    public void Pause(bool _pause) 
    {
        if (_pause)
        {
            GameManager.Instance._isPausing = false;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else 
        {
            GameManager.Instance._isPausing = true;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;

        }
    
    }

    public void Restart() 
    {
        restart.SetActive(true);
        highestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("HighScore",0);
        Time.timeScale = 0;

    }

    public void LoadScene(int _sceneIndex) 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneIndex);
    }
}
