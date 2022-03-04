using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public int coinAmount = 1;

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player") {
            GameController.instance.CoinCollect(coinAmount);
            Destroy(gameObject);
        }
    }
}