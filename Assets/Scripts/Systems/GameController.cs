using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text healthText;
    public Text coinsAmount;
    public int coinAmount;
    public int totalCoins;
    public GameObject gameOverObj;
    public GameObject pauseObj;
    public static GameController instance;

    private bool isPaused = false;

    void Awake() {
        instance = this;
    }

    void Start() {
        totalCoins = PlayerPrefs.GetInt("score");
    }

    void Update() {
        PauseGame();
    }

    public void UpdateLives(int value) {
        healthText.text = "X " + value;
    }

    public void CollectCoins(int amount) {
        coinsAmount.text = "X " + amount;
    }

    public void CoinCollect(int amount) {
        coinAmount += amount;
        CollectCoins(coinAmount);
        PlayerPrefs.SetInt("score", coinAmount + totalCoins);
    }

    public void PauseGame() {
        if(Input.GetKeyDown(KeyCode.P)) {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
        }

        if(isPaused) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
    }

    public void GameOver() {
        gameOverObj.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(1);
    }
}