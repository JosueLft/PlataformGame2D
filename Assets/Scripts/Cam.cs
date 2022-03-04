using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

    private Transform player;
    public float smooth;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate() {
        if(player.position.x >= 0) {
            Vector3 following = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, smooth); // movimentação entre dois pontos a camera, e o following nesse caso, 
        }
    }
}