using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text healthText;
    public Text coinsAmount;
    public int coinAmount;
    public int totalCoins;

    public static GameController instance;

    void Awake() {
        instance = this;
    }

    void Start() {
        totalCoins = PlayerPrefs.GetInt("score");
    }

    void Update() {
        
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
}