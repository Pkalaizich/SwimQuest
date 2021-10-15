using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance { get => instance; }
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject WinnerPanel;
    [SerializeField] private GameObject OxygenBar;
    [SerializeField] private GameObject KeyCounter;
    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void GameOver()
    {
        SoundController.Instance.Stop();
        SoundController.Instance.GameOverSound();
        OxygenBar.SetActive(false);
        KeyCounter.SetActive(false);
        if(Player.Instance.win==false)
            GameOverPanel.SetActive(true);
        else
            WinnerPanel.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Menu");
    }
}
